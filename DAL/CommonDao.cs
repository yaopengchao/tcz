using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class CommonDao
    {

        public int countEntity(string strSql, Dictionary<string, string> strWheres)
        {
            strSql = getSql(strSql, strWheres);
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(strSql));
        }

        public DataSet listEntity(string strSql)
        {
            return listEntity(strSql, null, -1, 0);
        }

        public DataSet listEntity(string strSql, Dictionary<string, string> strWheres)
        {
            return listEntity(strSql, strWheres, -1, 0);
        }

        public DataSet listEntity(string strSql, Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            strSql = getSql(strSql, strWheres);
            if (startIndex > -1 && pageSize > 0)
                strSql += " limit " + startIndex + ", " + pageSize;
            return MySqlHelper.DateSet(strSql);
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
