using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class BodyMain : Form
    {
        public BodyMain()
        {
            InitializeComponent();
        }

        private static BodyMain instance;

        public static BodyMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyMain();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
