﻿using System;
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

        ExamResultService Bll = new ExamResultService();

        public BodyScore()
        {
            InitializeComponent();

            //this.BackColor = Color.FromArgb(255, 208, 232, 253);
            btnQuery.BackColor = Color.FromArgb(255, 80, 151, 228);
            btnClear.BackColor = Color.FromArgb(255, 80, 151, 228);

            btnQuery.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;
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
                CheckBodySelfTest checkBodySelfTest = new CheckBodySelfTest();
                checkBodySelfTest.TopLevel = true;
                checkBodySelfTest.user_id = tempGdv.Rows[e.RowIndex].Cells[2].Value.ToString();
                checkBodySelfTest.examId = Convert.ToInt32(tempGdv.Rows[e.RowIndex].Cells[1].Value.ToString()); 
                checkBodySelfTest.FormBorderStyle = FormBorderStyle.None;
                checkBodySelfTest.Dock = System.Windows.Forms.DockStyle.Fill;
                checkBodySelfTest.ShowDialog();
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

            //考试名称,考生姓名,考试开始时间  dateTimePicker1 结束时间 dateTimePicker2
            if (this.comboBox1.Text.Length>0)
            {
                string exam_id = this.comboBox1.SelectedValue.ToString();
                if (exam_id != null && !exam_id.Equals(""))
                {
                    strWheres.Add(" t1.EXAMINATION_ID", " = '" + exam_id + "' ");
                }
            }

            string userName = this.userName.Text;
            if (userName!= null && !userName.Equals(""))
            {
                strWheres.Add(" u.user_name", " like '%" + userName + "%' ");
            }

            string dateTimePicker1 = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (dateTimePicker1 != null && !dateTimePicker1.Equals(""))
            {
                strWheres.Add(" t2.start_time", " >= '" + dateTimePicker1 + " 00:00:00' ");
            }

            //
            string dateTimePicker2 = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (dateTimePicker2 != null && !dateTimePicker2.Equals(""))
            {
                strWheres.Add(" t2.start_time    ", " <= '" + dateTimePicker2 + " 23:59:59' ");
            }

            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "结果ID","考试ID","考生ID","考试名称","考生姓名","考试时长", "得分率" };
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            int[] widths = new int[] { 100,100,200,200,200,100 };
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

            loadUserExams();

            

        }


        public void AdjustComboBoxDropDownListWidth(object comboBox)
        {
            Graphics g = null;
            Font font = null;
            try
            {
                ComboBox senderComboBox = null;
                if (comboBox is ComboBox)
                    senderComboBox = (ComboBox)comboBox;
                else if (comboBox is ToolStripComboBox)
                    senderComboBox = ((ToolStripComboBox)comboBox).ComboBox;
                else
                    return;

                int width = senderComboBox.Width;
                g = senderComboBox.CreateGraphics();
                font = senderComboBox.Font;

                //checks if a scrollbar will be displayed.
                //If yes, then get its width to adjust the size of the drop down list.
                int vertScrollBarWidth =
                    (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                    ? SystemInformation.VerticalScrollBarWidth : 0;

                int newWidth;
                foreach (object s in senderComboBox.Items)  //Loop through list items and check size of each items.
                {
                    if (s != null)
                    {
                        newWidth = (int)g.MeasureString(s.ToString().Trim(), font).Width
                            + vertScrollBarWidth;
                        if (width < newWidth)
                            width = newWidth;   //set the width of the drop down list to the width of the largest item.
                    }
                }
                senderComboBox.DropDownWidth = width;
            }
            catch
            { }
            finally
            {
                if (g != null)
                    g.Dispose();
            }
        }

        private void loadUserExams()
        {

            if (LoginRoler.roleid.Equals(Constant.RoleStudent))
            {
                strWheres.Clear();
                strWheres.Add("result.USER_ID", " = " + LoginRoler.userId);
                this.comboBox1.Items.Clear();
                this.comboBox1.DataSource = Bll.getUserExams(strWheres);
                this.comboBox1.DisplayMember = "ExamName";
                this.comboBox1.ValueMember = "ExamId";
            }
            else
            {
                strWheres.Clear();
                this.comboBox1.Items.Clear();
                this.comboBox1.DataSource = Bll.getAllUserExams(strWheres);
                this.comboBox1.DisplayMember = "ExamName";
                this.comboBox1.ValueMember = "ExamId";
            }
            this.comboBox1.SelectedIndex = -1;

            AdjustComboBoxDropDownListWidth(comboBox1);
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

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
