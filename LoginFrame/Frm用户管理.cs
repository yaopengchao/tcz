using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class Frm用户管理 : Form
    {
        public Frm用户管理()
        {
            InitializeComponent();
        }

       

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            string sqlstr = " where 1=1 ";
      
            if (this.txt_truename.Text != "")
            {
                sqlstr += "  and username like '%" + this.txt_truename.Text + "%'"; 
            }
         
            HWhere.Text = sqlstr;
            BindData("");
        }


        public void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Text);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Text) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Text) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Text);
                    break;
                case "refresh":
                    NowPage = Convert.ToInt32(HNowPage.Text);
                    break;
                default:
                    break;
            }





            DataTable dsLog = BLL.bllBook.GetBook(NowPage, PageSize, out AllPage, out DataCount, HWhere.Text);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            this.dataGridView_Book.DataSource = dsLog.DefaultView; 
            PageMes.Text = string.Format("[每页{0}条 第{1}页／共{2}页   共{3}条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Text = Convert.ToString(NowPage++);
            HAllPage.Text = AllPage.ToString();

            if (dsLog.Rows.Count > 0)
            {
                this.Btn_Update.Enabled = true;
                this.Btn_Del.Enabled = true;
            }
            else
            {
                this.Btn_Update.Enabled = false;
                this.Btn_Del.Enabled = false;
            }
        }

        /*开始加载窗体后*/
        private void FrmQueryBook_Load(object sender, EventArgs e)
        {
            //查询所有的图书类别
           // DataSet bookTypeDs = BLL.bllBookType.getAllBookType(); 
        
           // DataTable newDataTable = new DataTable();
           // newDataTable.Columns.Add("bookTypeId");
           // newDataTable.Columns.Add("bookTypeName");

           // foreach (DataRow oldDR in bookTypeDs.Tables[0].Rows)
           // {
           //     DataRow newDR = newDataTable.NewRow();
           //     newDR[0] = oldDR["bookTypeId"].ToString();
           //     newDR[1] = oldDR["bookTypeName"].ToString();
           //     newDataTable.Rows.InsertAt(newDR, newDataTable.Rows.Count);
           // }

            // Add your 'Select an item' option at the top  
           // DataRow dr = newDataTable.NewRow();
           // dr[0] = "0";
           // dr[1] = "请选择";
          //  newDataTable.Rows.InsertAt(dr, 0);

         
           
        }

        private void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }

        private void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }

        private void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }

        private void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.BaseCollection)(dataGridView_Book.SelectedRows)).Count != 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                FrmEditBook frmEditBook = new FrmEditBook(barcode,this); 
                frmEditBook.ShowDialog(); 
            }
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        { 
            if (((System.Windows.Forms.BaseCollection)(dataGridView_Book.SelectedRows)).Count != 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {  
                if ( MessageBox.Show("确定删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                    if (BLL.bllBook.DelBook(barcode))
                        MessageBox.Show("图书删除成功!");
                    else
                        MessageBox.Show("图书删除失败!");

                    BindData("refresh");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
