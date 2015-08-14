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
    public partial class AddUser : Form
    {

        private static AddUser instance;

        private static UserService userService;

        public BodyStu bodyStu;

        public static AddUser getInstance()
        {

            instance = new AddUser();

            if (userService == null)
            {
                userService = new UserService();
            }

            return instance;
        }

        public AddUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            int userId = Convert.ToInt32(labUserId.Text);
            User user = new User();
            user.LoginId = txtLoginId.Text;
            user.UserName = txtUserName.Text;
            user.UserType = "3";
            user.Pwd = txtPwd.Text;
            DateTime dt = DateTime.Now;
            if (userId > 0)            //修改
            {
                user.UserId = userId;
                result = userService.updateUser(user);
            } else
            {
                user.CreateDate = dt.ToString("yyyy-MM-dd HH: mm:ss");
                result = userService.addUser(user, bodyStu.classId);
            }

            if (result > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
                bodyStu.btnQueryClick();
            }
            else
            {
                MessageBox.Show("保存失败，请联系管理员");
            }
        }

        private void labUserId_Click(object sender, EventArgs e)
        {

        }
    }
}
