namespace LoginFrame
{
    partial class BodyTakeExam2
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.labResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labContent = new System.Windows.Forms.Label();
            this.labTopicOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSubmit.Location = new System.Drawing.Point(739, 453);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "退出/提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(583, 453);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "下一题";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.FlatAppearance.BorderSize = 0;
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPre.Location = new System.Drawing.Point(477, 453);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 13;
            this.btnPre.Text = "上一题";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Font = new System.Drawing.Font("宋体", 16F);
            this.labResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labResult.Location = new System.Drawing.Point(304, 454);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(0, 22);
            this.labResult.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(180, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "答案";
            // 
            // labContent
            // 
            this.labContent.AutoSize = true;
            this.labContent.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labContent.Location = new System.Drawing.Point(208, 61);
            this.labContent.Name = "labContent";
            this.labContent.Size = new System.Drawing.Size(23, 25);
            this.labContent.TabIndex = 10;
            this.labContent.Text = "1";
            // 
            // labTopicOrder
            // 
            this.labTopicOrder.AutoSize = true;
            this.labTopicOrder.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTopicOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labTopicOrder.Location = new System.Drawing.Point(183, 61);
            this.labTopicOrder.Name = "labTopicOrder";
            this.labTopicOrder.Size = new System.Drawing.Size(23, 25);
            this.labTopicOrder.TabIndex = 9;
            this.labTopicOrder.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(103, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "题干：";
            // 
            // BodyTakeExam2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1010, 648);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labContent);
            this.Controls.Add(this.labTopicOrder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyTakeExam2";
            this.Text = "BodyTakeExam2";
            this.Load += new System.EventHandler(this.BodyTakeExam2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labContent;
        private System.Windows.Forms.Label labTopicOrder;
        private System.Windows.Forms.Label label1;
    }
}