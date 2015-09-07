using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{
    public partial class ModifyPassword : Form
    {
        public MainFrame mainFram;                

        private int userId;

        private UserService userService;

        public ModifyPassword()
        {
            InitializeComponent();
            userId = LoginRoler.userId;
            userService = UserService.getInstance();
            if (mainFram == null)
            {
                mainFram = new MainFrame();
            }
        }

        private void ModifyPassword_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(ModifyPassword));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPwd_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPwd = txtOldPwd.Text;
            string newPwd = txtNewPwd.Text;
            string newConfPwd = txtNewConfPwd.Text;
            if (oldPwd == null || oldPwd.Equals(""))
            {
                MessageBox.Show("原密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
            }
            else if (newPwd == null || newPwd.Equals(""))
            {
                MessageBox.Show("新密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (newConfPwd == null || newConfPwd.Equals(""))
            {
                MessageBox.Show("确认密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string curPwd = LoginRoler.pwd;
                if (!oldPwd.Equals(curPwd))               //原密码不对
                {
                    txtOldPwd.Text = "";
                    MessageBox.Show("原密码不正确，请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (!newConfPwd.Equals(newPwd))
                    {
                        txtNewConfPwd.Text = "";
                        MessageBox.Show("两次输入的密码不一致，请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        int result = userService.modifyPwd(userId, newPwd);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功");
                            LoginRoler.pwd = newPwd;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("保存失败，请联系管理员");
                        }
                    }
                }
            }
        }

        private void txtNewPwd_Leave(object sender, EventArgs e)
        {

        }

        private void txtNewConfPwd_Leave(object sender, EventArgs e)
        {
        }
    }
}
