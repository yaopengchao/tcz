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
    public partial class TitletTopic : Form
    {
        public TitletTopic()
        {
            InitializeComponent();
        }

        private static TitletTopic instance;

        public static TitletTopic createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitletTopic();
            }
            return instance;
        }

    }
}
