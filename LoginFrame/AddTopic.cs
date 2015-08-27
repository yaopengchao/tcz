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
    public partial class AddTopic : Form
    {
        public AddTopic()
        {
            InitializeComponent();
        }

        private static AddTopic instance;

        public static AddTopic getInstance()
        {
            if (instance == null)
            {
                instance = new AddTopic();
            }
            return instance;
        }
    }
}
