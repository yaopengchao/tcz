using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace DAL
{
    public class DAOUser
    {
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int ExistsName(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from users");
            strSql.Append(" where ");
            strSql.Append(" username = ?username  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?username", MySqlDbType.VarChar)};
            parameters[0].Value = username;

            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters));
        }


        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string username, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select username,truename,roleid from users");
            strSql.Append(" where ");
            strSql.Append(" username = ?username and password=?password ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar),
                    new MySqlParameter("?password", MySqlDbType.VarChar)};
            parameters[0].Value = username;
            parameters[1].Value = pwd;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        public DataSet getUsersFromChatroom()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select username,truename,ip from chatroom ");
            MySqlParameter[] parameters = {
            };

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }



        /// <summary>
        /// 记录登录用户日志
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        /// <returns></returns>

        public bool logLogin(string username, string loginip)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into online (username,logintime,loginip) values ( ");
            strSql.Append(" username = ?username, ");
            strSql.Append(" sysdate(), ");
            strSql.Append(" loginip = ?loginip ) ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar),
                    new MySqlParameter("?loginip", MySqlDbType.VarChar)};

            parameters[0].Value = username;
            parameters[1].Value = loginip;

            int rows = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool inChatroom(string username, string truename, string ip)
        {
            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录没有正确退出
            strSql.Append(" select count(1) from chatroom ");
            strSql.Append(" where ");
            strSql.Append(" username=?username ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?username", MySqlDbType.VarChar)
            };

            parameters0[0].Value = username;

            int row0= Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)
            {
                //更新数据
                strSql = new StringBuilder();
                strSql.Append(" update chatroom set truename=?truename,ip=?ip ");
                strSql.Append(" where ");
                strSql.Append(" username=?username ");
                MySqlParameter[] parameters1 = {
                    new MySqlParameter("?truename", MySqlDbType.VarChar),
                    new MySqlParameter("?ip", MySqlDbType.VarChar),
                    new MySqlParameter("?username", MySqlDbType.VarChar)
                };

                parameters1[0].Value = username;
                parameters1[1].Value = truename;
                parameters1[2].Value = ip;


                int rows1 = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters1);
                if (rows1 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {//inert into
                strSql = new StringBuilder();
                strSql.Append(" insert into chatroom (username,truename,ip) values ( ");
                strSql.Append(" ?username, ");
                strSql.Append(" ?truename, ");
                strSql.Append(" ?ip  ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar),
                    new MySqlParameter("?truename", MySqlDbType.VarChar),
                    new MySqlParameter("?ip", MySqlDbType.VarChar)
            };

                parameters[0].Value = username;
                parameters[1].Value = truename;
                parameters[2].Value = ip;

                int rows = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string getServerIp()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select r.ip as ip ,r.username as username,u.truename as truename from chatroom r,users u where r.username=u.username and u.roleid=?roleid ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?roleid", MySqlDbType.VarChar)
            };

            parameters[0].Value = "teacher";

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);
            if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                return (string)ds.Tables[0].Rows[0]["ip"];
            }
            return "";
        }


        public bool outChatroom(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  delete from chatroom where ");
            strSql.Append(" username = ?username ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar),
            };

            parameters[0].Value = username;

            int rows = MySqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
