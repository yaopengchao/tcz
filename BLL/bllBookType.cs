using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    /*图书类型业务逻辑层*/
    public class bllBookType{
        /*添加图书类型*/
        public static bool AddBookType(Model.BookType bookType)
        {
            return DAL.dalBookType.AddBookType(bookType);
        }

        /*根据bookTypeId获取某条图书类型记录*/
        public static Model.BookType getSomeBookType(int bookTypeId)
        {
            return DAL.dalBookType.getSomeBookType(bookTypeId);
        }

        /*更新图书类型*/
        public static bool EditBookType(Model.BookType bookType)
        {
            return DAL.dalBookType.EditBookType(bookType);
        }

        /*删除图书类型*/
        public static bool DelBookType(string p)
        {
            return DAL.dalBookType.DelBookType(p);
        }

        /*根据条件分页查询图书类型*/
        public static System.Data.DataTable GetBookType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalBookType.GetBookType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的图书类型*/
        public static System.Data.DataSet getAllBookType()
        {
            return DAL.dalBookType.getAllBookType();
        }
    }
}
