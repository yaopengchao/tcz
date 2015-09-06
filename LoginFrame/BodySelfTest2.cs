using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace LoginFrame
{
    public partial class BodySelfTest2 : Form
    {
        public BodySelfTest2()
        {
            InitializeComponent();

            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            if (examService == null)
            {
                examService = ExamService.getInstance();
            }

            if (topicService == null)
            {
                topicService = TopicService.getInstance();
            }
        }

        private int getCount(string category, DataTable dt)
        {
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[7].Equals(category))
                {
                    if (category == "1")
                    {
                        xzList.Add(Convert.ToInt32(dr.ItemArray[0]));
                    }
                    else if (category == "2")
                    {
                        feibList.Add(Convert.ToInt32(dr.ItemArray[0]));
                    }
                    else if (category == "3")
                    {
                        fubList.Add(Convert.ToInt32(dr.ItemArray[0]));
                    }
                    count++;
                }
            }
            return count;
        }

        private static BodySelfTest2 instance;

        public static BodySelfTest2 createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodySelfTest2();
            }
            
            return instance;
        }

        public BodySelfTest self;

        private TopicService topicService;

        private ExamService examService;

        private int xz;

        private int feib;

        private int fub;

        private int totalXz;

        private int totalFeib;

        private int totalFub;

        private List<int> xzList = new List<int>();

        private List<int> feibList = new List<int>();

        private List<int> fubList = new List<int>();

        private static Dictionary<string, string> strWheres;

        private void BodySelfTest2_Load(object sender, EventArgs e)
        {
            string type = Convert.ToString(self.topicCategory.SelectedValue);
            strWheres.Clear();
            strWheres.Add("a.topic_type", " = '" + type + "' ");
            DataSet ds2 = topicService.listTopics(strWheres, -1, 0);
            DataTable dt2 = ds2.Tables[0];

            totalXz = getCount("1", dt2);                                        //心脏听诊
            totalFeib = getCount("2", dt2);                                      //肺部听诊
            totalFub = getCount("3", dt2);                                       //腹部听触诊

            labTzCount.Text = "（题库共" + totalXz + "道题）";
            labFeibCount.Text = "（题库共" + totalFeib + "道题）";
            labFubCount.Text = "（题库共" + totalFub + "道题）";
        }
    }
}
