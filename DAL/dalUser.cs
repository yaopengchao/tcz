using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class dalUser
    {
        /*查询用户*/
        public static System.Data.DataTable GetUser(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
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
    }
}
