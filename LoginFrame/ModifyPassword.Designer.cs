namespace LoginFrame
{
    partial class ModifyPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyPassword));
            this.labTitle = new System.Windows.Forms.Label();
            this.labUname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtNewConfPwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            resources.ApplyResources(this.labTitle, "labTitle");
            this.labTitle.Name = "labTitle";
            // 
            // labUname
            // 
            resources.ApplyResources(this.labUname, "labUname");
            this.labUname.Name = "labUname";
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOldPwd
            // 
            resources.ApplyResources(this.txtOldPwd, "txtOldPwd");
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Leave += new System.EventHandler(this.txtOldPwd_Leave);
            // 
            // txtNewPwd
            // 
            resources.ApplyResources(this.txtNewPwd, "txtNewPwd");
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Leave += new System.EventHandler(this.txtNewPwd_Leave);
            // 
            // txtNewConfPwd
            // 
            resources.ApplyResources(this.txtNewConfPwd, "txtNewConfPwd");
            this.txtNewConfPwd.Name = "txtNewConfPwd";
            this.txtNewConfPwd.Leave += new System.EventHandler(this.txtNewConfPwd_Leave);
            // 
            // ModifyPassword
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNewConfPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labUname);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModifyPassword";
            this.Load += new System.EventHandler(this.ModifyPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        public System.Windows.Forms.Label labUname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtOldPwd;
        public System.Windows.Forms.TextBox txtNewPwd;
        public System.Windows.Forms.TextBox txtNewConfPwd;
    }
}