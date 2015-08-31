using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ExaminationDetail
    {

        private int examinationDetailId;
        public int ExaminationDetailId
        {
            get { return examinationDetailId; }
            set { examinationDetailId = value; }
        }

        private int examinationId;
        public int ExaminationId
        {
            get { return examinationId; }
            set { examinationId = value; }
        }

        private int topicId;
        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }

        private int topicOrder;
        public int TopicOrder
        {
            get { return topicOrder; }
            set { topicOrder = value; }
        }

    }
}
