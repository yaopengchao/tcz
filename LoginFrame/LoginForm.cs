using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //登录代码

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
            this.Visible = false;
            checkCode = "";

            //互相访问控件
            titleMain.bodyMain = bodyMain;
            bodyMain.titleMain = titleMain;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
