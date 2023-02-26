
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Text;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IoNetWork
{
    public partial class HkNetForm : Form
    {
        /// <summary>
        /// 通信服务器
        /// </summary>
        public TcpServer HkServer = new TcpServer();

        /// <summary>
        /// 封禁字典和用户信息字典集合
        /// </summary>
        public List<string> ListBans = new List<string>();

        /// <summary>
        /// 同网络地址检测集合
        /// </summary>
        public ConcurrentDictionary<string, uint> AcceptIps = new ConcurrentDictionary<string, uint>();

        private AppState NowAppState = AppState.Stoped;

        System.Windows.Forms.Timer AtTimer = new System.Windows.Forms.Timer();
        public int TimeIdx = 0;

        /// <summary>
        /// 心跳后台线程
        /// </summary>
        public Thread KeepTimeThread = null;

        /// <summary>
        /// 数据库操作器
        /// </summary>
        public InitMySql MysqlHandler = new InitMySql();

        /// <summary>
        /// 列表框更新事件委托 增/删
        /// </summary>
        private delegate void ListViewUpdate(IntPtr ClientId, string IpAndPort, bool Apply);
        private ListViewUpdate ViewUpdateDelegate;

        /// <summary>
        /// 列表框追加机器码事件委托
        /// </summary>
        private delegate void ListViewAppend(string IpAndPort, string PcKey);
        private ListViewAppend ViewAppendDelegate;

        #region 构造初始化窗口
        public HkNetForm()
        {
            InitializeComponent();

            Type RType = ListClients.GetType();
            PropertyInfo RInfo = RType.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            RInfo.SetValue(ListClients, true, null);

            TBoxPort.Text = Properties.Settings.Default.Port.Trim();
            TBoxMaxConn.Text = Properties.Settings.Default.MaxCon.Trim();

            BPortTextBox.Text = Properties.Settings.Default.BPort.Trim();
            ZPortTextBox.Text = Properties.Settings.Default.ZPort.Trim();
            DPortTextBox.Text = Properties.Settings.Default.DPort.Trim();
            TelecomTextBox.Text = Properties.Settings.Default.TelecomIp.Trim();
            MobileTextBox.Text = Properties.Settings.Default.MobileIp.Trim();
            UnicomTextBox.Text = Properties.Settings.Default.UnicomIp.Trim();
            NameListTextBox.Text = Properties.Settings.Default.NameList.Trim();
            ContentsTextBox.Text = Properties.Settings.Default.Contents.Trim();
            HostTextBox.Text = Properties.Settings.Default.DBHost.Trim();
            RootTextBox.Text = Properties.Settings.Default.DBRoot.Trim();
            PassTextBox.Text = Properties.Settings.Default.DBPass.Trim();
            PortTextBox.Text = Properties.Settings.Default.DBPort.Trim();
            AuthTextBox.Text = Properties.Settings.Default.DBAuth.Trim();
            CharTextBox.Text = Properties.Settings.Default.DBChar.Trim();
            GameVeTextBox.Text = Properties.Settings.Default.GameVe.Trim();
            PNameTextBox.Text = Properties.Settings.Default.PName.Trim();
            PMdTextBox.Text = Properties.Settings.Default.PMd.Trim();
            PUrlTextBox.Text = Properties.Settings.Default.PUrl.Trim();
            ShopTextBox.Text = Properties.Settings.Default.ShopUrl.Trim();
            GwTextBox.Text = Properties.Settings.Default.GwUrl.Trim();

            NetHelper.NetPort = TBoxPort.Text;
            NetHelper.NetMaxConn = TBoxMaxConn.Text;
            NetHelper.NetBPort = BPortTextBox.Text;
            NetHelper.NetZPort = ZPortTextBox.Text;
            NetHelper.NetDPort = DPortTextBox.Text;
            NetHelper.NetTelecomIp = TelecomTextBox.Text;
            NetHelper.NetMobileIp = MobileTextBox.Text;
            NetHelper.NetUnicomIp = UnicomTextBox.Text;
            NetHelper.NetNameList = NameListTextBox.Text;
            NetHelper.NetContents = ContentsTextBox.Text;
            NetHelper.NetDBHost = HostTextBox.Text;
            NetHelper.NetDBRoot = RootTextBox.Text;
            NetHelper.NetDBPass = PassTextBox.Text;
            NetHelper.NetDBPort = PortTextBox.Text;
            NetHelper.NetDBAuth = AuthTextBox.Text;
            NetHelper.NetDBChar = CharTextBox.Text;
            NetHelper.NetGameVe = GameVeTextBox.Text;
            NetHelper.NetPName = PNameTextBox.Text;
            NetHelper.NetPMd = PMdTextBox.Text;
            NetHelper.NetPUrl = PUrlTextBox.Text;
            NetHelper.NetShopUrl = ShopTextBox.Text;
            NetHelper.NetGwUrl = GwTextBox.Text;

            NetHelper.NetRegister = Properties.Settings.Default.Register.Trim();
            NetHelper.NetStuck = Properties.Settings.Default.Stuck.Trim();
            NetHelper.NetCgPassword = Properties.Settings.Default.CgPassword.Trim();
            NetHelper.NetForward = Properties.Settings.Default.Forward.Trim();
            NetHelper.NetModKey = Properties.Settings.Default.ModKey.Trim();

            CheckBoxReg.Checked = (Properties.Settings.Default.Register == "1");
            CheckBoxSt.Checked = (Properties.Settings.Default.Stuck == "1");
            CheckBoxCg.Checked = (Properties.Settings.Default.CgPassword == "1");
            ForwardCheckBox.Checked = (Properties.Settings.Default.Forward == "1");
            CheckKey.Checked = (Properties.Settings.Default.ModKey == "1");

            string GText = File.ReadAllText(NetHelper.GTextPath, Encoding.UTF8);
            NetHelper.NetGText = GText;

            //随便给个焦点
            TBoxMaxConn.Focus();
        }
        #endregion

        #region 保存配置按钮事件操作
        private void Btn_setting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = TBoxPort.Text.Trim();
            Properties.Settings.Default.MaxCon = TBoxMaxConn.Text.Trim();

            Properties.Settings.Default.BPort = BPortTextBox.Text.Trim();
            Properties.Settings.Default.ZPort = ZPortTextBox.Text.Trim();
            Properties.Settings.Default.DPort = DPortTextBox.Text.Trim();
            Properties.Settings.Default.TelecomIp = TelecomTextBox.Text.Trim();
            Properties.Settings.Default.MobileIp = MobileTextBox.Text.Trim();
            Properties.Settings.Default.UnicomIp = UnicomTextBox.Text.Trim();
            Properties.Settings.Default.NameList = NameListTextBox.Text.Trim();
            Properties.Settings.Default.Contents = ContentsTextBox.Text.Trim();
            Properties.Settings.Default.DBHost = HostTextBox.Text.Trim();
            Properties.Settings.Default.DBRoot = RootTextBox.Text.Trim();
            Properties.Settings.Default.DBPass = PassTextBox.Text.Trim();
            Properties.Settings.Default.DBPort = PortTextBox.Text.Trim();
            Properties.Settings.Default.DBAuth = AuthTextBox.Text.Trim();
            Properties.Settings.Default.DBChar = CharTextBox.Text.Trim();
            Properties.Settings.Default.GameVe = GameVeTextBox.Text.Trim();
            Properties.Settings.Default.PName = PNameTextBox.Text.Trim();
            Properties.Settings.Default.PMd = PMdTextBox.Text.Trim();
            Properties.Settings.Default.PUrl = PUrlTextBox.Text.Trim();
            Properties.Settings.Default.ShopUrl = ShopTextBox.Text.Trim();
            Properties.Settings.Default.GwUrl = GwTextBox.Text.Trim();

            Properties.Settings.Default.Register = CheckBoxReg.Checked ? "1" : "0";
            Properties.Settings.Default.Stuck = CheckBoxSt.Checked ? "1" : "0";
            Properties.Settings.Default.CgPassword = CheckBoxCg.Checked ? "1" : "0";
            Properties.Settings.Default.Forward = ForwardCheckBox.Checked ? "1" : "0";
            Properties.Settings.Default.ModKey = CheckKey.Checked ? "1" : "0";

            Properties.Settings.Default.Save();

            NetHelper.NetPort = TBoxPort.Text.Trim();
            NetHelper.NetMaxConn = TBoxMaxConn.Text.Trim();
            NetHelper.NetBPort = BPortTextBox.Text.Trim();
            NetHelper.NetZPort = ZPortTextBox.Text.Trim();
            NetHelper.NetDPort = DPortTextBox.Text.Trim();
            NetHelper.NetTelecomIp = TelecomTextBox.Text.Trim();
            NetHelper.NetMobileIp = MobileTextBox.Text.Trim();
            NetHelper.NetUnicomIp = UnicomTextBox.Text.Trim();
            NetHelper.NetNameList = NameListTextBox.Text.Trim();
            NetHelper.NetContents = ContentsTextBox.Text.Trim();
            NetHelper.NetDBHost = HostTextBox.Text.Trim();
            NetHelper.NetDBRoot = RootTextBox.Text.Trim();
            NetHelper.NetDBPass = PassTextBox.Text.Trim();
            NetHelper.NetDBPort = PortTextBox.Text.Trim();
            NetHelper.NetDBAuth = AuthTextBox.Text.Trim();
            NetHelper.NetDBChar = CharTextBox.Text.Trim();
            NetHelper.NetGameVe = GameVeTextBox.Text.Trim();
            NetHelper.NetPName = PNameTextBox.Text.Trim();
            NetHelper.NetPMd = PMdTextBox.Text.Trim();
            NetHelper.NetPUrl = PUrlTextBox.Text.Trim();
            NetHelper.NetShopUrl = ShopTextBox.Text.Trim();
            NetHelper.NetGwUrl = GwTextBox.Text;

            NetHelper.NetRegister = CheckBoxReg.Checked ? "1" : "0";
            NetHelper.NetStuck = CheckBoxSt.Checked ? "1" : "0";
            NetHelper.NetCgPassword = CheckBoxCg.Checked ? "1" : "0";
            NetHelper.NetForward = ForwardCheckBox.Checked ? "1" : "0";
            NetHelper.NetModKey = CheckKey.Checked ? "1" : "0";

            string GText = File.ReadAllText(NetHelper.GTextPath, Encoding.UTF8);
            NetHelper.NetGText = GText;

            if (HkServer != null && HkServer.IsStarted)
            {
                SendResetConfigAll();
                ConsoleHelper.WriteLine(true, ">> 所有配置已经更新完毕 已同步到所有登录器");
            }
            else
            {
                ConsoleHelper.WriteLine(true, ">> 所有配置已经更新完毕");
            }
        }
        #endregion

        #region 加载窗口
        private void NetForm_Load(object sender, EventArgs e)
        {
            //窗体标题显示长度和宽度
            Text = Application.ProductName + " [ " + Width.ToString() + " X " + Height.ToString() + " ]";

            //保存初始大小宽度
            NetHelper.CurrX = Width;
            NetHelper.CurrY = Height;
            NetHelper.SetTag(this);

            //挂起事件 处理回调
            AtTimer.Tick += new EventHandler(ShowTimeCallback);
            //设置可用状态
            AtTimer.Enabled = true;
            //设置时间间隔 以毫秒为单位
            AtTimer.Interval = 1000;

            //心跳超时线程 低优先级
            KeepTimeThread = new Thread(KeepTimeStart)
            {
                IsBackground = true,
                Priority = ThreadPriority.Lowest
            };
            KeepTimeThread.Start();

            //加载外部文件的封禁集合到字典中
            StreamReader Sr = new StreamReader(NetHelper.BanPath, Encoding.Default);
            string Line;
            while ((Line = Sr.ReadLine()) != null)
            {
                ListBans.Add(Line.ToString());
                UpdateCBox(Line.ToString(), true);
            }
            Sr.Close();

            try
            {
                //界面委托
                ViewUpdateDelegate = new ListViewUpdate(UpdateListView);
                ViewAppendDelegate = new ListViewAppend(AddPcKeyToListView);

                //设置服务器事件
                HkServer.OnAccept += new ServerEvent.OnAcceptEventHandler(HkServerOnAccept);
                HkServer.OnReceive += new ServerEvent.OnReceiveEventHandler(HkServerOnReceive);
                HkServer.OnClose += new ServerEvent.OnCloseEventHandler(HkServerOnClose);

                SetAppState(AppState.Stoped);
            }
            catch (Exception)
            {
                SetAppState(AppState.Error);
            }
        }
        #endregion

        #region 窗体大小改变处理
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Resize += new EventHandler(TcpForm_Resize);

            //窗体标题显示长度和宽度
            Text = Application.ProductName + " [ " + Width.ToString() + " X " + Height.ToString() + " ]";

            //保存初始大小宽度
            NetHelper.CurrX = Width;
            NetHelper.CurrY = Height;
            NetHelper.SetTag(this);
        }

        private void TcpForm_Resize(object sender, EventArgs e)
        {
            //当前宽度与变化前宽度之比
            float Newx = Width / NetHelper.CurrX;
            //当前高度与变化前宽度之比
            float Newy = Height / NetHelper.CurrY;
            NetHelper.SetControls(Newx, Newy, this);

            //窗体标题显示长度和宽度
            Text = Application.ProductName + " [ " + Width.ToString() + " X " + Height.ToString() + " ]";
        }
        #endregion

        #region 启动关闭按钮
        private void Btn_run_Click(object sender, EventArgs e)
        {
            if (!HkServer.IsStarted)
            {
                if (TBoxPort.Text.Length < 3 || Convert.ToInt32(TBoxPort.Text) < 1024 || Convert.ToInt32(TBoxPort.Text) > 65535)
                {
                    ConsoleHelper.WriteErr(false, ">> 请重新设置 正确的端口 1024-65535");
                    MessageBox.Show(null, "请重新设置 正确的端口 1024-65535", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (NetHelper.TcpPortInUse(Convert.ToInt32(TBoxPort.Text)))
                {
                    ConsoleHelper.WriteErr(false, ">> 请重新设置 端口已被占用");
                    MessageBox.Show(null, "请重新设置 端口已被占用", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var NStore = PNameTextBox.Text.Trim().Split('|');
                if ((PNameTextBox.Text != string.Empty && !PNameTextBox.Text.Contains("|")) || NStore.Length >5)
                {
                    ConsoleHelper.WriteErr(false, ">> 补丁名配置错误 请重新设置");
                    MessageBox.Show(null, "补丁名配置错误 请重新设置", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var MStore = PMdTextBox.Text.Trim().Split('|');
                if ((PMdTextBox.Text != string.Empty && !PMdTextBox.Text.Contains("|")) || MStore.Length > 5)
                {
                    ConsoleHelper.WriteErr(false, ">> 补丁MD5配置错误 请重新设置");
                    MessageBox.Show(null, "补丁MD5配置错误 请重新设置", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var UStore = PUrlTextBox.Text.Trim().Split('|');
                if ((PUrlTextBox.Text != string.Empty && !PUrlTextBox.Text.Contains("|")) || UStore.Length > 6)
                {
                    ConsoleHelper.WriteErr(false, ">> 补丁路径配置错误 请重新设置");
                    MessageBox.Show(null, "补丁路径配置错误 请重新设置", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (PNameTextBox.Text != string.Empty && PMdTextBox.Text != string.Empty && PUrlTextBox.Text != string.Empty && (NStore.Length != MStore.Length || MStore.Length != UStore.Length))
                {
                    ConsoleHelper.WriteErr(false, ">> 补丁配置不一致 请重新设置");
                    MessageBox.Show(null, "补丁配置不一致 请重新设置", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    HkServer.MaxConnectionCount = Convert.ToUInt32(TBoxMaxConn.Text.Trim());

                    SetAppState(AppState.Starting);
                    ushort SerPort = ushort.Parse(TBoxPort.Text.Trim());

                    //设置监听的端口
                    HkServer.Port = SerPort;
                    //启动服务
                    if (!HkServer.Start())
                    {
                        ConsoleHelper.WriteErr(true, ">> 系统出错 无法启动服务");
                        MessageBox.Show(null, "系统出错 无法启动服务", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetAppState(AppState.Stoped);
                        return;
                    }

                    NetHelper.NetDBHost = HostTextBox.Text;
                    NetHelper.NetDBRoot = RootTextBox.Text;
                    NetHelper.NetDBPass = PassTextBox.Text;
                    NetHelper.NetDBPort = PortTextBox.Text;
                    NetHelper.NetDBAuth = AuthTextBox.Text;
                    NetHelper.NetDBChar = CharTextBox.Text;

                    MysqlHandler.StartMySql(HostTextBox.Text.Trim(), PortTextBox.Text.Trim(), AuthTextBox.Text.Trim(), CharTextBox.Text.Trim(), RootTextBox.Text.Trim(), PassTextBox.Text.Trim());

                    SetAppState(AppState.Started);
                    
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, ">> 登录器网关 当前启用端口: " + TBoxPort.Text.Trim());
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, ">> 当前允许的最大连接数: " + TBoxMaxConn.Text.Trim());
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, ">> 当前工作线程池数量: " + HkServer.WorkerThreadCount.ToString());
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, ">> 当前程序文件版本号 " + Application.ProductVersion.ToString());
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, ">> 当前VC++动态库文件版本号 " + NetWorkLib.GetHPSocketVersion());
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, "☆☆☆☆☆☆☆☆☆☆仅限单机使用 永不宕机 商业使用与作者无关☆☆☆☆☆☆☆☆☆☆", ConsoleColor.Cyan);
                    ConsoleHelper.WriteLine(false, "");
                    ConsoleHelper.WriteLine(false, "----------关闭 [控制台] 或 [登录器网关] 退出服务----------");
                    ConsoleHelper.WriteLine(false, "");
                }
                catch (Exception ex)
                {
                    SetAppState(AppState.Stoped);
                    ConsoleHelper.WriteErr(true, ">> 系统出错 启动服务时 产生的异常\n>> 异常信息 " + ex.Message);
                }
            }
            else
            {
                SetAppState(AppState.Stoping);

                if (ListClients.Items.Count >= NetHelper.RCount)
                {
                    DialogResult Res = MessageBox.Show(null, "由于释放的资源过大 为了不影响使用\n建议直接退出再重启\n你确定这样做么?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (Res == DialogResult.OK)
                    {
                        if (HkServer != null)
                        {
                            HkServer.Destroy();
                        }
                        Process.GetCurrentProcess().Kill();
                    }
                    return;
                }

                if (!HkServer.Stop())
                {
                    ConsoleHelper.WriteErr(true, ">> 服务相关组件互斥 暂时无法关闭服务 请稍候尝试");
                    MessageBox.Show(null, "服务相关组件互斥 暂时无法关闭服务 请稍候尝试", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MysqlHandler.StopMySql();

                SetAppState(AppState.Stoped);

                ConsoleHelper.WriteLine(false, "");
                ConsoleHelper.WriteLine(false, ">> 登录器网关 服务已释放重置 服务已完全关闭 可再次启动服务");
                ConsoleHelper.WriteLine(false, "");
            }
        }
        #endregion

        #region 程序运行时间回调函数
        /// <summary>
        /// 程序运行时间回调函数
        /// </summary>
        private void ShowTimeCallback(object sender, EventArgs e)
        {
            ++TimeIdx;
            TimeSpan Ts = new TimeSpan(0, 0, TimeIdx);
            string TimeTx = (int)Ts.TotalHours + "时" + Ts.Minutes + "分" + Ts.Seconds + "秒";
            TimeLt.Text = string.Format("程序运行时间: {0}", TimeTx);
        }
        #endregion

        #region 心跳线程执行方法
        /// <summary>
        /// 静默连接处理 后台线程
        /// </summary>
        private void KeepTimeStart()
        {
            while (true)
            {
                //全局检测 关闭掉静默连接超过时间的 相当于心跳机制 只要客户端在此检测前传入任何数据则不会被关掉
                if (HkServer != null && HkServer.IsStarted)
                {
                    HkServer.DisconnectSilenceConnections(NetHelper.NetSilenceTime * 1000);
                    ConsoleHelper.WriteLine(true, string.Format(">> 心跳线程执行 当前连接数 {0} 更新时间 {1} 秒", HkServer.ConnectionCount.ToString(), NetHelper.NetKeepTime.ToString()), ConsoleColor.DarkGreen);
                }

                Thread.Sleep(NetHelper.NetKeepTime * 1000);
            }
        }
        #endregion

        #region 自定义列表框菜单的操作

        private void MenuSendMsg_Click(object sender, EventArgs e)
        {
            var SItems =ListClients.SelectedItems;
            if (SItems.Count > 0)
            {
                string Datagram = Interaction.InputBox("请在编辑框输入内容", "发送内容到指定客户端", string.Empty, -1, -1);
                if (Datagram != string.Empty)
                {
                    for (int i = 0; i < SItems.Count; i++)
                    {
                        string ClientId = SItems[i].SubItems[1].Text;

                        SendToSelectedClient(ClientId, "SendMsg" + NetHelper.NetSplitOne + Datagram);
                    }
                }
            }

        }

        private void MenuBanIp_Click(object sender, EventArgs e)
        {
            var SItems = ListClients.SelectedItems;
            if (SItems.Count > 0)
            {
                for (int i = 0; i < SItems.Count; i++)
                {
                    string ClientId = SItems[i].SubItems[1].Text;
                    string IpAndPort = SItems[i].SubItems[2].Text;
                    string sIp = IpAndPort.Split(':')[0];

                    SendToSelectedClient(ClientId, "BanIp" + NetHelper.NetSplitOne + sIp + NetHelper.NetSplitOne);
                    ConsoleHelper.WriteLine(true, ">> 网络地址已被封禁 " + sIp);

                    if (!ListBans.Contains(sIp))
                        ListBans.Add(sIp);

                    UpdateCBox(sIp, true);

                    NetHelper.BanFileWriter(sIp);
                }
            }
        }

        private void MenuBanKey_Click(object sender, EventArgs e)
        {
            var SItems = ListClients.SelectedItems;
            if (SItems.Count > 0)
            {
                for (int i = 0; i < SItems.Count; i++)
                {
                    string ClientId = SItems[i].SubItems[1].Text;
                    string IpAndPort = SItems[i].SubItems[2].Text;
                    string sIp = IpAndPort.Split(':')[0];
                    string PcKey = SItems[i].SubItems[3].Text;

                    SendToSelectedClient(ClientId, "BanPcKey" + NetHelper.NetSplitOne + PcKey + NetHelper.NetSplitOne);
                    ConsoleHelper.WriteLine(true, ">> 机器码已被封禁 " + PcKey);

                    if (!ListBans.Contains(PcKey))
                        ListBans.Add(PcKey);

                    UpdateCBox(PcKey, true);

                    NetHelper.BanFileWriter(PcKey);
                }
            }
        }

        private void UnBanBtn_Click(object sender, EventArgs e)
        {
            string CText = BanComboBox.Text;
            if (CText != string.Empty)
            {
                if (ListBans.Contains(CText))
                    ListBans.Remove(CText);

                UpdateCBox(CText, false);

                NetHelper.UnBanFileWriter(CText);

                ConsoleHelper.WriteLine(true, string.Format(">> 解封 {0} 操作完毕 解封成功", CText));
            }
        }
        #endregion

        #region 更新项目
        /// <summary>
        /// 更新增/删
        /// </summary>
        private void UpdateListView(IntPtr ClientId, string IpAndPort, bool Apply)
        {
            if (ListClients.InvokeRequired)
            {
                //调用自己
                ListClients.Invoke(ViewUpdateDelegate, ClientId, IpAndPort, Apply);
            }
            else
            {
                ListClients.BeginUpdate();
                if (Apply)
                {
                    ListViewItem List;
                    List = new ListViewItem(" 登录器在线", 0);

                    List.SubItems.Add(ClientId.ToString());
                    List.SubItems.Add(IpAndPort);
                    List.SubItems.Add("AAAAAAAAAAAAAAAA");

                    ListClients.Items.Add(List);
                }
                else
                {
                    for (int i = ListClients.Items.Count - 1; i >= 0; i--)
                    {
                        string Id = ListClients.Items[i].SubItems[1].Text;
                        if (Id == ClientId.ToString())
                            ListClients.Items[i].Remove();
                    }
                }

                ListClients.EndUpdate();

                OnLineTextBox.Text = "当前在线: " + ListClients.Items.Count.ToString();
            }
        }
        #endregion

        #region 追加机器码
        /// <summary>
        /// 追加机器码
        /// </summary>
        private void AddPcKeyToListView(string IpAndPort, string PcKey)
        {
            if (ListClients.InvokeRequired)
            {
                //调用自己
                ListClients.Invoke(ViewAppendDelegate, IpAndPort, PcKey);
            }
            else
            {
                ListClients.BeginUpdate();
                for (int i = 0; i < ListClients.Items.Count; i++)
                {
                    string IpPort = ListClients.Items[i].SubItems[2].Text;
                    if (IpPort == IpAndPort)
                        ListClients.Items[i].SubItems[3].Text = PcKey;
                }
                ListClients.EndUpdate();
            }
        }
        #endregion

        #region 更新组合框的状态
        private void UpdateCBox(string Ban, bool Apply)
        {
            BanComboBox.Invoke((MethodInvoker)delegate
            {
                if (Apply)
                {
                    BanComboBox.Items.Add(Ban);
                }
                else
                {
                    BanComboBox.Items.Remove(Ban);
                    if (BanComboBox.Items.Count <= 0)
                    {
                        BanComboBox.Text = "";
                    }
                }
            });
        }
        #endregion

        #region 程序关闭之前的提醒和释放资源
        private void NetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Dr = MessageBox.Show(null, "关闭程序会使服务强制停止\n你确定要这么做吗?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Dr != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = false;

            if (KeepTimeThread != null)
            {
                KeepTimeThread.Abort();
                KeepTimeThread.Join();
            }

            if (HkServer != null)
            {
                HkServer.Destroy();
            }
        }
        #endregion

        #region 设置程序状态
        /// <summary>
        /// 设置程序状态
        /// </summary>
        private void SetAppState(AppState State)
        {
            NowAppState = State;
            bool Bet = (NowAppState == AppState.Stoped);

            TBoxPort.Enabled = Bet;
            TBoxMaxConn.Enabled = Bet;
            BPortTextBox.Enabled = Bet;
            ZPortTextBox.Enabled = Bet;
            DPortTextBox.Enabled = Bet;
            TelecomTextBox.Enabled = Bet;
            MobileTextBox.Enabled = Bet;
            UnicomTextBox.Enabled = Bet;
            NameListTextBox.Enabled = Bet;
            HostTextBox.Enabled = Bet;
            RootTextBox.Enabled = Bet;
            PassTextBox.Enabled = Bet;
            PortTextBox.Enabled = Bet;
            AuthTextBox.Enabled = Bet;
            CharTextBox.Enabled = Bet;
            GameVeTextBox.Enabled = Bet;

            Worklabel.Text = Bet ? "工作线程池数: 处理器核心 X 2 + 2" : "工作线程池数: " + HkServer.WorkerThreadCount.ToString();
            BtnStart.ForeColor = Bet ? Color.Green : Color.Red;
            BtnStart.Text = Bet ? "启动服务" : "关闭服务";
        }
        #endregion

        #region 通信服务处理-服务端关闭-客户端连接-客户端关闭-客户端发来的数据
        HandleResult HkServerOnAccept(IServer Sender, IntPtr ConnectId, IntPtr Client)
        {
            //客户端进入

            //获取客户端地址和端口
            var IpAndPort = HkServer.GetIpAndPortString(ConnectId);
            var IpAccept = IpAndPort.Split(':')[0];
            
            if (!AcceptIps.ContainsKey(IpAccept))
                AcceptIps[IpAccept] = 0;

            if (AcceptIps[IpAccept] >= NetHelper.NetInIps)
                return HandleResult.Error;

            AcceptIps[IpAccept]++;

            UpdateListView(ConnectId, IpAndPort, true);

            return HandleResult.Ok;
        }

        HandleResult HkServerOnClose(IServer Sender, IntPtr ConnectId, SocketOperation EnOperation, int ErrorCode)
        {
            //客户端关闭或强制关闭 错误等等 任何错误都应该关闭 ErrorCode != 0 表示正常退出 非正常退出则 EnOperation=类型 ErrorCode=代号

            //获取客户端地址和端口
            var IpAndPort = HkServer.GetIpAndPortString(ConnectId);
            var IpAccept = IpAndPort.Split(':')[0];
            if (AcceptIps.ContainsKey(IpAccept))
                AcceptIps[IpAccept]--;

            UpdateListView(ConnectId, IpAndPort, false);

            return HandleResult.Ok;
        }

        HandleResult HkServerOnReceive(IServer Sender, IntPtr ConnectId, byte[] Bytes)
        {
            //数据到达
            try
            {
                //获取客户端地址和端口
                string ClientIp = string.Empty;
                ushort ClientPort = 0;
                if (!HkServer.GetRemoteAddress(ConnectId, ref ClientIp, ref ClientPort))
                    return HandleResult.Error;

                //解密
                var DeCodeBytes = NetHelper.AlgorithmToByte(Bytes);
                string ReadData = Encoding.UTF8.GetString(DeCodeBytes, 0, DeCodeBytes.Length);

                if (!ReadData.Contains(NetHelper.NetSplitOne))
                {
                    return HandleResult.Error;
                }

                //ConsoleHelper.WriteLine(true, ">> 接收到数据 " + ReadData);

                //如果收到的消息 不包含指定的消息字符 则判定为非法 立刻断开
                if (!ReadData.Contains(NetHelper.NetPacketHead + NetHelper.NetSplitOne))
                {
                    //ConsoleHelper.WriteLine(true, ">> 非法消息 " + ReadData + " 来自 " + IpAndPort + " 系统自动踢出");
                    //HkServer.Disconnect(ConnectId);
                    return HandleResult.Error;
                }

                if (ReadData == NetHelper.NetKeep)
                    return HandleResult.Ok;

                var SplitData = ReadData.Split(NetHelper.NetSplitOne.ToCharArray());

                if (SplitData.Length < 1)
                    return HandleResult.Ignore;

                switch (SplitData[1])
                {
                    //拼接
                    case "LoginGetConfigToOne":

                        var PcKey = SplitData[2];

                        if (ListBans.Contains(ClientIp))
                        {
                            ConsoleHelper.WriteLine(true, ">> 由于系统封禁IP地址强制踢出 " + ClientIp);
                            ServerSend(ConnectId, "BanIp" + NetHelper.NetSplitOne + ClientIp + NetHelper.NetSplitOne);
                            return HandleResult.Ignore;
                        }

                        if (ListBans.Contains(PcKey))
                        {
                            ConsoleHelper.WriteLine(true, ">> 由于系统封禁机器码强制踢出 " + PcKey);
                            ServerSend(ConnectId, "BanIp" + NetHelper.NetSplitOne + PcKey + NetHelper.NetSplitOne);
                            return HandleResult.Ignore;
                        }

                        var IpAndPort = ClientIp + ":" + ClientPort.ToString();
                        AddPcKeyToListView(IpAndPort, PcKey);

                        string sData = "SendConfig" + NetHelper.NetSplitOne
                            + NetHelper.NetBPort + NetHelper.NetSplitOne + NetHelper.NetZPort + NetHelper.NetSplitOne + NetHelper.NetDPort + NetHelper.NetSplitOne
                            + NetHelper.NetTelecomIp + NetHelper.NetSplitOne + NetHelper.NetMobileIp + NetHelper.NetSplitOne + NetHelper.NetUnicomIp + NetHelper.NetSplitOne
                            + NetHelper.NetNameList + NetHelper.NetSplitOne + NetHelper.NetContents + NetHelper.NetSplitOne + NetHelper.NetRegister + NetHelper.NetSplitOne
                            + NetHelper.NetStuck + NetHelper.NetSplitOne + NetHelper.NetCgPassword + NetHelper.NetSplitOne + NetHelper.NetGameVe + NetHelper.NetSplitOne
                            + NetHelper.NetPName + NetHelper.NetSplitOne + NetHelper.NetPMd + NetHelper.NetSplitOne + NetHelper.NetPUrl + NetHelper.NetSplitOne
                            + NetHelper.NetShopUrl + NetHelper.NetSplitOne + NetHelper.NetGwUrl + NetHelper.NetSplitOne + NetHelper.NetForward + NetHelper.NetSplitOne
                            + NetHelper.NetModKey + NetHelper.NetSplitOne + NetHelper.NetGText + NetHelper.NetSplitOne;
                        
                        return ServerSend(ConnectId, sData);
                    case "Reg":
                        string UserName = SplitData[2];
                        string UserPass = SplitData[3];
                        string Security = SplitData[4];
                        MysqlResult RegRes = MysqlHandler.RegisterUser(UserName, UserPass, Security, ClientIp);
                        switch (RegRes)
                        {
                            case MysqlResult.Error:
                                return ServerSend(ConnectId, "RegError" + NetHelper.NetSplitOne);
                            case MysqlResult.Has:
                                return ServerSend(ConnectId, "RegHas" + NetHelper.NetSplitOne);
                            case MysqlResult.Yes:
                                ConsoleHelper.WriteLine(true, ">> 账号注册成功 " + ClientIp + ":" + ClientPort.ToString() + " 账号 " + UserName);
                                return ServerSend(ConnectId, "RegOk" + NetHelper.NetSplitOne + UserName + NetHelper.NetSplitOne + UserPass + NetHelper.NetSplitOne + Security + NetHelper.NetSplitOne);
                            default:
                                return ServerSend(ConnectId, "RegError" + NetHelper.NetSplitOne);
                        }
                    case "Player":
                        string UName = SplitData[2];
                        string UPass = SplitData[3];
                        string PName = SplitData[4];
                        MysqlResult PlayerRes = MysqlHandler.UnlockName(UName, UPass, PName);
                        switch (PlayerRes)
                        {
                            case MysqlResult.Error:
                                return ServerSend(ConnectId, "PlayerError" + NetHelper.NetSplitOne);
                            case MysqlResult.Has:
                                return ServerSend(ConnectId, "NoPass" + NetHelper.NetSplitOne);
                            case MysqlResult.Wrong:
                                return ServerSend(ConnectId, "NoPlayer" + NetHelper.NetSplitOne);
                            case MysqlResult.Yes:
                                ConsoleHelper.WriteLine(true, ">> 角色解卡成功 " + ClientIp + ":" + ClientPort.ToString() + " 角色 " + PName);
                                return ServerSend(ConnectId, "PlayerOk" + NetHelper.NetSplitOne + PName + NetHelper.NetSplitOne);
                            default:
                                return ServerSend(ConnectId, "PlayerError" + NetHelper.NetSplitOne);
                        }
                    case "Pass":
                        string WName = SplitData[2];
                        string WPass = SplitData[3];
                        string WSecurity = SplitData[4];
                        MysqlResult PassRes = MysqlHandler.ChangePass(WName, WPass, WSecurity);
                        switch (PassRes)
                        {
                            case MysqlResult.Error:
                                return ServerSend(ConnectId, "PassError" + NetHelper.NetSplitOne);
                            case MysqlResult.Wrong:
                                return ServerSend(ConnectId, "PassNo" + NetHelper.NetSplitOne);
                            case MysqlResult.Yes:
                                ConsoleHelper.WriteLine(true, ">> 修改密码成功 " + ClientIp + ":" + ClientPort.ToString() + " 密码 " + WPass);
                                return ServerSend(ConnectId, "PassOk" + NetHelper.NetSplitOne + WPass + NetHelper.NetSplitOne);
                            default:
                                return ServerSend(ConnectId, "PassError" + NetHelper.NetSplitOne);
                        }
                }

                //在以上的流程保证都有返回 那么此时这里就是错误的 应当断开
                return HandleResult.Error;
            }
            catch (Exception)
            {
                return HandleResult.Ignore;
            }
        }
        #endregion

        #region 发消息到客户端的方法
        /// <summary>
        /// 发送给指定连接
        /// </summary>
        private HandleResult ServerSend(IntPtr ConnectId, string Datagram)
        {
            var SendData = Encoding.UTF8.GetBytes(Datagram);

            //加密
            var EncryData = NetHelper.AlgorithmToByte(SendData);

            return HkServer.Send(ConnectId, EncryData, EncryData.Length) ? HandleResult.Ok : HandleResult.Error;
        }

        /// <summary>
        /// 发送给指定连接
        /// </summary>
        public HandleResult SendToSelectedClient(string ConnectId, string Datagram)
        {
            return ServerSend((IntPtr)Convert.ToInt32(ConnectId), Datagram);
        }

        /// <summary>
        /// 发送给全部连接
        /// </summary>
        private HandleResult ServerSendToAll(string Datagram)
        {
            var SendData = Encoding.UTF8.GetBytes(Datagram);
            //加密
            var EncryData = NetHelper.AlgorithmToByte(SendData);

            IntPtr[] IntPtrList = HkServer.GetAllConnectionIDs();
            if (IntPtrList == null)
                return HandleResult.Error;

            bool Ret = true;
            foreach (IntPtr ConnectId in IntPtrList)
            {
                Ret = HkServer.Send(ConnectId, EncryData, EncryData.Length);
            }

            return Ret ? HandleResult.Ok : HandleResult.Error;
        }

        /// <summary>
        /// 发送给全部连接 配置信息
        /// </summary>
        public HandleResult SendResetConfigAll()
        {
            string sData = "ResetAllConfig" + NetHelper.NetSplitOne
                            + NetHelper.NetBPort + NetHelper.NetSplitOne + NetHelper.NetZPort + NetHelper.NetSplitOne + NetHelper.NetDPort + NetHelper.NetSplitOne
                            + NetHelper.NetTelecomIp + NetHelper.NetSplitOne + NetHelper.NetMobileIp + NetHelper.NetSplitOne + NetHelper.NetUnicomIp + NetHelper.NetSplitOne
                            + NetHelper.NetNameList + NetHelper.NetSplitOne + NetHelper.NetContents + NetHelper.NetSplitOne + NetHelper.NetRegister + NetHelper.NetSplitOne
                            + NetHelper.NetStuck + NetHelper.NetSplitOne + NetHelper.NetCgPassword + NetHelper.NetSplitOne + NetHelper.NetGameVe + NetHelper.NetSplitOne
                            + NetHelper.NetPName + NetHelper.NetSplitOne + NetHelper.NetPMd + NetHelper.NetSplitOne + NetHelper.NetPUrl + NetHelper.NetSplitOne
                            + NetHelper.NetShopUrl + NetHelper.NetSplitOne + NetHelper.NetGwUrl + NetHelper.NetSplitOne + NetHelper.NetForward + NetHelper.NetSplitOne
                            + NetHelper.NetModKey + NetHelper.NetSplitOne + NetHelper.NetGText + NetHelper.NetSplitOne;

            return ServerSendToAll(sData);
        }
        #endregion

        private void KeyButton_Click(object sender, EventArgs e)
        {
            if (!CheckKey.Checked)
            {
                ConsoleHelper.WriteErr(false, ">> 补丁加密模块尚未开启 无法使用此功能");
                return;
            }

            ConsoleHelper.WriteLine(false, "");
            ConsoleHelper.WriteLine(false, ">> ----------补丁加密 开始进行----------", ConsoleColor.DarkMagenta);
            ConsoleHelper.WriteLine(false, "");

            var NPatch = PNameTextBox.Text.Trim().Split('|');
            foreach (var Patchs in NPatch)
            {
                if (Patchs == string.Empty)
                    continue;

                string ThePath = Application.StartupPath + "\\" + Patchs;

                if (!File.Exists(ThePath))
                {
                    ConsoleHelper.WriteErr(false, ">> ----------补丁文件 [" + Patchs + "] 不存在 已忽略----------");
                    continue;
                }

                ConsoleHelper.WriteLine(false, ">> ----------正在进行 [" + Patchs + "] 加密中----------");

                int DoRun = NetHelper.DoEncryption(ThePath);
                if (DoRun == 2)
                    ConsoleHelper.WriteErr(false, ">> [" + Patchs + "] 加密不成功 读取文件出错...");
                else if (DoRun == 3)
                    ConsoleHelper.WriteErr(false, ">> [" + Patchs + "] 加密不成功 此补丁已经加密过了...");
                else if (DoRun == 0)
                    ConsoleHelper.WriteErr(false, ">> [" + Patchs + "] 加密不成功 未知错误 请联系作者...");
                else if (DoRun == 1)
                    ConsoleHelper.WriteLine(false, ">> [" + Patchs + "] 加密成功 请将文件拷贝保存", ConsoleColor.Green);
            }
            ConsoleHelper.WriteLine(false, "");
            ConsoleHelper.WriteLine(false, ">> ----------补丁加密 过程结束----------", ConsoleColor.DarkMagenta);
        }
    }
}
