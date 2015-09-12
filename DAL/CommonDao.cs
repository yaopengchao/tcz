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

        public int countEntityGroup(string strSql, Dictionary<string, string> strWheres,string strGroup)
        {
            strSql = getSqlGroup(strSql, strWheres, strGroup);
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(" select count(1) from ("+strSql+") t "));
        }

        public DataSet listEntity(string strSql)
        {
            return listEntity(strSql, null, -1, 0);
        }

        public DataSet listEntity(string strSql, Dictionary<string, string> strWheres)
        {
            return listEntity(strSql, strWheres, -1, 0);
        }

        public DataSet listEntityGroup(string strSql, Dictionary<string, string> strWheres,string strGroup)
        {
            return listEntityGroup(strSql, strWheres, -1, 0, strGroup);
        }

        

        public DataSet listEntity(string strSql, Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            strSql = getSql(strSql, strWheres);
            if (startIndex > -1 && pageSize > 0)
                strSql += " limit " + startIndex + ", " + pageSize;
            return MySqlHelper.DateSet(strSql);
        }

        public DataSet listEntityGroup(string strSql, Dictionary<string, string> strWheres, int startIndex, int pageSize,string strGroup)
        {
            strSql = getSqlGroup(strSql, strWheres, strGroup);
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


        public string getSqlGroup(string strSql, Dictionary<string, string> strWheres,string strGroup)
        {
            if (strWheres != null && strWheres.Count > 0)
            {
                foreach (string key in strWheres.Keys)
                {
                    strSql += " and " + key + strWheres[key];
                }
            }
            return strSql+ strGroup;
        }

    }
}
