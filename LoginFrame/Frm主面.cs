using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;


namespace LoginFrame
{
    public partial class Frm主面 : Form
    {
        public Frm主面()
        {
            InitializeComponent();
            this.Text = ConfigurationSettings.AppSettings["title"].ToString();
            this.toolStripStatusLabel4.Text = LoginRoler.truename.ToString();
                     
            this.toolStripStatusLabel7.Text = ConfigurationSettings.AppSettings["support"].ToString();
            this.toolStripStatusLabel9.Text = ConfigurationSettings.AppSettings["right"].ToString();
        }
        //现在时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            tool_NowTime.Text = DateTime.Now.ToString();
        }

        //退出系统
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }


        private void toolStripLabel16_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm主面_Load(object sender, EventArgs e)
        {
            this.tool_UserName.Text = LoginRoler.U_Name;//用户名

            string MainImage = "../../pic/" + ConfigurationSettings.AppSettings["MainImage"].ToString();//主界面图片
            //AboutImage += Application.StartupPath + AboutImage;
            this.pictureBox1.BackgroundImage = Image.FromFile(MainImage);
            

            //以下为权限控制哪些用于显示  TODO
            if (LoginRoler.U_ROlesType == 1)
            {
              
                toolStripButton4.Visible = false;
            
                toolStripButton6.Visible = false;
            
            }
            else//管理员
            {

              
                toolStripSeparator3.Visible = false;
            }
        }
        //个人信息
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm个人信息 frm = new Frm个人信息();
            frm.Message(LoginRoler.U_Id, "Update");
            frm.ShowDialog();
        }
        //密码修改
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Common().UpdatePassword();
        }
        //离开挂起
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            new Common().KeepLeve();
        }
        //密码修改
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(sender, e);
        }
        //离开挂起
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5_Click(sender, e);
        }
        //用户管理
        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm人员管理 frm = new Frm人员管理();
            frm.ShowDialog();
        }
        //管理员管理
        private void 管理员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm管理员管理 frm = new Frm管理员管理();
            frm.ShowDialog();
        }
        //用户管理
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            用户管理ToolStripMenuItem_Click(sender, e);
        }
        //管理员管理
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            管理员管理ToolStripMenuItem_Click(sender, e);
        }
        //站点维护
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
         
        }
        //车次管理
        //车次管理
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           
        }
        //列车管理
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
        }
        //列车管理
        private void 车票管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }
        //车次
        private void toolStripLabel10_Click(object sender, EventArgs e)
        {
           
        }
        //站点维护
        private void 站点维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton7_Click(sender, e);
        }
        //车次
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            toolStripLabel10_Click(sender, e);
        }
        //Frm车票查询
        private void toolStripLabel11_Click(object sender, EventArgs e)
        { 
        }
        //Frm车票查询
        private void 个检信息分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLabel11_Click(sender, e);
        }
        //订票记录
        private void toolStripButton2_Click(object sender, EventArgs e)
        { 
        }
        //订票记录
        private void 订票记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        { 
        }

        private void 退票记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new Common().ShowHelp();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            new Common().ShowAbout();//关于
        }

        //添加图书类别
        private void BookTypeAdd_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddBookType frm = new FrmAddBookType();
            frm.ShowDialog();
        }

        private void BookAdd_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddBook frmAddBook = new FrmAddBook();
            frmAddBook.ShowDialog();
        }

        private void BookManage_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm用户管理 frmQueryBook = new Frm用户管理();
            frmQueryBook.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tool_UserName_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Common().Show用户管理();
        }
    }
}
