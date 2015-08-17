using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlInstallProj
{
    public partial class Form1 : Form
    {

        private Process p;

        public Form1()
        {
            InitializeComponent();
            p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            p.Start();
            //停止mysql服务
            exeCmd("net stop MySQL");
            //进入固定mysql地址
            cdFixDBPath();
            //卸载mysql
            exeCmd("mysqld remove");
            //进入打包好的mysql地址
            cdDiyDBPath();
            //安装mysql
            exeCmd("mysqld install");
            //启动mysql服务
            exeCmd("net start mysql");
            p.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Start();
            //停止mysql服务
            exeCmd("net stop MySQL");
            //进入打包好的mysql地址
            cdDiyDBPath();
            //卸载mysql
            exeCmd("mysqld remove");
            //进入固定mysql地址
            cdFixDBPath();            
            //安装mysql
            exeCmd("mysqld install");
            //启动mysql服务
            exeCmd("net start mysql");
            p.Close();
        }

        private void cdFixDBPath()
        {
            string dMsql = "D:/software/mysql-5.6.24-win32/bin";
            p.StandardInput.WriteLine("d:");
            p.StandardInput.WriteLine("cd " + dMsql);
        }

        //进入程序打包好的mysql目录
        private void cdDiyDBPath()
        {
            string curPath = Environment.CurrentDirectory.ToString();
            int index = curPath.IndexOf(":");
            string hardPath = curPath.Substring(0, index + 1);

            p.StandardInput.WriteLine(hardPath);
            p.StandardInput.WriteLine("cd " + curPath);
            p.StandardInput.WriteLine("cd ../../db/mysql-5.6.24-win32/bin");
        }

        private void exeCmd(string cmd)
        {
            p.StandardInput.WriteLine(cmd);
        }

    }
}
