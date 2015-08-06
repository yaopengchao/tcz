using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Model;

namespace LoginFrame
{
    public partial class FrmEditBook : Form
    {
        public FrmEditBook(String barcode,Frm用户管理 frmQueryBook)
        {
            InitializeComponent();

            this.barcode = barcode;
            this.frmQueryBook = frmQueryBook;
        }

        private Book book;
        private String barcode;
        private Frm用户管理 frmQueryBook;

        /*
        public void setBarCode(String barcode)
        {
            this.barcode = barcode;
        }
        */

        private void Btn_Update_Click(object sender, EventArgs e)
        { 

            
            if (this.txt_bookName.Text == "")
            {
                MessageBox.Show("图书名称输入不能为空!");
                this.txt_bookName.Focus();
                return;
            }
            book.bookName = this.txt_bookName.Text; //图书名称


            book.bookType = Int32.Parse(this.cb_bookType.SelectedValue.ToString()); //图书类别

            try
            {
                book.price = Convert.ToSingle(this.txt_price.Text);  //图书价格
            }
            catch
            {
                MessageBox.Show("图书价格请输入正确的格式!");
                this.txt_price.SelectAll();
                this.txt_price.Focus();
                return;
            }

            try
            {
                book.count = Convert.ToInt32(this.txt_count.Text);  //图书库存
            }
            catch
            {
                MessageBox.Show("图书库存请输入正确的格式!");
                this.txt_count.SelectAll();
                this.txt_count.Focus();
                return;
            }

            book.publish = this.txt_publish.Text;  //出版社

            book.publishDate = this.dtp_publishDate.Value;



            if (BLL.bllBook.EditBook(book))
                MessageBox.Show("图书更新成功!");
            else
                MessageBox.Show("图书更新失败!");

            //FrmQueryBook frmQueryBook = (FrmQueryBook)this.Parent;
            frmQueryBook.BindData("refresh");

            this.Close(); 
        }

        private void btn_bookPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                openFileDialog1.Filter = "图片（*.jpg;*.bmp;*.gif,*.png）|*.jpg;*.bmp;*.gif;*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txt_bookPhoto.Text = openFileDialog1.FileName;
                    pictureBox_bookPhoto.Image = Image.FromFile(txt_bookPhoto.Text);
                    pictureBox_bookPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader bw = new BinaryReader(fs);
                    book.bookPhoto = bw.ReadBytes((int)fs.Length);
                }
            }
            catch
            {
                MessageBox.Show("请选择正确的图片格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FrmEditBook_Load(object sender, EventArgs e)
        {
            //查询所有的图书类别
            DataSet bookTypeDs = BLL.bllBookType.getAllBookType();

            this.cb_bookType.DataSource = bookTypeDs.Tables[0];
            this.cb_bookType.DisplayMember = "bookTypeName";
            this.cb_bookType.ValueMember = "bookTypeId";

            book = BLL.bllBook.getSomeBook(barcode);

            this.txt_barcode.ReadOnly = true;

            this.txt_barcode.Text = book.barcode;
            this.txt_bookName.Text = book.bookName;
            this.cb_bookType.SelectedValue = book.bookType.ToString();
            this.txt_price.Text = book.price.ToString();
            this.txt_count.Text = book.count.ToString();
            this.txt_publish.Text = book.publish;
            this.dtp_publishDate.Value = book.publishDate;



            byte[] bookPhoto = (byte[])(book.bookPhoto);
            MemoryStream ms = new MemoryStream(bookPhoto);
            pictureBox_bookPhoto.Image = Image.FromStream(ms);
            
             
        }
    }
}
