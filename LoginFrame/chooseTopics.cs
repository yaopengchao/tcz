using BLL;
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
        }

        private static string totalNum;

        private static int chooseNum;

        private static chooseTopics instance;

        private static TopicService topicService;

        private static Dictionary<string, string> strWheres;

        public static chooseTopics createForm()
        {
            //if (instance == null || instance.IsDisposed)
            //{
            instance = new chooseTopics();
            //}
            if (topicService == null)
            {
                topicService = TopicService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }

            return instance;
        }

        private void chooseTopics_Load(object sender, EventArgs e)
        {
            this.label4.Text = totalNum;
            this.label5.Text = chooseNum+"";

            

            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
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
            //string filter = filterText.Text;

            //if (filter != null && !filter.Equals(""))
            //{
            //    strWheres.Add(" LESSON_MUSIC_FILENAME ", " like '%" + filter + "%' ");
            //
            //}

            strWheres.Add(" 1 ", " = 1 ");

            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "题目编号", "题干", "题目种类", "题目分类", "正确答案", "创建时间" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            pageCtrl.dg.Columns[6].Visible = false;
            pageCtrl.dg.Columns[7].Visible = false;


            System.Windows.Forms.DataGridViewCheckBoxColumn isSelected;
            isSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            isSelected.HeaderText = "是否选择";
            isSelected.Name = "是否选择";
            isSelected.ReadOnly = false;
            isSelected.DataPropertyName = "isSelected";
            pageCtrl.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { isSelected });


            int[] widths = new int[] { 230, 150, 150, 150, 150, 150,50  };
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

        }
    }
}
