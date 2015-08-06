using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Model;

namespace DAL
{
    /*图书类型业务逻辑层实现*/
    public class dalBookType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加图书类型实现*/
        public static bool AddBookType(Model.BookType bookType)
        {
            string sql = "insert into BookType(bookTypeName,days) values(@bookTypeName,@days)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookTypeName",SqlDbType.VarChar),
             new SqlParameter("@days",SqlDbType.Int)
            };
            /*给参数赋值*/
            parm[0].Value = bookType.bookTypeName; //类别名称
            parm[1].Value = bookType.days; //可借阅天数

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据bookTypeId获取某条图书类型记录*/
        public static Model.BookType getSomeBookType(int bookTypeId)
        {
            /*构建查询sql*/
            string sql = "select * from BookType where bookTypeId=" + bookTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            Model.BookType bookType = new Model.BookType();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                bookType.bookTypeId = Convert.ToInt32(DataRead["bookTypeId"]);
                bookType.bookTypeName = DataRead["bookTypeName"].ToString();
                bookType.days = Convert.ToInt32(DataRead["days"]);
            }
            return bookType;
        }

        /*更新图书类型实现*/
        public static bool EditBookType(Model.BookType bookType)
        {
            string sql = "update BookType set bookTypeName=@bookTypeName,days=@days where bookTypeId=@bookTypeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookTypeName",SqlDbType.VarChar),
             new SqlParameter("@days",SqlDbType.Int),
             new SqlParameter("@bookTypeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = bookType.bookTypeName;
            parm[1].Value = bookType.days;
            parm[2].Value = bookType.bookTypeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除图书类型*/
        public static bool DelBookType(string p)
        {
            string sql = "delete from BookType where bookTypeId in (" + p + ") ";
            //return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
            return true;
        }


        /*查询图书类型*/
        public static System.Data.DataTable GetBookType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from BookType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "bookTypeId", strShow, strSql, strWhere, " bookTypeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllBookType()
        {
            try
            {
                string strSql = "select * from BookType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
