using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class Page
    {
        private int startIndex;         //开始索引
        private int curPage;            //当前页
        private int pageSize;           //每页最大数
        private int totalCount;         //总条数
        private int totalPage;          //总页数
        private DataSet ds;             //当前页记录

        public Page()
        {
            this.startIndex = 0;
            this.curPage = 1;
            this.pageSize = 2;
            this.totalCount = 0;
            this.totalPage = 1;
            this.ds = null;
        }

        public Page(int startIndex, int curPage, int pageSize, int totalCount, int totalPage, DataSet ds)
        {
            this.startIndex = startIndex;
            this.curPage = curPage;
            this.pageSize = pageSize;
            this.totalCount = totalCount;
            this.totalPage = totalPage;
            this.ds = ds;
        }

        public int TotalCount
        {
            get { return totalCount; }
            set {
                totalCount = value;
                if (totalCount % pageSize == 0)
                {
                    totalPage = totalCount / pageSize;
                } else
                {
                    totalPage = totalCount / pageSize + 1;
                }
            }
        }

        public int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; }
        }

        public int CurPage
        {
            get { return curPage; }
            set { curPage = value; }
        }

        public int StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public void goToFirstPage()
        {
            this.curPage = 1;
            startIndex = (curPage - 1) * pageSize;
        }

        public void goToNextPage()
        {
            curPage = curPage + 1;
            startIndex = (curPage - 1) * pageSize;
        }

        public void goToPrePage()
        {
            curPage = curPage - 1;
            startIndex = (curPage - 1) * pageSize;
        }

        public void goToLastPage()
        {
            curPage = totalPage;
            startIndex = (curPage - 1) * pageSize;
        }
    }
}
