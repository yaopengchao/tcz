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
    public partial class BodyTakeExam : Form
    {

        public MainFrame mainFrame;

        private static BodyTakeExam instance;

        public static BodyTakeExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyTakeExam();
            }
            return instance;
        }

        public BodyTakeExam()
        {
            InitializeComponent();
        }
    }
}
