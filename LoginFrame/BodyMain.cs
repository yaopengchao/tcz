using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{

    public partial class BodyMain : Form
    {
        public MainFrame mainFrame;  

        public BodyMain()
        {
            InitializeComponent();
        }


        ImplUser IUser = new ImplUser();
        /// <summary>
        /// 刷新当前登录用户的收藏夹内容
        /// </summary>
        private void refreshFavorites()
        {
            //清空当前收藏列表保留第一项
            for (int a = toolStripMenuItem1.DropDownItems.Count - 1; a >= 2; a--)
            {
                toolStripMenuItem1.DropDownItems.RemoveAt(a);
            }

            //再从数据库获取该用户最新列表
            DataSet dataSet = IUser.getFavorites(LoginRoler.login_id);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (LoginRoler.language == Constant.zhCN)
                {
                    ToolStripMenuItem subItem = AddContextMenu(row["NAME"].ToString(), menuStrip1.Items, null);
                    //subItem.Image = LoginFrame.Properties.Resources.Error;
                    //subItem.Click += new EventHandler(subItemClick_playLesson);//绑定方法
                    subItem.ToolTipText = "单击播放课件,双击删除收藏";
                    subItem.BackgroundImage = global::LoginFrame.Properties.Resources.收藏条目;
                    toolStripMenuItem1.DropDownItems.Add(subItem);
                }
                else if (LoginRoler.language == Constant.En)
                {
                    ToolStripMenuItem subItem = AddContextMenu(row["ENAME"].ToString(), menuStrip1.Items, null);
                    //subItem.Image = LoginFrame.Properties.Resources.Error;
                    //subItem.Click += new EventHandler(subItemClick_playLesson);//绑定方法
                    //subItem.DoubleClick += new EventHandler(subItemClick_deleteLesson);//绑定方法
                    subItem.ToolTipText = "Click play courseware, double click Delete";
                    subItem.BackgroundImage = global::LoginFrame.Properties.Resources.收藏条目;
                    toolStripMenuItem1.DropDownItems.Add(subItem);
                }
            }
        }


        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
        /// <param name="cms">要添加到的子菜单集合</param>
        /// <param name="callback">点击时触发的事件</param>
        /// <returns>生成的子菜单，如果为分隔条则返回null</returns>

        ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                tsmi.Tag = text + "TAG";
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);

                return tsmi;
            }

            return null;
        }

        public void BodyMain_Load(object sender, EventArgs e)
        {
            refreshFavorites();

            //初始化左侧课件列表
            initFlashLessons(LoginRoler.language);


            //加载列表
            //ListViewItem item = new ListViewItem(new string[] { "1" });
            //this.listView1.Items.Insert(0, item);
          
            //ListViewItem item2 = new ListViewItem(new string[] { "2" });
            //this.listView1.Items.Insert(1, item2);
            //ListViewItem item3 = new ListViewItem(new string[] { "3" });
            //this.listView1.Items.Insert(2, item3);
        }

        ImplCourses Bll = new ImplCourses();
        /// <summary>
        /// 初始化左侧课件列表
        /// </summary>
        private void initFlashLessons(int language)
        {
            DataTable dt = Bll.getAllCourses().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //从数据库获取课件分类  然后遍历产生 按钮 动态添加到动态panel中
                Button btnLessonType = new Button();
                btnLessonType.Width = 220;
                btnLessonType.Height = 22;
                btnLessonType.Margin = Padding.Empty;
                btnLessonType.BackgroundImage = global::LoginFrame.Properties.Resources.课件分类;
                btnLessonType.FlatStyle = FlatStyle.Popup;

                if (language == Constant.zhCN)
                {
                    btnLessonType.Text = dt.Rows[i]["TCZ_NAME"].ToString();
                }
                else if (language == Constant.En)
                {
                    btnLessonType.Text = dt.Rows[i]["TCZ_ENAME"].ToString();
                }
                btnLessonType.Tag = dt.Rows[i]["TCZ_ID"].ToString();
                btnLessonType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                //btnLessonType.Font
                //绑定按钮点击事件
                btnLessonType.Click += new EventHandler(btnLessonType_Click);

                this.leftPanel.Controls.Add(btnLessonType);
            }
        }

        /// <summary>
        /// 点击课件分类按钮 加载 章节数据
        /// </summary>
        /// <param name="lessonType"></param>
        /// <returns></returns>
        private void btnLessonType_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                //MessageBox.Show(btn.Tag.ToString());
                //MessageBox.Show(btn.Text);
                //检索该ID下的章节
                DataTable dt = Bll.getCourses(btn.Tag.ToString()).Tables[0];

                //创建一个流式的panel然后将按钮加到该panel中
                FlowLayoutPanel flowLayoutPanel= new FlowLayoutPanel();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btnClassType = new Button();
                    btnClassType.Width = 180;
                    btnClassType.Height = 15;
                    btnClassType.Margin = Padding.Empty;
                    btnClassType.BackgroundImage = global::LoginFrame.Properties.Resources.章节未选中;
                    btnClassType.FlatStyle = FlatStyle.Popup;

                    if (LoginRoler.language == Constant.zhCN)
                    {
                        btnClassType.Text = dt.Rows[i]["CLASS_NAME"].ToString();
                    }
                    else if (LoginRoler.language == Constant.En)
                    {
                        btnClassType.Text = dt.Rows[i]["CLASS_ENAME"].ToString();
                    }
                    btnClassType.Tag = dt.Rows[i]["CLASS_ID"].ToString();

                    //绑定按钮点击事件
                    //btnClassType.Click += new EventHandler(btnClassType_Click);

                    flowLayoutPanel.Controls.Add(btnClassType);
                }
                //btn.Controls.Add(flowLayoutPanel);
            }
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

        private void btn_pre_Click(object sender, EventArgs e)
        {

        }

        public bool isTalking = false;//是否对话中

        private void btn_voice_Click(object sender, EventArgs e)
        {
            if (LoginRoler.roleid != Constant.RoleStudent)
            {
                if (isTalking)
                {
                    isTalking = false;
                    closeVoiceChat();
                }
                else
                {
                    isTalking = true;
                    // 老师打开聊天室界面
                    openVoiceChat();
                }
            }
        }

        void closeVoiceChat()
        {
            MainFrame mainFrame = MainFrame.createForm();

            //加载主体栏
            mainFrame.panel6.Controls.Clear();
            BodyMain bodyMain = BodyMain.createForm();
            bodyMain.TopLevel = false;
            bodyMain.FormBorderStyle = FormBorderStyle.None;
            bodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            mainFrame.panel6.Controls.Add(bodyMain);
            bodyMain.Show();
            mainFrame.Show();
        }

        void openVoiceChat()
        {
            MainFrame mainFrame = MainFrame.createForm();
            this.mainFrame.panel6.Controls.Clear();
            VoiceChatRoom voiceChatRoom = VoiceChatRoom.createForm();
            voiceChatRoom.TopLevel = false;
            voiceChatRoom.FormBorderStyle = FormBorderStyle.None;
            voiceChatRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFrame.panel6.Controls.Add(voiceChatRoom);
            voiceChatRoom.Show();
        }
    }
}
