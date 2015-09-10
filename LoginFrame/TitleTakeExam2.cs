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
    public partial class TitleTakeExam2 : Form
    {

        public BodyTakeExam2 bodyTakeExam2;

        public double totalMins = 1.0;

        public DateTime endTime;


        public TitleTakeExam2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = endTime - now;
            totalMins = ts.TotalSeconds;
            if (totalMins < 0)
            {
                timer1.Stop();
                bodyTakeExam2.btnSubmit_Click(sender, e);
            }
            else
            {
                timeDes.Text = (ts.Hours < 10 ? "0" + ts.Hours : ts.Hours + "") + ":" + (ts.Minutes < 10 ? "0" + ts.Minutes : "" + ts.Minutes) + ":" + (ts.Seconds < 10 ? "0" + ts.Seconds : "" + ts.Seconds);
            }   
       
        }

        private void TitleTakeExam2_Load(object sender, EventArgs e)
        {
            this.timer1.Start();       
        }
    }
}
