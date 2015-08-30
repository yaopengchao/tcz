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

        ImplCourses Bll = new ImplCourses();

        public BodyTopic()
        {
            InitializeComponent();
            topicCategory.Items.Clear();
            topicCategory.DataSource = Bll.getAllCourses().Tables[0];
            topicCategory.DisplayMember = "name";
            topicCategory.ValueMember = "id";

            topicType.Items.Clear();
            topicType.Items.Clear();
            topicType.DataSource = Constant.getTopicType();
            topicType.DisplayMember = "name";
            topicType.ValueMember = "id";
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
            addTopic.bodyTopic = this;
            addTopic.ShowDialog();
        }

        public void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;
            string content = txtContent.Text;
            string type = Convert.ToString(topicType.SelectedValue);
            string category = Convert.ToString(topicCategory.SelectedValue);
            if (content != null && !content.Equals(""))
            {
                strWheres.Add("a.content", " like '%" + content + "%' ");
            }
            if (type != null && !type.Equals(""))
            {
                strWheres.Add("a.topic_type", " = '" + type + "' ");
            }
            if (category != null && !category.Equals(""))
            {
                strWheres.Add("a.topic_category", " = '" + category + "' ");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            topicCategory.SelectedIndex = 0;
            topicType.SelectedIndex = 0;
            txtContent.Text = "";
            btnQueryClick();
        }
    }
}
