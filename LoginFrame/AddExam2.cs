using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Collections;
using Model;

namespace LoginFrame
{
    public partial class AddExam2 : Form
    {

        private TopicService topicService;

        private static Dictionary<string, string> strWheres;

        ImplCourses Bll = new ImplCourses();

        public AddExam addExam;

        public BodyExam bodyExam;

        private ExamService examService;

        public AddExam2()
        {
            InitializeComponent();

            topicService = TopicService.getInstance();

            examService = ExamService.getInstance();

            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            string content = txtContent.Text;
            string category = Convert.ToString(topicCategory.SelectedValue);
            if (content != null && !content.Equals(""))
            {
                strWheres.Add("a.content", " like '%" + content + "%' ");
            }
            if (category != null && !category.Equals(""))
            {
                strWheres.Add("a.topic_category", " = '" + category + "' ");
            }
            DataSet dt = topicService.listTopics(strWheres, -1, 0);

            topics.DataSource = dt.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            topicCategory.SelectedIndex = 0;
            txtContent.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addItems(examDetail, topics.Items);
            removeItems(topics, topics.Items);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addItems(topics, examDetail.SelectedItems);
            removeItems(examDetail, examDetail.SelectedItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            addItems(examDetail, topics.SelectedItems);
            removeItems(topics, topics.SelectedItems);
        }

        private void removeItems(ListBox listBox, IEnumerable items)
        {
            DataTable dt = (DataTable) listBox.DataSource;
            DataTable newDt = dt.Clone();
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataRowView item in items)
                {
                    if (dr == item.Row)
                    {
                        flag = true;
                        break;
                    }
                    else
                        flag = false;
                }
                if (!flag)
                    newDt.Rows.Add(dr.ItemArray);
                else
                    continue;
            }
            listBox.DataSource = newDt;
        }

        private void addItems(ListBox listBox, IEnumerable items)
        {
            DataTable dt = null;
            foreach (object item in items)
            {
                if (item is DataRowView)
                    dt = ((DataRowView)item).Row.Table.Clone();
                if (item is DataRow)
                    dt = ((DataRow)item).Table.Clone();
                break;
            }
            if (listBox.DataSource != null)
                dt = ((DataTable)listBox.DataSource).Copy();
            foreach (object item in items)
            {
                if (item is DataRowView)
                    dt.Rows.Add(((DataRowView)item).Row.ItemArray);
                if (item is DataRow)
                    dt.Rows.Add(((DataRow)item).ItemArray);
            }
            listBox.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addItems(topics, examDetail.Items);
            removeItems(examDetail, examDetail.Items);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) examDetail.DataSource;
            string topicIds = "";
            foreach (DataRow dr in dt.Rows)
            {
                object topicId = dr.ItemArray[0];
                topicIds += topicId + ",";
            }
            if (topicIds == "")
            {
                MessageBox.Show("试卷不能没有题目");
            }
            else
            {
                Examination exam = new Examination();
                exam.ExamCat = Convert.ToString(addExam.topicCategory.SelectedValue);
                exam.ExamName = addExam.txtExamName.Text;
                exam.StartTime = addExam.startTime.Text;
                exam.TotalMins = Convert.ToInt32(addExam.totalMins.Text);
                exam.ExType = "1";
                exam.ExaminationId = Convert.ToInt32(addExam.labExamId.Text == "" ? "0" : addExam.labExamId.Text);
                int result = examService.addExam(exam, topicIds);
                if (result > 0)
                {
                    MessageBox.Show("保存成功");
                    bodyExam.btnQuery_Click(sender, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请联系管理员");
                }
            }            
        }

        private void AddExam2_Load(object sender, EventArgs e)
        {

            Util.setLanguage();
            ApplyResource();



            string type = Convert.ToString(addExam.topicCategory.SelectedValue);
            int examId = Convert.ToInt32(addExam.labExamId.Text == "" ? "0" : addExam.labExamId.Text);
            strWheres.Clear();
            strWheres.Add("a.topic_type", " = '" + type + "' ");
            DataSet dt = topicService.listNotInExamTopics(strWheres, examId);

            topics.DataSource = dt.Tables[0];
            topics.DisplayMember = "content";
            topics.ValueMember = "topic_id";

            strWheres.Clear();
            strWheres.Add("b.TOPIC_TYPE", " = '" + type + "' ");         
            strWheres.Add("a.EXAMINATION_ID", " = " + examId + " ");
        
            DataSet dt2 = examService.listExistDetail(strWheres);
            examDetail.DataSource = dt2.Tables[0];
            examDetail.DisplayMember = "content";
            examDetail.ValueMember = "topic_id";

            topicCategory.Items.Clear();
            topicCategory.DataSource = Bll.getAllCourses().Tables[0];
            topicCategory.DisplayMember = "TCZ_NAME";
            topicCategory.ValueMember = "TCZ_ID";
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddExam2));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
