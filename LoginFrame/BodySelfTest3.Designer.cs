namespace LoginFrame
{
    partial class BodySelfTest3
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
            this.label1 = new System.Windows.Forms.Label();
            this.labTopicOrder = new System.Windows.Forms.Label();
            this.labContent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(103, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "题干：";
            // 
            // labTopicOrder
            // 
            this.labTopicOrder.AutoSize = true;
            this.labTopicOrder.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTopicOrder.Location = new System.Drawing.Point(183, 61);
            this.labTopicOrder.Name = "labTopicOrder";
            this.labTopicOrder.Size = new System.Drawing.Size(19, 19);
            this.labTopicOrder.TabIndex = 1;
            this.labTopicOrder.Text = "1";
            // 
            // labContent
            // 
            this.labContent.AutoSize = true;
            this.labContent.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labContent.Location = new System.Drawing.Point(208, 61);
            this.labContent.Name = "labContent";
            this.labContent.Size = new System.Drawing.Size(19, 19);
            this.labContent.TabIndex = 2;
            this.labContent.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(180, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "答案";
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labResult.Location = new System.Drawing.Point(257, 454);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(0, 22);
            this.labResult.TabIndex = 4;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(477, 453);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 5;
            this.btnPre.Text = "上一题";
            this.btnPre.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(583, 453);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "下一题";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(739, 453);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "退出/提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // BodySelfTest3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(994, 566);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labContent);
            this.Controls.Add(this.labTopicOrder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodySelfTest3";
            this.Text = "BodySelfTest3";
            this.Load += new System.EventHandler(this.BodySelfTest3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labTopicOrder;
        private System.Windows.Forms.Label labContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSubmit;
    }
}