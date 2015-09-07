namespace LoginFrame
{
    partial class BodyScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodyScore));
            this.查询条件 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageCtrl = new LoginFrame.PageControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.查询条件.SuspendLayout();
            this.SuspendLayout();
            // 
            // 查询条件
            // 
            this.查询条件.Controls.Add(this.textBox1);
            this.查询条件.Controls.Add(this.label2);
            this.查询条件.Controls.Add(this.btnClear);
            this.查询条件.Controls.Add(this.btnQuery);
            this.查询条件.Controls.Add(this.txtUserName);
            this.查询条件.Controls.Add(this.label1);
            resources.ApplyResources(this.查询条件, "查询条件");
            this.查询条件.Name = "查询条件";
            this.查询条件.TabStop = false;
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            this.pageCtrl.Load += new System.EventHandler(this.pageControl1_Load);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BodyScore
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.查询条件);
            this.Controls.Add(this.pageCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyScore";
            this.Load += new System.EventHandler(this.BodyTea_Load);
            this.查询条件.ResumeLayout(false);
            this.查询条件.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PageControl pageCtrl;
        private System.Windows.Forms.GroupBox 查询条件;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}