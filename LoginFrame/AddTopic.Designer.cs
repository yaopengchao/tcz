namespace LoginFrame
{
    partial class AddTopic
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(30, 27);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(124, 27);
            this.labTitle.TabIndex = 5;
            this.labTitle.Text = "添加题目";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(85, 90);
            this.label1.MinimumSize = new System.Drawing.Size(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "题干";
            // 
            // txtClassName
            // 
            this.txtClassName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassName.Location = new System.Drawing.Point(227, 86);
            this.txtClassName.MaximumSize = new System.Drawing.Size(300, 30);
            this.txtClassName.MinimumSize = new System.Drawing.Size(300, 30);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(300, 26);
            this.txtClassName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(85, 157);
            this.label2.MinimumSize = new System.Drawing.Size(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "种类";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginId.Location = new System.Drawing.Point(227, 153);
            this.txtLoginId.MaximumSize = new System.Drawing.Size(300, 30);
            this.txtLoginId.MinimumSize = new System.Drawing.Size(300, 30);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(300, 26);
            this.txtLoginId.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(85, 221);
            this.label3.MinimumSize = new System.Drawing.Size(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "分类";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(227, 216);
            this.textBox1.MaximumSize = new System.Drawing.Size(300, 30);
            this.textBox1.MinimumSize = new System.Drawing.Size(300, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 26);
            this.textBox1.TabIndex = 11;
            // 
            // AddTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLoginId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddTopic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox1;
    }
}