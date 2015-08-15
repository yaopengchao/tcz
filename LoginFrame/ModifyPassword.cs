using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class ModifyPassword : Form
    {
        public MainFrame mainFram;        

        private Boolean oldPwdValid = false;

        private Boolean newValid = false;

        private Boolean newConfValid = false;

        public ModifyPassword()
        {
            InitializeComponent();
            if (mainFram == null)
            {
                mainFram = new MainFrame();
            }
        }

        private void ModifyPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPwd_Leave(object sender, EventArgs e)
        {
            string oldPwd = txtOldPwd.Text;
            if (oldPwd == null || oldPwd.Equals(""))
            {
                oldPwdValid = false;
                MessageBox.Show("原密码不能为空");
            } else
            {
                oldPwdValid = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oldPwdValid && newValid && newConfValid)
            {
                MessageBox.Show("验证成功");
            } else
            {
                MessageBox.Show("验证失败");
            }
        }

        private void txtNewPwd_Leave(object sender, EventArgs e)
        {
            string newPwd = txtNewPwd.Text;
            if (newPwd == null || newPwd.Equals(""))
            {
                newValid = false;
                MessageBox.Show("新密码不能为空");
            }
            else
            {
                newValid = true;
            }
        }

        private void txtNewConfPwd_Leave(object sender, EventArgs e)
        {
            string newConfPwd = txtNewConfPwd.Text;
            if (newConfPwd == null || newConfPwd.Equals(""))
            {
                newConfValid = false;
                MessageBox.Show("确认密码不能为空");
            }
            else
            {
                newConfValid = true;
            }
        }
    }
}
