namespace LoginFrame
{
    partial class FrmAddBookType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddBookType));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_bookTypeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_days = new System.Windows.Forms.TextBox();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别名称:";
            // 
            // txt_bookTypeName
            // 
            this.txt_bookTypeName.Location = new System.Drawing.Point(129, 38);
            this.txt_bookTypeName.Name = "txt_bookTypeName";
            this.txt_bookTypeName.Size = new System.Drawing.Size(167, 21);
            this.txt_bookTypeName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "可借阅天数:";
            // 
            // txt_days
            // 
            this.txt_days.Location = new System.Drawing.Point(129, 117);
            this.txt_days.Name = "txt_days";
            this.txt_days.Size = new System.Drawing.Size(95, 21);
            this.txt_days.TabIndex = 3;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Location = new System.Drawing.Point(129, 194);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(118, 23);
            this.Btn_Add.TabIndex = 4;
            this.Btn_Add.Text = "添加";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // FrmAddBookType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 282);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.txt_days);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_bookTypeName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddBookType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加图书类别";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bookTypeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_days;
        private System.Windows.Forms.Button Btn_Add;
    }
}