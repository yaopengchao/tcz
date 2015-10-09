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
    /// <summary>
    /// 音频选择界面
    /// </summary>
    public partial class searchSound : Form
    {
        public searchSound()
        {
            InitializeComponent();
        }

        public BodySimulation bodySimulation;

        private static searchSound instance;

        private static ImplCourses implCourses;

        private static Dictionary<string, string> strWheres;


        private static TextBox textBox;

        public static searchSound createForm(TextBox tBox)
        {
            //if (instance == null || instance.IsDisposed)
            //{
                instance = new searchSound();
            //}
            if (implCourses == null)
            {
                implCourses = ImplCourses.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            textBox = tBox;

            return instance;
        }


        private void searchSound_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = implCourses.getSounds(strWheres, startIndex, pageSize);
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
            string filter = filterText.Text;

            if (filter != null && !filter.Equals(""))
            {
                strWheres.Add(" LESSON_MUSIC_FILENAME ", " like '%" + filter + "%' ");

            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "课件ID", "课件中文名称", "课件英文名称", "课件FLASH名", "课件章节ID" ,"课件音频文件名"};
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            pageCtrl.dg.Columns[4].Visible = false;
            int[] widths = new int[] {   100, 100, 100,100 };
            pageCtrl.Widths = widths;
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = implCourses.countSounds(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (pageCtrl.dg.CurrentRow == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                textBox.Tag = pageCtrl.dg.CurrentRow.Cells[0].Value;
                textBox.Text= (string)pageCtrl.dg.CurrentRow.Cells[5].Value;
                this.Close();
            }
        }
    }
}
