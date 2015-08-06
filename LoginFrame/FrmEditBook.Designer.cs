namespace LoginFrame
{
    partial class FrmEditBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditBook));
            this.dtp_publishDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.btn_bookPhoto = new System.Windows.Forms.Button();
            this.txt_bookPhoto = new System.Windows.Forms.TextBox();
            this.pictureBox_bookPhoto = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_publish = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_bookType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bookName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bookPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_publishDate
            // 
            this.dtp_publishDate.Location = new System.Drawing.Point(184, 431);
            this.dtp_publishDate.Name = "dtp_publishDate";
            this.dtp_publishDate.Size = new System.Drawing.Size(208, 21);
            this.dtp_publishDate.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "出版日期：";
            // 
            // Btn_Update
            // 
            this.Btn_Update.Location = new System.Drawing.Point(198, 475);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(142, 25);
            this.Btn_Update.TabIndex = 35;
            this.Btn_Update.Text = "更新图书";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_bookPhoto
            // 
            this.btn_bookPhoto.Location = new System.Drawing.Point(355, 369);
            this.btn_bookPhoto.Name = "btn_bookPhoto";
            this.btn_bookPhoto.Size = new System.Drawing.Size(60, 26);
            this.btn_bookPhoto.TabIndex = 34;
            this.btn_bookPhoto.Text = "上 传";
            this.btn_bookPhoto.UseVisualStyleBackColor = true;
            this.btn_bookPhoto.Click += new System.EventHandler(this.btn_bookPhoto_Click);
            // 
            // txt_bookPhoto
            // 
            this.txt_bookPhoto.Location = new System.Drawing.Point(184, 401);
            this.txt_bookPhoto.Name = "txt_bookPhoto";
            this.txt_bookPhoto.ReadOnly = true;
            this.txt_bookPhoto.Size = new System.Drawing.Size(300, 21);
            this.txt_bookPhoto.TabIndex = 33;
            // 
            // pictureBox_bookPhoto
            // 
            this.pictureBox_bookPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_bookPhoto.Location = new System.Drawing.Point(184, 255);
            this.pictureBox_bookPhoto.Name = "pictureBox_bookPhoto";
            this.pictureBox_bookPhoto.Size = new System.Drawing.Size(156, 140);
            this.pictureBox_bookPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_bookPhoto.TabIndex = 32;
            this.pictureBox_bookPhoto.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "图书图片：";
            // 
            // txt_publish
            // 
            this.txt_publish.Location = new System.Drawing.Point(184, 214);
            this.txt_publish.Name = "txt_publish";
            this.txt_publish.Size = new System.Drawing.Size(354, 21);
            this.txt_publish.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "出版社：";
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(184, 178);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(199, 21);
            this.txt_count.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "图书库存：";
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(184, 141);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(199, 21);
            this.txt_price.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "图书价格：";
            // 
            // cb_bookType
            // 
            this.cb_bookType.FormattingEnabled = true;
            this.cb_bookType.Location = new System.Drawing.Point(184, 103);
            this.cb_bookType.Name = "cb_bookType";
            this.cb_bookType.Size = new System.Drawing.Size(199, 20);
            this.cb_bookType.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "图书类别：";
            // 
            // txt_bookName
            // 
            this.txt_bookName.Location = new System.Drawing.Point(184, 69);
            this.txt_bookName.Name = "txt_bookName";
            this.txt_bookName.Size = new System.Drawing.Size(199, 21);
            this.txt_bookName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "图书名称：";
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(184, 34);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(199, 21);
            this.txt_barcode.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "图书条形码：";
            // 
            // FrmEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 517);
            this.Controls.Add(this.dtp_publishDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.btn_bookPhoto);
            this.Controls.Add(this.txt_bookPhoto);
            this.Controls.Add(this.pictureBox_bookPhoto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_publish);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_bookType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_bookName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图书编辑界面";
            this.Load += new System.EventHandler(this.FrmEditBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bookPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_publishDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button btn_bookPhoto;
        private System.Windows.Forms.TextBox txt_bookPhoto;
        private System.Windows.Forms.PictureBox pictureBox_bookPhoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_publish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_bookType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label label1;
    }
}