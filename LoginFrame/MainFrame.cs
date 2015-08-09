using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Media;


namespace LoginFrame
{
    public partial class MainFrame : Form
    {

        public BodyMain bodyMain;
        public TitleMain titleMain;
        public TalkMain talkMain;

        public SoundPlayer splayer;


        public MainFrame()
        {
            InitializeComponent();
        }

        private static MainFrame instance;


        /// <summary>
        /// 窗体控件加载完毕后  处理一些事务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_Load(object sender, EventArgs e)
        {

            if (LoginRoler.roleid == Constant.RoleStudent)
            {
                //MessageBox.Show("开启自动监听....");

                Thread t = new Thread(new ThreadStart(RecvThread));
                t.IsBackground = true;
                t.Start();

            }
        }

        /// <summary>
        /// 接收方法线程
        /// </summary>
        void RecvThread()
        {
            UdpClient client = new UdpClient(7788);
            client.JoinMulticastGroup(IPAddress.Parse("234.5.6.7"));
            IPEndPoint multicast = new IPEndPoint(IPAddress.Parse("234.5.6.7"), 5566);
            while (true)
            {
                //Console.WriteLine("学生端监听中......");
                byte[] buf = client.Receive(ref multicast);
                string msg = Encoding.Default.GetString(buf);
                //MessageBox.Show("接收到..." + msg + "...的指令");
                string[] splitString = msg.Split('^');
                string swfName = splitString[1];
                switch (splitString[0])
                {
                    case "PlayFlash"://播放Flash指令
                        if (isTitleFrmAndMainFrm())
                        {
                            //MessageBox.Show("接收到播放Flash:" + swfName + "的指令");
                            //初始化播放器并且进行播放
                            string filpath = Application.StartupPath + @"/../../lessons/" + swfName + ".swf";
                            FlashPlayerInit();
                            playFlash(filpath);
                        }
                        break;
                    case "StopFlash"://停止播放Flash指令
                        if (isTitleFrmAndMainFrm())
                        {
                            stopFlash();
                        }
                        break;
                    case "PlayAudio"://开始扩音
                        audioPlayer(swfName);
                        break;
                    case "StopAudio"://停止扩音
                        stopPlayer();
                        break;
                    default: break;
                }

                //MessageBox.Show(msg);
            }
        }
        /// <summary>
        /// delegate委托代理，为了在线程中访问 控件
        /// </summary>
        /// <param name="text"></param>
        public delegate void button6_changeText(string text);
        public void button6changeText(string text)
        {
            this.titleMain.button6.Text = text;
        }


        public delegate void button3_changeText(string text);
        public void button3changeText(string text)
        {
            this.titleMain.button3.Text = text;
        }



        /// <summary>
        /// 停止或者叫暂停播放Flash
        /// </summary>
        private void stopFlash()
        {
            this.bodyMain.axShockwaveFlashPlayer.Stop();

            button6_changeText button6outdelegate = new button6_changeText(button6changeText);
            this.BeginInvoke(button6outdelegate, new object[] { "播放" });
        }

        /// <summary>
        /// 播放指定路径Flash
        /// </summary>
        /// <param name="filpath"></param>
        public void playFlash(string filpath)
        {
            this.bodyMain.axShockwaveFlashPlayer.Loop = false;//不循环播放
            this.bodyMain.axShockwaveFlashPlayer.Movie = filpath;
            this.bodyMain.axShockwaveFlashPlayer.Play();
            //Console.WriteLine("地址:" + filpath);
            button6_changeText button6outdelegate = new button6_changeText(button6changeText);
            this.BeginInvoke(button6outdelegate, new object[] { "暂停" });
        }

        /// <summary>
        /// 初始化播放器
        /// </summary>
        private void FlashPlayerInit()
        {
            this.bodyMain.axShockwaveFlashPlayer.Loop = false;//不循环播放
            this.bodyMain.axShockwaveFlashPlayer.Stop();
        }

        /// <summary>
        /// 判断是否处于 多媒体界面 即   MainFrame中panel6 的界面为BobyMain
        /// </summary>
        /// <returns></returns>
        public bool isTitleFrmAndMainFrm()
        {
            bool flag = false;

            if (!this.panel6.Controls.Contains(this.bodyMain))
            {
                flag = true;

                //MessageBox.Show("跳转到多媒体界面......");

                MethodInvoker In = new MethodInvoker(frm2BodyMain);
                this.BeginInvoke(In);

            }
            else
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 跳转到多媒体界面
        /// </summary>
        private void frm2BodyMain()
        {

            panel1.Controls.Clear();
            TitleMain titleMain = TitleMain.createForm();
            titleMain.TopLevel = false;
            titleMain.FormBorderStyle = FormBorderStyle.None;
            titleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(titleMain);
            titleMain.Show();

            panel6.Controls.Clear();
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyMain);
            bodyMain.Show();

            //互相访问控件
            this.bodyMain = bodyMain;
            this.titleMain = titleMain;

            bodyMain.mainFrame = this;
            titleMain.mainFrame = this;


        }

        public static MainFrame createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MainFrame();
            }
            return instance;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("用户名不能为空!");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            panel5.Hide();

            panel1.Controls.Clear();
            TitleStu stu = TitleStu.createForm();
            stu.TopLevel = false;
            stu.FormBorderStyle = FormBorderStyle.None;
            stu.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(stu);
            stu.Show();

            panel6.Controls.Clear();
            BodyStu bodyStu = BodyStu.createForm();
            bodyStu.TopLevel = false;
            bodyStu.FormBorderStyle = FormBorderStyle.None;
            bodyStu.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyStu);
            bodyStu.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            panel5.Hide();

            panel1.Controls.Clear();
            TitleTea tea = TitleTea.createForm();
            tea.TopLevel = false;
            tea.FormBorderStyle = FormBorderStyle.None;
            tea.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(tea);
            tea.Show();

            panel6.Controls.Clear();
            BodyTea bodyTea = BodyTea.createForm();
            bodyTea.TopLevel = false;
            bodyTea.FormBorderStyle = FormBorderStyle.None;
            bodyTea.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyTea);
            bodyTea.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            TitleMain titleMain = TitleMain.createForm();
            titleMain.TopLevel = false;
            titleMain.FormBorderStyle = FormBorderStyle.None;
            titleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Add(titleMain);
            titleMain.Show();

            panel6.Controls.Clear();
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Controls.Add(bodyMain);
            bodyMain.Show();


            //互相访问控件
            this.bodyMain = bodyMain;
            this.titleMain = titleMain;

            bodyMain.mainFrame = this;
            titleMain.mainFrame = this;

        }

        /// <summary>
        /// 音频播放
        /// </summary>
        /// <param name="filepath">播放 音频文件路径</param>
        public void audioPlayer(string filename)
        {
            this.splayer = new SoundPlayer(LoginFrame.Properties.Resources.YouAreMySunshine);
            this.splayer.Play();

            button3_changeText button3outdelegate = new button3_changeText(button3changeText);
            this.BeginInvoke(button3outdelegate, new object[] { "扩音中" });

        }

        public void stopPlayer()
        {
            this.splayer.Stop();

            button3_changeText button3outdelegate = new button3_changeText(button3changeText);
            this.BeginInvoke(button3outdelegate, new object[] { "扩音" });
        }




        private void label6_Click(object sender, EventArgs e)
        {
            panel5.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
    }
}
