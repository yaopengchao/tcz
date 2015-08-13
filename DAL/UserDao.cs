using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDao
    {

        public DataSet listUsers()
        {
            string strSql = "select user_name, login_id, pwd, create_date from sys_user where 1 = 1 ";
            return listUsers(null, -1, 0);
        }

        public DataSet listUsers(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            string strSql = "select user_name, login_id, pwd, create_date from sys_user where 1 = 1 ";
            strSql = getSql(strSql, strWheres);
            if (startIndex > -1 && pageSize > 0)
                strSql += " limit " + startIndex + ", " + pageSize;
            return MySqlHelper.DateSet(strSql);
        }

        public int countUsers(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from sys_user where 1 = 1 ";
            strSql = getSql(strSql, strWheres);
            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql));
            return count;
        }

        public string getSql(string strSql, Dictionary<string, string> strWheres)
        {
            if (strWheres != null && strWheres.Count > 0)
            {
                foreach (string key in strWheres.Keys)
                {
                    strSql += " and " + key + strWheres[key];
                }
            }
            return strSql;
        }

    }
}
