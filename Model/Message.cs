using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 模拟人消息s
    /// </summary>
    public class Message
    {
        public string head;

        public string Head
        {
            get { return head; }
            set { head = value; }
        }

        public string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        public string control;
        public string Control
        {
            get { return control; }
            set { control = value; }
        }
        public string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string end;
        public string End
        {
            get { return end; }
            set { end = value; }
        }

    }
}
