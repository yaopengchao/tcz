﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class OnlineUser
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
            get { return chatName; }
            set { chatName = value; }
        }

        //是否在聊天
        public bool isChating=false;

        public bool IsChating
        {
            get { return isChating; }
            set { isChating = value; }
        }

    }
}
