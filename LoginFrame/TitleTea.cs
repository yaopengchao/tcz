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
    public partial class TitleTea : Form
    {
        public TitleTea()
        {
            InitializeComponent();
        }

        private static TitleTea instance;

        public static TitleTea createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleTea();
            }
            return instance;
        }

        private void TitleTea_Load(object sender, EventArgs e)
        {

        }
    }
}
