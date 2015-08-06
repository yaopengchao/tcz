using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    /*ͼ������ҵ���߼���*/
    public class bllBookType{
        /*���ͼ������*/
        public static bool AddBookType(Model.BookType bookType)
        {
            return DAL.dalBookType.AddBookType(bookType);
        }

        /*����bookTypeId��ȡĳ��ͼ�����ͼ�¼*/
        public static Model.BookType getSomeBookType(int bookTypeId)
        {
            return DAL.dalBookType.getSomeBookType(bookTypeId);
        }

        /*����ͼ������*/
        public static bool EditBookType(Model.BookType bookType)
        {
            return DAL.dalBookType.EditBookType(bookType);
        }

        /*ɾ��ͼ������*/
        public static bool DelBookType(string p)
        {
            return DAL.dalBookType.DelBookType(p);
        }

        /*����������ҳ��ѯͼ������*/
        public static System.Data.DataTable GetBookType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalBookType.GetBookType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ͼ������*/
        public static System.Data.DataSet getAllBookType()
        {
            return DAL.dalBookType.getAllBookType();
        }
    }
}
