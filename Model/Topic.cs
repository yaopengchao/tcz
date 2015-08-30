using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Topic
    {

        public Topic() { }

        private int topicId;
        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string topicType;
        public string TopicType
        {
            get { return topicType; }
            set { topicType = value; }
        }

        private string topicCategory;
        public string TopicCategory
        {
            get { return topicCategory; }
            set { topicCategory = value; }
        }

        private string answers;
        public string Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        private string createTime;
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

    }
}
