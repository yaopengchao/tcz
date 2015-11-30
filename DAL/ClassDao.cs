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

        public DataSet getAllClasses()
        {
            string strSql = " select CLASS_ID as CLASS_ID,CLASS_NAME as CLASS_NAME from sys_class where 1 = 1  ";
            return listEntity(strSql, null);
        }

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

        public int updateClass(ClassInfo classInfo)
        {
            string strSql = "update sys_class set class_name = ?className where class_id = ?classId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?className", MySqlDbType.VarChar),
                new MySqlParameter("?classId", MySqlDbType.Int32)
            };
            parames[0].Value = classInfo.ClassName;
            parames[1].Value = classInfo.ClassId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

        public int deleteClass(int classId)
        {
            string strSql = "delete from sys_class where class_id = ?classId";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?classId", MySqlDbType.Int32)
            };
            parames[0].Value = classId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

    }
}
