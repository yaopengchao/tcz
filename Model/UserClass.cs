using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserClass
    {

        private int userClassId;
        public int UserClassId
        {
            get { return userClassId; }
            set { userClassId = value; }
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int classId;
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

    }
}
