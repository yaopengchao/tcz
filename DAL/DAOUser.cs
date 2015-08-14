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
        public int ExistsName(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_user");
            strSql.Append(" where ");
            strSql.Append(" user_name = ?user_name  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?user_name", MySqlDbType.VarChar)};
            parameters[0].Value = user_name;

            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters));
        }


        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string user_name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_name,user_type from sys_user");
            strSql.Append(" where ");
            strSql.Append(" user_name = ?user_name and pwd=?pwd ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar),
                    new MySqlParameter("?pwd", MySqlDbType.VarChar)};
            parameters[0].Value = user_name;
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



        public bool inChatroom(string user_name, string user_ip)
        {
            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录没有正确退出
            strSql.Append(" select count(1) from chatroom ");
            strSql.Append(" where ");
            strSql.Append(" user_name=?user_name ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar)
            };

            parameters0[0].Value = user_name;

            int row0= Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)
            {
                //更新数据
                strSql = new StringBuilder();
                strSql.Append(" update chatroom set user_ip=?user_ip ");
                strSql.Append(" where ");
                strSql.Append(" user_name=?user_name ");
                MySqlParameter[] parameters1 = {
                    new MySqlParameter("?user_ip", MySqlDbType.VarChar),
                    new MySqlParameter("?user_name", MySqlDbType.VarChar)
                };

                parameters1[0].Value = user_ip;
                parameters1[1].Value = user_name;


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
                strSql.Append(" insert into chatroom (user_name,user_ip) values ( ");
                strSql.Append(" ?user_name, ");
                strSql.Append(" ?user_ip  ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar),
                    new MySqlParameter("?user_ip", MySqlDbType.VarChar)
                };

                parameters[0].Value = user_name;
                parameters[1].Value = user_ip;

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
            strSql.Append("  select r.user_ip as ip ,r.user_name as username from chatroom r,users u where r.use_rname=u.use_rname and u.user_type=?user_type ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?user_type", MySqlDbType.VarChar)
            };

            parameters[0].Value = "2";

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);
            if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                return (string)ds.Tables[0].Rows[0]["ip"];
            }
            return "";
        }


        public bool outChatroom(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  delete from chatroom where ");
            strSql.Append(" user_name = ?user_name ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar),
            };

            parameters[0].Value = user_name;

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


        /// <summary>
        /// 检索某个用户所有收藏
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public DataSet getFavorites(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select f.user_name as user_name,l.name as name,l.ename as ename,f.filename as filename from favorites f,lessons l where f.filename=l.filename ");
            strSql.Append(" and ");
            strSql.Append(" user_name=?user_name ");
            MySqlParameter[] parameters = {
                new MySqlParameter("?user_name", MySqlDbType.VarChar)
            };

            parameters[0].Value = user_name;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        /// <summary>
        /// 添加收藏夹文件
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_ip"></param>
        /// <returns></returns>
        public bool addFavorite(string user_name,string filename)
        {
            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录没有正确退出
            strSql.Append(" select count(1) from favorites  ");
            strSql.Append(" where ");
            strSql.Append(" user_name=?user_name ");
            strSql.Append(" and ");
            strSql.Append(" filename=?filename ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar),
                    new MySqlParameter("?filename", MySqlDbType.VarChar)
            };

            parameters0[0].Value = user_name;
            parameters0[1].Value = filename;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)
            {
                return true;
            }
            else
            {//inert into
                strSql = new StringBuilder();
                strSql.Append(" insert into favorites (user_name,filename) values ( ");
                strSql.Append(" ?user_name, ");
              
                strSql.Append(" ?filename  ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?user_name", MySqlDbType.VarChar),
               
                    new MySqlParameter("?filename", MySqlDbType.VarChar)
                };

                parameters[0].Value = user_name;
             
                parameters[1].Value = filename;

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
}
