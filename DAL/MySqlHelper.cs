using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;



namespace DAL
{
    public class MySqlHelper
    {
        private static MySqlConnection mysqlconnection;

        public static MySqlConnection GetMysqlConnection
        {
            get
            {
                string strConn = System.Configuration.ConfigurationSettings.AppSettings["strConn"].ToString();
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
            return cmd.ExecuteScalar();
        }





        public static int ExecuteNonQuery(string strSql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = MysqlCommand(strSql, values);
            return cmd.ExecuteNonQuery();
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


      


        

       


    }
}