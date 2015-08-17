using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using Oraycn.MCapture;
using Oraycn.MPlayer;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using BLL;
using Model;

namespace LoginFrame
{

    public partial class TalkMain : Form
    {
        public MainFrame mainFrame;

        public bool isSpeaking = false;

        ImplUser implUser = new ImplUser();

        public TalkMain()
        {
            InitializeComponent();
            Oraycn.MCapture.GlobalUtil.SetAuthorizedUser("FreeUser", "");
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Thread threadWatch = null;
        //负责监听的套接字
        Socket socketServer = null;

        Thread threadReceive = null;

        //客户端套接字
        Socket socketClient = null;

        public void BodyMain_Load(object sender, EventArgs e)
        {
            //加载列表
            this.listView1.Items.Clear();
            //threadListUsers = new Thread(new ThreadStart(ListUsersOnline));
            //threadListUsers.IsBackground = true;
            //threadListUsers.Start();

            //如果是老师则创建聊天服务
            if (LoginRoler.roleid==Constant.RoleTeacher)
            {

                //创建 服务器 负责监听的套接字 参数(使用IP4寻址协议，使用流式连接，使用TCP传输协议)
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //获取IP地址
                IPAddress ip = IPAddress.Parse(LoginRoler.ip);

                //创建 包含IP和Port的网络节点对象
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse("10021"));

                //将负责监听 的套接字 绑定到 唯一的IP和端口上
                socketServer.Bind(endPoint);

                //设置监听队列 一次可以处理的最大数量
                socketServer.Listen(10);

                //创建线程 负责监听
                threadWatch = new Thread(WatchConnection);
                //设置为后台线程
                threadWatch.IsBackground = true;
                //开启线程
                threadWatch.Start();

                Console.WriteLine("=====================服 务 器 启 动 成 功======================");
            }
            else if (LoginRoler.roleid == Constant.RoleStudent)
            {
                //获取老师服务IP
                string serverIp = implUser.getServerIp();

                //学生则创建连接客户端的操作
                //获取IP
                IPAddress ip = IPAddress.Parse(serverIp);
                //新建一个网络节点
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse("10021"));
                //新建一个Socket 负责 监听服务器的通信
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //连接远程主机
                socketClient.Connect(endPoint);

                //打印输出
                Console.WriteLine("=====================服 务 器 连 接 成 功======================");

                //创建线程 监听服务器 发来的消息
                threadReceive = new Thread(ClientRecMsg);
                //设置为后台线程
                threadReceive.IsBackground = true;
                //开启线程
                threadReceive.Start();
            }
            this.audioPlayer = PlayerFactory.CreateAudioPlayer(int.Parse("0"), 16000, 1, 16, 2);


        }

        Dictionary<string, Socket> socketDic = new Dictionary<string, Socket>();
            //用来接收数据的线程
           
            //监听方法
            void WatchConnection()
        {
                //持续不断的监听
                while (true)
                {

                    //开始监听 客户端 连接请求 【注意】Accept方法会阻断当前的线程--未接受到请求 程序卡在那里
                    Socket sokConnection = socketServer.Accept();//返回一个 负责和该客户端通信的 套接字
                                                                 //将返回的新的套接字 存储到 字典序列中
                    socketDic.Add(sokConnection.RemoteEndPoint.ToString(), sokConnection);
                //向在线列表中 添加一个 客户端的ip端口字符串 作为客户端的唯一标识
                listView1.Items.Add(sokConnection.RemoteEndPoint.ToString());
                //打印输出
Console.WriteLine("客户端连接成功:" + sokConnection.RemoteEndPoint.ToString());

                    //为该通信Socket 创建一个线程 用来监听接收数据
                    //threadRec = new Thread(ServerRecMsg);
                    //threadRec.IsBackground = true;
                    //threadRec.Start(sokConnection);

                }
        }

        void ClientRecMsg()
        {
            while (true)
            {

                //初始化一个 缓存区(字节数组)
                byte[] data = new byte[512];
                //将接受到的数据 存放到data数组中 返回接受到的数据的实际长度

                int receiveBytes = socketClient.Receive(data);

                if (this.audioPlayer != null)
                {
                    //Console.WriteLine(data.Length);
                    this.audioPlayer.Play(data);
                }

                //Console.WriteLine("学生接收数据：" + receiveBytes);
                //Console.WriteLine(this.audioPlayer == null);

                //if (this.audioPlayer != null)
                //{
                //Console.WriteLine(data);

                //this.audioPlayer.Play(data);
                //}


                //将字符串转换成字节数组
                //string strMsg = Encoding.UTF8.GetString(data, 0, receiveBytes);
                //打印输出

            }
        }

