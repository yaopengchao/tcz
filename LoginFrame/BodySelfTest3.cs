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

namespace LoginFrame
{
    public partial class BodySelfTest3 : Form
    {

        public int examId;

        private ExamService examService;

        private TopicService topicService;

        private int cur;

        private int totalTopic;

        private List<string> results = new List<string>();

        public BodySelfTest3()
        {
            InitializeComponent();

            if (examService == null)
            {
                examService = ExamService.getInstance();
            }
            if (topicService == null)
            {
                topicService = TopicService.getInstance();
            }
        }

        private void BodySelfTest3_Load(object sender, EventArgs e)
        {
            DataTable dt = examService.getExamByExamId(examId);
            totalTopic = dt.Rows.Count;
            cur = 0;
            btnVisible(cur, totalTopic);
            if (totalTopic > 0)
            {
                labTopicOrder.Text = "1.";
                labContent.Text = Convert.ToString(dt.Rows[0].ItemArray[3]);
                int topicId = Convert.ToInt32(dt.Rows[0].ItemArray[2]);
                DataSet ds = topicService.getTopicDetail(topicId);
                int topicCount = ds.Tables[0].Rows.Count;
                for (int i = 0; i < topicCount; i++)
                {
                    LinkLabel linLab = new LinkLabel();
                    linLab.Text = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]) + ":";
                    linLab.Location = new System.Drawing.Point(180, 152 + 30 * i);

                    linLab.AutoSize = true;
                    linLab.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    linLab.Name = "labPreA" + i;
                    linLab.LinkBehavior = LinkBehavior.NeverUnderline;
                    //this.labPreA.Size = new System.Drawing.Size(31, 19);
                    //this.labPreA.TabIndex = 3;
                    //this.labPreA.TabStop = true;
                    //this.labPreA.Text = "A:";
                    linLab.Click += new EventHandler(preClick);
                    this.Controls.Add(linLab);

                    Label lab = new Label();
                    lab.Text = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]);
                    lab.Location = new System.Drawing.Point(220, 152 + 30 * i);

                    lab.AutoSize = true;
                    lab.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lab.Name = "labItemDetail" + i;
                    //this.labItemDetail.Size = new System.Drawing.Size(69, 19);
                    //this.labItemDetail.TabIndex = 4;
                    //this.labItemDetail.Text = "label2";


                    this.Controls.Add(lab);
                }
            }
        }

        private void preClick(object sender, EventArgs e)
        {
            string preText = ((LinkLabel)sender).Text;
            preText = preText.Substring(0, preText.Length - 1);
            if (results.Contains(preText))
            {
                results.Remove(preText);
            }
            else
            {
                results.Add(preText);
            }
            labResult.Text = getResults(results);
        }

        private string getResults(List<string> list)
        {
            string result = "";
            foreach (string res in list)
            {
                result += res + "、";
            }
            if (result != "")
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }

        private void btnVisible(int cur, int total)
        {
            if (total == 1)
            {
                btnPre.Visible = false;
                btnNext.Visible = false;
            }
            else
            {
                if (cur == 0)
                {
                    btnPre.Visible = false;
                    btnNext.Visible = true;
                }
                else if (cur > 0 && cur < total)
                {
                    btnPre.Visible = true;
                    btnNext.Visible = true;
                }
                else if (cur == total)
                {
                    btnPre.Visible = true;
                    btnNext.Visible = false;
                }
            }
        }
    }
}
