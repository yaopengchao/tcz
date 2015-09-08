using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Model;

namespace LoginFrame
{
    public partial class TitleExam : Form
    {

        private static TitleExam instance;

        public static TitleExam createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleExam();
            }
            return instance;
        }

        public TitleExam()
        {
            InitializeComponent();
        }

        private void TitleExam_Load(object sender, EventArgs e)
        {
            if (LoginRoler.language == Constant.zhCN)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (LoginRoler.language == Constant.En)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            }
            //对当前窗体应用更改后的资源
            ApplyResource();
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(TitleExam));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
