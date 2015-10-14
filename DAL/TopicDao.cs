using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TopicDao : CommonDao
    {

        //根据条件进行分页查询
        public DataSet listTopics(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select topic_id, content, if (topic_type='1','理论类','操作类'), b.TCZ_NAME, answers, create_time, topic_type, topic_category from ex_topic a, tcz_type b where a.TOPIC_CATEGORY = b.TCZ_ID ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件进行分页查询
        public DataSet listNotInExamTopics(Dictionary<string, string> strWheres, int examId)
        {
            string strSql = "select topic_id, content, if (topic_type='1','理论类','操作类'), b.TCZ_NAME, answers, create_time, topic_type, topic_category from ex_topic a, tcz_type b where a.TOPIC_CATEGORY = b.TCZ_ID ";
            if (examId != 0)
            {
                strSql += " and a.TOPIC_ID not in (SELECT TOPIC_ID from ex_examination_detail where EXAMINATION_ID = " + examId + ")";
            }             
            return listEntity(strSql, strWheres);
        }

        //根据条件查询数量
        public int countTopics(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_topic a, tcz_type b where a.TOPIC_CATEGORY = b.TCZ_ID ";
            return countEntity(strSql, strWheres);
        }

        public DataSet listChooseTopics(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select topic_id, content, if (topic_type='1','理论类','操作类'), b.TCZ_NAME, answers, create_time, topic_type, topic_category,'1' as isSelected  from ex_topic a, tcz_type b where a.TOPIC_CATEGORY = b.TCZ_ID ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }


        public int countChooseTopics(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_topic a, tcz_type b where a.TOPIC_CATEGORY = b.TCZ_ID ";
            return countEntity(strSql, strWheres);
        }

        public int addTopic(Topic topic)
        {
            string strSql = "insert into ex_topic(content, topic_type, topic_category, answers, create_time) values(?content, ?topicType, ?topicCategory, ?answers, ?createDate); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?content", MySqlDbType.VarChar),
                new MySqlParameter("?topicType", MySqlDbType.VarChar),
                new MySqlParameter("?topicCategory", MySqlDbType.VarChar),
                new MySqlParameter("?answers", MySqlDbType.VarChar),
                new MySqlParameter("?createDate", MySqlDbType.VarChar)
            };

            parames[0].Value = topic.Content;
            parames[1].Value = topic.TopicType;
            parames[2].Value = topic.TopicCategory;
            parames[3].Value = topic.Answers;
            DateTime dt = DateTime.Now;
            parames[4].Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
            int topicId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            topic.TopicId = topicId;
            return topicId;
        }

        public int updateTopic(Topic topic)
        {
            string strSql = "update ex_topic set content = ?content, topic_type = ?topicType, topic_category = ?topicCategory, answers = ?answers where topic_id = ?topicId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?content", MySqlDbType.VarChar),
                new MySqlParameter("?topicType", MySqlDbType.VarChar),
                new MySqlParameter("?topicCategory", MySqlDbType.VarChar),
                new MySqlParameter("?answers", MySqlDbType.VarChar),
                new MySqlParameter("?topicId", MySqlDbType.Int32)
            };
            
            parames[0].Value = topic.Content;
            parames[1].Value = topic.TopicType;
            parames[2].Value = topic.TopicCategory;
            parames[3].Value = topic.Answers;
            parames[4].Value = topic.TopicId;
            return Convert.ToInt32(MySqlHelper.ExecuteNonQuery(strSql, parames));
        }

        public int deleteTopic(int topicId)
        {
            string strSql = "delete from ex_topic where topic_id = ?topicId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?topicId", MySqlDbType.Int32)
            };
            parames[0].Value = topicId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

    }
}
