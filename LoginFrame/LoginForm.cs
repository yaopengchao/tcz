using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using BLL;
using Model;
using System.Threading;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using TherapeuticApparatus.CommonMethod;
using System.IO;

namespace LoginFrame
{
    public partial class 听触诊登录 : Form
    {

        public static bool isLocalIp = false;//最终获取的Ip来源是本地的IP还是局域网中发送过来的IP标识
        //只有在定时器终止时候还没搜寻到IP且用户角色为  非 学生时候 才能设置为true 
        public static bool RunDoWhile = true;

        public 听触诊登录()
        {

            InitializeComponent();

            this.BackColor = Color.FromArgb(255, 208, 232, 253);

            Control.CheckForIllegalCrossThreadCalls = false;

            comboBox1.Items.Add("中文");
            comboBox1.Items.Add("English");
            comboBox1.SelectedIndex = 0;

            this.loginId.Text = "admin";
            this.textBox2.Text = "admin";

            //this.comboBox3.Items.Add(new ComboxItem("学生", Constant.RoleStudent));
            //this.comboBox3.Items.Add(new ComboxItem("教师", Constant.RoleTeacher));
            //this.comboBox3.Items.Add(new ComboxItem("管理员", Constant.RoleManager));
            //comboBox3.SelectedIndex = 2;

            

            
        }

