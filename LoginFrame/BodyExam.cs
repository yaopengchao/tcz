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
    public partial class BodyExam : Form
    {

        private static ExamService examService;


        private static BodyExam instance;

        private static Dictionary<string, string> strWheres;

        public static BodyExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyExam();
            }
            if (examService == null)
                examService = ExamService.getInstance();

            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            return instance;
        }

        public BodyExam()
        {
            InitializeComponent();

            //this.BackColor = Color.FromArgb(255, 208, 232, 253);
            btnQuery.BackColor= Color.FromArgb(255, 80, 151, 228);
            btnClear.BackColor = Color.FromArgb(255, 80, 151, 228);
            //button6.BackColor = Color.FromArgb(255, 80, 151, 228);
            //button5.BackColor = Color.FromArgb(255, 80, 151, 228);
            button4.BackColor = Color.FromArgb(255, 80, 151, 228);
            button1.BackColor = Color.FromArgb(255, 80, 151, 228);
            button2.BackColor = Color.FromArgb(255, 80, 151, 228);

            btnQuery.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;
            //button6.ForeColor = Color.White;
            //button5.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;

            topicType.Items.Clear();
            topicType.Items.Clear();
            topicType.DataSource = Constant.getTopicType();
            topicType.DisplayMember = "name";
            topicType.ValueMember = "id";
        }

        

        public void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;
            string examName = txtExamName.Text;
            string type = Convert.ToString(topicType.SelectedValue);
            if (examName != null && !examName.Equals(""))
            {
                strWheres.Add("exam_name", " like '%" + examName + "%' ");
            }
            if (type != null && !type.Equals(""))
            {
                strWheres.Add("exam_cat", " = '" + type + "' ");
            }

            strWheres.Add(" exam_name ", " not like '%的自我测试%' ");

            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "试卷编号", "考试名称", "试题种类", "考试开始时间", "考试时长(分钟)"};
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            pageCtrl.dg.Columns[5].Visible = false;
            pageCtrl.dg.Columns[6].Visible = false;
            pageCtrl.dg.Columns[7].Visible = false;

            int[] widths = new int[] { 30, 250, 150, 150, 150};
            pageCtrl.Widths = widths;
        }

        private void pageCtrl_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = examService.listExams(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = examService.countExams(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            topicType.SelectedIndex = 0;
            txtExamName.Text = "";
            btnQueryClick();
        }

        

        private void BodyExam_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodyExam));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pageCtrl.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                int examId = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[0].Value);
                if (examId > 0)
                {
                    DialogResult dr = MessageBox.Show("确定要删除'" + pageCtrl.dg.CurrentRow.Cells[1].Value + "'吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        examService.deleteExam(examId);
                        btnQueryClick();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddExam addExam = new AddExam(null);
            addExam.bodyExam = this;
            addExam.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //必须选中一行 
            if (pageCtrl.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {

                //获取选中行的信息 填充到对象中

                Examination exam = new Examination();
                exam.ExamCat = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[2].Value.ToString());
                exam.ExamName = pageCtrl.dg.CurrentRow.Cells[1].Value.ToString();
                exam.StartTime = pageCtrl.dg.CurrentRow.Cells[3].Value.ToString();
                exam.TotalMins = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[4].Value.ToString());
                exam.ExType = "1";
                exam.ExaminationId = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[0].Value.ToString());
                exam.Num = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[6].Value.ToString());
                exam.ExType_lx = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[7].Value.ToString());

                AddExam addExam = new AddExam(exam);
                addExam.bodyExam = this;
                addExam.ShowDialog();
                
            }
        }
    }
}
