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
    public partial class AddClass : Form
    {
        private static ClassService classService;

        public BodyStu bodyStu;

        private static AddClass instance;

        public static AddClass getInstance()
        {
            if (instance == null)
            {
                instance = new AddClass();

                if (classService == null)
                    classService = new ClassService();
            }
            return instance;
        }

        public AddClass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassInfo classInfo = new ClassInfo();
            classInfo.className = txtClassName.Text;
            int result = classService.addClass(classInfo);
            if (result > 0)
            {
                MessageBox.Show("保存成功");
                bodyStu.loadClass(null);
                this.Close();
            } else
            {
                MessageBox.Show("保存失败，请联系管理员");
            }
        }

        private void AddClass_Load(object sender, EventArgs e)
        {

        }
    }
}
