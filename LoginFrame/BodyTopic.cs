using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace LoginFrame
{
    public partial class BodyTopic : Form
    {
        public BodyTopic()
        {
            InitializeComponent();
        }

        private static BodyTopic instance;

        public static BodyTopic createForm()
        {
            if (instance == null)
            {
                instance = new BodyTopic();
            }
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

        private static TopicService topicService;

        private static Dictionary<string, string> strWheres;

        private void pageControl1_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = topicService.listTopics(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddTopic addTopic = AddTopic.getInstance();
            addTopic.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;
            string content = txtContent.Text;
            if (content != null && !content.Equals(""))
            {
                strWheres.Add("content", " like '%" + content + "%' ");
            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "题目编号", "题干", "题目种类", "题目分类", "正确答案", "创建时间" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            int[] widths = new int[] { 230, 150, 150, 150, 150, 150 };
            pageCtrl.Widths = widths;
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = topicService.countTopics(strWheres);
            pageCtrl.TotalRecord = userCount;
        }
    }
}
