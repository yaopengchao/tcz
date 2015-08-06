using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace LoginFrame
{
    public partial class Frm找回密码 : Form
    {
        public Frm找回密码()
        {
            InitializeComponent();
        }
        public string Pagetype = "";//操作类型

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select = cmbQuestion.SelectedIndex.ToString();

            string password = this.txt_anask.Text;

            BU_UserInfo Bll = new BU_UserInfo();

            if (Pagetype == "false")//完善个人资料
            {
                if (select == "-1")
                {
                    MessageBox.Show("请选择密保!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (password == "")
                {
                    MessageBox.Show("回答不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    bool flag = Bll.UpdateU_PsdAnswer(Convert.ToInt32(select), password, LoginRoler.U_Id);

                    if (flag)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("申请失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else //登录
            {
                string username = this.txt_UserName.Text;

                if (username == "")
                {
                    MessageBox.Show("用户名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (select == "-1")
                {
                    MessageBox.Show("请选择密保!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (password == "")
                {
                    MessageBox.Show("回答不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int a = Bll.ExistsName(username);

                    if (a != 0)
                    {
                        //密码处理,经过加密
                        DataSet ds = Bll.ShowPwd(username, password.Trim());

                        string PWD = ds.Tables[0].Rows[0][0].ToString();
                        if (PWD != "")
                        {
                            MessageBox.Show("查询成功!你的密码是:<" + PWD + ">  请牢记", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("密保输入错误,请重新输入密保", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.txt_anask.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在,请重新输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txt_UserName.Text = "";
                    }

                }
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm找回密码_Load(object sender, EventArgs e)
        {
            InitSet();

            //隐藏用户名
            if (Pagetype == "false")
            {
                label1.Visible = false;
                txt_UserName.Visible = false;
            }
        }

        /// <summary>
        /// 加载所有问题类型
        /// </summary>
        public void InitSet()
        {
            BU_UserInfo bll = new BU_UserInfo();
            DataSet ds = bll.GetMP_PasswordType();

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.cmbQuestion.DataSource = ds.Tables[0];
                cmbQuestion.DisplayMember = "U_Name";
                cmbQuestion.ValueMember = "P_Id";
            }
            else
            {
                cmbQuestion.Text = "=暂停访问=";
            }
        }

        /// <summary>
        /// 传递参数
        public void Message(string type)
        {
            this.Pagetype = type;
        }
    }
}
