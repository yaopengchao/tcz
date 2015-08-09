﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Media;


namespace LoginFrame
{

    public partial class TitleMain : Form
    {

        public MainFrame mainFrame;

        public bool isBroadcasting=false;//是否广播中

        public bool isAudioPlaying = false;//是否扩音中

        public bool isTalking = false;//是否对话中

        /// <summary>
        /// UDP客户端
        /// </summary>
        UdpClient client;
        IPEndPoint multicast;



        public TitleMain()
        {
            InitializeComponent();
        }

        private static TitleMain instance;

        public static TitleMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleMain();
            }
            return instance;
        }

        /// <summary>
        /// 窗体控件加载完毕后  处理一些事务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleMain_Load(object sender, EventArgs e)
        {

            
        }

        

        

        /// <summary>
        /// 解除禁止操作方法
        /// </summary>
        private static void abletooperate()
        {
            //取消给以下控件处 一个遮罩
            //多媒体课件分类
            //条目
            //扩音
            //同步教学
            //对话
            //模拟人设置
            //播放
            //上一个
            //下一个
            //收藏
            //listView双击事件
            //主屏幕 右上角下拉列表
        }

        /// <summary>
        /// 禁止操作方法
        private static void Unabletooperate()
        {
            //给以下控件处 一个遮罩
            //多媒体课件分类
            //条目
            //扩音
            //同步教学
            //对话
            //模拟人设置
            //播放
            //上一个
            //下一个
            //收藏
            //listView双击事件
            //主屏幕 右上角下拉列表
        }

        /// <summary>
        /// 播放按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button6_Click(object sender, EventArgs e)
        {
            //bodyMain.axShockwaveFlashPlayer.IsPlaying() 这个方法无效只能用以下替代方法this.button6.Text.Replace(" ", "").Trim().Equals("暂停")
            //之前无效是因为 控件默认 true了
            
            if (mainFrame.bodyMain.axShockwaveFlashPlayer.IsPlaying())
            {
                if (isBroadcasting)
                {
                    Broadcast("StopFlash^NoFileName^##");
                }
                mainFrame.bodyMain.axShockwaveFlashPlayer.Stop();
                this.button6.Text = "播放";
            }
            else
            {
                //判断是否已经单机选择或者双击选择了swf课件
                if (mainFrame.bodyMain.listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请先选择课件再点击播放!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string swfName = mainFrame.bodyMain.listView1.SelectedItems[0].Text;
                if (isBroadcasting)
                {
                    Broadcast("PlayFlash^" + swfName + "^##");
                }

                string filpath = Application.StartupPath + @"/../../lessons/" + swfName+ ".swf";
                //Console.WriteLine("地址:"+ filpath);
                this.mainFrame.playFlash(filpath);
                this.button6.Text = "暂停";
            }
        }


        /// <summary>
        /// 上一个按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //列表没有被选择过则无法上一个 下一个
            if (mainFrame.bodyMain.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index= mainFrame.bodyMain.listView1.SelectedItems[0].Index;
            //选择上一个item位置   listview越往上越小  
            int preIndex = index - 1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (preIndex<0)
            {
                MessageBox.Show("已经到达列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            mainFrame.bodyMain.listView1.Items[preIndex].Selected = true;
            //模拟双击事件执行播放
            mainFrame.bodyMain.BodyMain_listView_MouseDoubleClick(null,null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + mainFrame.bodyMain.listView1.SelectedItems[0].Text + "^##");
            }

        }

        /// <summary>
        /// 同步教学按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //该按钮只是告诉 非 学生机 处于何种状态   
            //  一种是同步状态   另外一种是非同步状态
            //同步状态下  几个按钮触发点击事件的时候发送指令到学生机
            if (isBroadcasting)
            {
                isBroadcasting = false;
                this.button4.Text = "同步教学";

                client = null;
                multicast = null;
            }
            else
            {

                client = new UdpClient(5566);
                client.JoinMulticastGroup(IPAddress.Parse("234.5.6.7"));
                multicast = new IPEndPoint(IPAddress.Parse("234.5.6.7"), 7788);


                isBroadcasting = true;
                this.button4.Text = "同步教学中";
            }
            
        }

        /// <summary>
        /// 发送同步指令公共方法
        /// </summary>
        /// <param name="code">指令</param>
        public void Broadcast(string code)
        {
            
            byte[] buf = Encoding.Default.GetBytes(code);
            //MessageBox.Show("同步指令发送......"+ "PlayFlash^" + swfName + "^##");
            client.Send(buf, buf.Length, multicast);
        }

        /// <summary>
        /// 扩音 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (mainFrame.bodyMain.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择课件播放后再扩音操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //播放与 Falsh配对的音频文件名 不包括拓展名
            string audioFilename = mainFrame.bodyMain.listView1.SelectedItems[0].Text;
            //获取列表选中项，组装音频文件路径传给播放器

            if (this.isAudioPlaying)
            {

                if (isBroadcasting)
                {
                    Broadcast("StopAudio^NoFileName^##");
                }

                this.isAudioPlaying = false;
                this.mainFrame.stopPlayer();
                this.button3.Text = "扩音";

                if (!this.mainFrame.bodyMain.axShockwaveFlashPlayer.IsPlaying())
                {
                    this.mainFrame.titleMain.button6_Click(null, null);
                }

            }
            else
            {
                if (isBroadcasting)
                {
                    Broadcast("PlayAudio^"+ audioFilename + "^##");
                }

                this.isAudioPlaying = true;
                this.mainFrame.audioPlayer(audioFilename);
                this.button3.Text = "扩音中";

                //暂停播放Flash
                if (this.mainFrame.bodyMain.axShockwaveFlashPlayer.IsPlaying())
                {
                    this.mainFrame.titleMain.button6_Click(null, null);
                }
            }



            
        }

        /// <summary>
        /// 下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button10_Click(object sender, EventArgs e)
        {
            //列表没有被选择过则无法上一个 下一个
            if (mainFrame.bodyMain.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index = mainFrame.bodyMain.listView1.SelectedItems[0].Index;
            //选择上一个item位置   listview越往上越小  
            int sufIndex = index+1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (sufIndex > mainFrame.bodyMain.listView1.Items.Count-1)
            {
                MessageBox.Show("已经到达列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            mainFrame.bodyMain.listView1.Items[sufIndex].Selected = true;
            //模拟双击事件执行播放
            mainFrame.bodyMain.BodyMain_listView_MouseDoubleClick(null, null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + mainFrame.bodyMain.listView1.SelectedItems[0].Text + "^##");
            }
        }

        //对话按钮
        private void button9_Click(object sender, EventArgs e)
        {
            if (isTalking)
            {
                //切换到 非对话状态
                isTalking = false;

                this.mainFrame.panel6.Controls.Clear();
                BodyMain bodyMain = BodyMain.createForm();
                bodyMain.TopLevel = false;
                bodyMain.FormBorderStyle = FormBorderStyle.None;
                bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.mainFrame.panel6.Controls.Add(bodyMain);
                bodyMain.Show();

                //互相访问控件
                this.mainFrame.bodyMain = bodyMain;

                this.button9.Text = "对话";

            }
            else
            {
                //切换到  对话状态

                isTalking = true;

                this.mainFrame.panel6.Controls.Clear();
                TalkMain talkMain = TalkMain.createForm();
                talkMain.TopLevel = false;
                talkMain.FormBorderStyle = FormBorderStyle.None;
                talkMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.mainFrame.panel6.Controls.Add(talkMain);
                talkMain.Show();

                //互相访问控件

                this.mainFrame.talkMain = talkMain;

                this.button9.Text = "对话中";

            }
        }
    }
}
