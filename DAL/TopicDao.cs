﻿using System;
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
            string strSql = "select topic_id, content, topic_type, topic_category, answers, create_time from ex_topic where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countTopics(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_topic where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

        public int addTopic(Topic topic)
        {
            string strSql = "insert into ex_topic(topic_id, content, topic_type, topic_category, answers, create_time) values(?topicId, ?content, ?topicType, ?topicCategory, ?answers, ?createDate); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?topicId", MySqlDbType.VarChar),
                new MySqlParameter("?content", MySqlDbType.VarChar),
                new MySqlParameter("?topicType", MySqlDbType.VarChar),
                new MySqlParameter("?topicCategory", MySqlDbType.VarChar),
                new MySqlParameter("?answers", MySqlDbType.VarChar),
                new MySqlParameter("?createDate", MySqlDbType.VarChar)
            };
            parames[0].Value = topic.TopicId;
            parames[1].Value = topic.Content;
            parames[2].Value = topic.TopicType;
            parames[3].Value = topic.TopicCategory;
            parames[4].Value = topic.Answers;
            DateTime dt = DateTime.Now;
            parames[5].Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
            int topicId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            topic.TopicId = topicId;
            return topicId;
        }

    }
}
