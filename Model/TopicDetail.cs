using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TopicDetail
    {

        public TopicDetail() { }

        private int topicDetailId;
        public int TopicDetailId
        {
            get { return topicDetailId; }
            set { topicDetailId = value; }
        }

        private int topicId;
        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }

        private string itemPre;
        public string ItemPre
        {
            get { return itemPre; }
            set { itemPre = value; }
        }

        private string itemDetail;
        public string ItemDetail
        {
            get { return itemDetail; }
            set { itemDetail = value; }
        }

        private string agreement;
        public string Agreement
        {
            get { return agreement; }
            set { agreement = value; }
        }

        private string itemOrder;
        public string ItemOrder
        {
            get { return itemOrder; }
            set { itemOrder = value; }
        }

    }
}
