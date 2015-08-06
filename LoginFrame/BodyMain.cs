using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginFrame
{

    

    public partial class BodyMain : Form
    {

        


        public TitleMain titleMain;  

        public BodyMain()
        {
            InitializeComponent();
        }

        public void BodyMain_Load(object sender, EventArgs e)
        {
            //加载列表
            ListViewItem item = new ListViewItem(new string[] { "test2.swf" });
            this.listView1.Items.Insert(0, item);
            ListViewItem item1 = new ListViewItem(new string[] { "test1.swf" });
            this.listView1.Items.Insert(1, item1);
            ListViewItem item2 = new ListViewItem(new string[] { "萝卜.swf" });
            this.listView1.Items.Insert(2, item2);
        }


        //listview双击事件
        public void BodyMain_listView_MouseDoubleClick(object sender, EventArgs e)
        {
            //重置按钮状态或者说flash播放状态    每次双击时候都需要 flash播放器处于停止未播放的状态
            initFlashState();
            titleMain.button6_Click(null,null);
        }

        //flash播放器处于停止未播放的状态
        public void initFlashState()
        {
            this.axShockwaveFlashPlayer.Stop();
            titleMain.button6.Text = "播放";
        }

        private static BodyMain instance;

        public static BodyMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BodyMain();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
