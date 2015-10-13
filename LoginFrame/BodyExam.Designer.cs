namespace LoginFrame
{
    partial class BodyExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodyExam));
            this.查询条件 = new System.Windows.Forms.GroupBox();
            this.topicType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pageCtrl = new LoginFrame.PageControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.查询条件.SuspendLayout();
            this.SuspendLayout();
            // 
            // 查询条件
            // 
            this.查询条件.Controls.Add(this.topicType);
            this.查询条件.Controls.Add(this.label2);
            this.查询条件.Controls.Add(this.btnClear);
            this.查询条件.Controls.Add(this.btnQuery);
            this.查询条件.Controls.Add(this.txtExamName);
            this.查询条件.Controls.Add(this.label1);
            resources.ApplyResources(this.查询条件, "查询条件");
            this.查询条件.Name = "查询条件";
            this.查询条件.TabStop = false;
            // 
            // topicType
            // 
            resources.ApplyResources(this.topicType, "topicType");
            this.topicType.FormattingEnabled = true;
            this.topicType.Name = "topicType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtExamName
            // 
            resources.ApplyResources(this.txtExamName, "txtExamName");
            this.txtExamName.Name = "txtExamName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pageCtrl
            // 
            this.pageCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageCtrl.Cols = new string[0];
            this.pageCtrl.CurPage = 1;
            resources.ApplyResources(this.pageCtrl, "pageCtrl");
            this.pageCtrl.Name = "pageCtrl";
            this.pageCtrl.PageSize = 15;
            this.pageCtrl.StartIndex = 0;
            this.pageCtrl.TotalPage = 1;
            this.pageCtrl.TotalRecord = 0;
            this.pageCtrl.Widths = new int[0];
            this.pageCtrl.Load += new System.EventHandler(this.pageCtrl_Load);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BodyExam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.查询条件);
            this.Controls.Add(this.pageCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyExam";
            this.Load += new System.EventHandler(this.BodyExam_Load);
            this.查询条件.ResumeLayout(false);
            this.查询条件.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PageControl pageCtrl;
        private System.Windows.Forms.GroupBox 查询条件;
        private System.Windows.Forms.ComboBox topicType;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}