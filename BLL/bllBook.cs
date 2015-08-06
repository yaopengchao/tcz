using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{

    
    /*图书业务逻辑层*/
    public class bllBook
    {
        /*添加图书*/
        public static bool AddBook(Model.Book book)
        {
            return DAL.dalBook.AddBook(book);
        }

        /*根据barcode获取某条图书记录*/
        public static Model.Book getSomeBook(string barcode)
        {
            return DAL.dalBook.getSomeBook(barcode);
        }

        /*更新图书*/
        public static bool EditBook(Model.Book book)
        {
            return DAL.dalBook.EditBook(book);
        }

        /*删除图书*/
        public static bool DelBook(string p)
        {
            return DAL.dalBook.DelBook(p);
        }

        /*根据条件分页查询图书*/
        public static System.Data.DataTable GetBook(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalBook.GetBook(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的图书*/
        public static System.Data.DataSet getAllBook()
        {
            return DAL.dalBook.getAllBook();
        }
    }
}
