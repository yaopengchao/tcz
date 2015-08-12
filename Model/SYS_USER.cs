using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SYS_USER
    {
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string userType;
        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        private string pwd;
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
}
