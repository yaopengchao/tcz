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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceChatRoom));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.onlineuses = new System.Windows.Forms.ListView();
            this.姓名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chatroomusers = new System.Windows.Forms.ListView();
            this.姓名2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP地址2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCall = new System.Windows.Forms.Button();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbCodecs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onlineuses);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // onlineuses
            // 
            this.onlineuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onlineuses.CheckBoxes = true;
            this.onlineuses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.姓名,
            this.IP地址});
            resources.ApplyResources(this.onlineuses, "onlineuses");
            this.onlineuses.Name = "onlineuses";
            this.onlineuses.UseCompatibleStateImageBehavior = false;
            this.onlineuses.View = System.Windows.Forms.View.Details;
            this.onlineuses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onlineuses_ItemChecked);
            // 
            // 姓名
            // 
            resources.ApplyResources(this.姓名, "姓名");
            // 
            // IP地址
            // 
            resources.ApplyResources(this.IP地址, "IP地址");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chatroomusers);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chatroomusers
            // 
            this.chatroomusers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatroomusers.CheckBoxes = true;
            this.chatroomusers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.姓名2,
            this.IP地址2});
            resources.ApplyResources(this.chatroomusers, "chatroomusers");
            this.chatroomusers.Name = "chatroomusers";
            this.chatroomusers.UseCompatibleStateImageBehavior = false;
            this.chatroomusers.View = System.Windows.Forms.View.Details;
            // 
            // 姓名2
            // 
            resources.ApplyResources(this.姓名2, "姓名2");
            // 
            // IP地址2
            // 
            resources.ApplyResources(this.IP地址2, "IP地址2");
            // 
            // btnCall
            // 
            resources.ApplyResources(this.btnCall, "btnCall");
            this.btnCall.Name = "btnCall";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnEndCall
            // 
            resources.ApplyResources(this.btnEndCall, "btnEndCall");
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbCodecs
            // 
            this.cmbCodecs.FormattingEnabled = true;
            this.cmbCodecs.Items.AddRange(new object[] {
            resources.GetString("cmbCodecs.Items"),
            resources.GetString("cmbCodecs.Items1"),
            resources.GetString("cmbCodecs.Items2")});
            resources.ApplyResources(this.cmbCodecs, "cmbCodecs");
            this.cmbCodecs.Name = "cmbCodecs";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // VoiceChatRoom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoiceChatRoom";
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