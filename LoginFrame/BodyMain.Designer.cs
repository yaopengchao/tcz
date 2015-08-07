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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 600);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.DarkGray;
            this.listView1.Location = new System.Drawing.Point(2, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(197, 596);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.BodyMain_listView_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.axShockwaveFlashPlayer);
            this.panel1.Location = new System.Drawing.Point(208, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 600);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // axShockwaveFlashPlayer
            // 
            this.axShockwaveFlashPlayer.Enabled = true;
            this.axShockwaveFlashPlayer.Location = new System.Drawing.Point(2, 2);
            this.axShockwaveFlashPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.axShockwaveFlashPlayer.Name = "axShockwaveFlashPlayer";
            this.axShockwaveFlashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlashPlayer.OcxState")));
            this.axShockwaveFlashPlayer.Size = new System.Drawing.Size(796, 596);
            this.axShockwaveFlashPlayer.TabIndex = 0;
            // 
            // BodyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1010, 604);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BodyMain";
            this.Text = "BodyMain";
            this.Load += new System.EventHandler(this.BodyMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        public AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlashPlayer;
        public System.Windows.Forms.ListView listView1;
    }
}