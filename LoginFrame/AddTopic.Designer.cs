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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTopic));
            this.labTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addDetail = new System.Windows.Forms.Button();
            this.delDetail = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.选项字符 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topicCategory = new System.Windows.Forms.ComboBox();
            this.topicType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labTopicId = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAnswers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            resources.ApplyResources(this.labTitle, "labTitle");
            this.labTitle.Name = "labTitle";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addDetail
            // 
            resources.ApplyResources(this.addDetail, "addDetail");
            this.addDetail.Name = "addDetail";
            this.addDetail.UseVisualStyleBackColor = true;
            this.addDetail.Click += new System.EventHandler(this.addDetail_Click);
            // 
            // delDetail
            // 
            resources.ApplyResources(this.delDetail, "delDetail");
            this.delDetail.Name = "delDetail";
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
            this.Column2,
            this.Column1});
            resources.ApplyResources(this.dg, "dg");
            this.dg.Name = "dg";
            this.dg.RowHeadersVisible = false;
            this.dg.RowTemplate.Height = 23;
            // 
            // 选项字符
            // 
            this.选项字符.FillWeight = 5.076141F;
            resources.ApplyResources(this.选项字符, "选项字符");
            this.选项字符.Name = "选项字符";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 194.9239F;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // topicCategory
            // 
            resources.ApplyResources(this.topicCategory, "topicCategory");
            this.topicCategory.FormattingEnabled = true;
            this.topicCategory.Name = "topicCategory";
            // 
            // topicType
            // 
            resources.ApplyResources(this.topicType, "topicType");
            this.topicType.FormattingEnabled = true;
            this.topicType.Name = "topicType";
            this.topicType.SelectedIndexChanged += new System.EventHandler(this.topicType_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labTopicId
            // 
            resources.ApplyResources(this.labTopicId, "labTopicId");
            this.labTopicId.Name = "labTopicId";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContent);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtContent
            // 
            resources.ApplyResources(this.txtContent, "txtContent");
            this.txtContent.Name = "txtContent";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAnswers);
            this.groupBox2.Controls.Add(this.dg);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labTopicId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.addDetail);
            this.groupBox2.Controls.Add(this.delDetail);
            this.groupBox2.Controls.Add(this.topicType);
            this.groupBox2.Controls.Add(this.topicCategory);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txtAnswers
            // 
            this.txtAnswers.FormattingEnabled = true;
            resources.ApplyResources(this.txtAnswers, "txtAnswers");
            this.txtAnswers.Name = "txtAnswers";
            // 
            // AddTopic
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTopic";
            this.Load += new System.EventHandler(this.AddTopic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addDetail;
        private System.Windows.Forms.Button delDetail;
        public System.Windows.Forms.DataGridView dg;
        public System.Windows.Forms.ComboBox topicCategory;
        public System.Windows.Forms.ComboBox topicType;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labTopicId;
        private System.Windows.Forms.DataGridViewTextBoxColumn 选项字符;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox txtAnswers;
        public System.Windows.Forms.TextBox txtContent;
    }
}