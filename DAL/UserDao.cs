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
            string strSql = "select a.user_name, a.login_id, a.pwd, a.create_date from sys_user a, sys_user_class b where a.USER_ID = b.USER_ID ";
            return listEntity(strSql, strWheres, startIndex, pageSize);
        }

        //根据条件查询数量
        public int countUsers(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from sys_user a, sys_user_class b where a.USER_ID = b.USER_ID ";
            return countEntity(strSql, strWheres);
        }
    }
}
