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
    public partial class TitleTakeExam : Form
    {

        private static TitleTakeExam instance;

        public static TitleTakeExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleTakeExam();
            }
            return instance;
        }

        public TitleTakeExam()
        {
            InitializeComponent();
        }
    }
}
