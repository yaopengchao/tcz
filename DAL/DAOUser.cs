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
        public int ExistsName(string loginId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_user");
            strSql.Append(" where ");
            strSql.Append(" login_id = ?loginId  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?loginId", MySqlDbType.VarChar)};
            parameters[0].Value = loginId;

            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters));
        }


        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string loginId, string pwd,string user_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select login_id,user_name,user_type, user_id from sys_user");
            strSql.Append(" where ");
            strSql.Append(" login_id = ?loginId and pwd=?pwd and user_type=?user_type ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?loginId", MySqlDbType.VarChar),
                    new MySqlParameter("?pwd", MySqlDbType.VarChar),
                    new MySqlParameter("?user_type", MySqlDbType.VarChar)
            };

            parameters[0].Value = loginId;
            parameters[1].Value = pwd;
            parameters[2].Value = user_type;

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
            strSql.Append("  select r.user_ip as ip ,r.user_name as username from chatroom r,sys_user u where r.user_name=u.user_name and u.user_type=?user_type ");

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
        public DataSet getFavorites(string login_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select f.LOGIN_ID as LOGIN_ID,l.LESSON_ID as LESSON_ID,l.LESSON_NAME as NAME,l.LESSON_ENAME as ENAME,l.LESSON_FILENAME as FILENAME,l.LESSON_MUSIC_FILENAME as  MUSICFILENAME from sys_user_favorites f,tcz_lessons l where 1=1 ");
            strSql.Append(" and f.LESSON_ID=l.LESSON_ID ");
            strSql.Append(" and f.LOGIN_ID=?login_id ");
            MySqlParameter[] parameters = {
                new MySqlParameter("?login_id", MySqlDbType.VarChar)
            };

            parameters[0].Value = login_id;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 删除某个收藏
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool deleteFavorite(string login_id, string lesson_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from sys_user_favorites  ");
            strSql.Append(" where ");
            strSql.Append(" login_id=?login_id ");
            strSql.Append(" and ");
            strSql.Append(" lesson_id=?lesson_id ");

            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?login_id", MySqlDbType.VarChar),
                    new MySqlParameter("?lesson_id", MySqlDbType.VarChar)
            };

            parameters0[0].Value = login_id;
            parameters0[1].Value = lesson_id;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加收藏夹文件
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_ip"></param>
        /// <returns></returns>
        public bool addFavorite(string login_id,string lesson_id)
        {
            StringBuilder strSql = new StringBuilder();
            //先检查是否有旧记录
            strSql.Append(" select count(1) from sys_user_favorites  ");
            strSql.Append(" where ");
            strSql.Append(" LOGIN_ID=?login_id ");
            strSql.Append(" and ");
            strSql.Append(" LESSON_ID=?lesson_id ");
            MySqlParameter[] parameters0 = {
                    new MySqlParameter("?login_id", MySqlDbType.VarChar),
                    new MySqlParameter("?lesson_id", MySqlDbType.VarChar)
            };

            parameters0[0].Value = login_id;
            parameters0[1].Value = lesson_id;

            int row0 = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql.ToString(), parameters0));

            if (row0 > 0)
            {
                return true;
            }
            else
            {//inert into
                strSql = new StringBuilder();
                strSql.Append(" insert into sys_user_favorites (LOGIN_ID,LESSON_ID) values ( ");
                strSql.Append(" ?login_id, ");
              
                strSql.Append(" ?lesson_id  ) ");

                MySqlParameter[] parameters = {
                    new MySqlParameter("?login_id", MySqlDbType.VarChar),
               
                    new MySqlParameter("?lesson_id", MySqlDbType.VarChar)
                };

                parameters[0].Value = login_id;
             
                parameters[1].Value = lesson_id;

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
