using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChatUser
    {
        public string chatIp;

        public string ChatIp
        {
            get { return chatIp; }
            set { chatIp = value; }
        }

        public string chatName;

        public string ChatName
        {
            get { return ChatName; }
            set { ChatName = value; }
        }
    }
}
