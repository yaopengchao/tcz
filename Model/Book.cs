using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Book
    {
        /*图书名称*/
        private string _bookName;
        public string bookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }

        /*图书所在类别*/
        private int _bookType;
        public int bookType
        {
            get { return _bookType; }
            set { _bookType = value; }
        }

        /*图书价格*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*库存*/
        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        /*出版社*/
        private string _publish;
        public string publish
        {
            get { return _publish; }
            set { _publish = value; }
        }

        /*图书条形码*/
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        /*图书图片*/
        private byte[] _bookPhoto;
        public byte[] bookPhoto
        {
            get { return _bookPhoto; }
            set { _bookPhoto = value; }
        }

        /*出版日期*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
