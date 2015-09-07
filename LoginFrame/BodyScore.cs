using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{
    public partial class BodyScore : Form
    {

        private static UserService userService;

        private static Dictionary<string, string> strWheres;

        public BodyScore()
        {
            InitializeComponent();
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

            pageCtrl.strWheres = strWheres;
            string userName = txtUserName.Text;
            if (userName != null && !userName.Equals(""))
            {
                //strWheres.Add("a.user_name", " like '%" + userName + "%' ");
            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "考试类型","考试名称","考试开始时间","考试时长" };
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
            if (LoginRoler.language == Constant.zhCN)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (LoginRoler.language == Constant.En)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            }
            //对当前窗体应用更改后的资源
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
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
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
