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

        public AddExam()
        {
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
                        this.Hide();
                        AddExam3 addExam3 = new AddExam3();
                        addExam3.addExam = this;
                        addExam3.bodyExam = this.bodyExam;
                        addExam3.ShowDialog();
                    }
                    else if (exTypeValue == "2")
                    {

                        this.Hide();
                        AddExam2 addExam2 = new AddExam2();
                        addExam2.addExam = this;
                        addExam2.bodyExam = this.bodyExam;
                        addExam2.ShowDialog();
                    }
                }
                else//修改处
                {
                    this.Hide();
                    //跳转到  考题列表进行选择
                    chooseTopics cTopics = chooseTopics.createForm();
                    cTopics.ShowDialog();

                }
                
            }
            
        }

        private void exType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddExam_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();

            this.questionsNum.Items.Add(10);
            this.questionsNum.Items.Add(20);
            this.questionsNum.Items.Add(30);
            this.questionsNum.Items.Add(40);
            this.questionsNum.Items.Add(50);
            this.questionsNum.Items.Add("全部");

            this.questionsNum.SelectedIndex = 0;
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
