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

namespace LoginFrame
{
    public partial class LoginForm : Form
    {

        public static bool isLocalIp = false;//最终获取的Ip来源是本地的IP还是局域网中发送过来的IP标识
        //只有在定时器终止时候还没搜寻到IP且用户角色为  非 学生时候 才能设置为true 
        public static bool RunDoWhile = true;

        public LoginForm()
        {
            InitializeComponent();


            p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            Control.CheckForIllegalCrossThreadCalls = false;

            comboBox1.Items.Add("中文");
            comboBox1.Items.Add("English");
            comboBox1.SelectedIndex = 0;

            this.loginId.Text = "admin";
            this.textBox2.Text = "admin";

            this.comboBox3.Items.Add(new ComboxItem("学生", Constant.RoleStudent));
            this.comboBox3.Items.Add(new ComboxItem("教师", Constant.RoleTeacher));
            this.comboBox3.Items.Add(new ComboxItem("管理员", Constant.RoleManager));
            comboBox3.SelectedIndex = 2;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool login()
        {
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

                    DataSet ds = Bll.ExistsPwd(username, password, ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value);

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

                        Console.WriteLine("模拟人协议加载数量"+LoginRoler.AgreeMents.Count);

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
                    MessageBox.Show("用户名不存在,请重新输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.loginId.Text = "";
                    this.textBox2.Text = "";
                }
            }
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
            strWheres.Clear();
            DataTable dataTable = agreementService.listAgreements(strWheres).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                AgreeMent agreeMent = new AgreeMent();
                string AgreeMents_str = "";
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (j==0)
                    {
                        agreeMent.Agreement_id = dataTable.Rows[i][j].ToString();
                    }
                    else if (j == 1)
                    {
                        AgreeMents_str = dataTable.Rows[i][j].ToString();
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




        int comboBox3selectIndex;
        private void button1_Click(object sender, EventArgs e)
        {
            this.label6.Text = "局域网搜索数据库IP中......";
            //重置默认
            RunDoWhile = true;

            //================================================================================
            //登录说明:
            //整体思路是   用户登录  然后开始搜索局域网中是否有  数据库IP的消息  时间限定5秒
            //假如搜索到那么停止搜索线程和定时器任务  将IP保存在LoginRole.serverip里面
            //假如没有搜索到 限定时间到  对于 管理员和老师  则在定时器中关闭搜索任务且将自己IP存入LoginRole.serverip因为它自己要开启数据库了
            //假如没有搜索到 限定时间到  对于 学生  则为LoginRole.serverip空
            //================================================================================
            //登陆首先获取角色选择的index，因为写在后面会发生些错误 提前先获取
            comboBox3selectIndex = this.comboBox3.SelectedIndex;

            this.label6.Text = "搜索局域网内是否已有教师机或管理员登录";

            searchIp();

            
            Console.WriteLine("******最终获取的IP:" + LoginRoler.serverIp + "/来源:" + (isLocalIp ? "本地创建" : "来自局域网"));

            //搜索操作完毕后  不管获取到和获取不到都要将IP保存在LoginRoler.serverIp字段

            if (LoginRoler.serverIp == "" || LoginRoler.serverIp == null)//不存在IP  只有学生先登录才会不存在
            {
                MessageBox.Show("请等待老师或者管理员先进入系统!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else//获取到IP了   且   isLocalIp  为true 就要给大家发消息了
            {
                if (isLocalIp)
                {
                    //createSendUDPClient();
                    Console.WriteLine(">>>>>>>>>>>>>.往局域网中发送数据库IP的消息");
                    Thread t = new Thread(new ThreadStart(sendThread));
                    t.IsBackground = true;
                    t.Start();
                }
            }

            //判断下是否局域网中已经有老师存在
            string user_type = ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value;
            if (user_type == Constant.RoleTeacher && Constant.RoleTeacher == LoginRoler.serverType && !isLocalIp)
            {
                MessageBox.Show("局域网中已经有教师登录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            LoginRoler.isLocalIp = isLocalIp;

            if (isLocalIp)
            {
                openLocalDb();
            }


            Console.WriteLine("开启数据库操作.......");
            this.label6.Text = "开启数据库操作";

            Console.WriteLine("开始登录操作.......");
            this.label6.Text = "开始登录操作";

            //登录代码
            bool isLogined = login();
            if (!isLogined)
            {
                return;
            }

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

            this.Visible = false;//登录框消失

            //互相访问控件
            mainFrame.bodyMain = bodyMain;
            mainFrame.titleMain = titleMain;

            bodyMain.mainFrame = mainFrame;
            titleMain.mainFrame = mainFrame;
        }

        private Process p;


        private void openLocalDb()
        {
            string mySql_Version, mySql_Path;
            //判断是否存在数据库
            if (CheckMySql.hasInstalledMySql(out mySql_Version, out mySql_Path))
            {
                p.Start();

                //停止mysql服务
                exeCmd("net stop MySQL");

                //进入打包好的mysql地址
                cdDiyDBPath();
                exeCmd("mysqld remove");
                //安装mysql
                exeCmd("mysqld install");

                //启动mysql服务
                exeCmd("net start MySQL");
                Thread.Sleep(10000);
                p.Close();
            }
            else
            {

                p.Start();
             
                exeCmd("net stop MySQL");

                //进入打包数据库目录
                cdDiyDBPath();
                //exeCmd("mysqld remove");
                //安装mysql
                exeCmd("mysqld install");
                //启动mysql服务
                exeCmd("net start MySQL");
                Console.WriteLine("mysql启动完毕等待10秒");
                Thread.Sleep(10000);
                p.Close();
            }
        }


        private void exeCmd(string cmd)
        {
            p.StandardInput.WriteLine(cmd);
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
            string mainPath = curPath.Substring(0, curPath.IndexOf("LoginFrame"));
            mainPath += "MysqlInstallProj/DB/mysql-5.6.24-win32/bin";
            Console.WriteLine("==========" + mainPath);
            p.StandardInput.WriteLine("cd " + mainPath);

        }

        System.Timers.Timer timer;
        private void searchIp()
        {
            //创建搜索需要的UDP
            createReceUDPClient();

            //创建定时器控制搜索异步进程的时间
            timer = createTimer(5000);
            timer.Start();

            Console.WriteLine("====开始搜寻局域网数据库IP====");

            do
            {
                if ((searchServerIpthr == null))
                {
                    //搜索异步线程
                    searchServerIpthr = new Thread(new ThreadStart(RecvThread));
                    searchServerIpthr.IsBackground = true;
                    searchServerIpthr.Start();
                }
            } while (RunDoWhile);
            Console.WriteLine("====结束搜寻局域网数据库IP====");

        }

        Socket s;
        private void recv(string mcastGroup, string port)
        {
            if (s == null)
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(port));
                s.Bind(ipep);

                IPAddress ip = IPAddress.Parse(mcastGroup);

                s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));
            }
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

        private void createReceUDPClient()
        {
            recv("224.5.6.7", "5000");
            //recv("224.224.224.224", "5000");
            //recv广播("5000");
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


        private void sendThread()
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

        private void send(string mcastGroup, string port, string ttl, byte[] data)
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

        Thread searchServerIpthr;

        private void theout(object sender, ElapsedEventArgs e)
        {
            if (RunDoWhile)
            {
                //超时之后假如是老师或者管理员(非学生登录)则将Ip设定为该机器IP

                string user_type = ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value;
                if (user_type == Constant.RoleManager)//管理员
                {
                    LoginRoler.serverIp = GetAddressIP();
                    LoginRoler.serverType = Constant.RoleManager;
                    isLocalIp = true;
                }
                else
                if (user_type == Constant.RoleTeacher)//老师
                {
                    LoginRoler.serverIp = GetAddressIP();
                    LoginRoler.serverType = Constant.RoleTeacher;
                    isLocalIp = true;
                }
                else
                {
                    LoginRoler.serverIp = "";
                    LoginRoler.serverType = Constant.RoleStudent;
                }

                //Console.WriteLine("搜索线程终止且终止定时器,IP:" + LoginRoler.serverIp);
                RunDoWhile = false;
                searchServerIpthr.Abort();

            }
        }

        void RecvThread()
        {
            while (true)
            {
                byte[] b = new byte[1024];
                s.Receive(b);
                string msg = System.Text.Encoding.ASCII.GetString(b, 0, b.Length);
                string[] splitString = msg.Split('^');
                switch (splitString[0])
                {
                    case "ServerIp"://服务器IP指令
                        Console.WriteLine("接收到局域网中某台机器传送来的IP:" + splitString[1]);
                        LoginRoler.serverIp = splitString[1];
                        LoginRoler.serverType = splitString[2];
                        //Console.WriteLine("^^^^^^^^^^^^^^^^" + LoginRoler.serverIp);
                        //搜索进程结束 且将定时器取消
                        RunDoWhile = false;
                        searchServerIpthr.Abort();
                        break;
                    default:
                        //Console.WriteLine("进入默认了...");
                        break;
                }

            }
            //s.Close();
        }



        void RecvThread广播()
        {
            while (true)
            {
                byte[] buf = recvclient.Receive(ref recvendpoint);
                string msg = Encoding.Default.GetString(buf);
                string[] splitString = msg.Split('^');
                switch (splitString[0])
                {
                    case "ServerIp"://服务器IP指令
                        Console.WriteLine("接收到局域网中某台机器传送来的IP:" + splitString[1]);
                        LoginRoler.serverIp = splitString[1];
                        LoginRoler.serverType = splitString[2];
                        //Console.WriteLine("^^^^^^^^^^^^^^^^" + LoginRoler.serverIp);
                        //搜索进程结束 且将定时器取消
                        RunDoWhile = false;
                        searchServerIpthr.Abort();
                        break;
                    default:
                        //Console.WriteLine("进入默认了...");
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(LoginForm));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
