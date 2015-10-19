using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Examination
    {

        private int examinationId;
        public int ExaminationId
        {
            get { return examinationId; }
            set { examinationId = value; }
        }

        private string examName;
        public string ExamName
        {
            get { return examName; }
            set { examName = value; }
        }

        private string startTime;
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private int totalMins;
        public int TotalMins
        {
            get { return totalMins; }
            set { totalMins = value; }
        }

        private int scores;
        public int Scores
        {
            get { return scores; }
            set { scores = value; }
        }

        private string exType;
        public string ExType
        {
            get { return exType; }
            set { exType = value; }
        }

        private string examCat;
        public string ExamCat
        {
            get { return examCat; }
            set { examCat = value; }
        }


        private int num;
        public int Num
        {
            get { return num; }
            set { num = value; }
        }


        private string exType_lx;
        public string ExType_lx
        {
            get { return exType_lx; }
            set { exType_lx = value; }
        }
    }
}
