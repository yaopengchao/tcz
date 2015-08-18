namespace LoginFrame
{
    partial class TalkMain
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCodecs = new System.Windows.Forms.ComboBox();
            this.btnCall = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.btnEndCall);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbCodecs);
            this.panel2.Controls.Add(this.btnCall);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 454);
            this.panel2.TabIndex = 1;
            // 
            // btnEndCall
            // 
            this.btnEndCall.Location = new System.Drawing.Point(101, 354);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(99, 53);
            this.btnEndCall.TabIndex = 8;
            this.btnEndCall.Text = "终止";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "语音编码格式:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbCodecs
            // 
            this.cmbCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodecs.FormattingEnabled = true;
            this.cmbCodecs.Items.AddRange(new object[] {
            "None",
            "A-Law",
            "u-Law"});
            this.cmbCodecs.Location = new System.Drawing.Point(101, 328);
            this.cmbCodecs.Name = "cmbCodecs";
            this.cmbCodecs.Size = new System.Drawing.Size(99, 20);
            this.cmbCodecs.TabIndex = 7;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(3, 353);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(91, 54);
            this.btnCall.TabIndex = 2;
            this.btnCall.Text = "邀请";
            this.btnCall.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(3, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(197, 320);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.BodyMain_listView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "聊天室在线列表";
            this.columnHeader1.Width = 193;
            // 
            // TalkMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(203, 462);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TalkMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BodyMain";
            this.Load += new System.EventHandler(this.BodyMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCodecs;
        private System.Windows.Forms.Button btnEndCall;
    }
}