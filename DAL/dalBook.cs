using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /*图书业务逻辑层实现*/
    public class dalBook
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加图书实现*/
        public static bool AddBook(Model.Book book)
        {
            string sql = "insert into Book(bookName,bookType,price,count,publish,barcode,bookPhoto,publishDate) values(@bookName,@bookType,@price,@count,@publish,@barcode,@bookPhoto,@publishDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookName",SqlDbType.VarChar),
             new SqlParameter("@bookType",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@publish",SqlDbType.VarChar),
             new SqlParameter("@barcode",SqlDbType.VarChar),
             new SqlParameter("@bookPhoto",SqlDbType.Image),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = book.bookName; //图书名称
            parm[1].Value = book.bookType; //图书所在类别
            parm[2].Value = book.price; //图书价格
            parm[3].Value = book.count; //库存
            parm[4].Value = book.publish; //出版社
            parm[5].Value = book.barcode; //图书条形码
            parm[6].Value = book.bookPhoto; //图书图片
            parm[7].Value = book.publishDate; //出版日期

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据barcode获取某条图书记录*/
        public static Model.Book getSomeBook(string barcode)
        {
            /*构建查询sql*/
            string sql = "select * from Book where barcode='" + barcode + "'";
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            Model.Book book = new Model.Book();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                book.bookName = DataRead["bookName"].ToString();
                book.bookType = Convert.ToInt32(DataRead["bookType"]);
                book.price = float.Parse(DataRead["price"].ToString());
                book.count = Convert.ToInt32(DataRead["count"]);
                book.publish = DataRead["publish"].ToString();
                book.barcode = DataRead["barcode"].ToString();
                book.bookPhoto = (byte[])DataRead["bookPhoto"];
                book.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            DataRead.Close();
            return book;
        }

        /*更新图书实现*/
        public static bool EditBook(Model.Book book)
        {
            string sql = "update Book set bookName=@bookName,bookType=@bookType,price=@price,count=@count,publish=@publish,bookPhoto=@bookPhoto,publishDate=@publishDate where barcode=@barcode";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookName",SqlDbType.VarChar),
             new SqlParameter("@bookType",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@publish",SqlDbType.VarChar),
             new SqlParameter("@bookPhoto",SqlDbType.Image),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@barcode",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = book.bookName;
            parm[1].Value = book.bookType;
            parm[2].Value = book.price;
            parm[3].Value = book.count;
            parm[4].Value = book.publish;
            parm[5].Value = book.bookPhoto;
            parm[6].Value = book.publishDate;
            parm[7].Value = book.barcode;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除图书*/
        public static bool DelBook(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                if (i != ids.Length - 1)
                    sql += "'" + ids[i] + "',";
                else
                    sql += "'" + ids[i] + "'";
            }
            sql = "delete from Book where barcode in (" + sql + ")";
            //return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
            return true;
        }


        /*查询图书*/
        public static System.Data.DataTable GetBook(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select Book.*,BookType.bookTypeName from Book,BookType where  Book.bookType=BookType.bookTypeId ";
                string strShow = "barcode as 图书条形码,bookName as 图书名称,bookTypeName as 图书类别,price as 价格,count as 库存,publish as 出版社,convert(char(11),publishDate,20) as 出版日期,bookPhoto as 图书图片";
              
               return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "barcode", strShow, strSql, strWhere, " barcode asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllBook()
        {
            try
            {
                string strSql = "select * from Book";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
