using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            
        }

        private bool isOpenLesson = false;//是否有课件lesson页面已经打开
        private bool isOpenClass = false;//是否有课件章节页面已经打开

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
                btnLessonType.Width = 190;
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
                //btnLessonType.Click += new EventHandler(btnLessonType_Click);

                this.leftPanel.Controls.Add(btnLessonType);
                Console.WriteLine("添加类型");


                DataTable classes = Bll.getCourses(dt.Rows[i]["TCZ_ID"].ToString()).Tables[0];
                //创建一个流式的panel然后将按钮加到该panel中
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.AutoScroll = true;
                for (int j = 0; j < classes.Rows.Count; j++)
                {
                    Button btnClassType = new Button();
                    btnClassType.Width = 160;
                    btnClassType.Height = 20;
                    btnClassType.Margin = Padding.Empty;
                    btnClassType.BackgroundImage = global::LoginFrame.Properties.Resources.章节未选中;
                    btnClassType.FlatStyle = FlatStyle.Popup;

                    if (LoginRoler.language == Constant.zhCN)
                    {
                        btnClassType.Text = classes.Rows[j]["CLASS_NAME"].ToString();
                    }
                    else if (LoginRoler.language == Constant.En)
                    {
                        btnClassType.Text = classes.Rows[j]["CLASS_ENAME"].ToString();
                    }
                    btnClassType.Tag = classes.Rows[j]["CLASS_ID"].ToString();

                    flowLayoutPanel.Controls.Add(btnClassType);

                    //循环课件
                    DataTable lessons = Bll.getLessons(classes.Rows[j]["CLASS_ID"].ToString()).Tables[0];
                    ListView listView = new ListView();
                    listView.Width = 130;
                    listView.View = View.List;
                    listView.BeginUpdate();
                    for (int k = 0; k < lessons.Rows.Count; k++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = lessons.Rows[k]["LESSON_NAME"].ToString();
                        lvItem.SubItems.Add(lessons.Rows[k]["LESSON_FILENAME"].ToString());
                        listView.Items.Add(lvItem);
                    }
                    listView.EndUpdate();
                    flowLayoutPanel.Controls.Add(listView);
                    Console.WriteLine("添加课件");
                }
                this.leftPanel.Controls.Add(flowLayoutPanel);

                if (isOpenClass)
                {
                    flowLayoutPanel.Hide();
                }
                else
                {
                    isOpenClass = true;
                    flowLayoutPanel.Show();
                }
                Console.WriteLine("添加章节");
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
            //列表没有被选择过则无法上一个 下一个
            if (chooseListView==null)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
             }
            //获取listview当前位置
            int index = chooseIndex;
            //选择上一个item位置   listview越往上越小  
            int preIndex = index - 1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (preIndex<0)
            {
                MessageBox.Show("已经到达本章列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            chooseListView.Items[preIndex].Selected = true;
            //模拟双击事件执行播放
            //mainFrame.bodyMain.BodyMain_listView_MouseDoubleClick(null,null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + chooseListView.SelectedItems[0].SubItems[1].Text + "^##");
            }
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

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 发送同步指令公共方法
        /// </summary>
        /// <param name="code">指令</param>
        public void Broadcast(string code)
        {
            byte[] buf = Encoding.Default.GetBytes(code);
            client.Send(buf, buf.Length, multicast);
        }


        public bool isBroadcasting = false;//是否广播中
        public bool isAudioPlaying = false;//是否扩音中


        private ListView chooseListView;//当前选中的listview
        private int chooseIndex;//当前选中的序号

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (this.axShockwaveFlashPlayer.IsPlaying())
            {
                if (isBroadcasting)
                {
                    Broadcast("StopFlash^NoFileName^##");
                }
                mainFrame.bodyMain.axShockwaveFlashPlayer.Stop();
            }
            else
            {
                //判断是否已经单机选择或者双击选择了swf课件
                if (chooseListView==null)
                {
                    MessageBox.Show("请先选择课件再点击播放!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string swfName = chooseListView.SelectedItems[0].SubItems[1].Text;
                string filpath = Application.StartupPath + @"/../../lessons/" + swfName + ".swf";
                //检测文件是否存在
                if (!File.Exists(filpath))
                {
                    MessageBox.Show("课件对应的Flash文件不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (isBroadcasting)
                {
                    Broadcast("PlayFlash^" + swfName + "^##");
                }
                this.mainFrame.playFlash(filpath);
            }
        }

        /// <summary>
        /// UDP客户端
        /// </summary>
        UdpClient client;
        IPEndPoint multicast;

        /// <summary>
        /// 同步教学按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_async_Click(object sender, EventArgs e)
        {
            //该按钮只是告诉 非 学生机 处于何种状态   
            //  一种是同步状态   另外一种是非同步状态
            //同步状态下  几个按钮触发点击事件的时候发送指令到学生机
            if (isBroadcasting)
            {
                isBroadcasting = false;
                client = null;
                multicast = null;
            }
            else
            {
                client = new UdpClient(5566);
                client.JoinMulticastGroup(IPAddress.Parse("234.5.6.7"));
                multicast = new IPEndPoint(IPAddress.Parse("234.5.6.7"), 7788);
                isBroadcasting = true;
            }
        }

       


        private void btn_music_Click(object sender, EventArgs e)
        {
            if (chooseListView==null)
            {
                MessageBox.Show("请先选择课件播放后再扩音操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            //播放与 Falsh配对的音频文件名 不包括拓展名
            string audioFilename = chooseListView.SelectedItems[0].SubItems[1].Text;


            //获取列表选中项，组装音频文件路径传给播放器

            if (this.isAudioPlaying)
            {

                if (isBroadcasting)
                {
                    Broadcast("StopAudio^NoFileName^##");
                }

                this.isAudioPlaying = false;
                this.mainFrame.stopPlayer();

                if (!this.axShockwaveFlashPlayer.IsPlaying())
                {
                    this.btn_play_Click(null, null);
                }

            }
            else
            {
                if (isBroadcasting)
                {
                    Broadcast("PlayAudio^"+ audioFilename + "^##");
                }

                this.isAudioPlaying = true;
                this.mainFrame.audioPlayer(audioFilename);

                //暂停播放Flash
                if (this.axShockwaveFlashPlayer.IsPlaying())
                {
                    this.btn_stop_Click(null, null);
                }
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            //列表没有被选择过则无法上一个 下一个
            if (chooseListView==null)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index = chooseIndex;
            //选择上一个item位置   listview越往上越小  
            int sufIndex = index+1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (sufIndex > chooseListView.Items.Count-1)
            {
               MessageBox.Show("已经到达本章列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            chooseListView.Items[sufIndex].Selected = true;
            //模拟双击事件执行播放
            //mainFrame.bodyMain.BodyMain_listView_MouseDoubleClick(null, null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + chooseListView.SelectedItems[0].SubItems[1].Text + "^##");
            }
        }
    }
}