        void ServerRecMsg(object socket)
        {
            //持续监听接收数据
            while (true)
            {

                while (true)
                {
                    //初始化一个 缓存区(字节数组)
                    byte[] data = new byte[512];
                    //将接受到的数据 存放到data数组中 返回接受到的数据的实际长度

                    int receiveBytes = socketServer.Receive(data);

                    if (this.audioPlayer != null)
                    {
                        this.audioPlayer.Play(data);
                    }
                }
                   
            }
        }

        
        private void ListUsersOnline()
        {
            //ArrayList alUsers = ListUsers.GetComputerList();

            ListUsers listUsers = new ListUsers();
            ArrayList alUsers = listUsers.GetComputerListFromChatRoom();

            if (alUsers.Count > 0)
            {
                for (int i = 0; i < alUsers.Count; i++)
                {
                    string[] strTreeNodeText=(string[])alUsers[i];
                    ListViewItem item = new ListViewItem(new string[] {strTreeNodeText[2] });
                    this.listView1.Items.Insert(i, item);
                }
            }
            PicVisible(false);
        }

        private delegate void PicVisibleHandle(bool b);

        private void PicVisible(bool bVisible)
        {
            PicVisibleHandle handle = new PicVisibleHandle(PicVisible);
            if (InvokeRequired)
            {
                this.Invoke(handle, new object[] { bVisible });
            }
            else
            {
                //picLoading.Visible = bVisible;
            }
        }

        //listview双击事件
        public void BodyMain_listView_MouseDoubleClick(object sender, EventArgs e)
        {

        }

        private static TalkMain instance;

        public static TalkMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TalkMain();
            }
            return instance;
        }

        private ICapturer capturer;
        private IAudioPlayer audioPlayer;

        private void button1_Click(object sender, EventArgs e)
        {
            if (isSpeaking)
            {
                isSpeaking = false;
                this.button1.Text = "开启语音";
                this.capturer.Stop();
            }
            else
            {
                isSpeaking = true;
                this.button1.Text = "关闭语音";

                //获取本机麦克风数据
                this.capturer = CapturerFactory.CreateMicrophoneCapturer(0);
                ((IMicrophoneCapturer)this.capturer).AudioCaptured += new ESBasic.CbGeneric<byte[]>(AudioCaptured);

                //开始采集
                this.capturer.Start();
            }
        }
        


     
        
        void AudioCaptured(byte[] audioData) //采集到的声音数据
        {
            if (LoginRoler.roleid==Constant.RoleTeacher)
            {
                //发送数据

                //循环出checkBox选择的数据项


                //socketDic[listView1.SelectedItems[0].Text].Send(audioData, SocketFlags.None);

                //获取发送信息
                //string Message = "服务器发送消息啦";
                //将字符串转换成字节数组
                //byte[] data = System.Text.Encoding.UTF8.GetBytes(Message);
                //找到对应的客户端 并发送数据

                Console.WriteLine("发送中...数据大小为" + audioData.Length);

                socketDic[listView1.SelectedItems[0].Text].Send(audioData, SocketFlags.None);
                //打印输出
                
            }
            else if (LoginRoler.roleid == Constant.RoleStudent)
            {
                Console.WriteLine("学生发送中..空数据未发送.");
            }

           
            //if (this.audioPlayer != null)
            //{
            //this.audioPlayer.Play(audioData);
            //找到对应的客户端 并发送数据
            //    Console.WriteLine(listView1.SelectedItems[0].Text);
            //    socketDic[listView1.SelectedItems[0].Text].Send(audioData, SocketFlags.None);
            //    Console.WriteLine("发送中");
            // }




            //循环发送语音数据  发送数据到学生


            //播放音频到耳机或者扬声器
            //if (this.audioPlayer != null)
            //{
            //    this.audioPlayer.Play(audioData);
            //}

            //以下是声音大小
            //this.autioDataTotalLen += audioData.Length;
            //++this.captureAudioCount;
            //if (this.captureAudioCount >= 20)
            //{
            //    this.captureAudioCount = 0;
            //    this.ShowAudioDataTotalLen(this.autioDataTotalLen);
            //}
        }

        private void ShowAudioDataTotalLen(int totalLen)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<int>(this.ShowAudioDataTotalLen), totalLen);
            }
            else
            {
                Console.WriteLine("接收语音数据大小KB:"+ totalLen.ToString());
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!listView1.Items[e.Index].Checked)//如果点击的CheckBoxes没有选中  
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    if (lv.Checked)//取消所有已选中的CheckBoxes  
                    {
                        lv.Checked = false;
                        lv.Selected = false;
                        // lv.BackColor = Color.White;  
                    }
                }
                listView1.Items[e.Index].Selected = true;
                // lv.Checked = false;  
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
            {

                if (lv.Selected)
                {
                    //if (lv.Checked)  
                    //{  
                    //    //lv.Checked = false;  
                    //}  
                    //else  
                    //{  
                    lv.Checked = true;
                    //}  
                }
                else
                {
                    if (listView1.SelectedIndices.Count > 0)
                    {
                        if (lv.Checked)
                        {
                            lv.Checked = false;
                        }
                    }

                }
            }
        }
    }
}
