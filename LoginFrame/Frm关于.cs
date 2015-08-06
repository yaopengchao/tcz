using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class Frm关于 : Form
    {
        public Frm关于()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm关于_Load(object sender, EventArgs e)
        {
            string version = ConfigurationSettings.AppSettings["version"].ToString();//窗口标题
            this.label1.Text = version;

            string AboutImage = "../../pic/" + ConfigurationSettings.AppSettings["AboutImage"].ToString();//关于图片
            //AboutImage += Application.StartupPath + AboutImage;
            this.pictureBox1.BackgroundImage = Image.FromFile(AboutImage);
            
        }
    }
}
