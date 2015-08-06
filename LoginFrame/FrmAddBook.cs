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
    public partial class FrmAddBook : Form
    {
        public FrmAddBook()
        {
            InitializeComponent();
        }

        private Book book = new Book();

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

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (this.txt_barcode.Text == "")
            {
                MessageBox.Show("条形码输入不能为空!");
                this.txt_barcode.Focus();
                return;
            }
            book.barcode = this.txt_barcode.Text;  //图书条形码

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



            if (BLL.bllBook.AddBook(book))
                MessageBox.Show("图书添加成功!");
            else
                MessageBox.Show("图书添加失败!");

            this.Close(); 


        }



        private void FrmAddBook_Load(object sender, EventArgs e)
        {

            //查询所有的图书类别
            DataSet bookTypeDs = BLL.bllBookType.getAllBookType();
           
            this.cb_bookType.DataSource = bookTypeDs.Tables[0];   
            this.cb_bookType.DisplayMember = "bookTypeName";
            this.cb_bookType.ValueMember = "bookTypeId";
             
            /*

            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add("bookTypeId");
            newDataTable.Columns.Add("bookTypeName");

            foreach (DataRow oldDR in bookTypeDs.Tables[0].Rows)
            {
                DataRow newDR = newDataTable.NewRow();
                newDR[0] = oldDR["bookTypeId"].ToString();
                newDR[1] = oldDR["bookTypeName"].ToString();
                newDataTable.Rows.InsertAt(newDR, newDataTable.Rows.Count);
            }

            // Add your 'Select an item' option at the top  
            DataRow dr = newDataTable.NewRow();
            dr[0] = "0";
            dr[1] = "请选择";
            newDataTable.Rows.InsertAt(dr, 0);

            this.cb_bookType.DataSource = newDataTable;
            this.cb_bookType.DisplayMember = "bookTypeName";
            this.cb_bookType.ValueMember = "bookTypeId"; 
             */

            pictureBox_bookPhoto.Image = Image.FromFile("pic/NoImage.jpg");
            pictureBox_bookPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs = new FileStream("pic/NoImage.jpg", FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            book.bookPhoto = bw.ReadBytes((int)fs.Length); 
           

        }

        
    }
}
