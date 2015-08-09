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

    public partial class TalkMain : Form
    {
        public MainFrame mainFrame;  

        public TalkMain()
        {
            InitializeComponent();
        }

        public void BodyMain_Load(object sender, EventArgs e)
        {
            //添加表头，设置该项需要将listView属性View设置为Details否则不会显示
            this.listView1.Columns.Add("局域网机器列表", 190, HorizontalAlignment.Center); 
            //加载列表
            ListViewItem item = new ListViewItem(new string[] { "YouAreMySunshine" });
            this.listView1.Items.Insert(0, item);
            ListViewItem item1 = new ListViewItem(new string[] { "感觉自己萌萌哒" });
            this.listView1.Items.Insert(1, item1);
            ListViewItem item2 = new ListViewItem(new string[] { "去大理" });
            this.listView1.Items.Insert(2, item2);
            ListViewItem item3 = new ListViewItem(new string[] { "跟我约会吧" });
            this.listView1.Items.Insert(3, item3);
        }


        //listview双击事件
        public void BodyMain_listView_MouseDoubleClick(object sender, EventArgs e)
        {

        }

        private static TalkMain instance;

        public static TalkMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TalkMain();
            }
            return instance;
        }

    }
}
