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
    public partial class BodyTea : Form
    {
        public BodyTea()
        {
            InitializeComponent();
        }

        private static BodyTea instance;

        public static BodyTea createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyTea();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
