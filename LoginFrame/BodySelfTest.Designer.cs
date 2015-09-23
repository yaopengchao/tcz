namespace LoginFrame
{
    partial class BodySelfTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodySelfTest));
            this.labTitle = new System.Windows.Forms.Label();
            this.topicCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            // txtExamName
            // 
            resources.ApplyResources(this.txtExamName, "txtExamName");
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.TextChanged += new System.EventHandler(this.txtExamName_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BodySelfTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topicCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodySelfTest";
            this.Load += new System.EventHandler(this.BodySelfTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        public System.Windows.Forms.ComboBox topicCategory;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}