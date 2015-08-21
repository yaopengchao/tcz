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
    public partial class BodySimulation : Form
    {
        public TitleSimulation titleSimulation;

        public BodySimulation()
        {
            InitializeComponent();
        }


        private static BodySimulation instance;


        public static BodySimulation createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodySimulation();
            }
            return instance;
        }

        /// <summary>
        /// 点击标签TAB后修改TITLE的文字显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //将当前索引的文字直接赋值到标题就可以了，所以只需要关注TAB的中文名称即可
            //Console.WriteLine(this.tabControl1.SelectedTab.Text);
            titleSimulation.label1.Text = this.tabControl1.SelectedTab.Text;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            AdjustPressure adjustPressure = AdjustPressure.createForm();
            adjustPressure.ShowDialog();
        }

        
    }

    

}
