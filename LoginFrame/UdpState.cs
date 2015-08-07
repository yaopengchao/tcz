using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LoginFrame
{
    class UdpState
    {

        private UdpClient myudpClient;

        public UdpClient MyudpClient
        {
            get { return myudpClient; }
            set { myudpClient = value; }
        }
        private IPEndPoint ipEndPoint;

        public IPEndPoint IpEndPoint
        {
            get { return ipEndPoint; }
            set { ipEndPoint = value; }
        }
    }
}
