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
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(83, 58);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(180, 27);
            this.labTitle.TabIndex = 7;
            this.labTitle.Text = "添加自我测试";
            // 
            // topicCategory
            // 
            this.topicCategory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topicCategory.FormattingEnabled = true;
            this.topicCategory.Location = new System.Drawing.Point(441, 149);
            this.topicCategory.Name = "topicCategory";
            this.topicCategory.Size = new System.Drawing.Size(300, 24);
            this.topicCategory.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(222, 149);
            this.label2.MinimumSize = new System.Drawing.Size(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 30);
            this.label2.TabIndex = 23;
            this.label2.Text = "种类";
            // 
            // txtExamName
            // 
            this.txtExamName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamName.Location = new System.Drawing.Point(441, 228);
            this.txtExamName.MaximumSize = new System.Drawing.Size(300, 30);
            this.txtExamName.MinimumSize = new System.Drawing.Size(300, 30);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(300, 26);
            this.txtExamName.TabIndex = 26;
            this.txtExamName.TextChanged += new System.EventHandler(this.txtExamName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(222, 233);
            this.label1.MinimumSize = new System.Drawing.Size(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 25;
            this.label1.Text = "自我测试标题";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 33;
            this.button1.Text = "下一步";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BodySelfTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1010, 604);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topicCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodySelfTest";
            this.Text = "BodySelfTest";
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