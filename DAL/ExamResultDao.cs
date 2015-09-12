using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class ExamResultDao : CommonDao
    {

        public DataSet listExamResults(Dictionary<string, string> strWheres)
        {
            string strSql = "select EXAM_RESULT_ID, USER_ID, EXAMINATION_ID, EXAMINATION_DETAIL_ID, TOPIC_ID, ANSWERS from ex_exam_result where 1 = 1 ";
            return listEntity(strSql, strWheres);
        }

        public DataSet listExamRightResults(Dictionary<string, string> strWheres)
        {
            string strSql = "select  ANSWERS from ex_topic where 1 = 1  ";
            return listEntity(strSql, strWheres);
        }

        public DataSet getAllUserExams(Dictionary<string, string> strWheres)
        {
            string strSql = " select   result.USER_ID USER_ID,result.EXAMINATION_ID ExamId,examination.EXAM_NAME  ExamName from ex_exam_result result,ex_examination examination where 1 = 1   and result.EXAMINATION_ID=examination.EXAMINATION_ID   ";
            return listEntityGroup(strSql, strWheres, " group by result.EXAMINATION_ID  ");
        }

        public DataSet getUserExams(Dictionary<string, string> strWheres)
        {
            string strSql = " select   result.USER_ID USER_ID,result.EXAMINATION_ID ExamId,examination.EXAM_NAME  ExamName from ex_exam_result result,ex_examination examination where 1 = 1   and result.EXAMINATION_ID=examination.EXAMINATION_ID   ";
            return listEntityGroup(strSql, strWheres, " group by result.EXAMINATION_ID  ");
        }


        public int addExamResult(ExamResult examResult)
        {
            string strSql = "insert into ex_exam_result(user_id, examination_id, examination_detail_id, topic_id, answers) values(?userId, ?examId, ?examDetailId, ?topicId, ?answer); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?userId", MySqlDbType.Int32),
                new MySqlParameter("?examId", MySqlDbType.Int32),
                new MySqlParameter("?examDetailId", MySqlDbType.Int32),
                new MySqlParameter("?topicId", MySqlDbType.Int32),
                new MySqlParameter("?answer", MySqlDbType.VarChar)
            };

            parames[0].Value = examResult.UserId;
            parames[1].Value = examResult.ExaminationId;
            parames[2].Value = examResult.ExaminationDetailId;
            parames[3].Value = examResult.TopicId;
            parames[4].Value = examResult.Answer;
            int examResultId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            examResult.ExamResultId = examResultId;
            return examResultId;
        }

        public int updateExamResult(ExamResult examResult)
        {
            string strSql = "update ex_exam_result set answers = ?answer where exam_result_id = ?examResultId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?answer", MySqlDbType.VarChar),
                new MySqlParameter("?examResultId", MySqlDbType.Int32)
            };
            parames[0].Value = examResult.Answer;
            parames[1].Value = examResult.ExamResultId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }
       
        public DataSet listUserExamResult(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select EXAM_RESULT_ID, USER_ID, EXAMINATION_ID, EXAMINATION_DETAIL_ID, TOPIC_ID, ANSWERS from ex_exam_result where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        public DataSet listExams(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = " select t1.exam_result_id,t2.EXAMINATION_ID as EXAMINATION_ID,u.user_id,t2.EXAM_NAME as 考试名称,u.user_name as 考生姓名,t2.TOTAL_MINS as 考试时长,'100' as 得分率  from ex_exam_result t1,ex_examination t2,sys_user u where t1.EXAMINATION_ID=t2.EXAMINATION_ID and t1.user_id=u.user_id ";
            return listEntityGroup(strSql, strWheres, startIndex, pageSize, " group by t1.EXAMINATION_ID,t1.USER_ID ");
        }

        public int countUserExamResult(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_exam_result a where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

        public int countExams(Dictionary<string, string> strWheres)
        {
            string strSql = " select t1.EXAMINATION_ID,t1.USER_ID  from ex_exam_result t1,ex_examination t2,sys_user u where t1.EXAMINATION_ID=t2.EXAMINATION_ID and t1.user_id=u.user_id ";
            return countEntityGroup(strSql, strWheres, " group by t1.EXAMINATION_ID,t1.USER_ID ");
        }
    }
}
