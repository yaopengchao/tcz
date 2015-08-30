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
    public partial class TestService : Form
    {
        public TestService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemService ss = new SystemService();
            ss.StartWindowsService("MySQL");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SystemService ss = new SystemService();
            ss.StopWindowsService("MySQL");
        }
    }
}
