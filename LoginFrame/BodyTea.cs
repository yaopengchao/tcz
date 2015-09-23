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
    public partial class BodyTea : Form
    {

        private static UserService userService;

        private static Dictionary<string, string> strWheres;

        public BodyTea()
        {
            InitializeComponent();

            //this.BackColor = Color.FromArgb(255, 208, 232, 253);

            btnQuery.BackColor = Color.FromArgb(255, 80, 151, 228);
            btnClear.BackColor = Color.FromArgb(255, 80, 151, 228);
           
            button6.BackColor = Color.FromArgb(255, 80, 151, 228);
            button5.BackColor = Color.FromArgb(255, 80, 151, 228);
            button4.BackColor = Color.FromArgb(255, 80, 151, 228);
         

            btnQuery.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;
         
            button6.ForeColor = Color.White;
            button5.ForeColor = Color.White;
            button4.ForeColor = Color.White;
         
        }

        private static BodyTea instance;

        public static BodyTea createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyTea();
            }
            if (userService == null)
            {
                userService = UserService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pageControl1_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = userService.listTeachers(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();
            strWheres.Add("a.user_type", " = '2' ");

            pageCtrl.strWheres = strWheres;
            string userName = txtUserName.Text;
            if (userName != null && !userName.Equals(""))
            {
                strWheres.Add("a.user_name", " like '%" + userName + "%' ");
            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "教师编号", "教师名称", "登录名", "密码", "创建时间" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            int[] widths = new int[] { 150, 200, 200, 300 };
            pageCtrl.Widths = widths;
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = userService.countTeachers(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void BodyTea_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodyTea));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            btnQuery_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.bodyTea = this;
            addUser.user.UserType = "2";
            addUser.labTitle.Text = "添加教师";
            addUser.labUname.Text = "教师名称";
            addUser.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            if (pageCtrl.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                AddUser addUser = new AddUser();
                addUser.bodyTea = this;
                addUser.user.UserType = "2";
                addUser.labTitle.Text = "修改教师";
                addUser.labUname.Text = "教师名称";
                addUser.labUserId.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[0].Value);
                addUser.txtLoginId.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[2].Value);
                addUser.txtUserName.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[1].Value);
                addUser.txtPwd.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[3].Value);
                addUser.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[0].Value);
            if (userId > 0)
            {
                DialogResult dr = MessageBox.Show("确定要删除'" + pageCtrl.dg.CurrentRow.Cells[1].Value + "'吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    userService.deleteUser(userId);
                    btnQueryClick();
                }
            }
        }
    }
}
