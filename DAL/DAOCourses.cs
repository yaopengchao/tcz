using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace DAL
{
    public class DAOCourses
    {
        public DataSet getAllCourses()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select '' as id , '' as name , '' as enname   union select id,name,enname from  classify ");

            MySqlParameter[] parameters = {};


            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        public DataSet getCourses(string parentid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select id,name,enname from  clauses   ");
            strSql.Append(" where ");
            strSql.Append(" parentid=?parentid ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?parentid", MySqlDbType.VarChar)};

            parameters[0].Value = parentid;


            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        public DataSet getLessons(string parentid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select id,name,ename,filename from  lessons   ");
            strSql.Append(" where ");
            strSql.Append(" parentid=?parentid ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?parentid", MySqlDbType.VarChar)};

            parameters[0].Value = parentid;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }

    }
}
