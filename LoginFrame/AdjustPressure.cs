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
    public partial class AdjustPressure : Form
    {
        public AdjustPressure()
        {
            InitializeComponent();
        }

        private static AdjustPressure instance;


        public static AdjustPressure createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AdjustPressure();
            }
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
