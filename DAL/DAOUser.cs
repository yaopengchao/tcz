using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using Model;

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
    }
}
