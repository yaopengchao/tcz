using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Media;
using System.Globalization;
using Model;
using Microsoft.DirectX.DirectSound;
using System.IO;
using g711audio;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace LoginFrame
{
    public partial class MainFrame : Form
    {

        public BodyMain bodyMain;
        public TitleMain titleMain;
        public TalkMain talkMain;

        public VoiceChatRoom voiceChatRoom;

        public SoundPlayer splayer;


        public MainFrame()
        {
            InitializeComponent();

            if (LoginRoler.language==0)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (LoginRoler.language == 1)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            }

            //对当前窗体应用更改后的资源
            ApplyResource();

            this.label6.Text = LoginRoler.username;

            string roleId = LoginRoler.roleid;
            if (roleId.Equals("1"))                 //管理员
            {
                menuStrip1.Items[2].Visible = false;             //考试
                panel5.Height = 180;                          
            } else if (roleId.Equals("2"))          //教师
            {
                menuStrip1.Items[1].Visible = false;            //自我测试
                menuStrip1.Items[2].Visible = false;            //考试
                menuStrip1.Items[5].Visible = false;            //教师管理
                panel5.Height = 140;
            } else if (roleId.Equals("3"))          //学生
            {
                menuStrip1.Items[7].Visible = false;            //云服务
                panel5.Height = 180;
            }

        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(MainFrame));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }

        private static MainFrame instance;

        Thread threadWatchInfo = null;

        Thread threadWatch = null;

        Thread recvthreadWatch = null;

        //负责监听的套接字
        Socket socketServer = null;

        //客户端套接字
        Socket socketClient = null;

        /// <summary>
        /// 窗体控件加载完毕后  处理一些事务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_Load(object sender, EventArgs e)
        {
            //只要不是老师你就要进去后搜索是否有语音邀请对话
            if (LoginRoler.roleid != Constant.RoleTeacher)
            {
                Initialize();
            }

            if (LoginRoler.roleid == Constant.RoleTeacher)
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
                threadWatchInfo = new Thread(WatchConnectionInfo);
                //设置为后台线程
                threadWatchInfo.IsBackground = true;
                //开启线程
                threadWatchInfo.Start();


                //创建线程 负责监听
                threadWatch = new Thread(WatchConnection);
                    //设置为后台线程
                    threadWatch.IsBackground = true;
                    //开启线程
                    //threadWatch.Start();

                    //Console.WriteLine("=====================服 务 器 启 动 成 功该Socekt用来通信聊天室用户的信息更新======================");
            }
            else
            {
                //获取老师服务IP
                string serverIp = LoginRoler.serverIp;

                //学生则创建连接客户端的操作
                //获取IP
                IPAddress ip = IPAddress.Parse(serverIp);
                //新建一个网络节点
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse("10021"));
                //新建一个Socket 负责 监听服务器的通信
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //连接远程主机
                socketClient.Connect(endPoint);


                //主动发送学生的IP和姓名 发一次
                OnlineUser onlineUser = new OnlineUser();
                onlineUser.ChatIp = LoginRoler.ip;
                onlineUser.ChatName = LoginRoler.username;
                sendLoaclInfo(socketClient, onlineUser);


                //该线程用来接收教师机发送过来的最新聊天室名单IP
                recvthreadWatch = new Thread(new ThreadStart(recvWatchConnection));
                recvthreadWatch.IsBackground = true;
                recvthreadWatch.Start();//可能有并发请求，所以消息的接收也需要在子线程中处理  


                //打印输出
                //Console.WriteLine("=====================服 务 器 连 接 成 功Socekt用来通信聊天室用户的信息更新======================");
            }
        }

        /// <summary>
        ///  //主动发送学生的IP和姓名 发一次
        /// </summary>
        /// <param name="serverIp"></param>
        /// <param name="onlineUser"></param>
        private void sendLoaclInfo(Socket socketSend,OnlineUser onlineUser)
        {
            MemoryStream mStream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();  //二进制序列化类  
            bformatter.Serialize(mStream, onlineUser); //将消息类转换为内存流  
            mStream.Flush();
            byte[] buffer = new byte[1024];
            mStream.Position = 0;  //将流的当前位置重新归0，否则Read方法将读取不到任何数据
            while (mStream.Read(buffer, 0, buffer.Length) > 0)
            {
                socketSend.Send(buffer); //从内存中读取二进制流，并发送  
            }
        }

        Dictionary<string, Socket> socketDic = new Dictionary<string, Socket>();
        //用来接收数据的线程

        public Dictionary<string, Socket> SocketDic
        {
            
            get { return socketDic; }
            set { socketDic = value; }
        }

        void recvWatchConnection()
        {
            //持续不断的监听   更新聊天室用户信息
           
                //socketClient
                byte[] buffer = new byte[1024];
                MemoryStream mStream = new MemoryStream();
                mStream.Position = 0;
                while (true)
                {
                    int ReceiveCount = socketClient.Receive(buffer, 1024, 0);
                    if (ReceiveCount == 0)
                    {
                        break;//接收到的字节数为0时break  
                    }
                    else
                    {
                        //Console.WriteLine("成功获取到数据");
                        mStream.Write(buffer, 0, ReceiveCount); //将接收到的数据写入内存流  
                    }

                    mStream.Flush();
                    mStream.Position = 0;
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    if (mStream.Capacity > 0)
                    {
                        List<ChatUser> chatUserslist = (List<ChatUser>)bFormatter.Deserialize(mStream);//将接收到的内存流反序列化为对象  

                        LoginRoler.chatUserlist = chatUserslist;

                        Console.WriteLine("接收到来教师发来最新聊天室用户数量:" + chatUserslist.Count + "的信息内容：");
                    }
                    else
                    {
                        //Console.WriteLine("接收到的数据为空。");
                    }

                }
        }

        //监听学生发来的信息
        void WatchConnectionInfo()
        {
           
                //持续不断的监听   更新聊天室用户信息

                //socketClient
                byte[] buffer = new byte[1024];
                MemoryStream mStream = new MemoryStream();
                mStream.Position = 0;
                while (true)
                {

                    Socket sokConnection = socketServer.Accept();//返回一个 负责和该客户端通信的 套接字
                                                                 //将返回的新的套接字 存储到 字典序列中

                    string ip = sokConnection.RemoteEndPoint.ToString().Split(':')[0];

                    socketDic.Add(ip, sokConnection);


                    int ReceiveCount = sokConnection.Receive(buffer, 1024, 0);
                    if (ReceiveCount == 0)
                    {
                        break;//接收到的字节数为0时break  
                    }
                    else
                    {
                        //Console.WriteLine("成功获取到数据");
                        mStream.Write(buffer, 0, ReceiveCount); //将接收到的数据写入内存流  
                       
                    }


                    mStream.Flush();
                    
                    mStream.Position = 0;
                   
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    if (mStream.Capacity > 0)
                    {

                        

                        OnlineUser onlineUser = (OnlineUser)bFormatter.Deserialize(mStream);//将接收到的内存流反序列化为对象  

                        Dictionary<string, OnlineUser> onlineUserDic = LoginRoler.OnlineUserDic;

                        onlineUserDic.Add(onlineUser.ChatIp.ToString(), onlineUser);

                    }
                    else
                    {
                        //Console.WriteLine("接收到的数据为空。");
                    }

                }
                
            
          
        }

        //监听方法
        void WatchConnection()
        {
            //持续不断的监听
            while (true)
            {

                //此处不仅仅需要学生机IP还需要学生的姓名

                //开始监听 客户端 连接请求 【注意】Accept方法会阻断当前的线程--未接受到请求 程序卡在那里
                Socket sokConnection = socketServer.Accept();//返回一个 负责和该客户端通信的 套接字
                                                                     //将返回的新的套接字 存储到 字典序列中

                string ip = sokConnection.RemoteEndPoint.ToString().Split(':')[0];

                socketDic.Add(ip, sokConnection);

                //将在线用户加入到LoginRoler  onlineUserDic

                //OnlineUser onlineUser = new OnlineUser();

               // Dictionary<string, OnlineUser> onlineUserDic = LoginRoler.OnlineUserDic;

                //onlineUser.ChatIp = ip;
                //onlineUser.ChatName = "测试";

                //onlineUserDic.Add(ip, onlineUser);

                //打印输出
                //Console.WriteLine("客户端连接成功:" + sokConnection.RemoteEndPoint.ToString());

            }
        }

        private CaptureBufferDescription captureBufferDescription;
        private AutoResetEvent autoResetEvent;
        private Notify notify;
        private WaveFormat waveFormat;
        private Capture capture;
        private int bufferSize;
        private CaptureBuffer captureBuffer;
        private UdpClient udpClient;                //Listens and sends data on port 1550, used in synchronous mode.
        private Device device;
        private SecondaryBuffer playbackBuffer;
        private BufferDescription playbackBufferDescription;
        private Socket clientSocket;
        private bool bStop;                         //Flag to end the Start and Receive threads.
        private IPEndPoint otherPartyIP;            //IP of party we want to make a call.
        private EndPoint otherPartyEP;
        private volatile bool bIsCallActive;                 //Tells whether we have an active call.
        private Vocoder vocoder;
        private byte[] byteData = new byte[1024];   //Buffer to store the data received.
        private volatile int nUdpClientFlag;                 //Flag used to close the udpClient socket.
        /*
         * Initializes all the data members.
         */
        private void Initialize()
        {
            try
            {
                device = new Device();
                device.SetCooperativeLevel(this, CooperativeLevel.Normal);

                CaptureDevicesCollection captureDeviceCollection = new CaptureDevicesCollection();

                DeviceInformation deviceInfo = captureDeviceCollection[0];

                capture = new Capture(deviceInfo.DriverGuid);

                short channels = 1; //Stereo.
                short bitsPerSample = 16; //16Bit, alternatively use 8Bits.
                int samplesPerSecond = 22050; //11KHz use 11025 , 22KHz use 22050, 44KHz use 44100 etc.

                //Set up the wave format to be captured.
                waveFormat = new WaveFormat();
                waveFormat.Channels = channels;
                waveFormat.FormatTag = WaveFormatTag.Pcm;
                waveFormat.SamplesPerSecond = samplesPerSecond;
                waveFormat.BitsPerSample = bitsPerSample;
                waveFormat.BlockAlign = (short)(channels * (bitsPerSample / (short)8));
                waveFormat.AverageBytesPerSecond = waveFormat.BlockAlign * samplesPerSecond;

                captureBufferDescription = new CaptureBufferDescription();
                captureBufferDescription.BufferBytes = waveFormat.AverageBytesPerSecond / 5;//approx 200 milliseconds of PCM data.
                captureBufferDescription.Format = waveFormat;

                playbackBufferDescription = new BufferDescription();
                playbackBufferDescription.BufferBytes = waveFormat.AverageBytesPerSecond / 5;
                playbackBufferDescription.Format = waveFormat;
                playbackBuffer = new SecondaryBuffer(playbackBufferDescription, device);

                bufferSize = captureBufferDescription.BufferBytes;

                bIsCallActive = false;
                nUdpClientFlag = 0;

                //Using UDP sockets
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                EndPoint ourEP = new IPEndPoint(IPAddress.Any, 1450);
                //Listen asynchronously on port 1450 for coming messages (Invite, Bye, etc).
                clientSocket.Bind(ourEP);

                //Receive data from any IP.
                EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));

                byteData = new byte[1024];
                //Receive data asynchornously.
                clientSocket.BeginReceiveFrom(byteData,
                                           0, byteData.Length,
                                           SocketFlags.None,
                                           ref remoteEP,
                                           new AsyncCallback(OnReceive),
                                           null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-Initialize ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * Commands are received asynchronously. OnReceive is the handler for them.
         */
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                EndPoint receivedFromEP = new IPEndPoint(IPAddress.Any, 0);

                //Get the IP from where we got a message.
                clientSocket.EndReceiveFrom(ar, ref receivedFromEP);

                //Convert the bytes received into an object of type Data.
                Data msgReceived = new Data(byteData);

                //Act according to the received message.
                switch (msgReceived.cmdCommand)
                {
                    //We have an incoming call.
                    case Command.Invite:
                        {
                            if (bIsCallActive == false)
                            {
                                //We have no active call.

                                //Ask the user to accept the call or not.
                                if (MessageBox.Show(msgReceived.strName + "邀请你进行语音通话.\r\n\r\n接受吗?",
                                    "通话邀请", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    SendMessage(Command.OK, receivedFromEP);
                                    vocoder = msgReceived.vocoder;
                                    otherPartyEP = receivedFromEP;
                                    otherPartyIP = (IPEndPoint)receivedFromEP;
                                    InitializeCall();
                                }
                                else
                                {
                                    //The call is declined. Send a busy response.
                                    SendMessage(Command.Busy, receivedFromEP);
                                }
                            }
                            else
                            {
                                //We already have an existing call. Send a busy response.
                                SendMessage(Command.Busy, receivedFromEP);
                            }
                            break;
                        }

                    //OK is received in response to an Invite.
                    case Command.OK:
                        {
                            //Start a call.
                            InitializeCall();
                            break;
                        }

                    //Remote party is busy.
                    case Command.Busy:
                        {
                            MessageBox.Show("User busy.", "VoiceChat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }

                    case Command.Bye:
                        {
                            //Check if the Bye command has indeed come from the user/IP with which we have
                            //a call established. This is used to prevent other users from sending a Bye, which
                            //would otherwise end the call.
                            if (receivedFromEP.Equals(otherPartyEP) == true)
                            {
                                //End the call.
                                UninitializeCall();
                            }
                            break;
                        }
                }

                byteData = new byte[1024];
                //Get ready to receive more commands.
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref receivedFromEP, new AsyncCallback(OnReceive), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-OnReceive ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNotifyPositions()
        {
            try
            {
                autoResetEvent = new AutoResetEvent(false);
                notify = new Notify(captureBuffer);
                BufferPositionNotify bufferPositionNotify1 = new BufferPositionNotify();
                bufferPositionNotify1.Offset = bufferSize / 2 - 1;
                bufferPositionNotify1.EventNotifyHandle = autoResetEvent.SafeWaitHandle.DangerousGetHandle();
                BufferPositionNotify bufferPositionNotify2 = new BufferPositionNotify();
                bufferPositionNotify2.Offset = bufferSize - 1;
                bufferPositionNotify2.EventNotifyHandle = autoResetEvent.SafeWaitHandle.DangerousGetHandle();

                notify.SetNotificationPositions(new BufferPositionNotify[] { bufferPositionNotify1, bufferPositionNotify2 });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-CreateNotifyPositions ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


        



        void microphoneCapturer_AudioCaptured(byte[] audioData)
        {
            Console.WriteLine("学生机发送语音中..." + audioData.Length);
            
                //循环聊天室里面的用户发送语音数据

                List<ChatUser> chatUserlist = LoginRoler.chatUserlist;

                //chatroomusers
                for (int a = 0; a < chatUserlist.Count; a++)
                {

                    //Console.WriteLine("ip=" + chatroomusers.Items[a].Text.ToString() + "进入聊天");

                    string ip = (((ChatUser)chatUserlist[a]).ChatIp).ToString();

                    if (ip.Equals(LoginRoler.ip)) continue;

                    //Console.WriteLine("发送音频数据到:" + ip);

                    if (vocoder == Vocoder.ALaw)
                    {
                        byte[] dataToWrite = ALawEncoder.ALawEncode(audioData);
                        //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                        udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                    }
                    else if (vocoder == Vocoder.uLaw)
                    {
                        byte[] dataToWrite = MuLawEncoder.MuLawEncode(audioData);
                        //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                        udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                        //udpClient.Send(dataToWrite, dataToWrite.Length, "192.168.0.104", 1550);
                    }
                    else
                    {
                        byte[] dataToWrite = audioData;
                        //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                        udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                    }
                }

            



        }


       


        /*
         * Send synchronously sends data captured from microphone across the network on port 1550.
         */
        private void Send()
        {
            try
            {
                //The following lines get audio from microphone and then send them 
                //across network.

                captureBuffer = new CaptureBuffer(captureBufferDescription, capture);

                CreateNotifyPositions();

                int halfBuffer = bufferSize / 2;

                captureBuffer.Start(true);

                bool readFirstBufferPart = true;
                int offset = 0;

                MemoryStream memStream = new MemoryStream(halfBuffer);
                bStop = false;
                while (!bStop)
                {
                    autoResetEvent.WaitOne();
                    memStream.Seek(0, SeekOrigin.Begin);
                    captureBuffer.Read(offset, memStream, halfBuffer, LockFlag.None);
                    readFirstBufferPart = !readFirstBufferPart;
                    offset = readFirstBufferPart ? 0 : halfBuffer;

                    //TODO: Fix this ugly way of initializing differently.

                    //Choose the vocoder. And then send the data to other party at port 1550.

                    //循环聊天室里面的用户发送语音数据

                    List<ChatUser> chatUserlist=LoginRoler.chatUserlist;

                    //chatroomusers
                    for (int a = 0; a < chatUserlist.Count; a++)
                    {

                        //Console.WriteLine("ip=" + chatroomusers.Items[a].Text.ToString() + "进入聊天");

                        string ip = (((ChatUser)chatUserlist[a]).ChatIp).ToString();

                        if (ip.Equals(LoginRoler.ip)) continue;

                        //Console.WriteLine("发送音频数据到:" + ip);

                        if (vocoder == Vocoder.ALaw)
                        {
                            byte[] dataToWrite = ALawEncoder.ALawEncode(memStream.GetBuffer());
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                        }
                        else if (vocoder == Vocoder.uLaw)
                        {
                            byte[] dataToWrite = MuLawEncoder.MuLawEncode(memStream.GetBuffer());
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                            //udpClient.Send(dataToWrite, dataToWrite.Length, "192.168.0.104", 1550);
                        }
                        else
                        {
                            byte[] dataToWrite = memStream.GetBuffer();
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, ip, 1550);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-Send ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                captureBuffer.Stop();

                //Increment flag by one.
                nUdpClientFlag += 1;

                //When flag is two then it means we have got out of loops in Send and Receive.
                while (nUdpClientFlag != 2)
                { }

                //Clear the flag.
                nUdpClientFlag = 0;

                //Close the socket.
                udpClient.Close();
            }
        }
        

        /*
         * Receive audio data coming on port 1550 and feed it to the speakers to be played.
         */
        private void Receive()
        {
            try
            {
                bStop = false;
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                while (!bStop)
                {
                    //Receive data.
                    byte[] byteData = udpClient.Receive(ref remoteEP);

                    //G711 compresses the data by 50%, so we allocate a buffer of double
                    //the size to store the decompressed data.
                    byte[] byteDecodedData = new byte[byteData.Length * 2];

                    //Decompress data using the proper vocoder.
                    if (vocoder == Vocoder.ALaw)
                    {
                        ALawDecoder.ALawDecode(byteData, out byteDecodedData);
                    }
                    else if (vocoder == Vocoder.uLaw)
                    {
                        MuLawDecoder.MuLawDecode(byteData, out byteDecodedData);
                    }
                    else
                    {
                        byteDecodedData = new byte[byteData.Length];
                        byteDecodedData = byteData;
                    }


                    //Play the data received to the user.
                    playbackBuffer = new SecondaryBuffer(playbackBufferDescription, device);
                    playbackBuffer.Write(0, byteDecodedData, LockFlag.None);
                    playbackBuffer.Play(0, BufferPlayFlags.Default);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-Receive ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                nUdpClientFlag += 1;
            }
        }
        private void InitializeCall()
        {
            try
            {
                //Start listening on port 1500.
                udpClient = new UdpClient(1550);

                Thread senderThread = new Thread(new ThreadStart(Send));
                    Thread receiverThread = new Thread(new ThreadStart(Receive));
                    bIsCallActive = true;

                    //Start the receiver and sender thread.
                    receiverThread.Start();
                    senderThread.Start();
                    //btnCall.Enabled = false;
                    //btnEndCall.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-InitializeCall ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DropCall()
        {
            try
            {
                //Send a Bye message to the user to end the call.
                SendMessage(Command.Bye, otherPartyEP);
                UninitializeCall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-DropCall ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UninitializeCall()
        {
            //Set the flag to end the Send and Receive threads.
            bStop = true;

            bIsCallActive = false;
           // btnCall.Enabled = true;
            //btnEndCall.Enabled = false;
        }


        /*
        * Send a message to the remote party.
        */
        private void SendMessage(Command cmd, EndPoint sendToEP)
        {
            try
            {
                //Create the message to send.
                Data msgToSend = new Data();

                msgToSend.strName = "用户名";   //Name of the user.
                msgToSend.cmdCommand = cmd;         //Message to send.
                msgToSend.vocoder = vocoder;        //Vocoder to be used.

                byte[] message = msgToSend.ToByte();

                //Send the message asynchronously.
                clientSocket.BeginSendTo(message, 0, message.Length, SocketFlags.None, sendToEP, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-SendMessage ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSendTo(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-OnSend ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        class Data
        {
            //Default constructor.
            public Data()
            {
                this.cmdCommand = Command.Null;
                this.strName = null;
                vocoder = Vocoder.ALaw;
            }

            //Converts the bytes into an object of type Data.
            public Data(byte[] data)
            {
                //The first four bytes are for the Command.
                this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

                //The next four store the length of the name.
                int nameLen = BitConverter.ToInt32(data, 4);

                //This check makes sure that strName has been passed in the array of bytes.
                if (nameLen > 0)
                    this.strName = Encoding.UTF8.GetString(data, 8, nameLen);
                else
                    this.strName = null;
            }

            //Converts the Data structure into an array of bytes.
            public byte[] ToByte()
            {
                List<byte> result = new List<byte>();

                //First four are for the Command.
                result.AddRange(BitConverter.GetBytes((int)cmdCommand));

                //Add the length of the name.
                if (strName != null)
                    result.AddRange(BitConverter.GetBytes(strName.Length));
                else
                    result.AddRange(BitConverter.GetBytes(0));

                //Add the name.
                if (strName != null)
                    result.AddRange(Encoding.UTF8.GetBytes(strName));

                return result.ToArray();
            }

            public string strName;      //Name by which the client logs into the room.
            public Command cmdCommand;  //Command type (login, logout, send message, etc).
            public Vocoder vocoder;
        }


        //The commands for interaction between the two parties.
        enum Command
        {
            Invite, //Make a call.
            Bye,    //End a call.
            Busy,   //User busy.
            OK,     //Response to an invite message. OK is send to indicate that call is accepted.
            Null,   //No command.
        }

        //Vocoder
        enum Vocoder
        {
            ALaw,   //A-Law vocoder.
            uLaw,   //u-Law vocoder.
            None,   //Don't use any vocoder.
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

            this.titleMain.button6.BackgroundImage = LoginFrame.Properties.Resources.volume;

            //button3_changeText button3outdelegate = new button3_changeText(button3changeText);
            //this.BeginInvoke(button3outdelegate, new object[] { "扩音中" });

        }

        public void stopPlayer()
        {
            this.splayer.Stop();

            this.titleMain.button6.BackgroundImage = LoginFrame.Properties.Resources.volume_up;

        }




        private void label6_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
            {
                panel5.Hide();
            }
            else
            {
                panel5.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel5.Hide();

            ModifyPassword modifyPassword = new ModifyPassword();
            modifyPassword.mainFram = this;
            modifyPassword.ShowDialog();
        }

        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel5.Hide();


            //跳转代码
            MainFrame mainFrame = MainFrame.createForm();


            //加载菜单栏
            mainFrame.panel1.Controls.Clear();
            TitleMain titleMain = TitleMain.createForm();
            titleMain.TopLevel = false;
            titleMain.FormBorderStyle = FormBorderStyle.None;
            titleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            mainFrame.panel1.Controls.Add(titleMain);
            titleMain.Show();


            //加载主体栏
            mainFrame.panel6.Controls.Clear();
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            mainFrame.panel6.Controls.Add(bodyMain);
            bodyMain.Show();
            mainFrame.Show();


            //互相访问控件
            mainFrame.bodyMain = bodyMain;
            mainFrame.titleMain = titleMain;

            bodyMain.mainFrame = mainFrame;
            titleMain.mainFrame = mainFrame;
        }
    }
}
