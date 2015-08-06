using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class billUser
    {
        /*根据条件分页查询用户*/
        public static System.Data.DataTable GetUser(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalBook.GetBook(NowPage, PageSize, out AllPage, out DataCount, p);
        }
    }
}
