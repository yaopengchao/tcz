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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodyStu));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (pageCtrl2.dg.SelectedRows.Count == 0)
                    pageCtrl2.dg.Rows[0].Selected = true;
            }            
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
            if (((DataTable)pageCtrl2.bs.DataSource).Rows.Count > 0)
            {
                if (pageCtrl2.dg.SelectedRows.Count > 0)
                {
                    classId = Convert.ToInt32(pageCtrl2.dg.SelectedRows[0].Cells[0].Value);
                }
                else
                {
                    classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
                }
                btnQueryClick();
            }  
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

            string[] cols = new string[] { "学员编号", "学员名称", "登录名", "密码", "创建时间" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
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
            addUser.user.UserType = "3";
            addUser.labTitle.Text = "添加学生";
            addUser.labUname.Text = "学生名称";
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
            if (pageCtrl2.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                AddClass addClass = AddClass.getInstance();
                addClass.bodyStu = this;
                addClass.labTitle.Text = "修改班级";
                addClass.txtClassName.Text = Convert.ToString(pageCtrl2.dg.CurrentRow.Cells[1].Value);
                classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
                addClass.labClassId.Text = Convert.ToString(classId);
                addClass.ShowDialog();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            if (classId > 0)
            {
                int userCount = classService.getUserCount(classId);
                if (userCount > 0)                      //班级底下有学员，不能删除
                {
                    MessageBox.Show("请先删除班级底下的学员再删班级");
                } else
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (pageCtrl.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
                AddUser addUser = AddUser.getInstance();
                addUser.bodyStu = this;
                addUser.labTitle.Text = "修改学生";
                addUser.labUname.Text = "学生名称";
                addUser.user.UserType = "3";
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

        private void button7_Click(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(pageCtrl2.dg.CurrentRow.Cells[0].Value);
            AddUsers addUsers = AddUsers.getInstance();
            addUsers.bodyStu = this;
            addUsers.labTitle.Text = "批量添加学生";
            addUsers.ShowDialog();
        }
    }
}
