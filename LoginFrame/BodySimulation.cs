using System;
using Model;
using System.Windows.Forms;
using BLL;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;
using InTheHand.Net;

namespace LoginFrame
{
    public partial class BodySimulation : Form
    {
        SimulationService simulationService = new SimulationService();

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

        /// <summary>
        /// 确定按钮  将数据持久化 且 发送通信指令到触诊模拟人硬件上面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           
            触诊模拟人 _触诊模拟人=get触诊模拟人数据();

            //持久化
            if (simulationService.add触诊人设置(_触诊模拟人, LoginRoler.username))
            {
                MessageBox.Show("设置成功!");
            }else{
                MessageBox.Show("设置失败!");
            }
            
        }

        /// <summary>
        ///  //获取触诊模拟人数据 封装成 对象
        /// </summary>
        /// <returns></returns>
        private 触诊模拟人 get触诊模拟人数据()
        {
            触诊模拟人 _触诊模拟人 = new 触诊模拟人();
            _触诊模拟人.肝脏肿大 = this.肝脏肿大.Text;
            if (this.肝脏质地硬.Checked)
            {
                _触诊模拟人.肝脏质地 = "1";
            }
            if (this.肝脏质地软.Checked)
            {
                _触诊模拟人.肝脏质地 = "0";
            }
            _触诊模拟人.脾脏肿大 = this.脾脏肿大.Text;
            if (this.胆囊触痛有.Checked)
            {
                _触诊模拟人.胆囊触痛 = "1";
            }
            if (this.胆囊触痛无.Checked)
            {
                _触诊模拟人.胆囊触痛 = "0";
            }
            if (this.胆囊肿大有.Checked)
            {
                _触诊模拟人.胆囊肿大 = "1";
            }
            if (this.胆囊肿大无.Checked)
            {
                _触诊模拟人.胆囊肿大 = "0";
            }
            if (this.胆囊墨菲氏征阳性.Checked)
            {
                _触诊模拟人.胆囊墨菲氏征 = "1";
            }
            if (this.胆囊墨菲氏征阴性.Checked)
            {
                _触诊模拟人.胆囊墨菲氏征 = "0";
            }
            if (this.压痛胃溃疡有.Checked)
            {
                _触诊模拟人.压痛胃溃疡 = "1";
            }
            if (this.压痛胃溃疡无.Checked)
            {
                _触诊模拟人.压痛胃溃疡 = "0";
            }
            if (this.压痛十二指肠有.Checked)
            {
                _触诊模拟人.压痛十二指肠 = "1";
            }
            if (this.压痛十二指肠无.Checked)
            {
                _触诊模拟人.压痛十二指肠 = "0";
            }
            if (this.压痛胰腺有.Checked)
            {
                _触诊模拟人.压痛胰腺 = "1";
            }
            if (this.压痛胰腺无.Checked)
            {
                _触诊模拟人.压痛胰腺 = "0";
            }
            if (this.压痛阑尾有.Checked)
            {
                _触诊模拟人.压痛阑尾 = "1";
            }
            if (this.压痛阑尾无.Checked)
            {
                _触诊模拟人.压痛阑尾 = "0";
            }
            if (this.压痛小肠有.Checked)
            {
                _触诊模拟人.压痛小肠 = "1";
            }
            if (this.压痛小肠无.Checked)
            {
                _触诊模拟人.压痛小肠 = "0";
            }
            if (this.压痛乙状结肠有.Checked)
            {
                _触诊模拟人.乙状结肠 = "1";
            }
            if (this.压痛乙状结肠无.Checked)
            {
                _触诊模拟人.乙状结肠 = "0";
            }
            if (this.反跳痛胰腺有.Checked)
            {
                _触诊模拟人.反跳痛胰腺 = "1";
            }
            if (this.反跳痛胰腺无.Checked)
            {
                _触诊模拟人.反跳痛胰腺 = "0";
            }
            if (this.反跳痛阑尾有.Checked)
            {
                _触诊模拟人.反跳痛阑尾 = "1";
            }
            if (this.反跳痛阑尾无.Checked)
            {
                _触诊模拟人.反跳痛阑尾 = "0";
            }
            if (this.反跳痛小肠有.Checked)
            {
                _触诊模拟人.反跳痛小肠 = "1";
            }
            if (this.反跳痛小肠无.Checked)
            {
                _触诊模拟人.反跳痛小肠 = "0";
            }
            _触诊模拟人.脉搏 = this.脉搏.Text;
            _触诊模拟人.血压收缩压 = this.血压收缩压.Text;
            _触诊模拟人.血压舒张压 = this.血压舒张压.Text;
            _触诊模拟人.肠鸣音 = this.肠鸣音.Text;
            _触诊模拟人.肾动脉听诊音 = this.肾动脉听诊音.Text;
            _触诊模拟人.股动脉听诊音 = this.股动脉听诊音.Text;
            return _触诊模拟人;
        }

