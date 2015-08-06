namespace LoginFrame
{
    partial class Frm用户管理
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm用户管理));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Query = new System.Windows.Forms.Button();
            this.txt_truename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Book = new System.Windows.Forms.DataGridView();
            this.PageMes = new System.Windows.Forms.Label();
            this.LBHome = new System.Windows.Forms.Button();
            this.LBUp = new System.Windows.Forms.Button();
            this.LBNext = new System.Windows.Forms.Button();
            this.LBEnd = new System.Windows.Forms.Button();
            this.HSelectID = new System.Windows.Forms.TextBox();
            this.HWhere = new System.Windows.Forms.TextBox();
            this.HNowPage = new System.Windows.Forms.TextBox();
            this.HPageSize = new System.Windows.Forms.TextBox();
            this.HAllPage = new System.Windows.Forms.TextBox();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Btn_Del = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Btn_Query);
            this.groupBox1.Controls.Add(this.txt_truename);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置查询条件";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Btn_Query
            // 
            this.Btn_Query.Location = new System.Drawing.Point(649, 18);
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Size = new System.Drawing.Size(89, 22);
            this.Btn_Query.TabIndex = 9;
            this.Btn_Query.Text = "查询";
            this.Btn_Query.UseVisualStyleBackColor = true;
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // txt_truename
            // 
            this.txt_truename.Location = new System.Drawing.Point(79, 20);
            this.txt_truename.Name = "txt_truename";
            this.txt_truename.Size = new System.Drawing.Size(143, 21);
            this.txt_truename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // dataGridView_Book
            // 
            this.dataGridView_Book.AllowUserToAddRows = false;
            this.dataGridView_Book.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Book.Location = new System.Drawing.Point(6, 74);
            this.dataGridView_Book.Name = "dataGridView_Book";
            this.dataGridView_Book.RowTemplate.Height = 23;
            this.dataGridView_Book.Size = new System.Drawing.Size(744, 377);
            this.dataGridView_Book.TabIndex = 1;
            // 
            // PageMes
            // 
            this.PageMes.AutoSize = true;
            this.PageMes.Location = new System.Drawing.Point(4, 460);
            this.PageMes.Name = "PageMes";
            this.PageMes.Size = new System.Drawing.Size(41, 12);
            this.PageMes.TabIndex = 2;
            this.PageMes.Text = "待查询";
            // 
            // LBHome
            // 
            this.LBHome.Enabled = false;
            this.LBHome.Location = new System.Drawing.Point(472, 453);
            this.LBHome.Name = "LBHome";
            this.LBHome.Size = new System.Drawing.Size(64, 26);
            this.LBHome.TabIndex = 3;
            this.LBHome.Text = "首页";
            this.LBHome.UseVisualStyleBackColor = true;
            this.LBHome.Click += new System.EventHandler(this.LBHome_Click);
            // 
            // LBUp
            // 
            this.LBUp.Enabled = false;
            this.LBUp.Location = new System.Drawing.Point(542, 453);
            this.LBUp.Name = "LBUp";
            this.LBUp.Size = new System.Drawing.Size(64, 26);
            this.LBUp.TabIndex = 4;
            this.LBUp.Text = "上一页";
            this.LBUp.UseVisualStyleBackColor = true;
            this.LBUp.Click += new System.EventHandler(this.LBUp_Click);
            // 
            // LBNext
            // 
            this.LBNext.Enabled = false;
            this.LBNext.Location = new System.Drawing.Point(616, 453);
            this.LBNext.Name = "LBNext";
            this.LBNext.Size = new System.Drawing.Size(64, 26);
            this.LBNext.TabIndex = 5;
            this.LBNext.Text = "下一页";
            this.LBNext.UseVisualStyleBackColor = true;
            this.LBNext.Click += new System.EventHandler(this.LBNext_Click);
            // 
            // LBEnd
            // 
            this.LBEnd.Enabled = false;
            this.LBEnd.Location = new System.Drawing.Point(686, 454);
            this.LBEnd.Name = "LBEnd";
            this.LBEnd.Size = new System.Drawing.Size(64, 26);
            this.LBEnd.TabIndex = 6;
            this.LBEnd.Text = "尾页";
            this.LBEnd.UseVisualStyleBackColor = true;
            this.LBEnd.Click += new System.EventHandler(this.LBEnd_Click);
            // 
            // HSelectID
            // 
            this.HSelectID.Location = new System.Drawing.Point(48, 457);
            this.HSelectID.Name = "HSelectID";
            this.HSelectID.Size = new System.Drawing.Size(56, 21);
            this.HSelectID.TabIndex = 7;
            this.HSelectID.Visible = false;
            // 
            // HWhere
            // 
            this.HWhere.Location = new System.Drawing.Point(110, 457);
            this.HWhere.Name = "HWhere";
            this.HWhere.Size = new System.Drawing.Size(56, 21);
            this.HWhere.TabIndex = 8;
            this.HWhere.Visible = false;
            // 
            // HNowPage
            // 
            this.HNowPage.Location = new System.Drawing.Point(151, 457);
            this.HNowPage.Name = "HNowPage";
            this.HNowPage.Size = new System.Drawing.Size(56, 21);
            this.HNowPage.TabIndex = 9;
            this.HNowPage.Text = "1";
            this.HNowPage.Visible = false;
            // 
            // HPageSize
            // 
            this.HPageSize.Location = new System.Drawing.Point(195, 457);
            this.HPageSize.Name = "HPageSize";
            this.HPageSize.Size = new System.Drawing.Size(56, 21);
            this.HPageSize.TabIndex = 10;
            this.HPageSize.Text = "5";
            this.HPageSize.Visible = false;
            // 
            // HAllPage
            // 
            this.HAllPage.Location = new System.Drawing.Point(230, 459);
            this.HAllPage.Name = "HAllPage";
            this.HAllPage.Size = new System.Drawing.Size(56, 21);
            this.HAllPage.TabIndex = 11;
            this.HAllPage.Text = "0";
            this.HAllPage.Visible = false;
            // 
            // Btn_Update
            // 
            this.Btn_Update.Enabled = false;
            this.Btn_Update.Location = new System.Drawing.Point(282, 459);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(76, 21);
            this.Btn_Update.TabIndex = 12;
            this.Btn_Update.Text = "查看/编辑";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Btn_Del
            // 
            this.Btn_Del.Enabled = false;
            this.Btn_Del.Location = new System.Drawing.Point(364, 457);
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Size = new System.Drawing.Size(71, 24);
            this.Btn_Del.TabIndex = 13;
            this.Btn_Del.Text = "删除记录";
            this.Btn_Del.UseVisualStyleBackColor = true;
            this.Btn_Del.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "支持模糊查询*代替字符,例如 张*  ";
            // 
            // Frm用户管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(758, 486);
            this.Controls.Add(this.Btn_Del);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.HAllPage);
            this.Controls.Add(this.HPageSize);
            this.Controls.Add(this.HNowPage);
            this.Controls.Add(this.HWhere);
            this.Controls.Add(this.HSelectID);
            this.Controls.Add(this.LBEnd);
            this.Controls.Add(this.LBNext);
            this.Controls.Add(this.LBUp);
            this.Controls.Add(this.LBHome);
            this.Controls.Add(this.PageMes);
            this.Controls.Add(this.dataGridView_Book);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm用户管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmQueryBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_truename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Book;
        private System.Windows.Forms.Label PageMes;
        private System.Windows.Forms.Button LBHome;
        private System.Windows.Forms.Button LBUp;
        private System.Windows.Forms.Button LBNext;
        private System.Windows.Forms.Button LBEnd;
        private System.Windows.Forms.TextBox HSelectID;
        private System.Windows.Forms.TextBox HWhere;
        private System.Windows.Forms.TextBox HNowPage;
        private System.Windows.Forms.TextBox HPageSize;
        private System.Windows.Forms.TextBox HAllPage;
        private System.Windows.Forms.Button Btn_Query;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button Btn_Del;
        private System.Windows.Forms.Label label2;
    }
}