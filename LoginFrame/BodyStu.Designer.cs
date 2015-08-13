namespace LoginFrame
{
    partial class BodyStu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.查询条件 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageCtrl2 = new LoginFrame.PageControl();
            this.pageCtrl = new LoginFrame.PageControl();
            this.查询条件.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(941, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(873, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "修改";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(807, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "添加";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // 查询条件
            // 
            this.查询条件.Controls.Add(this.btnClear);
            this.查询条件.Controls.Add(this.btnQuery);
            this.查询条件.Controls.Add(this.txtUserName);
            this.查询条件.Controls.Add(this.label1);
            this.查询条件.Location = new System.Drawing.Point(238, 35);
            this.查询条件.Name = "查询条件";
            this.查询条件.Size = new System.Drawing.Size(760, 60);
            this.查询条件.TabIndex = 7;
            this.查询条件.TabStop = false;
            this.查询条件.Text = "查询条件";
            this.查询条件.Enter += new System.EventHandler(this.查询条件_Enter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(278, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(186, 25);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(80, 27);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学员名称";
            // 
            // pageCtrl2
            // 
            this.pageCtrl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageCtrl2.Cols = new string[0];
            this.pageCtrl2.CurPage = 1;
            this.pageCtrl2.Location = new System.Drawing.Point(7, 38);
            this.pageCtrl2.Name = "pageCtrl2";
            this.pageCtrl2.PageSize = 15;
            this.pageCtrl2.Size = new System.Drawing.Size(200, 546);
            this.pageCtrl2.StartIndex = 0;
            this.pageCtrl2.TabIndex = 8;
            this.pageCtrl2.TotalPage = 1;
            this.pageCtrl2.TotalRecord = 0;
            this.pageCtrl2.Widths = new int[0];
            this.pageCtrl2.Load += new System.EventHandler(this.pageCtrl2_Load);
            // 
            // pageCtrl
            // 
            this.pageCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageCtrl.Cols = new string[0];
            this.pageCtrl.CurPage = 1;
            this.pageCtrl.Location = new System.Drawing.Point(238, 101);
            this.pageCtrl.Name = "pageCtrl";
            this.pageCtrl.PageSize = 15;
            this.pageCtrl.Size = new System.Drawing.Size(760, 483);
            this.pageCtrl.StartIndex = 0;
            this.pageCtrl.TabIndex = 6;
            this.pageCtrl.TotalPage = 1;
            this.pageCtrl.TotalRecord = 0;
            this.pageCtrl.Widths = new int[0];
            this.pageCtrl.Load += new System.EventHandler(this.pageCtrl_Load);
            // 
            // BodyStu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1010, 604);
            this.Controls.Add(this.pageCtrl2);
            this.Controls.Add(this.查询条件);
            this.Controls.Add(this.pageCtrl);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyStu";
            this.Text = "BodyStu";
            this.Load += new System.EventHandler(this.BodyStu_Load);
            this.查询条件.ResumeLayout(false);
            this.查询条件.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private PageControl pageCtrl;
        private System.Windows.Forms.GroupBox 查询条件;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private PageControl pageCtrl2;
    }
}