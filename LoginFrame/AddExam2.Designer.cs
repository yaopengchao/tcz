﻿namespace LoginFrame
{
    partial class AddExam2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labTitle = new System.Windows.Forms.Label();
            this.topics = new System.Windows.Forms.ListBox();
            this.examDetail = new System.Windows.Forms.ListBox();
            this.topicCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(30, 27);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(236, 27);
            this.labTitle.TabIndex = 7;
            this.labTitle.Text = "手动添加考试题目";
            // 
            // topics
            // 
            this.topics.FormattingEnabled = true;
            this.topics.ItemHeight = 12;
            this.topics.Location = new System.Drawing.Point(91, 153);
            this.topics.Name = "topics";
            this.topics.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.topics.Size = new System.Drawing.Size(210, 232);
            this.topics.TabIndex = 8;
            // 
            // examDetail
            // 
            this.examDetail.FormattingEnabled = true;
            this.examDetail.ItemHeight = 12;
            this.examDetail.Location = new System.Drawing.Point(484, 153);
            this.examDetail.Name = "examDetail";
            this.examDetail.Size = new System.Drawing.Size(210, 232);
            this.examDetail.TabIndex = 9;
            // 
            // topicCategory
            // 
            this.topicCategory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topicCategory.FormattingEnabled = true;
            this.topicCategory.Location = new System.Drawing.Point(140, 78);
            this.topicCategory.Name = "topicCategory";
            this.topicCategory.Size = new System.Drawing.Size(109, 24);
            this.topicCategory.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "分类";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(140, 117);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(109, 21);
            this.txtContent.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "题干";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "添加(向右)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(347, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "添加全部(向右)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(347, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "删除全部(向左)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(347, 262);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 23);
            this.button5.TabIndex = 31;
            this.button5.Text = "删除(向左)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(432, 430);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 30);
            this.button6.TabIndex = 34;
            this.button6.Text = "取消";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(274, 430);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 30);
            this.button7.TabIndex = 33;
            this.button7.Text = "保存";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(255, 116);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 23);
            this.button8.TabIndex = 35;
            this.button8.Text = "清空";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // AddExam2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topicCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.examDetail);
            this.Controls.Add(this.topics);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddExam2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddExam2";
            this.Load += new System.EventHandler(this.AddExam2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.ListBox topics;
        private System.Windows.Forms.ListBox examDetail;
        private System.Windows.Forms.ComboBox topicCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}