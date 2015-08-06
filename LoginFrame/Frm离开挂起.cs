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
    public partial class Frm离开挂起 : Form
    {
        public Frm离开挂起()
        {
            InitializeComponent();
            this.lbuser.Text = LoginRoler.truename.ToString();
        }
        private void butjiesuo_Click(object sender, EventArgs e)
        {
            string password = txtpwd.Text;

            if (txtpwd.Text == "")
            {
                MessageBox.Show("密码输入不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //密码处理,经过加密
                //byte[] result = Encoding.Default.GetBytes(password);//password为输入密码的文本框
               // MD5 md5 = new MD5CryptoServiceProvider();
               // byte[] output = md5.ComputeHash(result);

                BU_UserInfo bll = new BU_UserInfo();
                //DataSet ds = bll.ExistsPwd(lbuser.Text.Trim(), BitConverter.ToString(output).Replace("-", ""));
                DataSet ds = bll.ExistsPwd(LoginRoler.username.ToString(), password);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("解锁成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码输入错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        //退出
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
        private void Frm离开挂起_Load(object sender, EventArgs e)
        {
            this.lbuser.Text = LoginRoler.U_Name;
        }
    }
}
