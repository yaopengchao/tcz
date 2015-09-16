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
            topicCategory.DisplayMember = "TCZ_NAME";
            topicCategory.ValueMember = "TCZ_ID";

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
            AddTopic addTopic = new AddTopic();
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
            pageCtrl.dg.Columns[6].Visible = false;
            pageCtrl.dg.Columns[7].Visible = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            int topicId = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[0].Value);
            if (topicId > 0)
            {
                topicService.deleteTopic(topicId);
                btnQueryClick();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddTopic addTopic = new AddTopic();
            addTopic.bodyTopic = this;
            addTopic.labTitle.Text = "修改题目";
            addTopic.topicType.SelectedIndex = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[6].Value);
            addTopic.topicCategory.SelectedIndex = Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[7].Value);
            addTopic.txtContent.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[1].Value);
            addTopic.txtAnswers.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[4].Value);
            addTopic.labTopicId.Text = Convert.ToString(pageCtrl.dg.CurrentRow.Cells[0].Value);

            DataTable dt = topicService.getTopicDetail(Convert.ToInt32(pageCtrl.dg.CurrentRow.Cells[0].Value)).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                int total = addTopic.dg.Rows.Count;
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = dr[1];
                row.Cells.Add(cell1);
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = dr[2];
                row.Cells.Add(cell2);
                addTopic.dg.Rows.Add(row);
            }


            


            addTopic.ShowDialog();
        }

        private void BodyTopic_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodyTopic));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
