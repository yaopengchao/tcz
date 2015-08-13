using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ClassDao : CommonDao
    {
        //查询所有班级不进行分页
        public DataSet listClass(Dictionary<string, string> strWheres)
        {
            string strSql = "select class_id, class_name from sys_class where 1 = 1 ";
            return listEntity(strSql, strWheres);
        }

        public int addClass(ClassInfo classInfo)
        {
            string strSql = "insert into sys_class(class_name) values(?className)";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?className", MySqlDbType.VarChar)
            };
            parames[0].Value = classInfo.ClassName;
           return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

    }
}
