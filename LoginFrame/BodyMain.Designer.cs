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
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axShockwaveFlashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_favorite = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_music = new System.Windows.Forms.Button();
            this.btn_pre = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_voice = new System.Windows.Forms.Button();
            this.分隔线 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPlayer)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.listView1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.BodyMain_listView_MouseDoubleClick);
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
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.分隔线);
            this.panel3.Controls.Add(this.btn_play);
            this.panel3.Controls.Add(this.btn_stop);
            this.panel3.Controls.Add(this.btn_favorite);
            this.panel3.Controls.Add(this.btn_music);
            this.panel3.Controls.Add(this.btn_pre);
            this.panel3.Controls.Add(this.btn_next);
            this.panel3.Controls.Add(this.btn_voice);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btn_favorite
            // 
            this.btn_favorite.BackgroundImage = global::LoginFrame.Properties.Resources.收藏夹;
            resources.ApplyResources(this.btn_favorite, "btn_favorite");
            this.btn_favorite.Name = "btn_favorite";
            this.btn_favorite.UseVisualStyleBackColor = true;
            // 
            // btn_play
            // 
            this.btn_play.BackgroundImage = global::LoginFrame.Properties.Resources.播放;
            resources.ApplyResources(this.btn_play, "btn_play");
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_play.Name = "btn_play";
            this.btn_play.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.BackgroundImage = global::LoginFrame.Properties.Resources.暂停;
            resources.ApplyResources(this.btn_stop, "btn_stop");
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // btn_music
            // 
            this.btn_music.BackgroundImage = global::LoginFrame.Properties.Resources.扩音;
            resources.ApplyResources(this.btn_music, "btn_music");
            this.btn_music.Name = "btn_music";
            this.btn_music.UseVisualStyleBackColor = true;
            // 
            // btn_pre
            // 
            this.btn_pre.BackgroundImage = global::LoginFrame.Properties.Resources.上一个;
            resources.ApplyResources(this.btn_pre, "btn_pre");
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.BackgroundImage = global::LoginFrame.Properties.Resources.下一个;
            resources.ApplyResources(this.btn_next, "btn_next");
            this.btn_next.Name = "btn_next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // btn_voice
            // 
            this.btn_voice.BackColor = System.Drawing.Color.Transparent;
            this.btn_voice.BackgroundImage = global::LoginFrame.Properties.Resources.语音;
            resources.ApplyResources(this.btn_voice, "btn_voice");
            this.btn_voice.Name = "btn_voice";
            this.btn_voice.UseVisualStyleBackColor = false;
            // 
            // 分隔线
            // 
            this.分隔线.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.分隔线, "分隔线");
            this.分隔线.Name = "分隔线";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlashPlayer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_voice;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_favorite;
        private System.Windows.Forms.Button btn_music;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label 分隔线;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}