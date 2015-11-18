namespace LoginFrame
{
    partial class AddExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExam));
            this.labTitle = new System.Windows.Forms.Label();
            this.topicCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalMins = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exType = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labExamId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.questionsNum = new System.Windows.Forms.ComboBox();
            this.startTime = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            resources.ApplyResources(this.labTitle, "labTitle");
            this.labTitle.Name = "labTitle";
            // 
            // topicCategory
            // 
            resources.ApplyResources(this.topicCategory, "topicCategory");
            this.topicCategory.FormattingEnabled = true;
            this.topicCategory.Name = "topicCategory";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtExamName
            // 
            resources.ApplyResources(this.txtExamName, "txtExamName");
            this.txtExamName.Name = "txtExamName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // totalMins
            // 
            resources.ApplyResources(this.totalMins, "totalMins");
            this.totalMins.Name = "totalMins";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // exType
            // 
            resources.ApplyResources(this.exType, "exType");
            this.exType.FormattingEnabled = true;
            this.exType.Name = "exType";
            this.exType.SelectedIndexChanged += new System.EventHandler(this.exType_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labExamId
            // 
            resources.ApplyResources(this.labExamId, "labExamId");
            this.labExamId.Name = "labExamId";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // questionsNum
            // 
            this.questionsNum.FormattingEnabled = true;
            resources.ApplyResources(this.questionsNum, "questionsNum");
            this.questionsNum.Name = "questionsNum";
            // 
            // startTime
            // 
            resources.ApplyResources(this.startTime, "startTime");
            this.startTime.Name = "startTime";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // AddExam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.questionsNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labExamId);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalMins);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topicCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddExam";
            this.Load += new System.EventHandler(this.AddExam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        public System.Windows.Forms.ComboBox topicCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox totalMins;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox exType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labExamId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox questionsNum;
        public System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}