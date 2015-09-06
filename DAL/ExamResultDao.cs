using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExamResultDao : CommonDao
    {

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

            parames[0].Value = examResult.ExaminationId;
            parames[1].Value = examResult.ExaminationDetailId;
            parames[2].Value = examResult.TopicId;
            parames[3].Value = examResult.Answer;
            int examResultId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            examResult.ExamResultId = examResultId;
            return examResultId;
        }

    }
}
