﻿using System;
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

        public MainFrame mainFrame;

        public string topicType;

        public BodySelfTest2()
        {
            InitializeComponent();

            //this.BackColor = Color.FromArgb(255, 208, 232, 253);

            button7.BackColor = Color.FromArgb(255, 80, 151, 228);
            button7.ForeColor = Color.White;

            



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


            //string type = Convert.ToString(self.topicCategory.SelectedValue);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (topicType == null)
            {
                MessageBox.Show("请选择测试类别!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (xz == 0 && feib == 0 && fub == 0)
            {
                MessageBox.Show("请选择题目!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                Examination exam = new Examination();
                exam.ExamCat = topicType;
                DateTime dt = DateTime.Now;
                exam.ExamName = dt.ToString("yyyy-MM-dd HH:mm:ss") + LoginRoler.username + "的自我测试";
                exam.ExType = "2";
                exam.StartTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
                exam.Num = Convert.ToInt32(xz) + Convert.ToInt32(feib) + Convert.ToInt32(fub);
                string topicIds = getRandomTopicIds(xz, xzList);
                topicIds += getRandomTopicIds(feib, feibList);
                topicIds += getRandomTopicIds(fub, fubList);
                int result = examService.addExam(exam, topicIds);
                if (result > 0)
                {
                    mainFrame.panel6.Controls.Clear();
                    mainFrame.panel6.Controls.AddRange(mainFrame.items.ToArray());
                    BodySelfTest3 self3 = new BodySelfTest3();
                    self3.TopLevel = false;
                    self3.selfTest2 = this;
                    self3.examId = exam.ExaminationId;
                    self3.FormBorderStyle = FormBorderStyle.None;
                    self3.Dock = System.Windows.Forms.DockStyle.Fill;
                    mainFrame.panel6.Controls.Add(self3);
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

        

        

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xz = totalXz;
        }

        

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feib = totalFeib;
        }

        

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fub = totalFub;
        }

        private void getTopicNum(string type)
        {
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

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // topicType = "1";
            //getTopicNum(topicType);
            //radioButton1_CheckedChanged(radioButton1, null);
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //topicType = "2";
            //getTopicNum(topicType);
            //radioButton2_CheckedChanged(radioButton2, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            xz = Convert.ToInt32(((ComboxItem)this.comboBox1.Items[this.comboBox1.SelectedIndex]).Value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            feib = Convert.ToInt32(((ComboxItem)this.comboBox2.Items[this.comboBox2.SelectedIndex]).Value);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fub = Convert.ToInt32(((ComboxItem)this.comboBox3.Items[this.comboBox3.SelectedIndex]).Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            topicType = "1";
            getTopicNum(topicType);

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(new ComboxItem("10", "10"));
            this.comboBox1.Items.Add(new ComboxItem("15", "15"));
            this.comboBox1.Items.Add(new ComboxItem("20", "20"));
            this.comboBox1.Items.Add(new ComboxItem("25", "25"));
            this.comboBox1.Items.Add(new ComboxItem("30", "30"));
            this.comboBox1.Items.Add(new ComboxItem("全部", totalXz + ""));

            this.comboBox2.Items.Clear();
            this.comboBox2.Items.Add(new ComboxItem("10", "10"));
            this.comboBox2.Items.Add(new ComboxItem("15", "15"));
            this.comboBox2.Items.Add(new ComboxItem("20", "20"));
            this.comboBox2.Items.Add(new ComboxItem("25", "25"));
            this.comboBox2.Items.Add(new ComboxItem("30", "30"));
            this.comboBox2.Items.Add(new ComboxItem("全部", totalFeib + ""));


            this.comboBox3.Items.Clear();
            this.comboBox3.Items.Add(new ComboxItem("10", "10"));
            this.comboBox3.Items.Add(new ComboxItem("15", "15"));
            this.comboBox3.Items.Add(new ComboxItem("20", "20"));
            this.comboBox3.Items.Add(new ComboxItem("25", "25"));
            this.comboBox3.Items.Add(new ComboxItem("30", "30"));
            this.comboBox3.Items.Add(new ComboxItem("全部", totalFub + ""));


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            topicType = "2";
            getTopicNum(topicType);

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(new ComboxItem("10", "10"));
            this.comboBox1.Items.Add(new ComboxItem("15", "15"));
            this.comboBox1.Items.Add(new ComboxItem("20", "20"));
            this.comboBox1.Items.Add(new ComboxItem("25", "25"));
            this.comboBox1.Items.Add(new ComboxItem("30", "30"));
            this.comboBox1.Items.Add(new ComboxItem("全部", totalXz + ""));

            this.comboBox2.Items.Clear();
            this.comboBox2.Items.Add(new ComboxItem("10", "10"));
            this.comboBox2.Items.Add(new ComboxItem("15", "15"));
            this.comboBox2.Items.Add(new ComboxItem("20", "20"));
            this.comboBox2.Items.Add(new ComboxItem("25", "25"));
            this.comboBox2.Items.Add(new ComboxItem("30", "30"));
            this.comboBox2.Items.Add(new ComboxItem("全部", totalFeib + ""));


            this.comboBox3.Items.Clear();
            this.comboBox3.Items.Add(new ComboxItem("10", "10"));
            this.comboBox3.Items.Add(new ComboxItem("15", "15"));
            this.comboBox3.Items.Add(new ComboxItem("20", "20"));
            this.comboBox3.Items.Add(new ComboxItem("25", "25"));
            this.comboBox3.Items.Add(new ComboxItem("30", "30"));
            this.comboBox3.Items.Add(new ComboxItem("全部", totalFub + ""));
        }
    }
}
