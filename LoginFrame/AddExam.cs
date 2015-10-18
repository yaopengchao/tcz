using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class AddExam : Form
    {
        public BodyExam bodyExam;

        private ExamService examService;

        private Examination examination=null;

        public AddExam(Examination examination_in)
        {
            if (examination_in!=null)
            {
                examination = examination_in;
            }

            InitializeComponent();

            topicCategory.Items.Clear();
            topicCategory.DataSource = Constant.getTopicType();
            topicCategory.DisplayMember = "name";
            topicCategory.ValueMember = "id";

            exType.Items.Clear();
            exType.DataSource = Constant.getExamType();
            exType.DisplayMember = "name";
            exType.ValueMember = "id";
            exType.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private int xz;


        private void button1_Click(object sender, EventArgs e)
        {

            object categoryValue = topicCategory.SelectedValue;            
            if ((string)categoryValue == "")
            {
                MessageBox.Show("请选择种类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (txtExamName.Text == "")
            {
                MessageBox.Show("考试名称不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (totalMins.Text == "")
            {
                MessageBox.Show("考试时长不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                if (1==2)
                {//此处为原先代码
                    string exTypeValue = Convert.ToString(exType.SelectedValue);
                    if (exTypeValue == "1")
                    {
                        //随机
                        this.Hide();
                        AddExam3 addExam3 = new AddExam3();
                        addExam3.addExam = this;
                        addExam3.bodyExam = this.bodyExam;
                        addExam3.ShowDialog();
                    }
                    else if (exTypeValue == "2")
                    {
                        //手动
                        this.Hide();
                        AddExam2 addExam2 = new AddExam2();
                        addExam2.addExam = this;
                        addExam2.bodyExam = this.bodyExam;
                        addExam2.ShowDialog();
                    }
                }
                else//修改处
                {
                        //先保存试卷基础信息，然后手动或者自动添加试题到试卷上面
                        Examination exam = new Examination();
                        exam.ExamCat = Convert.ToString(this.topicCategory.SelectedValue);
                        exam.ExamName = this.txtExamName.Text;
                        exam.StartTime = this.startTime.Text;
                        exam.TotalMins = Convert.ToInt32(this.totalMins.Text);
                        
                        if (examination!=null)
                        {
                            exam.ExaminationId = examination.ExaminationId;
                        }
                        else
                        {
                            exam.ExType = this.exType.Text;
                            exam.ExaminationId = Convert.ToInt32(this.labExamId.Text == "" ? "0" : this.labExamId.Text);
                        }
                        exam.Num = Convert.ToInt32(this.questionsNum.Text);
                        int result = examService.addOnlyExam(exam);
                        if (result > 0)
                        {
                            string exTypeValue = Convert.ToString(exType.SelectedValue);
                            if (exTypeValue == "1")
                            {
                                //随机题目保存数据到表ex_examination_detail 
                                //获取题目数量  确定随机题目数量
                                int Num= Convert.ToInt32(this.questionsNum.Text);
                                if (examService.randomTopic(Num, exam.ExaminationId))
                                {
                                    //MessageBox.Show("保存成功");
                                    //bodyExam.btnQuery_Click(sender, e);
                                    //this.Close();

                                    this.Hide();
                                    //跳转到  考题列表进行选择
                                    chooseTopics cTopics = chooseTopics.createForm(exam);
                                    cTopics.ShowDialog();
                                }
                                else
                                {
                                    //随机选题发生系统问题，请联系管理员.
                                    MessageBox.Show("随机选题发生系统问题，请联系管理员");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("保存失败，请联系管理员");
                        }
                }
            }
        }

        private void exType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddExam_Load(object sender, EventArgs e)
        {

            examService = ExamService.getInstance();

            Util.setLanguage();
            ApplyResource();

            this.questionsNum.Items.Add(10);
            this.questionsNum.Items.Add(20);
            this.questionsNum.Items.Add(30);
            this.questionsNum.Items.Add(40);
            this.questionsNum.Items.Add(50);
            this.questionsNum.Items.Add("全部");

            this.questionsNum.SelectedIndex = 0;

            //加载传过来的考试信息到界面
            if (examination != null)
            {
                //将选题方式隐藏掉 该信息不需要显示
                this.label5.Visible = false;
                this.exType.Visible = false;

                if (examination.ExamCat.Equals('1'))
                {
                    topicCategory.SelectedIndex = 0;
                }
                else
                {
                    topicCategory.SelectedIndex = 1;
                }

                this.txtExamName.Text = examination.ExamName;

                this.startTime.Text = examination.StartTime;

                this.totalMins.Text = Convert.ToString(examination.TotalMins);

                this.questionsNum.Text = Convert.ToString(examination.Num);
            }

        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddExam));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
