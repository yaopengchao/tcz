using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
    public class UserDao
    {

        public DataSet listUsers()
        {
            string strSql = "select user_name, login_id, pwd, create_date from sys_user where 1 = 1";
            return MySqlHelper.DateSet(strSql);
        }

        public int countUsers()
        {
            string strSql = "select count(1) from sys_user where 1 = 1";
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql));
        }

    }
}
