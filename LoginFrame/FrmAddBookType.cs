using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Model;
using BLL;

namespace LoginFrame
{
    public partial class FrmAddBookType : Form
    {
        public FrmAddBookType()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            BookType bookType = new BookType();
            if (this.txt_bookTypeName.Text == "")
            {
                MessageBox.Show("图书类型输入不能为空!");
                this.txt_bookTypeName.Focus();
                return;
            }
            bookType.bookTypeName = this.txt_bookTypeName.Text;

            try
            {
                bookType.days = Convert.ToInt32(this.txt_days.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("天数请输入整数");
                this.txt_days.SelectAll();
                this.txt_days.Focus();
                return;
            }

            if (bllBookType.AddBookType(bookType))
                MessageBox.Show("图书类型添加成功!");
            else
                MessageBox.Show("图书类型添加失败!");


            this.Close();

        }
    }
}
