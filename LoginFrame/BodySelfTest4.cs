using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class BodySelfTest4 : Form
    {
        public BodySelfTest4()
        {
            InitializeComponent();

            button1.BackColor = Color.FromArgb(255, 80, 151, 228);
            button1.ForeColor = Color.White;

            button2.BackColor = Color.FromArgb(255, 80, 151, 228);
            button2.ForeColor = Color.White;
        }

        public BodySelfTest2 selfTest2;

        private static string exam_id;

        private static BodySelfTest4 instance;

        private static ExamResultService examResultService;

        private static Dictionary<string, string> strWheres;

        private static string totalNum;

        public static BodySelfTest4 createForm(string exam_id_in)
        {
            //if (instance == null || instance.IsDisposed)
            //{
            instance = new BodySelfTest4();
            //}
            if (examResultService == null)
            {
                examResultService = ExamResultService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            exam_id = exam_id_in;
            return instance;
        }

        private void BodySelfTest4_Load(object sender, EventArgs e)
        {
            strWheres.Clear();

            strWheres.Add(" t1.EXAMINATION_ID", " = '" + exam_id + "' ");
           
            strWheres.Add(" u.user_id", " = '" + LoginRoler.userId + "' ");

            //加载成绩
            DataSet ds = examResultService.listExams(strWheres, 0, 1);

            this.label2.Text= "共 "+ (string)(ds.Tables[0].Rows[0][7]) + " 题，答对 "+ (string)(ds.Tables[0].Rows[0][8]) + " 题，答错 "+(Convert.ToInt32((string)(ds.Tables[0].Rows[0][7]))- Convert.ToInt32((string)(ds.Tables[0].Rows[0][8]))) + " 题，得分率:"+(string)(ds.Tables[0].Rows[0][6]);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //加载主体栏
            selfTest2.mainFrame.panel6.Controls.Clear();
            selfTest2.mainFrame.panel6.Controls.AddRange(selfTest2.mainFrame.items.ToArray());
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            selfTest2.mainFrame.panel6.Controls.Add(bodyMain);
            bodyMain.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
