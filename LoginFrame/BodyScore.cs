using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{
    public partial class BodyScore : Form
    {

        private static ExamResultService examResultService;

        private static Dictionary<string, string> strWheres;

        public BodyScore()
        {
            InitializeComponent();
        }

        private static BodyScore instance;

        public static BodyScore createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyScore();
            }
            if (examResultService == null)
            {
                examResultService = ExamResultService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pageControl2_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl2.loadDataEventHandler(loadData);
            pageCtrl.dg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            btnQuery_Click(sender, e);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tempGdv = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                this.panel1.Controls.Clear();

                
                String tempStr = tempGdv.Rows[e.RowIndex].Cells[1].Value.ToString();
                MessageBox.Show("tempStr=" + tempStr);
            }
        }
        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = examResultService.listExams(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;
            string userName = "";
            if (userName != null && !userName.Equals(""))
            {
                //strWheres.Add("a.user_name", " like '%" + userName + "%' ");
            }

            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "考试ID","考试名称","考试时长" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            int[] widths = new int[] { 100,100,200};
            pageCtrl.Widths = widths;
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = examResultService.countExams(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void BodyScore_Load(object sender, EventArgs e)
        {
            if (LoginRoler.language == Constant.zhCN)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (LoginRoler.language == Constant.En)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            }
            //对当前窗体应用更改后的资源
            ApplyResource();
        }


        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(BodyScore));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtUserName.Text = "";
            btnQuery_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
