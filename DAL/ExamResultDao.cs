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

    }
}
