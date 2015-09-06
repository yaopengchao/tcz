using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ExamResult
    {

        private int examResultId;
        public int ExamResultId
        {
            get { return examResultId; }
            set { examResultId = value; }
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int examinationId;
        public int ExaminationId
        {
            get { return examResultId; }
            set { examResultId = value; }
        }

        private int examinationDetailId;
        public int ExaminationDetailId
        {
            get { return examinationDetailId; }
            set { examinationDetailId = value; }
        }

        private int topicId;
        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }

        private string answer;
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

    }
}
