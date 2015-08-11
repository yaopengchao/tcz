﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using BLL;

using System.Threading;
using System.Globalization;

namespace LoginFrame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("中文简体");
            comboBox1.Items.Add("English");
            comboBox1.SelectedIndex = 0;

            //this.textBox1.Text = "manager";
            //this.textBox2.Text = "manager";


            this.comboBox2.Items.Add("admin");
            this.comboBox2.Items.Add("student");
            this.comboBox2.Items.Add("teacher");

            comboBox2.SelectedIndex = 0;

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

                        DataSet ds = Bll.ExistsPwd(username, password);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            LoginRoler.username = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
                            LoginRoler.truename = Convert.ToString(ds.Tables[0].Rows[0][1].ToString());
                            LoginRoler.roleid = Convert.ToString(ds.Tables[0].Rows[0][2].ToString());
                            LoginRoler.language = comboBox1.SelectedIndex;
                            LoginRoler.ip = GetAddressIP();


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



        private void button1_Click(object sender, EventArgs e)
        {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedItem.ToString()+"/"+comboBox1.SelectedIndex);
            if (comboBox1.SelectedIndex==0)
            {
                //更改当前线程的 CultureInfo
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }else if (comboBox1.SelectedIndex == 1)
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
