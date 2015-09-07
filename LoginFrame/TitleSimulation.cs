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
    public partial class TitleSimulation : Form
    {

        public BodySimulation bodySimulation;

        public TitleSimulation()
        {
            InitializeComponent();
        }

        private static TitleSimulation instance;


        public static TitleSimulation createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleSimulation();
            }
            return instance;
        }

        private void TitleSimulation_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(TitleSimulation));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
