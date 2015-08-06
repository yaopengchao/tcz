using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private static MainFrame instance;

        public static MainFrame createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MainFrame();
            }
            return instance;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("用户名不能为空!");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            panel5.Hide();

            panel1.Controls.Clear();
            TitleStu stu = TitleStu.createForm();
            stu.TopLevel = false;
            stu.FormBorderStyle = FormBorderStyle.None;
            stu.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(stu);
            stu.Show();

            panel6.Controls.Clear();
            BodyStu bodyStu = BodyStu.createForm();
            bodyStu.TopLevel = false;
            bodyStu.FormBorderStyle = FormBorderStyle.None;
            bodyStu.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyStu);
            bodyStu.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            panel5.Hide();

            panel1.Controls.Clear();
            TitleTea tea = TitleTea.createForm();
            tea.TopLevel = false;
            tea.FormBorderStyle = FormBorderStyle.None;
            tea.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(tea);
            tea.Show();

            panel6.Controls.Clear();
            BodyTea bodyTea = BodyTea.createForm();
            bodyTea.TopLevel = false;
            bodyTea.FormBorderStyle = FormBorderStyle.None;
            bodyTea.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyTea);
            bodyTea.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            TitleMain titleMain = TitleMain.createForm();
            titleMain.TopLevel = false;
            titleMain.FormBorderStyle = FormBorderStyle.None;
            titleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(titleMain);
            titleMain.Show();

            panel6.Controls.Clear();
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyMain);
            bodyMain.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel5.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
    }
}
