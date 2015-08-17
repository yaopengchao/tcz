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

            Control.CheckForIllegalCrossThreadCalls = false;

            comboBox1.Items.Add("中文简体");
            comboBox1.Items.Add("English");
            comboBox1.SelectedIndex = 0;

            //this.textBox1.Text = "manager";
            //this.textBox2.Text = "manager";


            this.comboBox2.Items.Add("admin");
            this.comboBox2.Items.Add("student");
            this.comboBox2.Items.Add("teacher");

            comboBox2.SelectedIndex = 0;

            this.comboBox3.Items.Add(new ComboxItem("学生", Constant.RoleStudent));
            this.comboBox3.Items.Add(new ComboxItem("教师", Constant.RoleTeacher));
            this.comboBox3.Items.Add(new ComboxItem("管理员", Constant.RoleManager));
            comboBox3.SelectedIndex = 0;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkCode = GetRandomCode(4);
            CreateImage(checkCode);

            //测试时候直接将验证码写入
            this.textBox3.Text = checkCode;
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="checkCode"></param>
        private void CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 15);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 21);
            Graphics g = Graphics.FromImage(image);
            Font f = new System.Drawing.Font("Arial ", 10);//, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(Color.Black);
            Brush r = new System.Drawing.SolidBrush(Color.FromArgb(166, 8, 8));

            g.Clear(System.Drawing.ColorTranslator.FromHtml("#99C1CB"));//背景色

            char[] ch = checkCode.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] >= '0' && ch[i] <= '9')
                {
                    //数字用红色显示
                    g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                }
                else
                {   //字母用黑色显示
                    g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                }
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //history back 不重复 
            pictureBox2.Image = image;
        }



        private bool login()
        {
            bool flag = false;
            //string username = this.textBox1.Text;
            string username = comboBox2.SelectedItem.ToString();

            string password = this.textBox2.Text;

            if (username == "")
            {
                MessageBox.Show("用户名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (password == "")
            {
                MessageBox.Show("密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else if (this.textBox3.Text.Trim() == "")
            {
                MessageBox.Show("验证码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (checkCode.ToLower() != this.textBox3.Text.Trim().ToLower())
                {
                    MessageBox.Show("验证码输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                            LoginRoler.username = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
                            //LoginRoler.truename = Convert.ToString(ds.Tables[0].Rows[0][1].ToString());
                            LoginRoler.roleid = Convert.ToString(ds.Tables[0].Rows[0][1].ToString());
                            LoginRoler.language = comboBox1.SelectedIndex;
                            LoginRoler.ip = GetAddressIP();
                            LoginRoler.userId = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
                            LoginRoler.pwd = password;


                            //检查是否还有其他老师在同一个局域网登录


                            //记录登录信息
                            //bool islogedin = Bll.logLogin(LoginRoler.username, LoginRoler.ip);


                            checkCode = "";
                            flag = true;
                        }
                        else
                        {
                            MessageBox.Show("密码输入错误,请重新输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBox3.Text = "";
                            pictureBox2_Click(null, null);//调用刷新验证码方法
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在,请重新输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox3.Text = "";
                        pictureBox2_Click(null, null);//调用刷新验证码方法
                    }
                }
            }
            return flag;
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
            this.label6.Text = "搜寻局域网数据库IP";

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

            searchIp();

            Console.WriteLine("******最终获取的IP:"+LoginRoler.serverIp+"/来源:"+ (isLocalIp?"本地创建":"来自局域网"));

            //搜索操作完毕后  不管获取到和获取不到都要将IP保存在LoginRoler.serverIp字段

            if (LoginRoler.serverIp == "" || LoginRoler.serverIp==null)//不存在IP  只有学生先登录才会不存在
            {
                    MessageBox.Show("请等待老师先进入系统!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;    
            }
            else//获取到IP了   且   isLocalIp  为true 就要给大家发消息了
            {
                if (isLocalIp)
                {
                    createSendUDPClient();
Console.WriteLine(">>>>>>>>>>>>>.往局域网中发送数据库IP的消息");
                    Thread t = new Thread(new ThreadStart(sendThread));
                    t.IsBackground = true;
                    t.Start();
                }
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

        /// <summary>
        /// 是否已经修改app.config
        /// </summary>
        /// <param name="serverIp"></param>
        /// <returns></returns>
        private bool modifiyAppConfig(string serverIp)
        {
            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //获取appSettings节点
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");


            //删除name，然后添加新值
            appSettings.Settings.Remove("mysqlIp");
            appSettings.Settings.Add("mysqlIp", serverIp);

            //保存配置文件
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }

        System.Timers.Timer timer;
        private void searchIp()
        {
            //创建搜索需要的UDP
            createReceUDPClient();

            //创建定时器控制搜索异步进程的时间
            timer=createTimer(5000);
            timer.Start();

Console.WriteLine("====开始搜寻局域网数据库IP====");
            
            do
            {
                if ((searchServerIpthr == null))
                {
                        //搜索异步线程
                        Console.WriteLine("==创建搜索任务");
                        searchServerIpthr = new Thread(new ThreadStart(RecvThread));
                        searchServerIpthr.IsBackground = true;
                        Console.WriteLine("==执行搜索任务");
                        searchServerIpthr.Start();
                   
                }
            } while (RunDoWhile);
 Console.WriteLine("====结束搜寻局域网数据库IP====");
            
        }

        private System.Timers.Timer createTimer(int time)
        {
            System.Timers.Timer timer = new System.Timers.Timer(time);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            timer.AutoReset = true;
            timer.Enabled = true;
            return timer;
            
        }
     
        UdpClient sendClient;
        IPEndPoint sendMulticast;

        private void createSendUDPClient()
        {
            if (sendClient == null)
            {
                sendClient = new UdpClient(6000);
            }
            if (sendMulticast == null)
            {
                sendMulticast = new IPEndPoint(IPAddress.Parse("224.0.0.101"), 6005);
            }
        }

        UdpClient receClient;
        IPEndPoint receMulticast;

        private void createReceUDPClient()
        {
            if (receClient==null)
            {
                receClient = new UdpClient(6005);
            }
            if (receMulticast == null)
            {
                IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
            }
            receClient.JoinMulticastGroup(IPAddress.Parse("224.0.0.101"));
        }

        private void sendThread()
        {
            while (true)
            {
                byte[] buf = Encoding.Default.GetBytes("ServerIp^"+LoginRoler.serverIp+"^");
//Console.WriteLine("****发送消息"+ "ServerIp^" + LoginRoler.serverIp + "^");
                sendClient.Send(buf, buf.Length, sendMulticast);
            }
        }

        Thread searchServerIpthr;

        private void theout(object sender, ElapsedEventArgs e)
        {
            //超时之后假如是老师或者管理员(非学生登录)则将Ip设定为该机器IP
            
            string user_type = ((ComboxItem)this.comboBox3.Items[comboBox3selectIndex]).Value;
            if (user_type!=Constant.RoleStudent)//管理员和老师
            {
                LoginRoler.serverIp = GetAddressIP();
                isLocalIp = true;
            }
            else
            {
                LoginRoler.serverIp = "";
            }
Console.WriteLine("搜索线程终止且终止定时器,IP:"+ LoginRoler.serverIp);
                searchServerIpthr.Abort();
                timer.Stop();
                RunDoWhile = false;
                //receClient = null;
                //receMulticast = null;
        }

        void RecvThread()
        {
                while (true)
                {
                    byte[] buf = receClient.Receive(ref receMulticast);
                    string msg = Encoding.Default.GetString(buf);
                string[] splitString = msg.Split('^');
                    string swfName = splitString[1];
                    switch (splitString[0])
                    {
                        case "ServerIp"://服务器IP指令
                            Console.WriteLine("接收到局域网中某台机器传送来的IP:" + splitString[1]);
                            LoginRoler.serverIp = splitString[1];
                            //搜索进程结束 且将定时器取消
                            searchServerIpthr.Abort();
                            timer.Stop();
                            RunDoWhile = false;

                            //receClient = null;
                            //receMulticast = null;

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = comboBox2.SelectedItem.ToString();
        }
    }
}
