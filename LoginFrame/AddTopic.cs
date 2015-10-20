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
    public partial class AddTopic : Form
    {

        ImplCourses Bll = ImplCourses.getInstance();

        private static TopicService topicService = new TopicService();

        private AgreementService agreementService;

        public BodyTopic bodyTopic;

        private static Dictionary<string, string> strWheres;

        public AddTopic()
        {
            InitializeComponent();

            if (agreementService == null)
            {
                agreementService = AgreementService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }

            topicCategory.Items.Clear();
            topicCategory.DataSource = Bll.getAllCourses().Tables[0];
            topicCategory.DisplayMember = "TCZ_NAME";
            topicCategory.ValueMember = "TCZ_ID";

            topicType.Items.Clear();
            topicType.DataSource = Constant.getTopicType();
            topicType.DisplayMember = "name";
            topicType.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDetail_Click(object sender, EventArgs e)
        {
            string type = Convert.ToString(topicType.SelectedValue);
            if (type == "")
            {
                MessageBox.Show("分类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (type == "1")                  //理论类
                {
                    dg.Columns[1].Width = 335;
                    dg.Columns[2].Visible = false;
                    int total = dg.Rows.Count;
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                    cell1.Value = Constant.TOPIC_PRE[total];
                    row.Cells.Add(cell1);
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                    row.Cells.Add(cell2);
                    dg.Rows.Add(row);
                }
                else                             //操作类
                {
                    dg.Columns[1].Width = 235;
                    dg.Columns[2].Width = 100;
                    dg.Columns[2].Visible = true;
                    int total = dg.Rows.Count;
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                    cell1.Value = Constant.TOPIC_PRE[total];
                    row.Cells.Add(cell1);
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                    row.Cells.Add(cell2);
                    DataGridViewComboBoxCell cell3 = new DataGridViewComboBoxCell();
                    strWheres.Clear();
                    strWheres.Add("AGREEMENT_TYPE", " = '2' ");
                    cell3.DataSource = agreementService.listAgreements(strWheres).Tables[0];
                    cell3.DisplayMember = "AGREEMENT_NAME";
                    cell3.ValueMember = "AGREEMENT_ID";
                    row.Cells.Add(cell3);
                    dg.Rows.Add(row);
                }
            }
            
        }

        private void delDetail_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dg.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("请选择一行数据");
            } else
            {
                dg.Rows.Remove(selectedRow);            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text;
            string type = Convert.ToString(topicType.SelectedValue);
            string category = Convert.ToString(topicCategory.SelectedValue);
            string answers = txtAnswers.Text;
            int totalDetail = dg.Rows.Count;
            if (content == "")
            {
                MessageBox.Show("题干不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (type == "")
            {
                MessageBox.Show("题目种类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (category == "")
            {
                MessageBox.Show("题目分类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(answers == "")
            {
                MessageBox.Show("答案不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (totalDetail == 0)
            {
                MessageBox.Show("请填写具体选项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string topicContent = "";
                topicContent += content + "," + type + "," + category + "," + answers + "," + (labTopicId.Text == "" ? "0" : labTopicId.Text) + "|";
                string temp = "";
                for (int i = 0; i < totalDetail; i++)
                {
                    string itemPre = Convert.ToString(dg.Rows[i].Cells[0].Value);
                    string itemDetail = Convert.ToString(dg.Rows[i].Cells[1].Value);
                    string agreement = "";
                    if (type == "2")
                    {
                        agreement = Convert.ToString(dg.Rows[i].Cells[2].Value);
                    }
                    int order = i + 1;
                    topicContent += itemPre + "," + itemDetail + "," + agreement + "," + order + ";";
                    temp += itemPre + "、";
                }
                temp = temp.Substring(0, temp.Length - 1);         //如A、B、C、D
                if (validAnswers(temp, answers))
                {
                    int result = topicService.addTopic(topicContent);
                    if (result > 0)
                    {
                        MessageBox.Show("保存成功");
                        bodyTopic.btnQuery_Click(sender, e);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败，请联系管理员");
                    }
                }
                else
                {
                    MessageBox.Show("请正确填写答案，格式为选项字符，如有多个请以逗号分隔，如A、B、C");
                }
            }
        }

        private bool validAnswers(string items, string answers)
        {
            bool flag = true;
            if (answers.IndexOf("、") > -1)               //如果有多个选项
            {
                string[] attrs = answers.Split('、');
                foreach (string attr in attrs)
                {
                    if (!items.Contains(attr))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                if (!items.Contains(answers))
                {
                    flag = false;
                }
            }
            return flag;
        }

        private void topicType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTopic_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();

            this.txtAnswers.Items.Add("A");
            this.txtAnswers.Items.Add("B");
            this.txtAnswers.Items.Add("C");
            this.txtAnswers.Items.Add("D");

            

        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddTopic));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
