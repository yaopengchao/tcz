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
    public partial class Frm人员管理 : Form
    {
        public Frm人员管理()
        {
            InitializeComponent();

        }

        //退出
        private void toolStripLabel退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //人员新增
        private void toolStripLabel添加_Click(object sender, EventArgs e)
        {
            login frm = new login();
            frm.getName += new GetName(login_getName);
            frm.ShowDialog();
        }

        //委托获取传来的值 (刷新列表)
        public void login_getName(string s)
        {
            dataBind();
        }

        //修改
        private void toolStripLabel修改_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.BaseCollection)(dataGridView1.SelectedRows)).Count > 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                Frm个人信息 frm = new Frm个人信息();
                int UserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                frm.Message(UserID, "Update");
                frm.getName += new GetState(login_getName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        void dataBind()
        {
            DataSet ds = new BU_UserInfo().SelectAdmin("U_RoleType=1");//查询普通用户
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            toolStripStatusLabel2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                toolStripLabel修改.Enabled = true;
                toolStripLabel删除.Enabled = true;
            }
            else
            {
                toolStripLabel修改.Enabled = true;
                toolStripLabel删除.Enabled = true;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            if (userName == "")
            {
                toolStripButton1_Click_1(sender, e);
            }
            else
            {
                DataSet ds = new BU_UserInfo().SelectAdmin("U_RoleType=1 and U_Sex=0 and U_Name like '%" + userName + "%' ");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataBind();
        }
        //删除
        private void toolStripLabel删除_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.BaseCollection)(dataGridView1.SelectedRows)).Count > 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int UserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                if (new BU_UserInfo().Delete(UserID))
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Frm人员管理_Load_1(sender, e);
                }
                else
                    MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            string s = e.Node.FullPath;
            string[] data = s.Split('\\');
            if (data.Length == 2)
            {
                DataSet ds = null;
                if (data[1] == "男")
                {
                    ds = new BU_UserInfo().SelectAdmin("U_RoleType=1 and U_Sex=0");//查询普通用户
                }
                else
                {
                    ds = new BU_UserInfo().SelectAdmin("U_RoleType=1 and U_Sex=1");//查询普通用户
                }
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        //显示全部
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            dataBind();
        }

        //窗体加载
        private void Frm人员管理_Load_1(object sender, EventArgs e)
        {
            dataBind();
            this.dataGridView1.ReadOnly = true;
            this.treeView1.Nodes[0].Expand();//展开
        }
    }
}
