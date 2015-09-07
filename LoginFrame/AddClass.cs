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

            instance = new AddClass();

            if (classService == null)
                classService = new ClassService();

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
            int result = 0;
            ClassInfo classInfo = new ClassInfo();
            classInfo.className = txtClassName.Text;

            int classId = Convert.ToInt32(labClassId.Text);
            if (classId > 0)                //修改操作
            {
                classInfo.ClassId = classId;
                result = classService.updateClass(classInfo);
            } else                          //新增操作
            {
                result = classService.addClass(classInfo);
            }
             
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AddClass));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
