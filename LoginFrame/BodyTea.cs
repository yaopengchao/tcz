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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            btnQuery_Click(sender, e);
        }
    }
}
