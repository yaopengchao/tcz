namespace LoginFrame
{
    partial class VoiceChat
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
            this.btnCall = new System.Windows.Forms.Button();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.txtCallToIP = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCallTo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbCodecs = new System.Windows.Forms.ComboBox();
            this.lblCodec = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(41, 253);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 21);
            this.btnCall.TabIndex = 0;
            this.btnCall.Text = "邀请通话";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnEndCall
            // 
            this.btnEndCall.Enabled = false;
            this.btnEndCall.Location = new System.Drawing.Point(170, 253);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(75, 21);
            this.btnEndCall.TabIndex = 1;
            this.btnEndCall.Text = "结束通话";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // txtCallToIP
            // 
            this.txtCallToIP.Location = new System.Drawing.Point(82, 168);
            this.txtCallToIP.Name = "txtCallToIP";
            this.txtCallToIP.Size = new System.Drawing.Size(189, 21);
            this.txtCallToIP.TabIndex = 3;
            this.txtCallToIP.Text = "192.168.0.104";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 197);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 21);
            this.txtName.TabIndex = 4;
            // 
            // lblCallTo
            // 
            this.lblCallTo.AutoSize = true;
            this.lblCallTo.Location = new System.Drawing.Point(17, 171);
            this.lblCallTo.Name = "lblCallTo";
            this.lblCallTo.Size = new System.Drawing.Size(53, 12);
            this.lblCallTo.TabIndex = 5;
            this.lblCallTo.Text = "Call &To:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 200);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 12);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "发起人:";
            // 
            // cmbCodecs
            // 
            this.cmbCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodecs.FormattingEnabled = true;
            this.cmbCodecs.Items.AddRange(new object[] {
            "None",
            "A-Law",
            "u-Law"});
            this.cmbCodecs.Location = new System.Drawing.Point(82, 225);
            this.cmbCodecs.Name = "cmbCodecs";
            this.cmbCodecs.Size = new System.Drawing.Size(189, 20);
            this.cmbCodecs.TabIndex = 7;
            // 
            // lblCodec
            // 
            this.lblCodec.AutoSize = true;
            this.lblCodec.Location = new System.Drawing.Point(17, 228);
            this.lblCodec.Name = "lblCodec";
            this.lblCodec.Size = new System.Drawing.Size(59, 12);
            this.lblCodec.TabIndex = 8;
            this.lblCodec.Text = "语音编码:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(243, 182);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(16, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 208);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天组";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(16, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 149);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "局域网在线用户";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(3, 20);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(243, 123);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // VoiceChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCodec);
            this.Controls.Add(this.cmbCodecs);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCallTo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCallToIP);
            this.Controls.Add(this.btnEndCall);
            this.Controls.Add(this.btnCall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VoiceChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "语音聊天";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoiceChat_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnEndCall;
        private System.Windows.Forms.TextBox txtCallToIP;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCallTo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbCodecs;
        private System.Windows.Forms.Label lblCodec;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
    }
}

