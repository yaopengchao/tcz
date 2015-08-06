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
    public partial class TitleMain : Form
    {
        public TitleMain()
        {
            InitializeComponent();
        }

        private static TitleMain instance;

        public static TitleMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleMain();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
