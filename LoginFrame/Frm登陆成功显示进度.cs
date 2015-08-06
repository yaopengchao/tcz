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

namespace LoginFrame
{
    public partial class Frm登陆成功显示进度 : Form
    {
        public Frm登陆成功显示进度()
        {
            InitializeComponent();
        }

        private void Frm登陆成功显示进度_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        //进度条显示
        int count = 20;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 98)
            {
                progressBar1.Value += count;
            }
            else
            {
                timer1.Enabled = false;
                Frm主面 frm = new Frm主面();
                frm.Show();
                this.Close();
            }
        }

        private void Frm登陆成功显示进度_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
