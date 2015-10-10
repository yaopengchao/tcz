using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public class BluetoothUtil
    {
        //发送
        public static void BlueToothDataSend(SerialPort BluetoothConnection,string msg)
        {
            byte n;
            byte.TryParse(msg, out n);
            //int length = data.Length;
            //byte[] readData = new byte[length + 2];
            //readData[0] = (byte)(length % 255);
            //readData[1] = (byte)(length / 255);
            //for (int i = 0; i < length; i++)
            //{
            //    readData[i + 2] = data[i];
            //}
            //BluetoothConnection.Write(readData, 0, length + 2);
            BluetoothConnection.Write(new byte[] { n }, 0, 1);
            //Status = "发送数据字节数：" + length;
        }
    }
}
