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
            
        }

        private void exType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
