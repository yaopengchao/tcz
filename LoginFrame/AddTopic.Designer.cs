namespace LoginFrame
{
    partial class AddTopic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addDetail = new System.Windows.Forms.Button();
            this.delDetail = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.topicCategory = new System.Windows.Forms.ComboBox();
            this.topicType = new System.Windows.Forms.ComboBox();
            this.txtAnswers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.labTopicId = new System.Windows.Forms.Label();
            this.选项字符 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(30, 27);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(124, 27);
            this.labTitle.TabIndex = 5;
            this.labTitle.Text = "添加题目";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(125, 172);
            this.label1.MinimumSize = new System.Drawing.Size(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "题干";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(125, 79);
            this.label2.MinimumSize = new System.Drawing.Size(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "种类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(125, 123);
            this.label3.MinimumSize = new System.Drawing.Size(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "分类";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addDetail
            // 
            this.addDetail.Location = new System.Drawing.Point(587, 245);
            this.addDetail.Name = "addDetail";
            this.addDetail.Size = new System.Drawing.Size(75, 23);
            this.addDetail.TabIndex = 15;
            this.addDetail.Text = "添加行";
            this.addDetail.UseVisualStyleBackColor = true;
            this.addDetail.Click += new System.EventHandler(this.addDetail_Click);
            // 
            // delDetail
            // 
            this.delDetail.Location = new System.Drawing.Point(587, 274);
            this.delDetail.Name = "delDetail";
            this.delDetail.Size = new System.Drawing.Size(75, 23);
            this.delDetail.TabIndex = 16;
            this.delDetail.Text = "删除行";
            this.delDetail.UseVisualStyleBackColor = true;
            this.delDetail.Click += new System.EventHandler(this.delDetail_Click);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToResizeRows = false;
            this.dg.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.选项字符,
            this.Column2});
            this.dg.Location = new System.Drawing.Point(129, 245);
            this.dg.Name = "dg";
            this.dg.RowHeadersVisible = false;
            this.dg.RowTemplate.Height = 23;
            this.dg.Size = new System.Drawing.Size(438, 120);
            this.dg.TabIndex = 17;
            // 
            // topicCategory
            // 
            this.topicCategory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topicCategory.FormattingEnabled = true;
            this.topicCategory.Location = new System.Drawing.Point(267, 124);
            this.topicCategory.Name = "topicCategory";
            this.topicCategory.Size = new System.Drawing.Size(300, 24);
            this.topicCategory.TabIndex = 19;
            // 
            // topicType
            // 
            this.topicType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topicType.FormattingEnabled = true;
            this.topicType.Location = new System.Drawing.Point(267, 79);
            this.topicType.Name = "topicType";
            this.topicType.Size = new System.Drawing.Size(300, 24);
            this.topicType.TabIndex = 20;
            // 
            // txtAnswers
            // 
            this.txtAnswers.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAnswers.Location = new System.Drawing.Point(267, 387);
            this.txtAnswers.MaximumSize = new System.Drawing.Size(300, 30);
            this.txtAnswers.MinimumSize = new System.Drawing.Size(300, 30);
            this.txtAnswers.Name = "txtAnswers";
            this.txtAnswers.Size = new System.Drawing.Size(300, 26);
            this.txtAnswers.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(125, 391);
            this.label4.MinimumSize = new System.Drawing.Size(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 30);
            this.label4.TabIndex = 21;
            this.label4.Text = "答案";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.Location = new System.Drawing.Point(267, 167);
            this.txtContent.MaximumSize = new System.Drawing.Size(300, 60);
            this.txtContent.MinimumSize = new System.Drawing.Size(300, 60);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(300, 60);
            this.txtContent.TabIndex = 7;
            // 
            // labTopicId
            // 
            this.labTopicId.AutoSize = true;
            this.labTopicId.Location = new System.Drawing.Point(603, 363);
            this.labTopicId.Name = "labTopicId";
            this.labTopicId.Size = new System.Drawing.Size(11, 12);
            this.labTopicId.TabIndex = 23;
            this.labTopicId.Text = "0";
            this.labTopicId.Visible = false;
            // 
            // 选项字符
            // 
            this.选项字符.FillWeight = 5.076141F;
            this.选项字符.HeaderText = "选项字符";
            this.选项字符.Name = "选项字符";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 194.9239F;
            this.Column2.HeaderText = "选项文本";
            this.Column2.Name = "Column2";
            this.Column2.Width = 335;
            // 
            // AddTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.labTopicId);
            this.Controls.Add(this.txtAnswers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.topicType);
            this.Controls.Add(this.topicCategory);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.delDetail);
            this.Controls.Add(this.addDetail);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddTopic";
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addDetail;
        private System.Windows.Forms.Button delDetail;
        public System.Windows.Forms.DataGridView dg;
        public System.Windows.Forms.ComboBox topicCategory;
        public System.Windows.Forms.ComboBox topicType;
        public System.Windows.Forms.TextBox txtAnswers;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtContent;
        public System.Windows.Forms.Label labTopicId;
        private System.Windows.Forms.DataGridViewTextBoxColumn 选项字符;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}