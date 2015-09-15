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
    public partial class CheckBodySelfTest : Form
    {

        public int examId;

        public string user_id;

        private ExamService examService;

        private TopicService topicService;

        private ExamResultService examResultService;

        public BodySelfTest2 selfTest2;

        private static Dictionary<string, string> strWheres;

        private int cur;

        private int examResultId;
        private int examDetailId;
        private int topicId;
        private string answer;

        private int totalTopic;

        private List<Control> items;

        private List<string> results = new List<string>();

        private DataTable dt;

        public CheckBodySelfTest()
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
            if (examResultService == null)
            {
                examResultService = ExamResultService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
        }

        private void BodySelfTest3_Load(object sender, EventArgs e)
        {
            dt = examService.getExamByExamId(examId);
            cur = 0;
            showTopic(dt, cur);
        }

        private void parseAnswers(string answers)
        {
            results.Clear();
            if (answers.IndexOf("、") > -1)
            {
                string[] answerArr = answers.Split('、');
                foreach (string answer in answerArr)
                {
                    results.Add(answer);
                }
            }
            else
            {
                results.Add(answers);
            }
        }

        private void showTopic(DataTable dt, int cur)
        {
            items = new List<Control>();
            examDetailId = Convert.ToInt32(dt.Rows[cur].ItemArray[1]);
            topicId = Convert.ToInt32(dt.Rows[cur].ItemArray[2]);
            strWheres.Clear();
            strWheres.Add("examination_id", " = " + examId);
            strWheres.Add("examination_detail_id", " = " + examDetailId);
            strWheres.Add("topic_id", " = " + topicId);
            strWheres.Add("user_id", " = " + user_id);
            DataTable examResultDt = examResultService.listExamResult(strWheres);
            if (examResultDt != null && examResultDt.Rows.Count > 0)
            {
                examResultId = Convert.ToInt32(examResultDt.Rows[0].ItemArray[0]);
                answer = Convert.ToString(examResultDt.Rows[0].ItemArray[5]);
                parseAnswers(answer);
                labResult.Text = getResults(results);
            }
            else
            {
                results.Clear();
                labResult.Text = getResults(results);
            }


            //正确答案  显示
            strWheres.Clear();
            strWheres.Add("topic_id", " = " + topicId);
            DataTable examRightResultDt = examResultService.listExamRightResult(strWheres);
            if (examRightResultDt != null && examRightResultDt.Rows.Count > 0)
            {
                answer = Convert.ToString(examRightResultDt.Rows[0].ItemArray[0]);
                parseAnswers(answer);
                labRightResult.Text = getResults(results);
            }
            else
            {
                results.Clear();
                labRightResult.Text = getResults(results);
            }


            

            labTopicOrder.Text = cur + 1 + ".";
            labContent.Text = Convert.ToString(dt.Rows[cur].ItemArray[3]);            
            totalTopic = dt.Rows.Count;
            btnVisible(cur, totalTopic);
            DataSet ds = topicService.getTopicDetail(topicId);
            int topicCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < topicCount; i++)
            {
                LinkLabel linLab = new LinkLabel();
                linLab.Text = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]) + ":";
                linLab.Location = new System.Drawing.Point(180, 152 + 30 * i);
                linLab.AutoSize = true;
                linLab.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                linLab.Name = "labPre" + i;
                linLab.LinkBehavior = LinkBehavior.NeverUnderline;
                linLab.Click += new EventHandler(preClick);
                this.Controls.Add(linLab);

                Label lab = new Label();
                lab.Text = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]);
                lab.Location = new System.Drawing.Point(220, 152 + 30 * i);

                lab.AutoSize = true;
                lab.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lab.Name = "labItemDetail" + i;
                items.Add(lab);                
            }
            this.Controls.AddRange(items.ToArray());
            
            isRightAnswers(labResult.Text, labRightResult.Text);
        }

        private void isRightAnswers(string result, string rightResult)
        {
            //判定答案是否正确
            if (!result.Equals(rightResult))
            {
                labResult.BackColor = Color.Red;
                label2.BackColor = Color.Red;
            }
        }

        private void clearLabels()
        {

            foreach (Control ctrl in items)
            {
                this.Controls.Remove(ctrl);
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
            results.Sort();
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
                else if (cur > 0 && cur < total - 1)
                {
                    btnPre.Visible = true;
                    btnNext.Visible = true;
                }
                else if (cur == total - 1)
                {
                    btnPre.Visible = true;
                    btnNext.Visible = false;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {            
            ExamResult examResult = new ExamResult();
            examResult.ExamResultId = examResultId;
            examResult.ExaminationId = examId;
            examResult.ExaminationDetailId = examDetailId;
            examResult.TopicId = topicId;
            examResult.Answer = labResult.Text;
            examResult.UserId = LoginRoler.userId;
            examResultService.addOrUpdateExamResult(examResult);

            cur++;                                         //当前题号+1
            labResult.Text = "";
            clearLabels();
            showTopic(dt, cur);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            ExamResult examResult = new ExamResult();
            examResult.ExamResultId = examResultId;
            examResult.ExaminationId = examId;
            examResult.ExaminationDetailId = examDetailId;
            examResult.TopicId = topicId;
            examResult.Answer = labResult.Text;
            examResult.UserId = LoginRoler.userId;
            examResultService.addOrUpdateExamResult(examResult);

            cur--;                                         //当前题号+1
            labResult.Text = "";
            clearLabels();
            showTopic(dt, cur);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
