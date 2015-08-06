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
    public partial class Frm管理员 : Form
    {
        public Frm管理员()
        {
            InitializeComponent();
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


        private void Frm主面_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripLabel16_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        //使用帮助
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new Common().ShowHelp();
        }
        //关于
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            new Common().ShowAbout();
        }
        //密码修改
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Common().UpdatePassword();
        }
        //个人信息
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm个人信息 frm = new Frm个人信息();
            frm.ShowDialog();
        }
        //离开挂起
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            new Common().KeepLeve();
        }

        private void Frm管理员_Load(object sender, EventArgs e)
        {
            CreateOutlookList();

            this.tool_UserName.Text = LoginRoler.U_Name;
        }

        //信息管理
        private void CreateCarList()
        {
            listView1.Items.Clear();
            listView1.LargeImageList = imageListCars;
            listView1.Items.Add("我的信息", 0);
            listView1.Items.Add("人员维护", 1);
            listView1.Items.Add("添加管理员", 2);
        }
        /// <summary>
        /// 车次管理
        /// </summary>
        private void CreateOutlookList()
        {
            listView1.Items.Clear();
            listView1.LargeImageList = imageListOutlook;
            listView1.Items.Add("Outlook Today", 0);
            listView1.Items.Add("Inbox", 1);
            listView1.Items.Add("Calendar", 2);
            listView1.Items.Add("Contacts", 3);
            listView1.Items.Add("Tasks", 4);
            listView1.Items.Add("Deleted Items", 5);
        }


        void ButtonClick(object sender, System.EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int clickedButtonTabIndex = clickedButton.TabIndex;

            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is Button)
                {
                    Button btn = (Button)ctl;
                    if (btn.TabIndex > clickedButtonTabIndex)
                    {
                        if (btn.Dock != DockStyle.Bottom)
                        {
                            btn.Dock = DockStyle.Bottom;
                            btn.BringToFront();
                        }
                    }
                    else
                    {
                        if (btn.Dock != DockStyle.Top)
                        {
                            btn.Dock = DockStyle.Top;
                            btn.BringToFront();
                        }
                    }
                }
            }
            switch (clickedButton.Text)
            {
                case "信息管理":
                    CreateCarList();
                    break;

                case "车次管理":
                    CreateOutlookList();
                    break;
            }
            listView1.BringToFront();  // Without this, the buttons will hide the items.
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                switch (this.listView1.SelectedItems[0].Text)
                {
                    case "我的信息":
                        toolStripMenuItem1_Click(sender, e);
                        break;
                    case "人员维护":
                        break;
                    case "添加管理员":
                        break;
                    case "1":
                        break;
                    case "12":
                        break;
                    case "123":
                        break;
                    case "124":
                        break;

                }
            }
        }

        /// <summary>
        /// 人员维护
        /// </summary>
        public void 人员维护()
        {

        }
    }
}
