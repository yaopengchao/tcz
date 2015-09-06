using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{
    public partial class BodySelfTest3 : Form
    {

        public int examId;

        private ExamService examService;

        private TopicService topicService;

        public BodySelfTest3()
        {
            InitializeComponent();

            if (examService == null)
            {
                examService = ExamService.getInstance();
            }
            if (topicService == null)
            {
                topicService = TopicService.getInstance();
            }
        }

        private void BodySelfTest3_Load(object sender, EventArgs e)
        {
            DataTable dt = examService.getExamByExamId(examId);
            foreach (DataRow dr in dt.Rows)
            {

            }
        }
    }
}
