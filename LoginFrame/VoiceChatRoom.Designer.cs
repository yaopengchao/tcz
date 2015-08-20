namespace LoginFrame
{
    partial class VoiceChatRoom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.onlineuses = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chatroomusers = new System.Windows.Forms.ListView();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbCodecs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.姓名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.姓名2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP地址2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onlineuses);
            this.groupBox1.Location = new System.Drawing.Point(59, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可邀请在线用户";
            // 
            // onlineuses
            // 
            this.onlineuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onlineuses.CheckBoxes = true;
            this.onlineuses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.姓名,
            this.IP地址});
            this.onlineuses.Location = new System.Drawing.Point(6, 20);
            this.onlineuses.Name = "onlineuses";
            this.onlineuses.Size = new System.Drawing.Size(187, 267);
            this.onlineuses.TabIndex = 0;
            this.onlineuses.UseCompatibleStateImageBehavior = false;
            this.onlineuses.View = System.Windows.Forms.View.Details;
            this.onlineuses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onlineuses_ItemChecked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chatroomusers);
            this.groupBox2.Location = new System.Drawing.Point(477, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 293);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "聊天室用户";
            // 
            // chatroomusers
            // 
            this.chatroomusers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatroomusers.CheckBoxes = true;
            this.chatroomusers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.姓名2,
            this.IP地址2});
            this.chatroomusers.Location = new System.Drawing.Point(6, 20);
            this.chatroomusers.Name = "chatroomusers";
            this.chatroomusers.Size = new System.Drawing.Size(187, 267);
            this.chatroomusers.TabIndex = 0;
            this.chatroomusers.UseCompatibleStateImageBehavior = false;
            this.chatroomusers.View = System.Windows.Forms.View.Details;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(281, 195);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(167, 44);
            this.btnCall.TabIndex = 2;
            this.btnCall.Text = "邀请进入聊天室>>>";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnEndCall
            // 
            this.btnEndCall.Location = new System.Drawing.Point(281, 245);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(167, 50);
            this.btnEndCall.TabIndex = 3;
            this.btnEndCall.Text = "结束通话退出聊天室";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(281, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "语音聊天室";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "手动更新可邀请用户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbCodecs
            // 
            this.cmbCodecs.FormattingEnabled = true;
            this.cmbCodecs.Items.AddRange(new object[] {
            "None",
            "A-Law",
            "u-Law"});
            this.cmbCodecs.Location = new System.Drawing.Point(353, 118);
            this.cmbCodecs.Name = "cmbCodecs";
            this.cmbCodecs.Size = new System.Drawing.Size(95, 20);
            this.cmbCodecs.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "语音编码：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(281, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 60);
            this.label3.TabIndex = 8;
            this.label3.Text = "  教师从左侧列表选择在线学生邀请进入聊天状态，待学生接受后即可通话(语音编码用于不同环境下对语音数据的数据压缩手段,默认即可)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCall);
            this.panel1.Controls.Add(this.cmbCodecs);
            this.panel1.Controls.Add(this.btnEndCall);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(143, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 364);
            this.panel1.TabIndex = 9;
            // 
            // 姓名
            // 
            this.姓名.Text = "姓名";
            this.姓名.Width = 70;
            // 
            // IP地址
            // 
            this.IP地址.Text = "IP地址";
            this.IP地址.Width = 116;
            // 
            // 姓名2
            // 
            this.姓名2.Text = "姓名";
            this.姓名2.Width = 70;
            // 
            // IP地址2
            // 
            this.IP地址2.Text = "IP地址";
            this.IP地址2.Width = 116;
            // 
            // VoiceChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 604);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoiceChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音聊天室";
            this.Load += new System.EventHandler(this.VoiceChat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView onlineuses;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView chatroomusers;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnEndCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbCodecs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader 姓名;
        private System.Windows.Forms.ColumnHeader IP地址;
        private System.Windows.Forms.ColumnHeader 姓名2;
        private System.Windows.Forms.ColumnHeader IP地址2;
    }
}