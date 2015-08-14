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

        private static ClassService classService;

        public int classId;

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

                if (classService == null)
                    classService = ClassService.getInstance();

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
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        private void pageCtrl2_Load(object sender, EventArgs e)
        {
            //隐藏班级分页栏
            pageCtrl2.pageShow = false;
            //pageCtrl2.firstCellShow = false;
            pageCtrl2.initPage();

            loadClass(null);

            string[] cols = new string[] {"班级编号", "班级名称"};
            pageCtrl2.Cols = cols;
            pageCtrl2.dg.Columns[0].Visible = false;
            pageCtrl2.cellClick = new PageControl.cellClickEventHandler(cellClick);

        }

        private void cellClick()
        {
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            btnQueryClick();
        }

        public void loadClass(Dictionary<string, string> strWheres)
        {
            DataSet ds = classService.listClass(strWheres);
            pageCtrl2.bs.DataSource = ds.Tables[0];
            pageCtrl2.dg.Rows[0].Selected = true;
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
            if (pageCtrl2.dg.SelectedRows.Count > 0)
            {
                classId = Convert.ToInt32(pageCtrl2.dg.SelectedRows[0].Cells[0].Value);
            } else
            {
                classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            }
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();
            strWheres.Add("a.user_type", " = '3' ");

            //班级编号
            strWheres.Add("b.class_id", " = '" + classId + "' ");

            pageCtrl.strWheres = strWheres;
            string userName = txtUserName.Text;
            if (userName != null && !userName.Equals(""))
            {
                strWheres.Add("a.user_name", " like '%" + userName + "%' ");
            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "学员名称", "登录名", "密码", "创建时间" };
            pageCtrl.Cols = cols;
            int[] widths = new int[] { 100, 150, 150, 200 };
            pageCtrl.Widths = widths;
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
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            AddUser addUser = AddUser.getInstance();
            addUser.bodyStu = this;
            addUser.labTitle.Text = "添加学生";
            addUser.ShowDialog();

        }

        private void 查询条件_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClass addClass = AddClass.getInstance();
            addClass.labTitle.Text = "添加班级";
            addClass.bodyStu = this;
            addClass.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddClass addClass = AddClass.getInstance();
            addClass.bodyStu = this;
            addClass.labTitle.Text = "修改班级";
            addClass.txtClassName.Text = Convert.ToString(pageCtrl2.dg.CurrentRow.Cells[1].Value);
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            addClass.labClassId.Text = Convert.ToString(classId);
            addClass.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            if (classId > 0)
            {
                DialogResult dr = MessageBox.Show("确定要删除'" + pageCtrl2.dg.CurrentRow.Cells[1].Value + "'吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    classService.deleteClass(classId);
                    loadClass(null);
                }
            }
        }
    }
}
