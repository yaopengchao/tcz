using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

using Oraycn.MCapture;
using Oraycn.MPlayer;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LoginFrame
{

    public partial class TalkMain : Form
    {
        public MainFrame mainFrame;

        public bool isSpeaking = false;

        public TalkMain()
        {
            InitializeComponent();
            Oraycn.MCapture.GlobalUtil.SetAuthorizedUser("FreeUser", "");
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private Thread threadListUsers;
        private Thread threadChatroom;
        public void BodyMain_Load(object sender, EventArgs e)
        {
            //添加表头，设置该项需要将listView属性View设置为Details否则不会显示
            //this.listView1.Columns.Add("局域网机器列表", 190, HorizontalAlignment.Center);
            //加载列表

            threadListUsers = new Thread(new ThreadStart(ListUsersOnline));
            threadListUsers.IsBackground = true;
            threadListUsers.Start();

            //如果是老师则创建聊天服务器
            if (LoginRoler.roleid==Constant.RoleTeacher)
            {
                threadChatroom = new Thread(new ThreadStart(createChatroom));
                threadChatroom.IsBackground = true;
                threadChatroom.Start();
            }
            

        }

        private void createChatroom()
        {
            //开启聊天室服务器监听
            //首先建立一个套接字(服务器端)
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //将套接字绑定到本地的IP和端口
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9999);
            //绑定套接字
            socketServer.Bind(endPoint);
            //输出语句 服务已经启动
            Console.WriteLine("=====TCP Server Is OK======\r\n ===IP:" + endPoint.Address + "  Port:" + endPoint.Port + "===");
            //开始监听
            socketServer.Listen(10);
            //接受消息并返回的新的套接字对象
            Socket sk = socketServer.Accept();


            //接受数据
            //新建一个字节数组
            byte[] recveMsg = new byte[1024 * 1024];

                //使用receive方法接受发送到服务器端的数据
                int bytes = sk.Receive(recveMsg, SocketFlags.None);
                //将数据进行编码
                string receive = System.Text.Encoding.UTF8.GetString(recveMsg, 0, bytes);
                //将信息打印到控制台
                Console.WriteLine("服务器接收到的消息" + receive);

                // 发送数据

                //实例化发送的信息
                string message = receive;
                //将字符串转换成字节数组
                byte[] sendMsg = System.Text.Encoding.UTF8.GetBytes(message);
                //发送数据
                int sendBytes = sk.Send(sendMsg, SocketFlags.None);

            //关闭套接字
            //socketServer.Close();
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
                picLoading.Visible = bVisible;
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

        Socket socketClient;
        IPEndPoint endPoint;
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

                //新建一个套接字(老师客户端)
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //设置与远程主机连接的网络节点
                endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                //与远程主机建立连接
                socketClient.Connect(endPoint);

                //获取 IP数据
                //获取本机麦克风数据
                this.capturer = CapturerFactory.CreateMicrophoneCapturer(0);
                ((IMicrophoneCapturer)this.capturer).AudioCaptured += new ESBasic.CbGeneric<byte[]>(AudioCaptured);
                this.audioPlayer = PlayerFactory.CreateAudioPlayer(int.Parse("0"), 16000, 1, 16, 2);
                //开始采集
                this.capturer.Start();
            }
        }
        


        private int autioDataTotalLen = 0;
        private int captureAudioCount = 0;
        
        void AudioCaptured(byte[] audioData) //采集到的声音数据
        {

            //发送数据
        
            int bytes = socketClient.Send(audioData, SocketFlags.None);



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
    }
}
