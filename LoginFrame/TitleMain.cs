using System;
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
using System.Threading;

namespace LoginFrame
{

    public partial class TitleMain : Form
    {

        public BodyMain bodyMain;
        
        public bool isBroadcasting=false;//是否广播中

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


        private void TitleMain_Load(object sender, EventArgs e)
        {

            if (LoginRoler.roleid == Constant.RoleStudent)
            {
                MessageBox.Show("开启自动监听....");

                Thread t = new Thread(new ThreadStart(RecvThread));
                t.IsBackground = true;
                t.Start();

            }
        }

        void RecvThread()
        {
            UdpClient client = new UdpClient(7788);
            client.JoinMulticastGroup(IPAddress.Parse("234.5.6.7"));
            IPEndPoint multicast = new IPEndPoint(IPAddress.Parse("234.5.6.7"), 5566);
            while (true)
            {
                Console.WriteLine("学生端监听中......");
                byte[] buf = client.Receive(ref multicast);
                string msg = Encoding.Default.GetString(buf);
                MessageBox.Show("接收到..." + msg + "...的指令");
                string[] splitString = msg.Split('^');
                switch (splitString[0])
                {
                    case "PlayFlash"://播放Flash指令
                        
                        string swfName = splitString[1];
                        MessageBox.Show("接收到播放Flash:" + swfName + "的指令");
                        //初始化播放器并且进行播放
                        string filpath = Application.StartupPath + @"/../../swf/" + swfName;
                        FlashPlayerInit();
                        playFlash(filpath);
                        break;

                    default: break;
                }

                //MessageBox.Show(msg);
            }
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

        //播放按钮
        public void button6_Click(object sender, EventArgs e)
        {
            //判断是否已经单机选择或者双击选择了swf课件
            if (bodyMain.listView1.SelectedItems.Count==0)
            {
                MessageBox.Show("请先选择课件再点击播放!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //bodyMain.axShockwaveFlashPlayer.IsPlaying() 这个方法无效只能用以下替代方法this.button6.Text.Replace(" ", "").Trim().Equals("暂停")
            //之前无效是因为 控件默认 true了
            if (bodyMain.axShockwaveFlashPlayer.IsPlaying())
            {
                bodyMain.axShockwaveFlashPlayer.Stop();
                this.button6.Text = "播放";
            }
            else
            {
                string filpath = Application.StartupPath + @"/../../swf/" + bodyMain.listView1.SelectedItems[0].Text;
                playFlash(filpath);
                this.button6.Text = "暂停";
            }
                       
        }

        /// <summary>
        /// 播放指定路径Flash
        /// </summary>
        /// <param name="filpath"></param>
        private void playFlash(string filpath)
        {
            bodyMain.axShockwaveFlashPlayer.Loop = false;//不循环播放
            bodyMain.axShockwaveFlashPlayer.Movie = filpath;
            bodyMain.axShockwaveFlashPlayer.Play();
        }

        /// <summary>
        /// 初始化播放器
        /// </summary>
        private void FlashPlayerInit()
        {
            bodyMain.axShockwaveFlashPlayer.Loop = false;//不循环播放
            bodyMain.axShockwaveFlashPlayer.Stop();
        }

        //上一个按钮
        private void button7_Click(object sender, EventArgs e)
        {
            //列表没有被选择过则无法上一个 下一个
            if (bodyMain.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index=bodyMain.listView1.SelectedItems[0].Index;
            //选择上一个item位置   listview越往上越小  
            int preIndex = index - 1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (preIndex<0)
            {
                MessageBox.Show("已经到达列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            bodyMain.listView1.Items[preIndex].Selected = true;
            //模拟双击事件执行播放
            bodyMain.BodyMain_listView_MouseDoubleClick(null,null);
        }

        //同步教学按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (!isBroadcasting)
            {
                //只有在播放的时候才可以点击同步教学按钮
                if (bodyMain.axShockwaveFlashPlayer.IsPlaying())
                {
                    //与此同时 限制学生端 按钮等控件无法使用
                    Unabletooperate();

                    isBroadcasting = true;
                    //是否处于同步状态   且  为教师登录(不为学生)   是则发送指令
                    if (isBroadcasting && LoginRoler.roleid != Constant.RoleStudent)
                    {
                        Broadcast();
                    }
                    this.button4.Text = "同步教学中";
                    
                }
                else
                {
                    MessageBox.Show("请先播放Flash才能同步教学哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                isBroadcasting = false;
                if (bodyMain.axShockwaveFlashPlayer.IsPlaying())
                {
                    bodyMain.axShockwaveFlashPlayer.Stop();
                    this.button6.Text = "播放";
                }
                this.button4.Text = "同步教学";
                

            }
            
        }

        //发送同步指令公共方法
        public void Broadcast()
        {
            UdpClient client = new UdpClient(5566);
            client.JoinMulticastGroup(IPAddress.Parse("234.5.6.7"));
            IPEndPoint multicast = new IPEndPoint(IPAddress.Parse("234.5.6.7"), 7788);
            string swfName =bodyMain.listView1.SelectedItems[0].Text;
            byte[] buf = Encoding.Default.GetBytes("PlayFlash^" + swfName + "^##");
            MessageBox.Show("同步指令发送......"+ "PlayFlash^" + swfName + "^##");
            client.Send(buf, buf.Length, multicast);
        }
    }
}
