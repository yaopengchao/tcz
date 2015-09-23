using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace LoginFrame
{
    public partial class BodySelfTest : Form
    {

        private static BodySelfTest instance;

        public MainFrame mainFrame;

        public static BodySelfTest createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodySelfTest();
            }
            return instance;
        }

        public BodySelfTest()
        {
            InitializeComponent();

            //this.BackColor = Color.FromArgb(255, 208, 232, 253);

            button1.BackColor = Color.FromArgb(255, 80, 151, 228);
            button1.ForeColor = Color.White;

            topicCategory.Items.Clear();
            topicCategory.DataSource = Constant.getTopicType();
            topicCategory.DisplayMember = "name";
            topicCategory.ValueMember = "id";
            DateTime dt = DateTime.Now;

            txtExamName.Text = dt.ToString("yyyy-MM-dd HH:mm") + LoginRoler.username + "的自我测试";
        }

        private void txtExamName_TextChanged(object sender, EventArgs e)
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
                MessageBox.Show("自我测试标题不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                mainFrame.panel6.Controls.Clear();
                BodySelfTest2 self2 = new BodySelfTest2();
                self2.TopLevel = false;
                self2.self = this;
                self2.FormBorderStyle = FormBorderStyle.None;
                self2.Dock = System.Windows.Forms.DockStyle.Fill;
                mainFrame.panel6.Controls.Add(self2);
                self2.Show();
            }
        }

        private void BodySelfTest_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodySelfTest));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
