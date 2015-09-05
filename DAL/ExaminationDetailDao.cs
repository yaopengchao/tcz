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
