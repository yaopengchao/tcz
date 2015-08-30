using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TopicDetailDao : CommonDao
    {

        public int addTopicDetail(TopicDetail topicDetail)
        {
            string strSql = "insert into ex_topic_detail(topic_detail_id, topic_id, item_pre, item_detail, item_order) values(?topicDetailId, ?topicId, ?itemPre, ?itemDetail, ?itemOrder); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?topicDetailId", MySqlDbType.VarChar),
                new MySqlParameter("?topicId", MySqlDbType.VarChar),
                new MySqlParameter("?itemPre", MySqlDbType.VarChar),
                new MySqlParameter("?itemDetail", MySqlDbType.VarChar),
                new MySqlParameter("?itemOrder", MySqlDbType.VarChar)
            };
            parames[0].Value = topicDetail.TopicDetailId;
            parames[1].Value = topicDetail.TopicId;
            parames[2].Value = topicDetail.ItemPre;
            parames[3].Value = topicDetail.ItemDetail;
            parames[4].Value = topicDetail.ItemOrder;
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
        }

    }
}
