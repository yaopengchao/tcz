using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using BLL;
using Model;
using Microsoft.DirectX.DirectSound;
using System.IO;
using g711audio;

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
            Control.CheckForIllegalCrossThreadCalls = false;
            Initialize();
        }


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
                                if (MessageBox.Show("Call coming from " + msgReceived.strName + ".\r\n\r\nAccept it?",
                                    "VoiceChat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void UninitializeCall()
        {
            //Set the flag to end the Send and Receive threads.
            bStop = true;

            bIsCallActive = false;
            //btnCall.Enabled = true;
            //btnEndCall.Enabled = false;
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

                    if (vocoder == Vocoder.ALaw)
                    {
                        byte[] dataToWrite = ALawEncoder.ALawEncode(memStream.GetBuffer());
                        udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                    }
                    else if (vocoder == Vocoder.uLaw)
                    {
                        byte[] dataToWrite = MuLawEncoder.MuLawEncode(memStream.GetBuffer());
                        udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                    }
                    else
                    {
                        byte[] dataToWrite = memStream.GetBuffer();
                        udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
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

               
            }


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

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (isSpeaking)
            {
                isSpeaking = false;
                this.btnEndCall.Text = "开启语音";
            }
            else
            {
                isSpeaking = true;
                this.btnEndCall.Text = "关闭语音";
            }
        }

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
        private void Call()
        {
            try
            {
                //Get the IP we want to call.
                otherPartyIP = new IPEndPoint(IPAddress.Parse("192.168.0.104"), 1450);
                otherPartyEP = (EndPoint)otherPartyIP;

                //Get the vocoder to be used.
                if (cmbCodecs.SelectedText == "A-Law")
                {
                    vocoder = Vocoder.ALaw;
                }
                else if (cmbCodecs.SelectedText == "u-Law")
                {
                    vocoder = Vocoder.uLaw;
                }
                else if (cmbCodecs.SelectedText == "None")
                {
                    vocoder = Vocoder.None;
                }
                else
                {
                    vocoder = Vocoder.None;
                }

                //Send an invite message.
                SendMessage(Command.Invite, otherPartyEP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-Call ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMessage(Command cmd, EndPoint sendToEP)
        {
            try
            {
                //Create the message to send.
                Data msgToSend = new Data();

                msgToSend.strName = LoginRoler.username;   //Name of the user.
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
        //The data structure by which the server and the client interact with 
        //each other.
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

        private void button2_Click(object sender, EventArgs e)
        {
            Call();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            DropCall();
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
    }
}
