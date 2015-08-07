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

    public partial class TitleMain : Form
    {

        public BodyMain bodyMain;
        
        public bool isBroadcasting=false;//是否广播中

        public TitleMain()
        {
            InitializeComponent();
        }

        private static TitleMain instance;

        public static TitleMain createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TitleMain();
            }
            return instance;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //播放按钮
        public void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(bodyMain.listView1.SelectedItems[0].Text);

            //是否处于同步状态   且  为教师登录   是则发送指令
            if (isBroadcasting  && LoginRoler.roleid!=Constant.RoleStudent)
            {
                Broadcast();
            }

            //判断是否已经单机选择或者双击选择了swf课件
            if (bodyMain.listView1.SelectedItems.Count==0)
            {
                MessageBox.Show("请先选择课件再点击播放!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //bodyMain.axShockwaveFlashPlayer.IsPlaying() 这个方法无效只能用以下替代方法this.button6.Text.Replace(" ", "").Trim().Equals("暂停")
            //之前无效是因为 控件默认 true了
            if (bodyMain.axShockwaveFlashPlayer.IsPlaying())
            {
                bodyMain.axShockwaveFlashPlayer.Stop();
                this.button6.Text = "播放";
            }
            else
            {
                bodyMain.axShockwaveFlashPlayer.Loop = false;//不循环播放
                bodyMain.axShockwaveFlashPlayer.Movie = Application.StartupPath + @"/../../swf/"+ bodyMain.listView1.SelectedItems[0].Text;
                bodyMain.axShockwaveFlashPlayer.Play();
                this.button6.Text = "暂停";
            }
                       
        }

        //上一个按钮
        private void button7_Click(object sender, EventArgs e)
        {
            //列表没有被选择过则无法上一个 下一个
            if (bodyMain.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("当前没有选择课件，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //获取listview当前位置
            int index=bodyMain.listView1.SelectedItems[0].Index;
            //选择上一个item位置   listview越往上越小  
            int preIndex = index - 1;
            //判断 该preIndex是否已经小于0了  小于0了则已经到列表顶部了无法再上一个课件了
            if (preIndex<0)
            {
                MessageBox.Show("已经到达列表开头，本操作无法执行!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            bodyMain.listView1.Items[preIndex].Selected = true;
            //模拟双击事件执行播放
            bodyMain.BodyMain_listView_MouseDoubleClick(null,null);
        }

        //同步教学按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.button4.Text.Replace(" ", "").Trim().Equals("同步教学"))
            {
                this.button4.Text = "同步教学中";
                isBroadcasting = true;
            }
            else
            {
                this.button4.Text = "同步教学";
                isBroadcasting = false;
            }
            
        }


        //发送同步指令公共方法
        public void Broadcast()
        {
            MessageBox.Show("同步指令发送......");
        }
    }
}
