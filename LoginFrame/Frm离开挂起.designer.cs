namespace LoginFrame
{
    partial class Frm离开挂起
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm离开挂起));
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.butjiesuo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(101, 57);
            this.txtpwd.MaxLength = 10;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(135, 21);
            this.txtpwd.TabIndex = 7;
            // 
            // butjiesuo
            // 
            this.butjiesuo.Location = new System.Drawing.Point(92, 95);
            this.butjiesuo.Name = "butjiesuo";
            this.butjiesuo.Size = new System.Drawing.Size(62, 23);
            this.butjiesuo.TabIndex = 6;
            this.butjiesuo.Text = "解  除(&D)";
            this.butjiesuo.UseVisualStyleBackColor = true;
            this.butjiesuo.Click += new System.EventHandler(this.butjiesuo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "请输入密码：";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(100, 19);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(0, 12);
            this.lbuser.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前管理员：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "退出系统";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm离开挂起
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 144);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.butjiesuo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm离开挂起";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "离开挂起";
            this.Load += new System.EventHandler(this.Frm离开挂起_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button butjiesuo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}