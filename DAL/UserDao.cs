using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDao : CommonDao
    {

        //根据条件进行分页查询
        public DataSet listUsers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select a.user_id, a.user_name, a.login_id, a.pwd, a.create_date from sys_user a, sys_user_class b where a.USER_ID = b.USER_ID ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countUsers(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from sys_user a, sys_user_class b where a.USER_ID = b.USER_ID ";
            return countEntity(strSql, strWheres);
        }

        //根据条件进行分页查询教师
        public DataSet listTeachers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select a.user_id, a.user_name, a.login_id, a.pwd, a.create_date from sys_user a where 1 = 1 ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询教师数量
        public int countTeachers(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from sys_user a where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }

        public int addUser(User user)
        {
            string strSql = "insert into sys_user(login_id, user_name, user_type, pwd, create_date) values(?loginId, ?userName, ?userType, ?pwd, ?createDate); select last_insert_id();";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?loginId", MySqlDbType.VarChar),
                new MySqlParameter("?userName", MySqlDbType.VarChar),
                new MySqlParameter("?userType", MySqlDbType.VarChar),
                new MySqlParameter("?pwd", MySqlDbType.VarChar),
                new MySqlParameter("?createDate", MySqlDbType.VarChar)
            };
            parames[0].Value = user.LoginId;
            parames[1].Value = user.UserName;
            parames[2].Value = user.UserType;
            parames[3].Value = user.Pwd;
            DateTime dt = DateTime.Now;
            parames[4].Value = dt.ToString("yyyy-MM-dd HH:mm:ss"); ;
            int userId = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql, parames));
            user.UserId = userId;
            return userId;
        }

        public int updateUser(User user)
        {
            string strSql = "update sys_user set login_id = ?loginId, user_name = ?userName, pwd = ?pwd where user_id = ?userId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?loginId", MySqlDbType.VarChar),
                new MySqlParameter("?userName", MySqlDbType.VarChar),
                new MySqlParameter("?pwd", MySqlDbType.VarChar),
                new MySqlParameter("?userId", MySqlDbType.Int32)
            };
            parames[0].Value = user.LoginId;
            parames[1].Value = user.UserName;
            parames[2].Value = user.Pwd;
            parames[3].Value = user.UserId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

        public int deleteUser(int userId)
        {
            string strSql = "delete from sys_user where user_id = ?userId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?userId", MySqlDbType.Int32)
            };
            parames[0].Value = userId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }
    }
}
