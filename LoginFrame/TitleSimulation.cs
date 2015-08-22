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
    public partial class TitleSimulation : Form
    {

        public BodySimulation bodySimulation;

        public TitleSimulation()
        {
            InitializeComponent();
        }

        private static TitleSimulation instance;


        public static TitleSimulation createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleSimulation();
            }
            return instance;
        }


    }
}