        private void BodySimulation_Load(object sender, EventArgs e)
        {
            //初始化数据
            initData();

            触诊模拟人 _触诊模拟人= simulationService.get触诊人设置(LoginRoler.username);

            听诊模拟人 _听诊模拟人 = simulationService.get听诊人设置(LoginRoler.username);

            load触诊人Data2Frm(_触诊模拟人);

            load听诊人Data2Frm(_听诊模拟人);

            //检测蓝牙设备
            checkBluetooth();
        }

        BluetoothRadio radio = null;//蓝牙适配器

        private void checkBluetooth()
        {
            radio = BluetoothRadio.PrimaryRadio;//获取当前PC的蓝牙适配器
            CheckForIllegalCrossThreadCalls = false;//不检查跨线程调用
            if (radio == null)//检查该电脑蓝牙是否可用
            {
                MessageBox.Show("这个电脑蓝牙不可用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void load听诊人Data2Frm(听诊模拟人 _听诊模拟人)
        {
            if (_听诊模拟人!=null)
            {
                if (_听诊模拟人.心前区震颤 == "1")
                {
                    this.心前区震颤有.Checked = true;
                }
                else if (_听诊模拟人.心前区震颤 == "0")
                {
                    this.心前区震颤无.Checked = true;
                }
                if (_听诊模拟人.心尖搏动 == "1")
                {
                    this.心尖搏动有.Checked = true;
                }
                else if (_听诊模拟人.心尖搏动 == "0")
                {
                    this.心尖搏动无.Checked = true;
                }
                this.二尖瓣听诊区.Text = _听诊模拟人.二尖瓣听诊区;
                this.肺动脉瓣听诊区.Text = _听诊模拟人.肺动脉瓣听诊区;
                this.主动脉瓣区.Text = _听诊模拟人.主动脉瓣区;
                this.主动脉瓣第二听诊区.Text = _听诊模拟人.主动脉瓣第二听诊区;
                this.三尖瓣区.Text = _听诊模拟人.三尖瓣区;
                this.气管.Text = _听诊模拟人.气管;
                this.左肺上.Text = _听诊模拟人.左肺上;
                this.左肺中.Text = _听诊模拟人.左肺中;
                this.左肺下.Text = _听诊模拟人.左肺下;
                this.右肺上.Text = _听诊模拟人.右肺上;
                this.右肺中.Text = _听诊模拟人.右肺中;
                this.右肺下.Text = _听诊模拟人.右肺下;
                
            }
        }


        /// <summary>
        /// 将数据库获取的对象赋值到界面上面
        /// </summary>
        /// <param name="_触诊模拟人"></param>
        private void load触诊人Data2Frm(触诊模拟人 _触诊模拟人)
        {
            if (_触诊模拟人!=null)
            {
                this.肝脏肿大.Text = _触诊模拟人.肝脏肿大;
                this.脾脏肿大.Text = _触诊模拟人.脾脏肿大;
                if (_触诊模拟人.肝脏质地 == "1")
                {
                    this.肝脏质地硬.Checked = true;
                }
                else if (_触诊模拟人.肝脏质地 == "0")
                {
                    this.肝脏质地软.Checked = true;
                }
                this.脾脏肿大.Text = _触诊模拟人.脾脏肿大;
                if (_触诊模拟人.胆囊触痛 == "1")
                {
                    this.胆囊触痛有.Checked = true;
                }
                else if (_触诊模拟人.胆囊触痛 == "0")
                {
                    this.胆囊触痛无.Checked = true;
                }
                if (_触诊模拟人.胆囊肿大 == "1")
                {
                    this.胆囊肿大有.Checked = true;
                }
                else if (_触诊模拟人.胆囊肿大 == "0")
                {
                    this.胆囊肿大无.Checked = true;
                }
                if (_触诊模拟人.胆囊墨菲氏征 == "1")
                {
                    this.胆囊墨菲氏征阳性.Checked = true;
                }
                else if (_触诊模拟人.胆囊墨菲氏征 == "0")
                {
                    this.胆囊墨菲氏征阴性.Checked = true;
                }
                if (_触诊模拟人.压痛胃溃疡 == "1")
                {
                    this.压痛胃溃疡有.Checked = true;
                }
                else if (_触诊模拟人.压痛胃溃疡 == "0")
                {
                    this.压痛胃溃疡无.Checked = true;
                }
                if (_触诊模拟人.压痛十二指肠 == "1")
                {
                    this.压痛十二指肠有.Checked = true;
                }
                else if (_触诊模拟人.压痛十二指肠 == "0")
                {
                    this.压痛十二指肠无.Checked = true;
                }
                if (_触诊模拟人.压痛胰腺 == "1")
                {
                    this.压痛胰腺有.Checked = true;
                }
                else if (_触诊模拟人.压痛胰腺 == "0")
                {
                    this.压痛胰腺无.Checked = true;
                }
                if (_触诊模拟人.压痛阑尾 == "1")
                {
                    this.压痛阑尾有.Checked = true;
                }
                else if (_触诊模拟人.压痛阑尾 == "0")
                {
                    this.压痛阑尾无.Checked = true;
                }
                if (_触诊模拟人.压痛小肠 == "1")
                {
                    this.压痛小肠有.Checked = true;
                }
                else if (_触诊模拟人.压痛小肠 == "0")
                {
                    this.压痛小肠无.Checked = true;
                }
                if (_触诊模拟人.乙状结肠 == "1")
                {
                    this.压痛乙状结肠有.Checked = true;
                }
                else if (_触诊模拟人.乙状结肠 == "0")
                {
                    this.压痛乙状结肠无.Checked = true;
                }
                if (_触诊模拟人.反跳痛胰腺 == "1")
                {
                    this.反跳痛胰腺有.Checked = true;
                }
                else if (_触诊模拟人.反跳痛胰腺 == "0")
                {
                    this.反跳痛胰腺无.Checked = true;
                }
                if (_触诊模拟人.反跳痛阑尾 == "1")
                {
                    this.反跳痛阑尾有.Checked = true;
                }
                else if (_触诊模拟人.反跳痛阑尾 == "0")
                {
                    this.反跳痛阑尾无.Checked = true;
                }
                if (_触诊模拟人.反跳痛小肠 == "1")
                {
                    this.反跳痛小肠有.Checked = true;
                }
                else if (_触诊模拟人.反跳痛小肠 == "0")
                {
                    this.反跳痛小肠无.Checked = true;
                }
                this.脉搏.Text = _触诊模拟人.脉搏;
                this.血压收缩压.Text = _触诊模拟人.血压收缩压;
                this.血压舒张压.Text = _触诊模拟人.血压舒张压;
                this.肠鸣音.Text = _触诊模拟人.肠鸣音;
                this.肾动脉听诊音.Text = _触诊模拟人.肾动脉听诊音;
                this.股动脉听诊音.Text = _触诊模拟人.股动脉听诊音;
                
            }
        }

        private void initData()
        {
            //触诊人初始化
            this.肝脏质地硬.Checked = true;
            this.胆囊触痛有.Checked = true;
            this.胆囊肿大有.Checked = true;
            this.胆囊墨菲氏征阳性.Checked = true;
            this.压痛胃溃疡有.Checked = true;
            this.压痛十二指肠有.Checked = true;
            this.压痛胰腺有.Checked = true;
            this.压痛阑尾有.Checked = true;
            this.压痛小肠有.Checked = true;
            this.压痛乙状结肠有.Checked = true;
            this.反跳痛胰腺有.Checked = true;
            this.反跳痛阑尾有.Checked = true;
            this.反跳痛小肠有.Checked = true;


            //听诊人初始化
            this.心前区震颤有.Checked = true;
            this.心尖搏动有.Checked = true;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {


            听诊模拟人 _听诊模拟人 = get听诊模拟人数据();

            //持久化
            if (simulationService.add听诊人设置(_听诊模拟人, LoginRoler.username))
            {
                MessageBox.Show("设置成功!");
            }
            else
            {
                MessageBox.Show("设置失败!");
            }


            
        }

        private 听诊模拟人 get听诊模拟人数据()
        {
            听诊模拟人 _听诊模拟人 = new 听诊模拟人();
            if (this.心前区震颤有.Checked)
            {
                _听诊模拟人.心前区震颤 = "1";
            }
            if (this.心前区震颤无.Checked)
            {
                _听诊模拟人.心前区震颤 = "0";
            }
            if (this.心尖搏动有.Checked)
            {
                _听诊模拟人.心尖搏动 = "1";
            }
            if (this.心尖搏动无.Checked)
            {
                _听诊模拟人.心尖搏动 = "0";
            }
            _听诊模拟人.二尖瓣听诊区 = this.二尖瓣听诊区.Text;
            _听诊模拟人.肺动脉瓣听诊区 = this.肺动脉瓣听诊区.Text;
            _听诊模拟人.主动脉瓣区 = this.主动脉瓣区.Text;
            _听诊模拟人.主动脉瓣第二听诊区 = this.主动脉瓣第二听诊区.Text;
            _听诊模拟人.三尖瓣区 = this.三尖瓣区.Text;
            _听诊模拟人.气管 = this.气管.Text;
            _听诊模拟人.左肺上 = this.左肺上.Text;
            _听诊模拟人.左肺中 = this.左肺中.Text;
            _听诊模拟人.左肺下 = this.左肺下.Text;
            _听诊模拟人.右肺上 = this.右肺上.Text;
            _听诊模拟人.右肺中 = this.右肺中.Text;
            _听诊模拟人.右肺下 = this.右肺下.Text;
            return _听诊模拟人;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        BluetoothAddress sendAddress = null;//发送目的地址
        private void chooseBluetooth(Label label,Button button,string type)
        {
            SelectBluetoothDeviceDialog dialog = new SelectBluetoothDeviceDialog();
            dialog.ShowRemembered = true;//显示已经记住的蓝牙设备
            dialog.ShowAuthenticated = true;//显示认证过的蓝牙设备
            dialog.ShowUnknown = true;//显示位置蓝牙设备
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sendAddress = dialog.SelectedDevice.DeviceAddress;//获取选择的远程蓝牙地址
                //判别是否对应的模拟人类型  
                if (checkMonitor(type))
                {
                    label.Text = "地址:" + sendAddress.ToString() + "    设备名:" + dialog.SelectedDevice.DeviceName;
                    button.Text = "已连接";
                }
                else
                {
                    label.Text = "所连接的设备不是模拟人";
                }
               
            }

        }

        private bool checkMonitor(string type)
        {
            return false;
        }

        public static bool tzmonitor1 = false;
        /// <summary>
        /// 听诊模拟人1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click_1(object sender, EventArgs e)
        {
            if (tzmonitor1)
            {
                //断开
                tzmonitor1 = false;
                this.label57.Text = "";
                this.button17.Text = "未连接";
            }
            else
            {
                chooseBluetooth(this.label57, this.button17);
                tzmonitor1 = true;
            }
            
        }

        public static bool tzmonitor2 = false;

        /// <summary>
        /// 听诊模拟人2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            if (tzmonitor2)
            {
                //断开
                tzmonitor2 = false;
                this.label58.Text = "";
                this.button18.Text = "未连接";
            }
            else
            {
                chooseBluetooth(this.label58, this.button18);
                tzmonitor2 = true;
            }
        }

        public static bool czmonitor1 = false;

        /// <summary>
        /// 触诊模拟人1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            if (czmonitor1)
            {
                //断开
                czmonitor1 = false;
                this.label59.Text = "";
                this.button19.Text = "未连接";
            }
            else
            {
                chooseBluetooth(this.label59, this.button19);
                czmonitor1 = true;
            }
            
        }

        
    }

    

}
