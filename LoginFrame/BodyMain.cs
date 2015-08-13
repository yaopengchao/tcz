using System;
using System.Windows.Forms;


namespace LoginFrame
{

    public partial class BodyMain : Form
    {
        public MainFrame mainFrame;  

        public BodyMain()
        {
            InitializeComponent();
        }

        public void BodyMain_Load(object sender, EventArgs e)
        {
            if (LoginRoler.language == 0)
            {
                //添加表头，设置该项需要将listView属性View设置为Details否则不会显示
                this.listView1.Columns.Add("Flash课件列表", 190, HorizontalAlignment.Center);
            }
            else if (LoginRoler.language == 1)
            {
                //添加表头，设置该项需要将listView属性View设置为Details否则不会显示
                this.listView1.Columns.Add("FlashLists", 190, HorizontalAlignment.Center);
            }

            
            //加载列表
            //ListViewItem item = new ListViewItem(new string[] { "1" });
            //this.listView1.Items.Insert(0, item);
          
            //ListViewItem item2 = new ListViewItem(new string[] { "2" });
            //this.listView1.Items.Insert(1, item2);
            //ListViewItem item3 = new ListViewItem(new string[] { "3" });
            //this.listView1.Items.Insert(2, item3);
        }


        //listview双击事件
        public void BodyMain_listView_MouseDoubleClick(object sender, EventArgs e)
        {
            //重置按钮状态或者说flash播放状态    每次双击时候都需要 flash播放器处于停止未播放的状态
            initFlashState();
            mainFrame.titleMain.button6_Click(null,null);
        }

        //flash播放器处于停止未播放的状态
        public void initFlashState()
        {
            this.axShockwaveFlashPlayer.Stop();
            mainFrame.titleMain.button6.Text = "播放";
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
       
    }
}
