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
    public partial class AdjustPressure : Form
    {
        public AdjustPressure()
        {
            InitializeComponent();

            button1.BackColor = Color.FromArgb(255, 80, 151, 228);
            button1.ForeColor = Color.White;

        }

        private static AdjustPressure instance;


        public static AdjustPressure createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AdjustPressure();
            }
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdjustPressure_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(AdjustPressure));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }
}
