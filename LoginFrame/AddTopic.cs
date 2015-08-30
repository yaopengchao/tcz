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
    public partial class AddTopic : Form
    {

        ImplCourses Bll = new ImplCourses();

        private static TopicService topicService;

        public BodyTopic bodyTopic;

        public AddTopic()
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

        private static AddTopic instance;

        public static AddTopic getInstance()
        {
            if (instance == null)
            {
                instance = new AddTopic();
            }
            if (topicService == null)
            {
                topicService = new TopicService();
            }
            return instance;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDetail_Click(object sender, EventArgs e)
        {
            int total = dg.Rows.Count;
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
            cell1.Value = Constant.TOPIC_PRE[total];
            row.Cells.Add(cell1);
            DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
            row.Cells.Add(cell2);
            dg.Rows.Add(row);
        }

        private void delDetail_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dg.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("请选择一行数据");
            } else
            {
                dg.Rows.Remove(selectedRow);            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text;
            string type = Convert.ToString(topicType.SelectedValue);
            string category = Convert.ToString(topicCategory.SelectedValue);
            string answers = txtAnswers.Text;
            int totalDetail = dg.Rows.Count;
            if (content == "")
            {
                MessageBox.Show("题干不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (type == "")
            {
                MessageBox.Show("种类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (category == "")
            {
                MessageBox.Show("分类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(answers == "")
            {
                MessageBox.Show("答案不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (totalDetail == 0)
            {
                MessageBox.Show("请填写具体选项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string topicContent = "";
                topicContent += content + "," + type + "," + category + "," + answers + "|";
                for (int i = 0; i < totalDetail; i++)
                {
                    string itemPre = Convert.ToString(dg.Rows[i].Cells[0].Value);
                    string itemDetail = Convert.ToString(dg.Rows[i].Cells[1].Value);
                    topicContent += itemPre + "," + itemDetail + ";";
                }
                int result = topicService.addTopic(topicContent);
                if (result > 0)
                {
                    MessageBox.Show("保存成功");
                    bodyTopic.btnQuery_Click(sender, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请联系管理员");
                }
            }
        }
    }
}
