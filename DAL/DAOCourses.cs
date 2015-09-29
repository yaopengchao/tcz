using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;

namespace DAL
{
    public class DAOCourses : CommonDao
    {
        public DataSet getAllCourses()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select '' as TCZ_ID, '' as TCZ_NAME, '' as TCZ_ENAME union select TCZ_ID,TCZ_NAME,TCZ_ENAME from  tcz_type ");

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

        public int countSounds(Dictionary<string, string> strWheres)
        {
            string strSql = "select count(1) from  tcz_lessons where 1 = 1 ";
            return countEntity(strSql, strWheres);
        }
      

        public DataSet getSounds(Dictionary<string, string> strWheres, int startIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select LESSON_ID,LESSON_NAME,LESSON_ENAME,LESSON_FILENAME,LESSON_CLASS_ID,LESSON_MUSIC_FILENAME from  tcz_lessons  ");
            strSql.Append(" where ");
            strSql.Append(" 1=1 ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?parentid", MySqlDbType.VarChar)};

            //parameters[0].Value = filter;

            DataSet ds = MySqlHelper.DateSet(strSql.ToString(), parameters);

            return ds;
        }


    }
}
