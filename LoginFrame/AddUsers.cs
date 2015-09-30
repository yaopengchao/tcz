using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using System.IO;
using Excel2007ReadWrite;
using System.Collections;
using System.ComponentModel;

namespace LoginFrame
{
    public partial class AddUsers : Form
    {

        private const string tempDir = @"..\..\TEMP";

        private const string templateFile = @"..\..\Template.xlsx";

        private DataTable data = new DataTable();

        private static AddUsers instance;

        private static UserService userService;

        public BodyStu bodyStu;

        public static AddUsers getInstance()
        {

            instance = new AddUsers();

            if (userService == null)
            {
                userService = new UserService();
            }

            return instance;
        }

        public AddUsers()
        {
            InitializeComponent();

            this.data.Columns.Add("学生名称", Type.GetType("System.String"));
            this.data.Columns.Add("登录名", Type.GetType("System.String"));
            this.data.Columns.Add("密码", Type.GetType("System.String"));
            this.data.Columns.Add("结果", Type.GetType("System.String"));

            this.dataGridView1.DataSource = data;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            bodyStu.btnQueryClick();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            Util.setLanguage();
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddUsers));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
        /// <summary>
        /// 导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the input file name from the text box.
            string fileName = this.textBoxInput.Text;
            // Delete contents of the temporary directory.
            ExcelRW.DeleteDirectoryContents(AddUsers.tempDir);
            // Unzip input XLSX file to the temporary directory.
            ExcelRW.UnzipFile(fileName, AddUsers.tempDir);
            // Open XML file with table of all unique strings used in the workbook..
            FileStream fs = new FileStream(AddUsers.tempDir + @"\xl\sharedStrings.xml",
                FileMode.Open, FileAccess.Read);
            // ..and call helper method that parses that XML and returns an array of strings.
            ArrayList stringTable = ExcelRW.ReadStringTable(fs);
            // Open XML file with worksheet data..
            fs = new FileStream(AddUsers.tempDir + @"\xl\worksheets\sheet1.xml",
                FileMode.Open, FileAccess.Read);
            // ..and call helper method that parses that XML and fills DataTable with values.
            ExcelRW.ReadWorksheet(fs, stringTable, this.data, bodyStu.classId,Constant.RoleStudent);
        }
        

        /// <summary>
        /// 浏览按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = this.textBoxInput.Text;

            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
                this.textBoxInput.Text = this.openFileDialog1.FileName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"/../../批量导入学生.xlsx");
        }
    }
}
