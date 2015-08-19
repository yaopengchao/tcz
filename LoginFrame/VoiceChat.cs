using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectSound;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using g711audio;

using Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace LoginFrame
{
    public partial class VoiceChat : Form
    {
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
        

        public VoiceChat()
        {
            InitializeComponent();
            // 加入这行
            Control.CheckForIllegalCrossThreadCalls = false;
            Initialize();
        }


        private void VoiceChat_Load(object sender, EventArgs e)
        {
            
            this.cmbCodecs.SelectedIndex = 1;

            loadOnlineUses();
            
        }

        private void loadOnlineUses()
        {
            //加载在线用户列表  数据从LoginRoler获取
            Dictionary<string, OnlineUser> onlineUserDic = LoginRoler.OnlineUserDic;
            //循环添加到onlineusers列表控件
            this.onlineuses.Items.Clear();

            foreach (var dic in onlineUserDic)
            {
                //Console.WriteLine("Output Key : {0}, Value : {1} ", dic.Key, dic.Value);
                OnlineUser onlineUser = (OnlineUser)dic.Value;
                onlineuses.Items.Add(onlineUser.chatIp);
            }
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

        private ListView.SelectedListViewItemCollection selectedUsers;


        private void btnCall_Click(object sender, EventArgs e)
        {
            if (this.onlineuses.SelectedItems.Count>0)
            {
                string ip = this.onlineuses.SelectedItems[0].Text;

                //循环处理 在线用户列表
                 selectedUsers = this.onlineuses.SelectedItems;
                 for (int a=0;a<selectedUsers.Count;a++)
                {
                    Call(selectedUsers[a].Text);
                 }
            }
            else
            {
                MessageBox.Show("请选择需要聊天的用户");
            }
        }

        private void Call(string ip)
        {
            try
            {
                //Get the IP we want to call.
               
               
                    otherPartyIP = new IPEndPoint(IPAddress.Parse(ip), 1450);
             
              
            
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

            
                    //Send an invite message.
                    SendMessage(Command.Invite, otherPartyEP);
              
                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-Call ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSendTo (ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-OnSend ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string ip = receivedFromEP.ToString().Split(':')[0];
                            //将远程同意邀请的用户IP写到教师机的  聊天室列表中
                            addChatRoom(ip, "测试用户名");
                            //更新在线用户的  isChating 值改成true
                            updateOnlineUser(ip);
                            //同时需要通知其他学生机更新目前最新的聊天室用户IP列表  而这个操作需要由一开始登录的Socket来做
                            updateNetNewChatRoomUsersToStudent();
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
                            if (receivedFromEP.Equals (otherPartyEP) == true)
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

        private void updateOnlineUser(string ip)
        {
            Dictionary<string, OnlineUser> onlineUserDic = LoginRoler.OnlineUserDic;
            //循环添加到onlineusers列表控件

            foreach (var dic in onlineUserDic)
            {
                if (dic.Key.Equals(ip)==true)
                {
                    //Console.WriteLine("Output Key : {0}, Value : {1} ", dic.Key, dic.Value);
                    OnlineUser onlineUser = (OnlineUser)dic.Value;
                    onlineUser.isChating = true;
                    onlineUserDic.Add(ip, onlineUser);
                }
            }
        }


        /// <summary>
        /// 更新局域网中聊天室用户 推送到学生机其上面
        /// </summary>
        private void updateNetNewChatRoomUsersToStudent()
        {
            //循环  发送  局域网 聊天用户
            MainFrame mFrame = MainFrame.createForm();
            Dictionary<string, Socket> socketDic = mFrame.SocketDic;

            foreach (var dic in socketDic)
            {
                //Console.WriteLine("Output Key : {0}, Value : {1} ", dic.Key, dic.Value);
                string ip = dic.Key;
                Socket socketSend = dic.Value;
                List<ChatUser> chatUserslist = LoginRoler.chatUserlist;
                MemoryStream mStream = new MemoryStream();
                BinaryFormatter bformatter = new BinaryFormatter();  //二进制序列化类  
                bformatter.Serialize(mStream, chatUserslist); //将消息类转换为内存流  
                mStream.Flush();
                byte[] buffer = new byte[1024];
                mStream.Position = 0;  //将流的当前位置重新归0，否则Read方法将读取不到任何数据
                while (mStream.Read(buffer, 0, buffer.Length) > 0)
                {
                    socketSend.Send(buffer); //从内存中读取二进制流，并发送  
                }
                socketSend.Close();
            }
        }

        public void addChatRoom(string ip,string name)
        {
            chatroomusers.Items.Add(ip);

            //将用户加入LoginRole.chatUserslist里面
            List<ChatUser> chatUserslist=LoginRoler.chatUserlist;
            ChatUser chatUser = new ChatUser();
            chatUser.ChatIp = ip;
            chatUser.ChatName = name;
            chatUserslist.Add(chatUser);
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

                    //chatroomusers
                    for (int a=0;a< chatroomusers.Items.Count;a++)
                    {
                        if (vocoder == Vocoder.ALaw)
                        {
                            byte[] dataToWrite = ALawEncoder.ALawEncode(memStream.GetBuffer());
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, chatroomusers.Items[a].ToString(), 1550);
                        }
                        else if (vocoder == Vocoder.uLaw)
                        {
                            byte[] dataToWrite = MuLawEncoder.MuLawEncode(memStream.GetBuffer());
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, chatroomusers.Items[a].ToString(), 1550);
                        }
                        else
                        {
                            byte[] dataToWrite = memStream.GetBuffer();
                            //udpClient.Send(dataToWrite, dataToWrite.Length, otherPartyIP.Address.ToString(), 1550);
                            udpClient.Send(dataToWrite, dataToWrite.Length, chatroomusers.Items[a].ToString(), 1550);
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

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            if (bIsCallActive)
            {
                DropCall();
            }
            
            this.Close();
        }

        private void UninitializeCall()
        {
            //Set the flag to end the Send and Receive threads.
            bStop = true;

            bIsCallActive = false;
            btnCall.Enabled = true;
            btnEndCall.Enabled = false;
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

        private void InitializeCall()
        {
            try
            {
                udpClient = new UdpClient(1550);

                Thread senderThread = new Thread(new ThreadStart(Send));
                Thread receiverThread = new Thread(new ThreadStart(Receive));
                bIsCallActive = true;

                //Start the receiver and sender thread.
                receiverThread.Start();
                senderThread.Start();
                btnCall.Enabled = false;
                btnEndCall.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VoiceChat-InitializeCall ()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void VoiceChat_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (bIsCallActive)
            {
                UninitializeCall();
                DropCall();
            }
        }


        /// <summary>
        /// 加载聊天室用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            loadOnlineUses();
        }
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
}