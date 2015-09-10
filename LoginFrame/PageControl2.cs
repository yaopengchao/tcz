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
    public partial class PageControl2 : UserControl
    {
        public delegate void loadDataEventHandler(Dictionary<string, string> strWheres);
        public delegate void cellClickEventHandler();

        public loadDataEventHandler loadData;
        public cellClickEventHandler cellClick;

        public Dictionary<string, string> strWheres;
        public Boolean pageShow = true;
        public Boolean firstCellShow = true;

        public PageControl2()
        {
            InitializeComponent();
        }

        public void initPage()
        {
            widths = new int[] { };
            cols = new string[] { };
            dropPageSize.SelectedIndex = 0;
            pageSize = Convert.ToInt32(dropPageSize.SelectedItem);
            TotalRecord = 0;
            CurPage = 1;
            if (pageShow)
            {
                bn.Show();
            } else
            {
                bn.Hide();
            }

            loadData = new loadDataEventHandler(loadDataNull);
            cellClick = new cellClickEventHandler(cellClickNull);

            if (firstCellShow)
            {
                dg.RowHeadersVisible = true;
            } else
            {
                dg.RowHeadersVisible = false;
            }
        }

        private void loadDataNull(Dictionary<string, string> strWheres)
        {

        }

        private void cellClickNull()
        {
            
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
            loadData(strWheres);
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            CurPage = Convert.ToInt32(txtCurPage.Text) - 1;
            loadData(strWheres);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {            
            CurPage = Convert.ToInt32(txtCurPage.Text) + 1;
            loadData(strWheres);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {           
            CurPage = totalPage;
            loadData(strWheres);
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

        private void dg_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dg_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rowHeaderBounds = new Rectangle
            (
                 2, e.RowBounds.Top,
                 this.dg.RowHeadersWidth - 2, e.RowBounds.Height - 1
            );

            using (Brush backbrush =
                new SolidBrush(SystemColors.Control))
            {
                e.Graphics.FillRectangle(backbrush, rowHeaderBounds);
            }

            if (e.RowIndex >= dg.FirstDisplayedScrollingRowIndex)
            {
                using (SolidBrush b = new SolidBrush(dg.RowHeadersDefaultCellStyle.ForeColor))
                {
                    int linen = 0;
                    linen = e.RowIndex + 1;
                    string line = linen.ToString();
                    e.Graphics.DrawString(line, e.InheritedRowStyle.Font, b, e.RowBounds.Location.X, e.RowBounds.Location.Y + 5);
                    SolidBrush B = new SolidBrush(Color.Red);
                }
            }
        }

        private void dg_Click(object sender, EventArgs e)
        {
            cellClick();
        }

        
    }
}
