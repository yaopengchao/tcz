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
    public partial class TitleSelfTest : Form
    {

        private static TitleSelfTest instance;

        public static TitleSelfTest createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleSelfTest();
            }
            return instance;
        }

        public TitleSelfTest()
        {
            InitializeComponent();
        }
    }
}
