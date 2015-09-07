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

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodySelfTest2));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }

        private void BodySelfTest2_Load(object sender, EventArgs e)
        {

            Util.setLanguage();
            ApplyResource();


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

        private void button7_Click(object sender, EventArgs e)
        {
            if (xz == 0 && feib == 0 && fub == 0)
            {
                MessageBox.Show("请选择题目!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                Examination exam = new Examination();
                exam.ExamCat = Convert.ToString(self.topicCategory.SelectedValue);
                exam.ExamName = self.txtExamName.Text;
                exam.ExType = "2";
                string topicIds = getRandomTopicIds(xz, xzList);
                topicIds += getRandomTopicIds(feib, feibList);
                topicIds += getRandomTopicIds(fub, fubList);
                int result = examService.addExam(exam, topicIds);
                if (result > 0)
                {
                    self.mainFrame.panel6.Controls.Clear();
                    BodySelfTest3 self3 = new BodySelfTest3();
                    self3.TopLevel = false;
                    self3.examId = exam.ExaminationId;
                    self3.FormBorderStyle = FormBorderStyle.None;
                    self3.Dock = System.Windows.Forms.DockStyle.Fill;
                    self.mainFrame.panel6.Controls.Add(self3);
                    self3.Show();
                }
                else
                {
                    MessageBox.Show("选题失败，请联系管理员");
                }
            }
            
        }

        private string getRandomTopicIds(int count, List<int> list)
        {
            string result = "";
            List<int> cloneList = new List<int>(list);
            if (count >= cloneList.Count)
            {
                foreach (int id in cloneList)
                {
                    result += id + ",";
                }
            }
            else
            {
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    int r = random.Next(cloneList.Count);
                    result += cloneList[r] + ",";
                    cloneList.RemoveAt(r);
                }
            }
            return result;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = Convert.ToInt32(linkLabel1.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = Convert.ToInt32(linkLabel2.Text);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = Convert.ToInt32(linkLabel3.Text);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = Convert.ToInt32(linkLabel4.Text);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = Convert.ToInt32(linkLabel5.Text);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = totalXz;
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = Convert.ToInt32(linkLabel12.Text);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = Convert.ToInt32(linkLabel11.Text);
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = Convert.ToInt32(linkLabel10.Text);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = Convert.ToInt32(linkLabel9.Text);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = Convert.ToInt32(linkLabel8.Text);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = totalFeib;
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = Convert.ToInt32(linkLabel18.Text);
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = Convert.ToInt32(linkLabel17.Text);
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = Convert.ToInt32(linkLabel16.Text);
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = Convert.ToInt32(linkLabel15.Text);
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = Convert.ToInt32(linkLabel14.Text);
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = totalFub;
        }
    }
}
