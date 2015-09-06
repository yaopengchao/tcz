using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExaminationDetailDao : CommonDao
    {

        //根据条件查询
        public DataSet listExistDetail(Dictionary<string, string> strWheres)
        {
            string strSql = "select b.topic_id, b.content, if (b.topic_type='1','理论类','操作类'), c.name, b.answers, b.create_time, b.topic_type, b.topic_category from ex_examination_detail a INNER JOIN ex_topic b on a.TOPIC_ID = b.TOPIC_ID INNER JOIN classify c on b.TOPIC_CATEGORY = c.id where 1 = 1 ";
            return listEntity(strSql, strWheres);
        }

        public int deleteExamDetail(int examId)
        {
            string strSql = "delete from ex_examination_detail where examination_id = ?examId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examId", MySqlDbType.Int32)
            };
            parames[0].Value = examId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }

        public int addExamDetail(ExaminationDetail examDetail)
        {
            string strSql = "insert into ex_examination_detail(EXAMINATION_ID, TOPIC_ID, TOPIC_ORDER) values(?examId, ?topicId, ?topicOrder)";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?examId", MySqlDbType.Int32),
                new MySqlParameter("?topicId", MySqlDbType.Int32),
                new MySqlParameter("?topicOrder", MySqlDbType.Int32)
            };
            parames[0].Value = examDetail.ExaminationId;
            parames[1].Value = examDetail.TopicId;
            parames[2].Value = examDetail.TopicOrder;
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
        }

    }
}
