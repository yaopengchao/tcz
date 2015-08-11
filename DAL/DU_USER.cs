using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    public class DU_USER
    {

        public DataSet listUser(SYS_USER user, string strWhere, int startIndex, int pageSize)
        {
            string userName = user.UserName;
            string strSql = "select USER_NAME, LOGIN_ID, PWD, CREATE_DATE from sys_user where 1 = 1 ";
            if (strWhere != null)
                strSql += strWhere;
            strSql += " limit " + startIndex + ", " + pageSize;
            return MySqlHelper.DateSet(strSql);
        }

        public object countUser(SYS_USER user, string strWhere)
        {
            string strSql = "select count(1) from sys_user where 1 = 1 ";
            if (strWhere != null)
                strSql += strWhere;
            return MySqlHelper.ExecuteScalar(strSql);
        }

    }
}
