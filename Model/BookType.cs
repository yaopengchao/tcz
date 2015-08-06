using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    ///BookType 的摘要说明：图书信息实体
    /// </summary>

    public class BookType
    {
        /*图书类别*/
        private int _bookTypeId;
        public int bookTypeId
        {
            get { return _bookTypeId; }
            set { _bookTypeId = value; }
        }

        /*类别名称*/
        private string _bookTypeName;
        public string bookTypeName
        {
            get { return _bookTypeName; }
            set { _bookTypeName = value; }
        }

        /*可借阅天数*/
        private int _days;
        public int days
        {
            get { return _days; }
            set { _days = value; }
        }

    }
}
