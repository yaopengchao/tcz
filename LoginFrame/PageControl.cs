using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class PageControl : UserControl
    {
        public delegate void loadDataEventHandler();
        public loadDataEventHandler loadData;

        public PageControl()
        {
            InitializeComponent();
        }

        public void initPage()
        {
            pageSize = 10;
            TotalRecord = 0;
            CurPage = 1;
            menuStatus();
        }

        private int startIndex;
        public int StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; }
        }

        private int curPage;
        public int CurPage
        {
            get { return curPage; }
            set
            {
                curPage = value;
                StartIndex = (curPage - 1) * pageSize;
                menuStatus();
            }
        }
        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int totalPage;
        private int totalRecord;
        public int TotalRecord
        {
            get { return totalRecord; }
            set
            {
                if (pageSize == 0)
                {
                    totalPage = 1;
                } else
                {
                    if (totalRecord % pageSize == 0)
                        totalPage = totalRecord / pageSize;
                    else
                        totalPage = totalRecord / pageSize + 1;
                }  
            }
        }


        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }

        private void bn_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PageControl_Load(object sender, EventArgs e)
        {
            bs.DataSource = new BindingSource();
            dg.DataSource = bs;
            bn.BindingSource = bs;
            menuStatus();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurPage = 1;
            loadData();
            menuStatus();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            CurPage = Convert.ToInt32(txtCurPage.Text) - 1;
            loadData();
            menuStatus();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            CurPage = Convert.ToInt32(txtCurPage.Text) + 1;
            loadData();
            menuStatus();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurPage = totalPage;
            loadData();
            menuStatus();
        }

        private void menuStatus()
        {
            if (totalPage == 1)
            {
                btnFirstPage.Enabled = false;
                btnPrePage.Enabled = false;
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            } else
            {
                if (curPage == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                } else if (curPage > 1 && curPage < totalPage)
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                } else
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
            }
        }

        
    }
}
