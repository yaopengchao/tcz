using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserClassDao
    {

        //添加学生与班级关系
        public int addUserClass(UserClass userClass)
        {
            string strSql = "insert into sys_user_class(user_id, class_id) values(?userId, ?classId)";
            MySqlParameter[] parames = new MySqlParameter[] {
                new MySqlParameter("?userId", MySqlDbType.Int32),
                new MySqlParameter("?classId", MySqlDbType.Int32)
            };
            parames[0].Value = userClass.UserId;
            parames[1].Value = userClass.ClassId;
            return MySqlHelper.ExecuteNonQuery(strSql, parames);
        }

    }
}
