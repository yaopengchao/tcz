using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using System.Globalization;

namespace LoginFrame
{
    public partial class BodyTakeExam : Form
    {

        public MainFrame mainFrame;

        private ExamService examService;

        private DataTable dt;

        private List<int> examIds = new List<int>();
        private List<DateTime> endTimes = new List<DateTime>();

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
            if (examService == null)
            {
                examService = ExamService.getInstance();
            }
        }

        private void BodyTakeExam_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            examIds.Clear();
            endTimes.Clear();
            dt = examService.listExams();

            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                int examId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                examIds.Add(examId);
                string examName = Convert.ToString(dt.Rows[i].ItemArray[1]);
                string startTime = Convert.ToString(dt.Rows[i].ItemArray[2]);
                int totalMins = Convert.ToInt32(dt.Rows[i].ItemArray[3]);
                DateTime st = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                st = st.AddMinutes(totalMins);
                endTimes.Add(st);
                if (DateTime.Compare(now, st) < 0)
                {
                    Label labExName = new Label();
                    labExName.AutoSize = true;
                    labExName.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    labExName.Location = new System.Drawing.Point(165, 120 + 40 * i);
                    labExName.Name = "labExamName" + i;
                    labExName.Text = examName;
                    this.Controls.Add(labExName);

                    Label labStartTime = new Label();
                    labStartTime.AutoSize = true;
                    labStartTime.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    labStartTime.Location = new System.Drawing.Point(450, 120 + 40 * i);
                    labStartTime.Name = "labStartTime" + i;
                    labStartTime.Text = examName;
                    this.Controls.Add(labStartTime);

                    Button btnBegin = new Button();
                    btnBegin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    btnBegin.Location = new System.Drawing.Point(670, 124 + 40 * i);
                    btnBegin.Name = "btnBegin" + i;
                    btnBegin.Text = "进入";
                    btnBegin.Click += new EventHandler(enterExam);
                    this.Controls.Add(btnBegin);
                }
            }
        }

        private void enterExam(object sender, EventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            int index = Convert.ToInt32(buttonName.Substring(buttonName.LastIndexOf("n") + 1));
            int examId = examIds[index];
            DateTime endTime = endTimes[index];

            mainFrame.panel6.Controls.Clear();
            BodyTakeExam2 exam2 = new BodyTakeExam2();
            exam2.TopLevel = false;
            exam2.takeExam = this;
            exam2.examId = examId;
            exam2.FormBorderStyle = FormBorderStyle.None;
            exam2.Dock = System.Windows.Forms.DockStyle.Fill;
            mainFrame.panel6.Controls.Add(exam2);
            mainFrame.panel6.Controls.AddRange(mainFrame.items.ToArray());
            exam2.Show();

            //mainFrame.panel1.Controls.Clear();
            //TitleTakeExam2 takeExam = new TitleTakeExam2();
            //takeExam.TopLevel = false;
            //takeExam.bodyTakeExam2 = exam2;
            //takeExam.endTime = endTime;
            //takeExam.FormBorderStyle = FormBorderStyle.None;
            //takeExam.Dock = System.Windows.Forms.DockStyle.Fill;
            //mainFrame.panel1.Controls.Add(takeExam);
            //takeExam.Show();
        }

    }
}
