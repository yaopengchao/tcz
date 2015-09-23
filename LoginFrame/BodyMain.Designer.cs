namespace LoginFrame
{
    partial class BodyMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodyMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axShockwaveFlashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_async = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.分隔线 = new System.Windows.Forms.Label();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_music = new System.Windows.Forms.Button();
            this.btn_pre = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_voice = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPlayer)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.leftPanel);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // leftPanel
            // 
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.leftPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.axShockwaveFlashPlayer);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // axShockwaveFlashPlayer
            // 
            resources.ApplyResources(this.axShockwaveFlashPlayer, "axShockwaveFlashPlayer");
            this.axShockwaveFlashPlayer.Name = "axShockwaveFlashPlayer";
            this.axShockwaveFlashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlashPlayer.OcxState")));
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_async);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.分隔线);
            this.panel3.Controls.Add(this.btn_play);
            this.panel3.Controls.Add(this.btn_stop);
            this.panel3.Controls.Add(this.btn_music);
            this.panel3.Controls.Add(this.btn_pre);
            this.panel3.Controls.Add(this.btn_next);
            this.panel3.Controls.Add(this.btn_voice);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btn_async
            // 
            resources.ApplyResources(this.btn_async, "btn_async");
            this.btn_async.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_async.FlatAppearance.BorderSize = 0;
            this.btn_async.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_async.Name = "btn_async";
            this.btn_async.UseVisualStyleBackColor = true;
            this.btn_async.Click += new System.EventHandler(this.btn_async_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.BackgroundImage = global::LoginFrame.Properties.Resources.收藏夹;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripSeparator1});
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem3.BackgroundImage = global::LoginFrame.Properties.Resources.收藏条目;
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // 分隔线
            // 
            this.分隔线.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.分隔线, "分隔线");
            this.分隔线.Name = "分隔线";
            // 
            // btn_play
            // 
            this.btn_play.BackgroundImage = global::LoginFrame.Properties.Resources.播放;
            resources.ApplyResources(this.btn_play, "btn_play");
            this.btn_play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_play.Name = "btn_play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackgroundImage = global::LoginFrame.Properties.Resources.暂停;
            resources.ApplyResources(this.btn_stop, "btn_stop");
            this.btn_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stop.FlatAppearance.BorderSize = 0;
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_music
            // 
            this.btn_music.BackgroundImage = global::LoginFrame.Properties.Resources.扩音;
            resources.ApplyResources(this.btn_music, "btn_music");
            this.btn_music.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_music.FlatAppearance.BorderSize = 0;
            this.btn_music.Name = "btn_music";
            this.btn_music.UseVisualStyleBackColor = true;
            this.btn_music.Click += new System.EventHandler(this.btn_music_Click);
            // 
            // btn_pre
            // 
            this.btn_pre.BackgroundImage = global::LoginFrame.Properties.Resources.上一个;
            resources.ApplyResources(this.btn_pre, "btn_pre");
            this.btn_pre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pre.FlatAppearance.BorderSize = 0;
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.UseVisualStyleBackColor = true;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // btn_next
            // 
            this.btn_next.BackgroundImage = global::LoginFrame.Properties.Resources.下一个;
            resources.ApplyResources(this.btn_next, "btn_next");
            this.btn_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.Name = "btn_next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_voice
            // 
            this.btn_voice.BackColor = System.Drawing.Color.Transparent;
            this.btn_voice.BackgroundImage = global::LoginFrame.Properties.Resources.语音;
            resources.ApplyResources(this.btn_voice, "btn_voice");
            this.btn_voice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_voice.FlatAppearance.BorderSize = 0;
            this.btn_voice.Name = "btn_voice";
            this.btn_voice.UseVisualStyleBackColor = false;
            this.btn_voice.Click += new System.EventHandler(this.btn_voice_Click);
            // 
            // BodyMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyMain";
            this.Load += new System.EventHandler(this.BodyMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPlayer)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlashPlayer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_voice;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_music;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label 分隔线;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel leftPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_async;
    }
}