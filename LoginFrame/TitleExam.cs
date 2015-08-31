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
    public partial class TitleExam : Form
    {

        private static TitleExam instance;

        public static TitleExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleExam();
            }
            return instance;
        }

        public TitleExam()
        {
            InitializeComponent();
        }
    }
}
