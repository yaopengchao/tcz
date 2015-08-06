namespace LoginFrame
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_pwd2 = new System.Windows.Forms.TextBox();
            this.time_Birthday = new System.Windows.Forms.DateTimePicker();
            this.radion_man = new System.Windows.Forms.RadioButton();
            this.radio_women = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "性  别:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出身日期:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(72, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "注   册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(191, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "取   消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(97, 21);
            this.txt_username.MaxLength = 10;
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(185, 21);
            this.txt_username.TabIndex = 9;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(97, 146);
            this.txt_pwd.MaxLength = 10;
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(185, 21);
            this.txt_pwd.TabIndex = 12;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.Location = new System.Drawing.Point(97, 195);
            this.txt_pwd2.MaxLength = 10;
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '*';
            this.txt_pwd2.Size = new System.Drawing.Size(185, 21);
            this.txt_pwd2.TabIndex = 13;
            // 
            // time_Birthday
            // 
            this.time_Birthday.Location = new System.Drawing.Point(97, 100);
            this.time_Birthday.Name = "time_Birthday";
            this.time_Birthday.Size = new System.Drawing.Size(185, 21);
            this.time_Birthday.TabIndex = 14;
            // 
            // radion_man
            // 
            this.radion_man.AutoSize = true;
            this.radion_man.Checked = true;
            this.radion_man.Location = new System.Drawing.Point(112, 69);
            this.radion_man.Name = "radion_man";
            this.radion_man.Size = new System.Drawing.Size(35, 16);
            this.radion_man.TabIndex = 15;
            this.radion_man.TabStop = true;
            this.radion_man.Text = "男";
            this.radion_man.UseVisualStyleBackColor = true;
            // 
            // radio_women
            // 
            this.radio_women.AutoSize = true;
            this.radio_women.Location = new System.Drawing.Point(191, 69);
            this.radio_women.Name = "radio_women";
            this.radio_women.Size = new System.Drawing.Size(35, 16);
            this.radio_women.TabIndex = 16;
            this.radio_women.Text = "女";
            this.radio_women.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 330);
            this.Controls.Add(this.radio_women);
            this.Controls.Add(this.radion_man);
            this.Controls.Add(this.time_Birthday);
            this.Controls.Add(this.txt_pwd2);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(347, 368);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(347, 368);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_pwd2;
        private System.Windows.Forms.DateTimePicker time_Birthday;
        private System.Windows.Forms.RadioButton radion_man;
        private System.Windows.Forms.RadioButton radio_women;

    }
}