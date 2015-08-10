using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
namespace LoginFrame
{

    public partial class TalkMain : Form
    {
        public MainFrame mainFrame;  

        public TalkMain()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private Thread threadListUsers;
        public void BodyMain_Load(object sender, EventArgs e)
        {
            //添加表头，设置该项需要将listView属性View设置为Details否则不会显示
            this.listView1.Columns.Add("局域网机器列表", 190, HorizontalAlignment.Center);
            //加载列表

            threadListUsers = new Thread(new ThreadStart(ListUsersOnline));
            threadListUsers.IsBackground = true;
            threadListUsers.Start();
         
        }

        private void ListUsersOnline()
        {
            ArrayList alUsers = ListUsers.GetComputerList();

            if (alUsers.Count > 0)
            {
                for (int i = 0; i < alUsers.Count; i++)
                {
                    string[] strTreeNodeText=(string[])alUsers[i];
                    ListViewItem item = new ListViewItem(new string[] {strTreeNodeText[2] });
                    this.listView1.Items.Insert(i, item);
                }
            }
            PicVisible(false);
        }

        private delegate void PicVisibleHandle(bool b);

        private void PicVisible(bool bVisible)
        {
            PicVisibleHandle handle = new PicVisibleHandle(PicVisible);
            if (InvokeRequired)
            {
                this.Invoke(handle, new object[] { bVisible });
            }
            else
            {
                picLoading.Visible = bVisible;
            }
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
