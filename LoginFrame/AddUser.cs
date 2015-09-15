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

        public BodyTea bodyTea;

        public User user = new User();

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
            if (userService == null)
            {
                userService = new UserService();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddUser));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            int userId = Convert.ToInt32(labUserId.Text == "" ? "0" : labUserId.Text);
            user.LoginId = txtLoginId.Text;
            user.UserName = txtUserName.Text;
            user.Pwd = txtPwd.Text;
            string userType = user.UserType;
            if (userId > 0)            //修改
            {
                user.UserId = userId;
                result = userService.updateUser(user);
            } else
            {                
                if ("3".Equals(userType))
                {
                    result = userService.addUser(user, bodyStu.classId);
                } else if ("2".Equals(userType))
                {
                    result = userService.addUser(user, 0);
                }
            }

            if (result > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
                if ("3".Equals(userType))
                {
                    bodyStu.btnQueryClick();
                } else if ("2".Equals(userType))
                {
                    bodyTea.btnQueryClick();
                }
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
