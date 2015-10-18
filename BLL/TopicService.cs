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

        private static TopicDetailDao topicDetailDao;

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
            if (topicDetailDao == null)
            {
                topicDetailDao = new TopicDetailDao();
            }
            return instance;
        }

        //分页查询题目
        public DataSet listTopics(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return topicDao.listTopics(strWheres, startIndex, pageSize);
        }

        public DataSet listNotInExamTopics(Dictionary<string, string> strWheres, int examId)
        {
            return topicDao.listNotInExamTopics(strWheres, examId);
        }

        //查询题目数量
        public int countTopics(Dictionary<string, string> strWheres)
        {
            return topicDao.countTopics(strWheres);
        }

        public DataSet listChooseTopics(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            return topicDao.listChooseTopics(strWheres, startIndex, pageSize);
        }

        public int countChooseedTopics(Dictionary<string, string> strWheres)
        {
            return topicDao.countChooseedTopics(strWheres);
        }

        public int countChooseTopics(Dictionary<string, string> strWheres)
        {
            return topicDao.countChooseTopics(strWheres);
        }

        public int addTopic(string topicContent)
        {
            Topic topic = new Topic();
            int flag = 0;
            if (topicContent != "")
            {
                string[] attrs = topicContent.Split(new char[] {'|'});
                string main = attrs[0];
                string detail = attrs[1];
                string[] mainDetail = main.Split(new char[] { ','});
                int topicId = Convert.ToInt32(mainDetail[4]);
                if (topicId == 0)                              //添加
                {
                    topic.Content = mainDetail[0];
                    topic.TopicType = mainDetail[1];
                    topic.TopicCategory = mainDetail[2];
                    topic.Answers = mainDetail[3];
                    flag = topicDao.addTopic(topic);
                    string[] dDetail = detail.Split(new char[] { ';' });
                    foreach (string dtl in dDetail)
                    {
                        if (dtl.IndexOf(",") > 0)
                        {
                            TopicDetail topicDetail = new TopicDetail();
                            string[] tpDetail = dtl.Split(new char[] { ',' });
                            topicDetail.TopicId = topic.TopicId;
                            topicDetail.ItemPre = tpDetail[0];
                            topicDetail.ItemDetail = tpDetail[1];
                            topicDetail.Agreement = tpDetail[2];
                            topicDetail.ItemOrder = tpDetail[3];
                            topicDetailDao.addTopicDetail(topicDetail);
                        }
                    }
                }
                else
                {
                    topic.TopicId = topicId;
                    topic.Content = mainDetail[0];
                    topic.TopicType = mainDetail[1];
                    topic.TopicCategory = mainDetail[2];
                    topic.Answers = mainDetail[3];
                    flag = topicDao.updateTopic(topic);

                    topicDetailDao.deleteTopicDetail(topicId);
                    string[] dDetail = detail.Split(new char[] { ';' });
                    foreach (string dtl in dDetail)
                    {
                        if (dtl.IndexOf(",") > 0)
                        {
                            TopicDetail topicDetail = new TopicDetail();
                            string[] tpDetail = dtl.Split(new char[] { ',' });
                            topicDetail.TopicId = topic.TopicId;
                            topicDetail.ItemPre = tpDetail[0];
                            topicDetail.ItemDetail = tpDetail[1];
                            topicDetailDao.addTopicDetail(topicDetail);
                        }
                    }
                }
            }
            return flag;
        }

        public int deleteTopic(int topicId)
        {
            topicDetailDao.deleteTopicDetail(topicId);
            return topicDao.deleteTopic(topicId);
        }

        public DataSet getTopicDetail(int topicId)
        {
            return topicDetailDao.getTopicDetail(topicId);
        }
    }
}
