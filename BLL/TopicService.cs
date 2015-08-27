using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class TopicService
    {

        private static TopicDao topicDao;

        private static TopicService instance;

        public static TopicService getInstance()
        {
            if (instance == null)
            {
                instance = new TopicService();
            }
            if (topicDao == null)
            {
                topicDao = new TopicDao();
            }
            return instance;
        }

        //分页查询题目
        public DataSet listTopics(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return topicDao.listTopics(strWheres, startIndex, pageSize);
        }

        //查询题目数量
        public int countTopics(Dictionary<string, string> strWheres)
        {
            return topicDao.countTopics(strWheres);
        }

    }
}