        /// <summary>
        /// 创建UDP收发对象和加载到LoginRoler中便于管理
        /// </summary>
        private void loadUDP()
        {
            //创建搜索需要的UDP接收对象

            LoginRoler.UDPRecv = new UdpClient(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["UDPPortRecv"]));
            LoginRoler.UDPRecv.JoinMulticastGroup(IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["UDPAddress"]));
            LoginRoler.RecvMulticast = new IPEndPoint(IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["UDPAddress"]), Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["UDPPortSend"]));


            //创建UDP需要的UDP发送对象
            LoginRoler.UDPSend = new UdpClient(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["UDPPortSend"]));
            LoginRoler.UDPSend.JoinMulticastGroup(IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["UDPAddress"]));
            LoginRoler.SendMulticast = new IPEndPoint(IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["UDPAddress"]), Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["UDPPortRecv"]));
        }

        private void messageThread()
        {
            Thread.Sleep(1000);
            this.label6.Image = null;
            this.label6.Text = "初始化完成....";
            this.button1.Enabled = true;
        }

        public static string checkCode = "";

        /// <summary>
        /// 产生验证码随机数
        /// </summary>
        /// <param name="CodeCount"></param>
        /// <returns></returns>
        private string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Process[] myProcess = Process.GetProcessesByName("mysqld-nt");
            //if (myProcess.Length > 0)
            //{
            //    foreach (Process process in myProcess)
            //    {
            //        process.Kill()  ;
            //    }
            //}
            //Thread.Sleep(500);

            {
                string DbserviceName = ConfigurationManager.AppSettings["mysqlServiceName"].ToString();
                p.Start();

                cdDiyDBPath();
                //停止mysql服务
                exeCmd("net stop " + DbserviceName);
                exeCmd("mysqld-nt remove");
                

                p.Close();

            }

            Application.Exit();
        }

        private bool login()
        {

            this.label6.Text = "开始登录操作..";
            Application.DoEvents();

            bool flag = false;
            string username = loginId.Text;

            string password = this.textBox2.Text;

            if (username == "")
            {
                MessageBox.Show("用户名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (password == "")
            {
                MessageBox.Show("密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ImplUser Bll = new ImplUser();

                int a = Bll.ExistsName(username);

                if (a != 0)
                {

                    //DataSet ds = Bll.ExistsPwd(username, password, ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value);

                    DataSet ds = Bll.ExistsPwd(username, password, "");

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        LoginRoler.login_id = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
                        LoginRoler.username = Convert.ToString(ds.Tables[0].Rows[0][1].ToString());
                        LoginRoler.roleid = Convert.ToString(ds.Tables[0].Rows[0][2].ToString());
                        LoginRoler.language = comboBox1.SelectedIndex;
                        LoginRoler.ip = GetAddressIP();
                        LoginRoler.userId = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
                        LoginRoler.pwd = password;

                        loadAgreeMent();

                        Console.WriteLine("模拟人协议加载数量" + LoginRoler.AgreeMents.Count);

                        if (!LoginRoler.isLocalIp)
                        {
                            LoginRoler.serverType = LoginRoler.roleid;
                        }


                        if (LoginRoler.roleid==Constant.RoleStudent && LoginRoler.isLocalIp)
                        {
                            MessageBox.Show("目前该用户登录在本地数据库", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        //判断下是否局域网中已经有老师存在

                        //string user_type = ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value;

                        string user_type = LoginRoler.serverType;


                        if (user_type == Constant.RoleTeacher && Constant.RoleTeacher == LoginRoler.serverType && !isLocalIp)
                        {
                            MessageBox.Show("局域网中已经有教师登录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            button1.Enabled = true;
                            return flag;
                        }

                        if (user_type == Constant.RoleManager && Constant.RoleManager == LoginRoler.serverType && !isLocalIp)
                        {
                            MessageBox.Show("局域网中已经有管理员登录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            button1.Enabled = true;
                            return flag;
                        }

                        checkCode = "";
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show("密码输入错误,请重新输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.loginId.Text = "";
                        this.textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在,请确认教师是否已经登录系统", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.loginId.Text = "";
                    this.textBox2.Text = "";
                }
            }

            this.label6.Text = "开始登录操作...";
            Application.DoEvents();


            return flag;
        }

        private AgreementService agreementService;
        private static Dictionary<string, string> strWheres;

        private void loadAgreeMent()
        {
            if (agreementService == null)
            {
                agreementService = AgreementService.getInstance();
            }
            if (strWheres == null)
            {
                strWheres = new Dictionary<string, string>();
            }
            Dictionary<string, AgreeMent> AgreeMents = LoginRoler.AgreeMents;
            AgreeMents.Clear();
            strWheres.Clear();
            DataTable dataTable = agreementService.listAgreements(strWheres).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                AgreeMent agreeMent = new AgreeMent();
                string AgreeMents_str = "";
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        AgreeMents_str = dataTable.Rows[i][j].ToString();
                        agreeMent.Agreement_id = dataTable.Rows[i][j].ToString();
                    }
                    else if (j == 1)
                    {
                        agreeMent.Agreement_name = dataTable.Rows[i][j].ToString();
                    }
                    else if (j == 2)
                    {
                        agreeMent.Agreement_ename = dataTable.Rows[i][j].ToString();
                    }
                    else if (j == 3)
                    {
                        agreeMent.Agreement_type = dataTable.Rows[i][j].ToString();
                    }
                    else if (j == 4)
                    {
                        agreeMent.Agreement = dataTable.Rows[i][j].ToString();
                    }
                }
                AgreeMents.Add(AgreeMents_str, agreeMent);
            }
        }

        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }

            return AddressIP;
        }

       // int comboBox3selectIndex;
        private void button1_Click(object sender, EventArgs e)
        {
            //重置默认
            RunDoWhile = true;
            isLocalIp = false;

            //================================================================================
            //登录说明:
            //整体思路是   用户登录  然后开始搜索局域网中是否有  数据库IP的消息  时间限定5秒
            //假如搜索到那么停止搜索线程和定时器任务  将IP保存在LoginRole.serverip里面
            //假如没有搜索到 限定时间到  对于 管理员和老师  则在定时器中关闭搜索任务且将自己IP存入LoginRole.serverip因为它自己要开启数据库了
            //假如没有搜索到 限定时间到  对于 学生  则为LoginRole.serverip空
            //================================================================================
            //登陆首先获取角色选择的index，因为写在后面会发生些错误 提前先获取
            //comboBox3selectIndex = this.comboBox3.SelectedIndex;

            searchIp();

            this.label6.Text = "开始搜寻局域网数据库IP...";
            Application.DoEvents();

           
            this.label6.Text = "结束搜寻局域网数据库IP";
            Application.DoEvents();


            //如果是测试的则会改变实际的IP结果   这样就能开启本地数据库进行测试修改
            if ("true".Equals(System.Configuration.ConfigurationManager.AppSettings["isTest"]))
            {
                LoginRoler.serverIp = GetAddressIP();
                isLocalIp = true;
            }

            Console.WriteLine("******最终获取的IP:" + LoginRoler.serverIp + "/来源:" + (isLocalIp ? "本地创建" : "来自局域网"));

            //搜索操作完毕后  不管获取到和获取不到都要将IP保存在LoginRoler.serverIp字段

            if (LoginRoler.serverIp == "" || LoginRoler.serverIp == null)//不存在IP  只有学生先登录才会不存在
            {
                MessageBox.Show("请等待老师或者管理员先进入系统!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else//获取到IP了   且   isLocalIp  为true 就要给大家发消息了
            {
              
            }

            LoginRoler.isLocalIp = isLocalIp;


            Thread.Sleep(500);
            this.label6.Text = "开始登录操作";
            Application.DoEvents();

            //登录代码
            bool isLogined = login();
            if (!isLogined)
            {
                button1.Enabled = true;
                return;
            }



            //跳转代码
            MainFrame mainFrame = MainFrame.createForm();


            mainFrame.panel6.Controls.Clear();
            mainFrame.panel6.Controls.AddRange(mainFrame.items.ToArray());

            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            mainFrame.panel6.Controls.Add(bodyMain);
            bodyMain.Show();
            mainFrame.Show();


            this.Visible = false;//登录框消失

            //互相访问控件
            mainFrame.bodyMain = bodyMain;
            bodyMain.mainFrame = mainFrame;

        }

        private void messageThread1()
        {
           
            this.label6.Image = null;
            this.label6.Text = "搜索局域网数据库信息...";
          
        }

        private Process p;


        public void openLocalDb()
        {
            //先关闭
            Process[] myProcess = Process.GetProcessesByName("mysqld-nt");
            if (myProcess.Length > 0)
            {
                foreach (Process process in myProcess)
                {
                    process.Kill();
                }
            }
            Thread.Sleep(1000);
            //再打开
            Process.Start(getDBPath());
            
            Thread.Sleep(2000);
        }


        private void exeCmd(string cmd)
        {
            p.StandardInput.WriteLine(cmd);
        }

        private string getDBPath()
        {

            //return Application.StartupPath + @"/../../../MysqlInstallProj/DB/MySQL5.1/bin/mysqld-nt.exe"
            p.Start();
            
            string curPath = Application.StartupPath;
            int index = curPath.IndexOf(":");
            string hardPath = curPath.Substring(0, index + 1);
            p.StandardInput.WriteLine(hardPath);
            p.StandardInput.WriteLine("cd " + curPath);
            //Console.WriteLine("=====curPath=====" + curPath);
            //string dMsql = Application.StartupPath + @"/../../../MysqlInstallProj/DB/MySQL5.1/bin/mysqld-nt.exe";
            string mainPath = curPath.Substring(0, curPath.IndexOf("bin"));
            mainPath += "DB/MySQL5.1/bin/mysqld-nt.exe";
            Console.WriteLine("==========" + mainPath);
            //p.StandardInput.WriteLine("cd " + mainPath);
            p.StandardInput.AutoFlush = true;
            p.Close();
            return mainPath;
        }

        //进入程序打包好的mysql目录
        private void cdDiyDBPath()
        {
            string curPath = Application.StartupPath;
            int index = curPath.IndexOf(":");
            string hardPath = curPath.Substring(0, index + 1);
            p.StandardInput.WriteLine(hardPath);
            p.StandardInput.WriteLine("cd " + curPath);
            //string dMsql = Application.StartupPath + @"/../../../MysqlInstallProj/DB/mysql-5.6.24-win32/bin";
            string mainPath = curPath.Substring(0, curPath.IndexOf("bin"));
            mainPath += "DB/MySQL5.1/bin";
            Console.WriteLine("==========" + mainPath);
            p.StandardInput.WriteLine("cd " + mainPath);

        }

        System.Timers.Timer timer;
        private void searchIp()
        {
            //创建定时器控制搜索异步进程的时间
            timer = createTimer(2000);
            timer.Start();

            this.label6.Text = "开始搜寻局域网数据库IP";
            Application.DoEvents();

            searchServerIpRecv = new Thread(new ThreadStart(RecvThread));
            searchServerIpRecv.IsBackground = true;
            searchServerIpRecv.Start();

            this.label6.Text = "开始搜寻局域网数据库IP.";
            Application.DoEvents();

            do
            {

                //发送指令
                byte[] buf = Encoding.Default.GetBytes("getIp^^##");
                LoginRoler.UDPSend.Send(buf, buf.Length, LoginRoler.SendMulticast);
                Console.WriteLine("发送指令");


            } while (RunDoWhile);

            this.label6.Text = "开始搜寻局域网数据库IP..";
            Application.DoEvents();


        }

        private void SendThread()
        {
            while (true)
            {
                //发送指令
                byte[] buf = Encoding.Default.GetBytes("getIp^^##");
                LoginRoler.UDPSend.Send(buf, buf.Length, LoginRoler.SendMulticast);
                Console.WriteLine("发送指令");
            }
        }

        private Socket recv(string mcastGroup, string port)
        {
            Socket s = null;

            if (s == null)
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(port));
                s.Bind(ipep);

                IPAddress ip = IPAddress.Parse(mcastGroup);

                s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));
            }
            return s;
        }

        private System.Timers.Timer createTimer(int time)
        {
            System.Timers.Timer timer = new System.Timers.Timer(time);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            timer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            timer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            return timer;

        }

        UdpClient sendclient;
        IPEndPoint sendendpoint;
        private void createSendUDPClient()
        {
            if (sendclient == null)
            {
                sendclient = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            }
            if (sendendpoint == null)
            {
                sendendpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 5000);
            }
        }

        private Socket createReceUDPClient()
        {
            return recv(System.Configuration.ConfigurationManager.AppSettings["UDPAddress"], System.Configuration.ConfigurationManager.AppSettings["UDPPort"]);
        }

        UdpClient recvclient;
        IPEndPoint recvendpoint;
        private void recv广播(string port)
        {
            if (recvclient == null)
            {
                recvclient = new UdpClient(new IPEndPoint(IPAddress.Any, 5000));
            }
            if (recvendpoint == null)
            {
                recvendpoint = new IPEndPoint(IPAddress.Any, 0);
            }
        }


        private void msgThread()
        {
            while (true)
            {
                byte[] buf = Encoding.Default.GetBytes("ServerIp^" + LoginRoler.serverIp + "^" + LoginRoler.serverType + "^");
                send("224.5.6.7", "5000", "10", buf);
                //send("224.224.224.224", "5000", "10", buf);
                //send广播(buf);
            }
        }

        private void send广播(byte[] buf)
        {
            sendclient.Send(buf, buf.Length, sendendpoint);
        }

        public void send(string mcastGroup, string port, string ttl, byte[] data)
        {

            IPAddress ip;
            try
            {
                //Console.WriteLine("MCAST Send on Group: {0} Port: {1} TTL: {2}", mcastGroup, port, ttl);
                ip = IPAddress.Parse(mcastGroup);

                Socket s = new Socket(AddressFamily.InterNetwork,
                                SocketType.Dgram, ProtocolType.Udp);

                s.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.AddMembership, new MulticastOption(ip));

                s.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.MulticastTimeToLive, int.Parse(ttl));

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(mcastGroup), int.Parse(port));

                //Console.WriteLine("Connecting...");

                s.Connect(ipep);

                s.Send(data, data.Length, SocketFlags.None);


                //Console.WriteLine("Closing Connection...");
                s.Close();
            }
            catch (System.Exception e) { Console.Error.WriteLine(e.Message); }
        }

        Thread searchServerIpRecv;

        private void theout(object sender, ElapsedEventArgs e)
        {

            Console.Write("..超时调用方法..");

            if (RunDoWhile)
            {
                //超时之后假如是老师或者管理员(非学生登录)则将Ip设定为该机器IP

                LoginRoler.serverIp = GetAddressIP();
                isLocalIp = true;

                if (1==2) {
                    //从本地库获取角色  获取不到说明不是 正式库  

                    ImplUser Bll = new ImplUser();

                    string username = loginId.Text;

                    string password = this.textBox2.Text;

                    int a = Bll.ExistsName(username);

                    if (a != 0)
                    {
                        //DataSet ds = Bll.ExistsPwd(username, password, ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value);

                        DataSet ds = Bll.ExistsPwd(username, password, "");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            LoginRoler.roleid = Convert.ToString(ds.Tables[0].Rows[0][2].ToString());
                        }
                    }

                    string user_type = LoginRoler.roleid;


                    if (user_type == Constant.RoleManager)//管理员
                    {

                        LoginRoler.serverType = Constant.RoleManager;

                    }
                    else
                    if (user_type == Constant.RoleTeacher)//老师
                    {
                        LoginRoler.serverType = Constant.RoleTeacher;
                    }
                    else//学生
                    if (user_type == Constant.RoleStudent)
                    {
                        LoginRoler.serverType = Constant.RoleStudent;
                    }
                    else
                    {
                        LoginRoler.serverType = "unknown";
                    }

                }
                RunDoWhile = false;
                if (searchServerIpRecv != null)
                {
                    searchServerIpRecv.Abort();
                }
            }
        }

        void RecvThread()
        {
            while (true)
            {
                byte[] buf = LoginRoler.UDPRecv.Receive(ref LoginRoler.recvMulticast);
                string msg = Encoding.Default.GetString(buf);
                string[] splitString = msg.Split('^');
                string swfName = splitString[1];
                switch (splitString[0])
                {
                    case "ServerIp"://服务器IP指令
 Console.WriteLine("接收到局域网中某台机器传送来的IP:" + splitString[1]);
                        LoginRoler.serverIp = splitString[1];
                        LoginRoler.serverType = splitString[2];
                        RunDoWhile = false;
                        searchServerIpRecv.Abort();
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedItem.ToString()+"/"+comboBox1.SelectedIndex);
            if (comboBox1.SelectedIndex == 0)
            {
                //更改当前线程的 CultureInfo
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (comboBox1.SelectedIndex == 1)
            { //更改当前线程的 CultureInfo
                //en 为英文，更多的关于 Culture 的字符串请查 MSDN
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");

            }

            //对当前窗体应用更改后的资源
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(听触诊登录));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            button1.Enabled = false;


            {
                string DbserviceName = ConfigurationManager.AppSettings["mysqlServiceName"].ToString();
                p.Start();

                cdDiyDBPath();
                //停止mysql服务
                exeCmd("net stop "+ DbserviceName);
                exeCmd("sc delete \"" + DbserviceName+"\"");

                exeCmd("mysqld-nt -install "+ DbserviceName);
                //启动mysql服务
                exeCmd("net start "+ DbserviceName);
                Thread.Sleep(3000);

                p.Close();

            }
            //installAndStartDBService();

            //openLocalDb();


            Thread t = new Thread(new ThreadStart(messageThread));
            t.IsBackground = true;
            t.Start();

            loadUDP();
        }

        private void installAndStartDBService()
        {
            string DbserviceName = ConfigurationManager.AppSettings["mysqlServiceName"].ToString();
            //检测 是否存在服务
            if (WinServiceUtil.IsServiceIsExisted(DbserviceName))
            {
                //判断是否在运行
                if (!WinServiceUtil.IsServiceStart(DbserviceName))
                {
                    //运行执行
                    if (!WinServiceUtil.StartService(DbserviceName))
                    {
                        MessageBox.Show("听触诊数据库无法启动，请联系管理员!");
                    }
                }
            }
            else
            {
                //安装服务

            }
        }
    }
}
