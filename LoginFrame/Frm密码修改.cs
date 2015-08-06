using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace LoginFrame
{
    public partial class Frm密码修改 : Form
    {
        public Frm密码修改()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = this.txt_pwd.Text.Trim();//密码1
            string pwd2 = this.txt_pwd2.Text.Trim();//密码2

            if (pwd == "")
            {
                MessageBox.Show("密码不能为空,请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pwd2 == "")
            {
                MessageBox.Show("确认密码不能为空,请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pwd != pwd2)
            {
                MessageBox.Show("密码输入不相同,请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txt_pwd2.Text = "";
            }
            else
            {
                BU_UserInfo bll = new BU_UserInfo();

                string username = LoginRoler.username;

                //密码处理,经过加密
                //byte[] result = Encoding.Default.GetBytes(pwd2);//pwd2为输入密码的文本框
                //MD5 md5 = new MD5CryptoServiceProvider();
                //byte[] output = md5.ComputeHash(result);

                //string NewPwd = BitConverter.ToString(output).Replace("-", "");

                string NewPwd = pwd2;

                bool flag = bll.UpdatePassword(NewPwd, username);

                if (flag)
                {
                    MessageBox.Show("密码更改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("密码更改失败,关闭后请重新更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.Close();
            }
        }
    }
}
