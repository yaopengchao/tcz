using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LoginRoler
    {

        public static string username;
        public static string truename;
        public static string roleid;
        public static string ip;
        public static int language;
        public static int userId;
        public static string pwd;
        public static string serverIp;
        public static string serverType;

        public static List<OnlineUser> onlineUserlist = new List<OnlineUser>();


        public static Dictionary<string, OnlineUser> onlineUserDic = new Dictionary<string, OnlineUser>();


        public static List<ChatUser>  chatUserlist=new List<ChatUser>();

        public static Dictionary<string, OnlineUser> OnlineUserDic
        {
            get { return onlineUserDic; }
            set { onlineUserDic = value; }
        }

        public static List<ChatUser> ChatUserlist
        {
            get { return chatUserlist; }
            set { chatUserlist = value; }
        }

        public static List<OnlineUser> OnlineUserlist
        {
            get { return onlineUserlist; }
            set { onlineUserlist = value; }
        }
    }
}
