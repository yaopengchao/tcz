using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DAL
{
    public class ExaminationDao : CommonDao
    {

        //查询考试列表  修改成可进入考试数据  过滤那些已经参加过得考试
        public DataSet listExams()
        {
            string strSql = "SELECT EXAMINATION_ID, EXAM_NAME, START_TIME, TOTAL_MINS from ex_examination where EX_TYPE = '1' and getAvailableExam(EXAMINATION_ID,"+LoginRoler.userId+")='false' ORDER BY START_TIME desc";
            return listEntity(strSql);
        }

        //根据条件进行分页查询
        public DataSet listExams(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select examination_id, exam_name, if (exam_cat='1','理论类','操作类'), start_time, total_mins, exam_cat ,num,ex_type_lx from ex_examination where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countExams(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_examination where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

        public DataTable getExamByExamId(int examId)
        {
            string strSql = "select a.EXAMINATION_ID, b.EXAMINATION_DETAIL_ID, b.TOPIC_ID, c.CONTENT from ex_examination a INNER JOIN ex_examination_detail b on a.EXAMINATION_ID = b.EXAMINATION_ID ";
            strSql += " INNER JOIN ex_topic c on b.TOPIC_ID = c.TOPIC_ID where a.EXAMINATION_ID = " + examId + " ORDER BY b.TOPIC_ORDER";
            return listEntity(strSql).Tables[0];
        }

        public DataSet getTopicCount(string type)
        {
            string strSql = "select a.TOPIC_CATEGORY, count(1) from ex_topic a ";
            if (type != null && !type.Equals(""))
            {
                strSql += " where a.TOPIC_TYPE = '" + type + "'";
            }
            strSql += " GROUP BY a.TOPIC_CATEGORY ";
            return listEntity(strSql, null);
        }

        public bool randomTopic(int Num,int exam_id)
        {

            
            //先获取题目总数
            string strSql = " select topic_id from ex_topic ";
            int totleNum= listEntity(strSql, null).Tables[0].Rows.Count;

            //判定 需要数量和总数  如果 总数小于 题目数量 则将所有考题选入该考试中
            if (Num> totleNum)
            {
                //全部考题
                strSql = "select topic_id from ex_topic ";
                DataTable Dt = listEntity(strSql, null).Tables[0];
                DataRowCollection rows = Dt.Rows;
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DataRow currRow = rows[i];
                    string topic_id=currRow["topic_id"]+"";

                    //获取TOPIC_ORDER
                    strSql = " select IFNULL(MAX(TOPIC_ORDER),0) from ex_examination_detail where  EXAMINATION_ID=" + exam_id;
                    DataSet ds = listEntity(strSql);
                    int order_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;

                    
                    strSql = "insert into ex_examination_detail(EXAMINATION_ID, TOPIC_ID, TOPIC_ORDER) values(?EXAMINATION_ID, ?TOPIC_ID, ?TOPIC_ORDER); select last_insert_id();";
                    MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?EXAMINATION_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ORDER", MySqlDbType.VarChar)
                };

                    parames[0].Value = exam_id;
                    parames[1].Value = topic_id;
                    parames[2].Value = order_id;

                    int EXAMINATION_DETAIL_ID = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
                }
            }
            else
            {

               



                //全部考题
                strSql = "select topic_id from ex_topic ";
                DataTable Dt = listEntity(strSql, null).Tables[0];
                DataRowCollection rows = Dt.Rows;

                List<int> topic_ids = new List<int>();
                //因为TIPIC_ID不一定是连续的所以我们必须将TIOPIC_ID放入一个集合中然后按照随机数字从集合获取该ID
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DataRow currRow = rows[i];
                    string topic_id = currRow["topic_id"] + "";
                    topic_ids.Add(Convert.ToInt32(topic_id));
                }




                    Hashtable hashtable = new Hashtable();
                Random rm = new Random();
                int RmNum = Num;
                int MaxNum = rows.Count;

                bool doRandom = true;
                int ChooseNum = 0;

                do
                {

                    int nValue = topic_ids[rm.Next(MaxNum)];

                    //检查该数值是否已经存在该次考试中
                    strSql = "select topic_id from ex_examination_detail where topic_id=" + nValue+ " and EXAMINATION_ID="+exam_id;
                    Dt = listEntity(strSql, null).Tables[0];
                    rows = Dt.Rows;
                    if (rows.Count>0)
                    {
                        continue;
                    }

                    if (!hashtable.ContainsValue(nValue) && nValue != 0)
                    {
                        //hashtable.Add(nValue, nValue);
                        //Console.WriteLine(nValue.ToString());
                        //获取TOPIC_ORDER
                        strSql = " select IFNULL(MAX(TOPIC_ORDER),0) from ex_examination_detail where  EXAMINATION_ID=" + exam_id;
                        DataSet ds = listEntity(strSql);
                        int order_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;

                        int topic_id = nValue;

                        strSql = "insert into ex_examination_detail(EXAMINATION_ID, TOPIC_ID, TOPIC_ORDER) values(?EXAMINATION_ID, ?TOPIC_ID, ?TOPIC_ORDER); select last_insert_id();";
                        MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?EXAMINATION_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ORDER", MySqlDbType.VarChar)
                };

                        parames[0].Value = exam_id;
                        parames[1].Value = topic_id;
                        parames[2].Value = order_id;

                        int EXAMINATION_DETAIL_ID = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));

                    }

                    ChooseNum = ChooseNum + 1;

                    if (ChooseNum== RmNum)
                    {
                        doRandom = false;
                    }
                } while (doRandom);
            }

            //如果总数大于所需数量 则随机添加
            //随机时候判定是否已经添加到该考试  已经添加过了继续随机知道达到要求



            return true;
        }
        public bool updateChooseTopic(string exam_id,string topic_id,string topic_state)
        {
            //检索  exam_id,topic_id  在表ex_examination_detail 是否存在 就删除
            string strSql = " select EXAMINATION_DETAIL_ID from ex_examination_detail where  EXAMINATION_ID=?examination_id and TOPIC_ID=?topic_id ";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examination_id", MySqlDbType.VarChar),
                new MySqlParameter("?topic_id", MySqlDbType.VarChar)
            };
            parames[0].Value = exam_id;
            parames[1].Value = topic_id;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parames));

            if (row0 > 0)
            {
                //删除
                strSql = "delete from ex_examination_detail where  EXAMINATION_ID=?examination_id and TOPIC_ID=?topic_id ";
                if (MySqlHelper.ExecuteNonQuery(strSql, parames)==0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {

                //获取TOPIC_ORDER
                strSql = " select IFNULL(MAX(TOPIC_ORDER),0) from ex_examination_detail where  EXAMINATION_ID=" + exam_id;
                DataSet ds= listEntity(strSql);
                int order_id=Convert.ToInt32(ds.Tables[0].Rows[0][0])+1;


                //不存在就新增
                strSql = "insert into ex_examination_detail(EXAMINATION_ID, TOPIC_ID, TOPIC_ORDER) values(?EXAMINATION_ID, ?TOPIC_ID, ?TOPIC_ORDER); select last_insert_id();";
                parames = new MySqlParameter[] {
                new MySqlParameter("?EXAMINATION_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ID", MySqlDbType.VarChar),
                new MySqlParameter("?TOPIC_ORDER", MySqlDbType.VarChar)
                };

                parames[0].Value = exam_id;
                parames[1].Value = topic_id;
                parames[2].Value = order_id;
                
                int EXAMINATION_DETAIL_ID = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
                if (EXAMINATION_DETAIL_ID!=-1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int addOnlyExam(Examination exam)
        {
            string strSql = "insert into ex_examination(EXAM_CAT, EXAM_NAME, START_TIME, TOTAL_MINS, SCORES, EX_TYPE,NUM,EX_TYPE_LX) values(?examCat, ?examName, ?startTime, ?totalMins, ?scores, ?exType, ?Num,?exType_lx); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?scores", MySqlDbType.VarChar),
                new MySqlParameter("?exType", MySqlDbType.VarChar),
                new MySqlParameter("?Num", MySqlDbType.Int32),
                new MySqlParameter("?exType_lx", MySqlDbType.VarChar)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.Scores;
            parames[5].Value = "1";
            parames[6].Value = exam.Num;
            parames[7].Value = exam.ExType_lx;//选题方式
            
            int examId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            exam.ExaminationId = examId;
            return examId;
        }

        public int updateOnlyExam(Examination exam)
        {
            string strSql = "update ex_examination set EXAM_CAT =?examCat, EXAM_NAME = ?examName, START_TIME = ?startTime, TOTAL_MINS = ?totalMins, EX_TYPE = ?exType, NUM = ?Num where examination_id = ?examId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?exType", MySqlDbType.VarChar),
                new MySqlParameter("?examId", MySqlDbType.Int32),
                new MySqlParameter("?Num", MySqlDbType.Int32)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.ExType;
            parames[5].Value = exam.ExaminationId;
            parames[6].Value = exam.Num;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }

        public int addExam(Examination exam)
        {
            string strSql = "insert into ex_examination(EXAM_CAT, EXAM_NAME, START_TIME, TOTAL_MINS, SCORES, EX_TYPE,NUM,EX_TYPE_LX) values(?examCat, ?examName, ?startTime, ?totalMins, ?scores, ?exType,?num,?exType_lx); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?scores", MySqlDbType.VarChar),
                new MySqlParameter("?exType", MySqlDbType.VarChar),
                new MySqlParameter("?num", MySqlDbType.VarChar),
                new MySqlParameter("?exType_lx", MySqlDbType.VarChar)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.Scores;
            parames[5].Value = exam.ExType;
            parames[6].Value = exam.Num;
            parames[7].Value = "随机选题";
            int examId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            exam.ExaminationId = examId;
            return examId;
        }

        public int updateExam(Examination exam)
        {
            string strSql = "update ex_examination set EXAM_CAT =?examCat, EXAM_NAME = ?examName, START_TIME = ?startTime, TOTAL_MINS = ?totalMins, EX_TYPE = ?exType where examination_id = ?examId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examCat", MySqlDbType.VarChar),
                new MySqlParameter("?examName", MySqlDbType.VarChar),
                new MySqlParameter("?startTime", MySqlDbType.VarChar),
                new MySqlParameter("?totalMins", MySqlDbType.Int32),
                new MySqlParameter("?exType", MySqlDbType.VarChar),
                new MySqlParameter("?examId", MySqlDbType.Int32)
            };
            parames[0].Value = exam.ExamCat;
            parames[1].Value = exam.ExamName;
            parames[2].Value = exam.StartTime;
            parames[3].Value = exam.TotalMins;
            parames[4].Value = exam.ExType;
            parames[5].Value = exam.ExaminationId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }

        public int deleteExam(int examId)
        {
            string strSql = "delete from ex_examination where examination_id = ?examId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examId", MySqlDbType.Int32)
            };
            parames[0].Value = examId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }
    }
}
