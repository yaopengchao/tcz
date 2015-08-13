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
    public partial class BodyStu : Form
    {

        private static UserService userService;
        private static Dictionary<string, string> strWheres;

        public BodyStu()
        {
            InitializeComponent();
        }

        private static BodyStu instance;

        public static BodyStu createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyStu();
                if (userService == null)
                    userService = UserService.getInstance();
                if (strWheres == null)
                    strWheres = new Dictionary<string, string>();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BodyStu_Load(object sender, EventArgs e)
        {
            
        }

        private void pageCtrl_Load(object sender, EventArgs e)
        {
            btnQuery_Click(sender, e);            

            string[] cols = new string[] {"学员名称", "登录名", "密码", "创建时间"};
            pageCtrl.Cols = cols;
            int[] widths = new int[] {100, 150, 150, 200 };
            pageCtrl.Widths = widths;

            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
        }

        private void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = userService.listUsers(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            strWheres.Clear();
            string userName = txtUserName.Text;
            if (userName != null && !userName.Equals(""))
            {
                strWheres.Add("user_name", " like '%" + userName + "%'");
            }
            loadCount(strWheres);
            loadData(strWheres);
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = userService.countUsers(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            btnQuery_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            addUser.ShowDialog();

        }
    }
}
