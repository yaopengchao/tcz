using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    ///BookType ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class BookType
    {
        /*ͼ�����*/
        private int _bookTypeId;
        public int bookTypeId
        {
            get { return _bookTypeId; }
            set { _bookTypeId = value; }
        }

        /*�������*/
        private string _bookTypeName;
        public string bookTypeName
        {
            get { return _bookTypeName; }
            set { _bookTypeName = value; }
        }

        /*�ɽ�������*/
        private int _days;
        public int days
        {
            get { return _days; }
            set { _days = value; }
        }

    }
}
