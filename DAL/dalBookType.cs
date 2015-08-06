using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Model;

namespace DAL
{
    /*ͼ������ҵ���߼���ʵ��*/
    public class dalBookType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ͼ������ʵ��*/
        public static bool AddBookType(Model.BookType bookType)
        {
            string sql = "insert into BookType(bookTypeName,days) values(@bookTypeName,@days)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookTypeName",SqlDbType.VarChar),
             new SqlParameter("@days",SqlDbType.Int)
            };
            /*��������ֵ*/
            parm[0].Value = bookType.bookTypeName; //�������
            parm[1].Value = bookType.days; //�ɽ�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����bookTypeId��ȡĳ��ͼ�����ͼ�¼*/
        public static Model.BookType getSomeBookType(int bookTypeId)
        {
            /*������ѯsql*/
            string sql = "select * from BookType where bookTypeId=" + bookTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            Model.BookType bookType = new Model.BookType();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                bookType.bookTypeId = Convert.ToInt32(DataRead["bookTypeId"]);
                bookType.bookTypeName = DataRead["bookTypeName"].ToString();
                bookType.days = Convert.ToInt32(DataRead["days"]);
            }
            return bookType;
        }

        /*����ͼ������ʵ��*/
        public static bool EditBookType(Model.BookType bookType)
        {
            string sql = "update BookType set bookTypeName=@bookTypeName,days=@days where bookTypeId=@bookTypeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookTypeName",SqlDbType.VarChar),
             new SqlParameter("@days",SqlDbType.Int),
             new SqlParameter("@bookTypeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = bookType.bookTypeName;
            parm[1].Value = bookType.days;
            parm[2].Value = bookType.bookTypeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ͼ������*/
        public static bool DelBookType(string p)
        {
            string sql = "delete from BookType where bookTypeId in (" + p + ") ";
            //return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
            return true;
        }


        /*��ѯͼ������*/
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
