using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace LoginFrame
{
    public partial class BodyStu : Form
    {
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
            UserDao userDao = new UserDao();
            int userCount = userDao.countUsers();
            pageCtrl.TotalRecord = userCount;
            DataSet ds = userDao.listUsers();
            pageCtrl.bs.DataSource = ds.Tables[0];
            

            string[] cols = new string[] {"学员名称", "登录名", "密码", "创建时间"};
            pageCtrl.Cols = cols;
            int[] widths = new int[] {100, 150, 150, 200 };
            pageCtrl.Widths = widths;

            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
        }

        private void loadData()
        {
            UserDao userDao = new UserDao();
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = userDao.listUsers(startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }
    }
}
