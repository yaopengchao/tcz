﻿using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using System.Drawing;
using System.Collections.Generic;

namespace LoginFrame
{

    public partial class BodyMain : Form
    {
        public MainFrame mainFrame;

        public Button chooseButton;

        public BodyMain()
        {
            InitializeComponent();
            leftPanel.BackColor = Color.FromArgb(255,208 ,232,253);
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
                    subItem.Tag = row["FILENAME"].ToString();
                    //subItem.Image = LoginFrame.Properties.Resources.Error;
                    subItem.Click += new EventHandler(subItemClick_playLesson);//绑定方法
                    subItem.ToolTipText = "单击播放课件,双击删除收藏";
                    subItem.BackgroundImage = global::LoginFrame.Properties.Resources.收藏条目;
                    toolStripMenuItem1.DropDownItems.Add(subItem);
                }
                else if (LoginRoler.language == Constant.En)
                {
                    ToolStripMenuItem subItem = AddContextMenu(row["ENAME"].ToString(), menuStrip1.Items, null);
                    subItem.Tag = row["FILENAME"].ToString();
                    //subItem.Image = LoginFrame.Properties.Resources.Error;
                    subItem.Click += new EventHandler(subItemClick_playLesson);//绑定方法
                    //subItem.DoubleClick += new EventHandler(subItemClick_deleteLesson);//绑定方法
                    subItem.ToolTipText = "Click play courseware, double click Delete";
                    subItem.BackgroundImage = global::LoginFrame.Properties.Resources.收藏条目;
                    toolStripMenuItem1.DropDownItems.Add(subItem);
                }
            }
        }

        private void subItemClick_playLesson(object sender, EventArgs e)
        {
            ToolStripMenuItem subItem = (ToolStripMenuItem)sender;
            string swfName = subItem.Tag.ToString();
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
            playFlash(filpath);
        }

        private void subItemClick_deleteLesson(object sender, EventArgs e)
        {
            MessageBox.Show("删除");
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

        ImplCourses Bll = new ImplCourses();
        /// <summary>
        /// 初始化左侧课件列表
        /// </summary>
        private void initFlashLessons(int language)
        {
            DataTable dt = Bll.getAllCourses().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //从数据库获取课件分类  然后遍历产生 按钮 动态添加到动态leftPanel中
                Button btnLessonType = new Button();
                btnLessonType.Width = 190;
                btnLessonType.Height = 25;  
                btnLessonType.BackgroundImage = global::LoginFrame.Properties.Resources.课件分类;
                btnLessonType.FlatStyle = FlatStyle.Flat;
                btnLessonType.FlatAppearance.BorderSize = 0;
                //btnLessonType.Font = new Font("微软雅黑", 9);
                //btnLessonType.ForeColor = Color.White;
                btnLessonType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                if (language == Constant.zhCN)
                {
                    btnLessonType.Text = dt.Rows[i]["TCZ_NAME"].ToString();
                }
                else if (language == Constant.En)
                {
                    btnLessonType.Text = dt.Rows[i]["TCZ_ENAME"].ToString();
                }
                btnLessonType.Tag = "NOTOPEN#"+dt.Rows[i]["TCZ_ID"].ToString();
                
                //btnLessonType.Font
                //绑定按钮点击事件
                btnLessonType.Click += new EventHandler(btnLessonType_Click);
                
                this.leftPanel.Controls.Add(btnLessonType);
                Console.WriteLine("添加类型");
            }
            
        }

        /// <summary>
        /// 点击分类按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLessonType_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                string state = btn.Tag.ToString().Split('#')[0];
                string type_id= btn.Tag.ToString().Split('#')[1];
                //获取按钮索引
                int btn_index = this.leftPanel.Controls.IndexOf(btn);
                if (state== "NOTOPEN")
                {
                    //创建一个流式的panel然后将按钮加到该panel中
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.Width = 190;
                    //flowLayoutPanel.AutoSize = true;
                    flowLayoutPanel.AutoScroll = true;
                    DataTable classes = Bll.getCourses(type_id).Tables[0];
                    int height = 5;
                    for (int j = 0; j < classes.Rows.Count; j++)
                    {
                        Button btnClassType = new Button();
                        btnClassType.Width = 175;
                        btnClassType.Height = 20;
                        btnClassType.BackgroundImage = global::LoginFrame.Properties.Resources.章节未选中;
                        btnClassType.FlatStyle = FlatStyle.Flat;
                        btnClassType.FlatAppearance.BorderSize = 0;
                        //btnClassType.Font = new Font("微软雅黑", 9);
                        //btnClassType.ForeColor = Color.White;
                        if (LoginRoler.language == Constant.zhCN)
                        {
                            btnClassType.Text = classes.Rows[j]["CLASS_NAME"].ToString();
                        }
                        else if (LoginRoler.language == Constant.En)
                        {
                            btnClassType.Text = classes.Rows[j]["CLASS_ENAME"].ToString();
                        }
                        btnClassType.Tag = "NOTOPEN#" + classes.Rows[j]["CLASS_ID"].ToString();

                        btnClassType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //绑定按钮点击事件
                        btnClassType.Click += new EventHandler(btnClassType_Click);

                        height += 25;

                        flowLayoutPanel.Controls.Add(btnClassType);
                    }

                    //Console.WriteLine("第一层高度为：" + height);
                    flowLayoutPanel.Height = height;


                    {//刷新控件  将下拉的panel加载到leftpanel
                        List<Control> list = new List<Control>();

                        for (int i = 0; i < this.leftPanel.Controls.Count; i++)
                        {
                            //MessageBox.Show("往临时PANEL添加控件");
                            list.Add(this.leftPanel.Controls[i]);
                        }
                        //MessageBox.Show("list控件数量:" + list.Count);

                        this.leftPanel.Controls.Clear();
                        for (int i = 0; i < list.Count + 1; i++)
                        {
                            if (i < btn_index + 1)
                            {
                                this.leftPanel.Controls.Add(list[i]);
                            }
                            else if (i == btn_index + 1)
                            {
                                this.leftPanel.Controls.Add(flowLayoutPanel);
                            }
                            else if (i > btn_index + 1)
                            {
                                this.leftPanel.Controls.Add(list[i-1]);
                            }
                        }
                    }

                    Console.WriteLine("章节");
                    btn.Tag= "OPEN#" + type_id;
                }
                else
                {
                    this.leftPanel.Controls.RemoveAt(btn_index+1);
                    btn.Tag = "NOTOPEN#" + type_id;
                }

            }
        }


        /// <summary>
        /// 点击章节按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClassType_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (btn != null)
            {
                string state = btn.Tag.ToString().Split('#')[0];
                string type_id = btn.Tag.ToString().Split('#')[1];
                //父控件
                FlowLayoutPanel parentPanel = (FlowLayoutPanel)btn.Parent;
                //获取按钮索引
                int btn_index = parentPanel.Controls.IndexOf(btn);
                //MessageBox.Show("章节索引"+btn_index);
                
                if (state == "NOTOPEN")
                {
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    //flowLayoutPanel.AutoSize = true;
                    flowLayoutPanel.Width = 180;
                    flowLayoutPanel.AutoScroll = true;

                    ListView listView = new ListView();
                    listView.Width = 120;
                    listView.View = View.List;
                    listView.DoubleClick += new System.EventHandler(listView_MouseDoubleClick);
                    DataTable lessons = Bll.getLessons(type_id).Tables[0];
                    for (int j = 0; j < lessons.Rows.Count; j++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        if (LoginRoler.language == Constant.zhCN)
                        {
                            lvItem.Text = lessons.Rows[j]["LESSON_NAME"].ToString();
                            lvItem.SubItems.Add(lessons.Rows[j]["LESSON_FILENAME"].ToString());
                        }
                        else if (LoginRoler.language == Constant.En)
                        {
                            lvItem.Text = lessons.Rows[j]["LESSON_ENAME"].ToString();
                            lvItem.SubItems.Add(lessons.Rows[j]["LESSON_FILENAME"].ToString());
                        }

                        listView.Items.Add(lvItem);


                        Button btnLesson = new Button();
                        btnLesson.Width = 160;
                        btnLesson.Height = 20;
                        btnLesson.FlatStyle = FlatStyle.Flat;
                        btnLesson.FlatAppearance.BorderSize = 0;
                        //btnLesson.Font = new Font("微软雅黑", 9);
                        //btnLesson.ForeColor = Color.White;
                        btnLesson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        if (LoginRoler.language == Constant.zhCN)
                        {
                            btnLesson.Text = lessons.Rows[j]["LESSON_NAME"].ToString();
                        }
                        else if (LoginRoler.language == Constant.En)
                        {
                            btnLesson.Text = lessons.Rows[j]["LESSON_ENAME"].ToString();
                        }
                        btnLesson.Tag = lessons.Rows[j]["LESSON_FILENAME"].ToString()+"#";

                        btnLesson.Click += new System.EventHandler(btnLesson_Click);
                        btnLesson.DoubleClick += new System.EventHandler(btnLesson_DBClick);
                        flowLayoutPanel.Controls.Add(btnLesson);
                    }
                    
                    //flowLayoutPanel.Controls.Add(listView);
                    flowLayoutPanel.Height = flowLayoutPanel.Height + 10;

                    {//刷新控件  将下拉的panel加载到leftpanel
                        List<Control> list = new List<Control>();

                        for (int i = 0; i < parentPanel.Controls.Count; i++)
                        {
                            //MessageBox.Show("往临时PANEL添加控件");
                            list.Add(parentPanel.Controls[i]);
                        }
                        //MessageBox.Show("list控件数量:" + list.Count);

                        parentPanel.Controls.Clear();
                        for (int i = 0; i < list.Count + 1; i++)
                        {
                            if (i < btn_index + 1)
                            {
                                parentPanel.Controls.Add(list[i]);
                            }
                            else if (i == btn_index + 1)
                            {
                                parentPanel.Height = parentPanel.Height + flowLayoutPanel.Height + 10;
                                parentPanel.Controls.Add(flowLayoutPanel);                                
                            }
                            else if (i > btn_index + 1)
                            {
                                parentPanel.Controls.Add(list[i - 1]);
                            }
                        }
                    }

                    Console.WriteLine("课件");

                    btn.Tag = "OPEN#" + type_id;
                    btn.BackgroundImage = global::LoginFrame.Properties.Resources.章节选中;
                    btn.ForeColor= Color.FromArgb(255, 78, 148, 226);
                }
                else
                {

                    FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel) parentPanel.Controls[btn_index + 1];
                    parentPanel.Height = parentPanel.Height - flowLayoutPanel.Height - 10;
                    parentPanel.Controls.RemoveAt(btn_index + 1);
                    btn.Tag = "NOTOPEN#" + type_id;
                    btn.BackgroundImage = global::LoginFrame.Properties.Resources.章节未选中;
                    btn.ForeColor = Color.White;
                }
            }
        }

        private void btnLesson_DBClick(object sender, EventArgs e)
        {
            btnLesson_Click(null, null);
            btn_play_Click(null,null);
        }


        /// <summary>
        /// 点击课件 进行播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLesson_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (btn != null)
            {
                //选中的按钮不为空 那么要先清除原先按钮的状态
                if (chooseButton != null)
                {
                    chooseButton.BackColor = Color.Transparent;//变为透明色
                }
                chooseButton = btn;
                btn.BackColor = Color.FromArgb(255, 78, 148, 226);
                //将此次的按钮保存在chooseButton中
                //且将该按钮背景色改为 蓝色
            }
        }

        //listview双击事件
        public void listView_MouseDoubleClick(object sender, EventArgs e)
        {
            //重置按钮状态或者说flash播放状态    每次双击时候都需要 flash播放器处于停止未播放的状态
            initFlashState();

            //将当前点击的 Listview对象和索引保存
            ListView listView = (ListView)sender;
            //chooseListView= listView;

            btn_play_Click(null,null);
        }

        //flash播放器处于停止未播放的状态
        public void initFlashState()
        {
            this.axShockwaveFlashPlayer.Stop();
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
            if (chooseButton==null)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
             }
            //获取listview当前位置
            int index = chooseButton.Parent.Controls.IndexOf(chooseButton);
            //选择上一个item位置   listview越往上越小  
            int preIndex = index - 1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (preIndex<0)
            {
                MessageBox.Show("已经到达本章列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            chooseButton.BackColor = Color.Transparent;
            chooseButton.Parent.Controls[preIndex].BackColor= Color.FromArgb(255, 78, 148, 226);
            chooseButton = (Button)chooseButton.Parent.Controls[preIndex];
            //模拟双击事件执行播放
            btnLesson_DBClick(null,null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + chooseButton.Tag.ToString().Split('#')[0].ToString() + "^##");
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
                if (chooseButton==null)
                {
                    MessageBox.Show("请先选择课件再点击播放!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string swfName = chooseButton.Tag.ToString().Split('#')[0].ToString(); ;
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
                playFlash(filpath);
            }
        }


        /// <summary>
        /// 播放指定路径Flash
        /// </summary>
        /// <param name="filpath"></param>
        public void playFlash(string filpath)
        {
            this.axShockwaveFlashPlayer.Loop = false;//不循环播放
            this.axShockwaveFlashPlayer.Movie = filpath;
            this.axShockwaveFlashPlayer.Play();
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
            if (chooseButton == null)
            {
                MessageBox.Show("请先选择课件播放后再扩音操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            //播放与 Falsh配对的音频文件名 不包括拓展名
            string audioFilename = chooseButton.Tag.ToString().Split('#')[1].ToString();


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
            if (chooseButton == null)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index = chooseButton.Parent.Controls.IndexOf(chooseButton);
            //选择上一个item位置   listview越往上越小  
            int sufIndex = index+1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (sufIndex > chooseButton.Parent.Controls.Count-1)
            {
               MessageBox.Show("已经到达本章列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            chooseButton.BackColor = Color.Transparent;
            chooseButton.Parent.Controls[sufIndex].BackColor = Color.FromArgb(255, 78, 148, 226);
            chooseButton = (Button)chooseButton.Parent.Controls[sufIndex];
            //模拟双击事件执行播放
            btnLesson_DBClick(null, null);

            //播放选中的文件
            if (isBroadcasting)
            {
                Broadcast("PlayFlash^" + chooseButton.Tag.ToString().Split('#')[0].ToString() + "^##");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //收藏当前课件到数据库
            //获取当前课件的文件名  文件名
            if (chooseButton!=null)
            {
               MessageBox.Show("请先选择课件再点击收藏!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                bool flag = true;
            
                        string filename = chooseButton.Tag.ToString().Split('#')[0].ToString();
                        bool isAdd = IUser.addFavorite(LoginRoler.login_id, filename);
                       flag = flag && isAdd;
                  
               if (!flag)
               {
                       MessageBox.Show("有课件收藏失败!请核对");
                   }
                   //重新刷新收藏夹数据
                  refreshFavorites();
              }
             }
        }
    }
}
