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

            strSql.Append(" select TCZ_ID,TCZ_NAME,TCZ_ENAME from  tcz_type ");

            MySqlParameter[] parameters = {};


            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        public DataSet getCourses(string parentid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select CLASS_ID,CLASS_NAME,CLASS_ENAME from  tcz_classes   ");
            strSql.Append(" where ");
            strSql.Append(" CLASS_TYPE_ID=?parentid ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?parentid", MySqlDbType.VarChar)};

            parameters[0].Value = parentid;


            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


        public DataSet getLessons(string parentid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select LESSON_ID,LESSON_NAME,LESSON_ENAME,LESSON_FILENAME,LESSON_MUSIC_FILENAME from  tcz_lessons  ");
            strSql.Append(" where ");
            strSql.Append(" LESSON_CLASS_ID=?parentid ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?parentid", MySqlDbType.VarChar)};

            parameters[0].Value = parentid;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }

    }
}
