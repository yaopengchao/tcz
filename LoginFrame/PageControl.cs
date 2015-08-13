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
            dropPageSize.SelectedIndex = 0;
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
                txtCurPage.Text = Convert.ToString(curPage);
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

        private string[] cols;
        public string[] Cols
        {
            get { return cols; }
            set
            {
                cols = value;
                if (cols != null)
                {
                    int colsCount = cols.Length;
                    for (int i = 0; i < colsCount; i++)
                    {
                        dg.Columns[i].HeaderText = cols[i];
                    }
                }
            }
        }

        private int[] widths;
        public int[] Widths
        {
            get { return widths; }
            set
            {
                widths = value;
                int widthCount = widths.Length;
                for (int i = 0; i < widthCount; i++)
                {
                    dg.Columns[i].Width = widths[i];
                }
            }
        }

        private int totalPage;
        public int TotalPage
        {
            get { return totalPage; }
            set
            {
                totalPage = value;
                labTotalPage.Text = Convert.ToString(totalPage);
            }
        }

        private int totalRecord;
        public int TotalRecord
        {
            get { return totalRecord; }
            set
            {
                totalRecord = value;
                labTotalRecord.Text = Convert.ToString(totalRecord);              
                if (pageSize == 0 || totalRecord == 0)
                {
                    TotalPage = 1;
                } else
                {
                    if (totalRecord % pageSize == 0)
                        TotalPage = totalRecord / pageSize;
                    else
                        TotalPage = totalRecord / pageSize + 1;
                }
                CurPage = 1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PageControl_Load(object sender, EventArgs e)
        {
            initPage();
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurPage = 1;
            loadData();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            CurPage = Convert.ToInt32(txtCurPage.Text) - 1;
            loadData();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {            
            CurPage = Convert.ToInt32(txtCurPage.Text) + 1;
            loadData();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {           
            CurPage = totalPage;
            loadData();
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

        private void dropPageSize_Click(object sender, EventArgs e)
        {

        }
    }
}
