﻿using System;
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
    public partial class BodyExam : Form
    {

        private static ExamService examService;

        private static BodyExam instance;

        private static Dictionary<string, string> strWheres;

        public static BodyExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyExam();
            }
            if (examService == null)
                examService = ExamService.getInstance();

            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            return instance;
        }

        public BodyExam()
        {
            InitializeComponent();

            topicType.Items.Clear();
            topicType.Items.Clear();
            topicType.DataSource = Constant.getTopicType();
            topicType.DisplayMember = "name";
            topicType.ValueMember = "id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddExam addExam = new AddExam();
            addExam.bodyExam = this;
            addExam.ShowDialog();
        }

        public void btnQuery_Click(object sender, EventArgs e)
        {
            btnQueryClick();
        }

        public void btnQueryClick()
        {
            strWheres.Clear();

            pageCtrl.strWheres = strWheres;
            string examName = txtExamName.Text;
            string type = Convert.ToString(topicType.SelectedValue);
            if (examName != null && !examName.Equals(""))
            {
                strWheres.Add("exam_name", " like '%" + examName + "%' ");
            }
            if (type != null && !type.Equals(""))
            {
                strWheres.Add("exam_cat", " = '" + type + "' ");
            }
            loadCount(strWheres);
            loadData(strWheres);

            string[] cols = new string[] { "试卷编号", "考试名称", "试题种类", "考试开始时间", "考试时长(分钟)"};
            pageCtrl.Cols = cols;
            pageCtrl.dg.Columns[0].Visible = false;
            int[] widths = new int[] { 30, 250, 150, 150, 150};
            pageCtrl.Widths = widths;
        }

        private void pageCtrl_Load(object sender, EventArgs e)
        {
            pageCtrl.loadData = new PageControl.loadDataEventHandler(loadData);
            btnQuery_Click(sender, e);
        }

        public void loadData(Dictionary<string, string> strWheres)
        {
            int startIndex = pageCtrl.StartIndex;
            int pageSize = pageCtrl.PageSize;
            DataSet ds = examService.listExams(strWheres, startIndex, pageSize);
            pageCtrl.bs.DataSource = ds.Tables[0];
        }

        private void loadCount(Dictionary<string, string> strWheres)
        {
            int userCount = examService.countExams(strWheres);
            pageCtrl.TotalRecord = userCount;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            topicType.SelectedIndex = 0;
            txtExamName.Text = "";
            btnQueryClick();
        }
    }
}