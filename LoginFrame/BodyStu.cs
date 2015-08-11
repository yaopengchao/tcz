using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using DAL;

namespace LoginFrame
{
    public partial class BodyStu : Form
    {
        public BodyStu()
        {
            InitializeComponent();
        }

        private static BodyStu instance;

        public static BodyStu createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyStu();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void loadData()
        {
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            loadData();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

    }
}
