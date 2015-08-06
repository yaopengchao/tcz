using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace LoginFrame
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();

            //更改背景色
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            linkLabel1.Parent = pictureBox1;
            linkLabel2.Parent = pictureBox1;
                       
            string MainImage = "../../pic/" + ConfigurationSettings.AppSettings["LoginImage"].ToString();//登录界面图片
            this.pictureBox1.BackgroundImage = Image.FromFile(MainImage); 
            
            string title = ConfigurationSettings.AppSettings["title"].ToString();//窗口标题
            this.Text = title;

            this.skinEngine1.SkinFile = "../../Skins/" + ConfigurationSettings.AppSettings["image"].ToString();
            this.skinEngine1.SkinAllForm = true;
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

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string version = ConfigurationSettings.AppSettings["version"].ToString();//窗口标题
            this.label3.Text = version;


            checkCode = GetRandomCode(4);
            CreateImage(checkCode);

            this.Opacity = 0;
            timer1.Start();

            string ButtonShow = ConfigurationSettings.AppSettings["ButtonShow"].ToString();//是否显示登录界面密码找回按钮(0:隐藏 1:显示)

            if (ButtonShow == "0")
            {
                linkLabel2.Visible = false;
                linkLabel1.Visible = false;
            }

            this.linkLabel3.Text= ConfigurationSettings.AppSettings["right"].ToString(); 
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="checkCode"></param>
        private void CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 14);
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
        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkCode = GetRandomCode(4);
            CreateImage(checkCode);

            //测试时候直接将验证码写入
            this.textBox1.Text = checkCode;
        }

        /// <summary>
        /// 窗体显示效果
        /// </summary>
        double dou = 0.5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += dou;
            if (this.Opacity == 1)
            {
                timer1.Stop();
                dou = -0.05;

            }
            else if (this.Opacity == 0)
            {
                timer1.Stop();
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.txt_username.Text;

            string password = this.txt_Pwd.Text;

            if (username == "")
            {
                MessageBox.Show("用户名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (password == "")
            {
                MessageBox.Show("密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
         
            else if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("验证码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 
            else
            {
                if (checkCode.ToLower() != this.textBox1.Text.Trim().ToLower())
                {
                    MessageBox.Show("验证码输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    BU_UserInfo Bll = new BU_UserInfo();

                    int a = Bll.ExistsName(username);

                    if (a != 0)
                    {
                        //密码处理,经过加密
                        byte[] result = Encoding.Default.GetBytes(password);//password为输入密码的文本框
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] output = md5.ComputeHash(result);

                        //DataSet ds = Bll.ExistsPwd(username, BitConverter.ToString(output).Replace("-", ""));
                        DataSet ds = Bll.ExistsPwd(username, password);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("登录成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
                            LoginRoler.username= Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
                            LoginRoler.truename = Convert.ToString(ds.Tables[0].Rows[0][1].ToString());
                            LoginRoler.roleid = Convert.ToString(ds.Tables[0].Rows[0][2].ToString());
                            
                            this.Visible = false;
                            checkCode = "";
                            Frm登陆成功显示进度 frm = new Frm登陆成功显示进度();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("密码输入错误,请重新输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.txt_Pwd.Text = "";
                            this.txt_username.Text = "";
                            this.textBox1.Text = "";
                            pictureBox2_Click(sender, e);//调用刷新验证码方法
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在,请重新输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txt_Pwd.Text = "";
                        this.txt_username.Text = "";
                        this.textBox1.Text = "";
                        pictureBox2_Click(sender, e);//调用刷新验证码方法
                    }
                }
            }
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.getName += new GetName(login_getName);
            login.ShowDialog();
        }

        //委托获取传来的值
        public void login_getName(string s)
        {
            this.txt_username.Text = s;
        }
        //密码找回
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm找回密码 frm = new Frm找回密码();
            frm.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
