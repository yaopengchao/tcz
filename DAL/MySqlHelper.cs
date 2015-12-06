using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Model;
using System.IO;
using System;

namespace DAL
{
    public class MySqlHelper
    {
        private static MySqlConnection mysqlconnection;

        public static MySqlConnection GetMysqlConnection
        {
            get
            {
                string strConn = "server="+ LoginRoler.serverIp + ";Port="+ ConfigurationManager.AppSettings["databaseport"].ToString() + "; user id="+ ConfigurationManager.AppSettings["username"].ToString() + "; password="+ ConfigurationManager.AppSettings["password"].ToString() + "; database="+ ConfigurationManager.AppSettings["database"].ToString() + "; pooling=false;charset=utf8";

                try {
                    if (mysqlconnection == null)
                    {
                        mysqlconnection = new MySqlConnection(strConn);
                        mysqlconnection.Open();
                    }
                    else if (mysqlconnection.State == ConnectionState.Closed)
                    {
                        mysqlconnection = new MySqlConnection(strConn);
                        mysqlconnection.Open();
                    }
                    else if (mysqlconnection.State == ConnectionState.Broken)
                    {
                        mysqlconnection.Close();
                        mysqlconnection.Open();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("数据库连接发生错误:"+ex.Message+"数据库连接地址"+ strConn);
                }
                return mysqlconnection;
            }
        }
       

        public static MySqlCommand MysqlCommand(string strSql)
        {
            using (MySqlCommand cmd = new MySqlCommand(strSql, GetMysqlConnection))
            {
                return cmd;
            }

        }
        
        public static MySqlCommand MysqlCommand(string strSql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(strSql, GetMysqlConnection);
            if (values != null) cmd.Parameters.AddRange(values);
            return cmd;
        }
      
        
        //返回第一行第一列的值 sql语句带参数(查询)
        public static object ExecuteScalar(string strSql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = MysqlCommand(strSql, values);
            return cmd.ExecuteScalar();
        }

        //返回第一行第一列的值 sql语句不带参数(查询)
        public static object ExecuteScalar(string strSql)
        {
            MySqlCommand cmd = MysqlCommand(strSql);
            object obj = cmd.ExecuteScalar();
            mysqlconnection.Close();
            return obj;
        }


        public static int ExecuteNonQuery(string strSql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = MysqlCommand(strSql, values);
            int i = cmd.ExecuteNonQuery();
            mysqlconnection.Close();
            return i;
        }

        public static DataSet DateSet(string strSql)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(strSql, GetMysqlConnection);
            adapter.Fill(ds);
            return ds;
        }

        public static DataSet DateSet(string strSql, MySqlParameter[] param)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(strSql, GetMysqlConnection);
            adapter.SelectCommand.Parameters.AddRange(param);
            adapter.Fill(ds);
            return ds;
        }

        /// <summary> 
        /// 执行Sql文件 
        /// </summary> 
        /// <param name="varFileName">sql文件</param> 
        /// <returns></returns> 
        private static bool ExecuteSqlFile(string varFileName)
        {
            using (StreamReader reader = new StreamReader(varFileName, System.Text.Encoding.GetEncoding("utf-8")))
            {
                MySqlCommand command;
                MySqlConnection Connection = GetMysqlConnection;
                Connection.Open();
                try
                {
                    string line = "";
                    string l;
                    while (true)
                    {
                        // 如果line被使用，则设为空
                        if (line.EndsWith(";"))
                            line = "";

                        l = reader.ReadLine();

                        // 如果到了最后一行，则退出循环
                        if (l == null) break;
                        // 去除空格
                        l = l.TrimEnd();
                        // 如果是空行，则跳出循环
                        if (l == "") continue;
                        // 如果是注释，则跳出循环
                        if (l.StartsWith("--")) continue;

                        // 行数加1 
                        line += l;
                        // 如果不是完整的一条语句，则继续读取
                        if (!line.EndsWith(";")) continue;
                        if (line.StartsWith("/*!"))
                        {
                            continue;
                        }

                        //执行当前行
                        command = new MySqlCommand(line, Connection);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    Connection.Close();
                }
            }

            return true;
        }




    }
}