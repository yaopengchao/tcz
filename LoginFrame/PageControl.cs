using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace LoginFrame
{
    public partial class PageControl : UserControl
    {
        public delegate void loadDataEventHandle();
        public loadDataEventHandle loadData;

        public string[] cols;
        public string[] Cols
        {
            get { return cols; }
            set
            {
                cols = value;
                int colLength = cols.Length;
                if (colLength > 0)
                {
                    string str = "";
                    for (int i = 0; i < colLength; i++)
                    {
                        dataGridView1.Columns[i].HeaderText = cols[i];
                        str += cols[i];
                    }
                    Console.WriteLine(str);
                }
            }
        }

        public int[] widths;
        public int[] Widths
        {
            get { return widths; }
            set
            {
                widths = value;
                int widLength = widths.Length;
                if (widLength > 0)
                {
                    for (int i = 0; i < widLength; i++)
                    {
                        dataGridView1.Columns[i].Width = widths[i];
                    }
                }
                
            }
        }

        public Page page = new Page();

        public PageControl()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            page.goToFirstPage();
            txtCurPage.Text = Convert.ToString(page.CurPage);
            loadData();
            menuStatus();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            page.goToPrePage();
            txtCurPage.Text = Convert.ToString(page.CurPage);
            loadData();
            menuStatus();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page.goToNextPage();
            txtCurPage.Text = Convert.ToString(page.CurPage);
            loadData();
            menuStatus();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            page.goToLastPage();
            txtCurPage.Text = Convert.ToString(page.CurPage);
            loadData();
            menuStatus();
        }

        private void PageControl_Load(object sender, EventArgs e)
        {
            loadInit();
        }

        public void loadInit()
        {
            bs = new BindingSource();
            dataGridView1.DataSource = bs;
            bn.BindingSource = bs;

            txtCurPage.Text = Convert.ToString(page.CurPage);
            DropPageSize.SelectedIndex = 0;
        }

        public void menuStatus()
        {
            if (page.TotalPage == 1)
            {
                btnFirstPage.Enabled = false;
                btnPrePage.Enabled = false;
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            } else if (page.TotalPage > 1)
            {
                if (page.CurPage == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                } else if (page.CurPage > 1 && page.CurPage < page.TotalPage)
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                } else if (page.CurPage == page.TotalPage)
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
