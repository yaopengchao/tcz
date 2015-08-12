using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {

        public User() { }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string loginId;
        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
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

        private string createDate;
        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

    }
}
