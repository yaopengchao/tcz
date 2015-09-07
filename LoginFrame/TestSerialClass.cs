using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace LoginFrame
{
    class TestSerialClass
    {
        static SerialClass sc = new SerialClass("COM1");
        static void Main(string[] Args)
        {
            sc.DataReceived += new SerialClass.SerialPortDataReceiveEventArgs(sc_DataReceived);
            sc.SendData("at");
            Console.ReadLine();
            sc.closePort();
        }
        static void sc_DataReceived(object sender, SerialDataReceivedEventArgs e, byte[] bits)
        {
            Console.WriteLine(Encoding.Default.GetString(bits));
        }
    }
}
