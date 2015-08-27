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
            string strSql = "select topic_id, content, topic_type, topic_category, answers, create_time from ex_topic where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countTopics(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from ex_topic where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

    }
}
