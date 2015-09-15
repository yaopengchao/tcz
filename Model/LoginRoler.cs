using InTheHand.Net;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Model
{
    public class LoginRoler
    {

        public static string login_id;


        public static string username;
        public static string roleid;
        public static string ip;
        public static int language;
        public static int userId;
        public static string pwd;
        public static string serverIp;
        public static string serverType;

        public static bool isLocalIp;

        public static List<string> sendMsglist = new List<string>();

        public static List<OnlineUser> onlineUserlist = new List<OnlineUser>();


        public static Dictionary<string, OnlineUser> onlineUserDic = new Dictionary<string, OnlineUser>();


        public static Dictionary<string, SerialPort> tzmonitors = new Dictionary<string, SerialPort>();//听诊模拟人

        public static List<string> SendMsglist
        {
            get { return sendMsglist; }
            set { sendMsglist = value; }
        }


        public static Dictionary<string, SerialPort> Tzmonitors
        {
            get { return tzmonitors; }
            set { tzmonitors = value; }
        }

        public static Dictionary<string, SerialPort> czmonitors = new Dictionary<string, SerialPort>();//触诊模拟人

        public static Dictionary<string, SerialPort> Czmonitors
        {
            get { return czmonitors; }
            set { czmonitors = value; }
        }


        public static List<ChatUser> chatUserlist = new List<ChatUser>();

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
