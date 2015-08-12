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

        }
    }
}
