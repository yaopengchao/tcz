using BLL;
using Model;
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
    public partial class chooseTopics : Form
    {
        public chooseTopics()
        {
            InitializeComponent();

            button1.BackColor = Color.FromArgb(255, 80, 151, 228);
            button1.ForeColor = Color.White;

            

        }

        private static string totalNum;

        private static int chooseNum=0;

        private static chooseTopics instance;

        private static TopicService topicService;

        private static ExamService examService;

        private static Dictionary<string, string> strWheres;

        private static Examination exam;

        public static chooseTopics createForm(Examination exam_in)
        {
            exam = exam_in;
            //if (instance == null || instance.IsDisposed)
            //{
            instance = new chooseTopics();
            //}
            if (topicService == null)
            {
                topicService = TopicService.getInstance();
            }
            if (examService == null)
            {
                examService = ExamService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }

            return instance;
        }

        private void chooseTopics_Load(object sender, EventArgs e)
        {

            this.label4.Text = exam.Num+"";

            this.label5.Text = chooseNum+"";

            

            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            pageCtrl.dg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);

            btnQuery_Click(sender, e);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;


            strWheres.Add(" exam_id ", "" + exam.ExaminationId + "");


            //string filter = filterText.Text;

            //if (filter != null && !filter.Equals(""))
            //{
            //    strWheres.Add(" LESSON_MUSIC_FILENAME ", " like '%" + filter + "%' ");
            //
            //}

            strWheres.Add(" 1 ", " = 1 ");

            loadCount(strWheres);
            loadData(strWheres);
            loadChooseCount(strWheres);


            string[] cols = new string[] { "题目编号", "题干", "题目种类", "题目分类", "正确答案", "创建时间", "topic_type", "topic_category","是否选择" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            //pageCtrl.dg.Columns[1].Visible = false;
            pageCtrl.dg.Columns[2].Visible = false;
            pageCtrl.dg.Columns[3].Visible = false;
            pageCtrl.dg.Columns[4].Visible = false;
           // pageCtrl.dg.Columns[5].Visible = false;

            pageCtrl.dg.Columns[6].Visible = false;
            pageCtrl.dg.Columns[7].Visible = false;
            //pageCtrl.dg.Columns[8].Visible = false;



            //System.Windows.Forms.DataGridViewCheckBoxColumn isSelected;
            //isSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            //isSelected.TrueValue = "true";
            //isSelected.FalseValue = "false";
            //isSelected.HeaderText = "是否选择";
            //isSelected.Name = "是否选择";
            //isSelected.ReadOnly = false;
            //isSelected.DataPropertyName = "是否选择";//将CHECKBOX显示数据绑定到SQL中的列上
            //pageCtrl.dg.ReadOnly = false;
            //pageCtrl.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { isSelected });

            //pageCtrl.dg.CellValueChanged += new DataGridViewCellEventHandler(CellValueChanged);


            int[] widths = new int[] {10,250,10,10,10,100,10,10,100};
            pageCtrl.Widths = widths;


        }


        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tempGdv = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                string exam_id= Convert.ToString(exam.ExaminationId);
                string topic_id= tempGdv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string topic_state= tempGdv.Rows[e.RowIndex].Cells[8].Value.ToString();

                if (!("已选择").Equals(topic_state))
                {
                    if (Convert.ToInt32(this.label5.Text)>= Convert.ToInt32(this.label4.Text))
                    {
                        MessageBox.Show("已经满足题目数量，无法再选择，请确定结束选题操作!");
                        return;
                    }
                }

                if (examService.updateChooseTopic( exam_id,  topic_id,  topic_state))
                {
                    //刷新 选择列表  定位当前页
                    btnQueryClick();
                }
            }
        }

        void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (pageCtrl.dg.Rows.Count > 0)
            {
                for (int i = 0; i < pageCtrl.dg.Rows.Count; i++)
                {
                    string _selectValue = pageCtrl.dg.Rows[i].Cells["是否选择"].EditedFormattedValue.ToString();
                    if (_selectValue == "true")
                    {
                        MessageBox.Show("选中...");
                        //如果CheckBox已选中，则在此处继续编写代码
                    }
                }
            }
        }

        private void loadChooseCount(Dictionary<string, string> strWheres)
        {
            int userChooseCount = topicService.countChooseedTopics(strWheres);
            this.label5.Text = userChooseCount + "";

            if (this.label5.Text.Equals(this.label4.Text))
            {
                this.label3.Text = "题";
            }
            else
            {
                this.label3.Text = "题，请继续";
            }

        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = topicService.countChooseTopics(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = topicService.listChooseTopics(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
