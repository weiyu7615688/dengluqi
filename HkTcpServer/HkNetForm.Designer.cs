namespace IoNetWork
{
    partial class HkNetForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 窗体构造

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HkNetForm));
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuSendMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBanIp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBanKey = new System.Windows.Forms.ToolStripMenuItem();
            this.ListImages = new System.Windows.Forms.ImageList(this.components);
            this.PortStaticText = new System.Windows.Forms.Label();
            this.TBoxPort = new System.Windows.Forms.TextBox();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.MaxStaticText = new System.Windows.Forms.Label();
            this.TBoxMaxConn = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.ListClients = new System.Windows.Forms.ListView();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetIpAndPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PcKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DPortStatic = new System.Windows.Forms.Label();
            this.ZPortStatic = new System.Windows.Forms.Label();
            this.DPortTextBox = new System.Windows.Forms.TextBox();
            this.ZPortTextBox = new System.Windows.Forms.TextBox();
            this.BPortStatic = new System.Windows.Forms.Label();
            this.BPortTextBox = new System.Windows.Forms.TextBox();
            this.UnicomStatic = new System.Windows.Forms.Label();
            this.MobileStatic = new System.Windows.Forms.Label();
            this.UnicomTextBox = new System.Windows.Forms.TextBox();
            this.MobileTextBox = new System.Windows.Forms.TextBox();
            this.TelecomStatic = new System.Windows.Forms.Label();
            this.TelecomTextBox = new System.Windows.Forms.TextBox();
            this.NameListStatic = new System.Windows.Forms.Label();
            this.NameListTextBox = new System.Windows.Forms.TextBox();
            this.ContentsStatic = new System.Windows.Forms.Label();
            this.ContentsTextBox = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ForwardCheckBox = new System.Windows.Forms.CheckBox();
            this.Worklabel = new System.Windows.Forms.Label();
            this.TimeLt = new System.Windows.Forms.Label();
            this.CheckBoxCg = new System.Windows.Forms.CheckBox();
            this.CheckBoxSt = new System.Windows.Forms.CheckBox();
            this.CheckBoxReg = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.DBHostStatic = new System.Windows.Forms.Label();
            this.RootTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.DBRootStatic = new System.Windows.Forms.Label();
            this.DBPassStatic = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.DBPortStatic = new System.Windows.Forms.Label();
            this.GameVeStatic = new System.Windows.Forms.Label();
            this.AuthTextBox = new System.Windows.Forms.TextBox();
            this.GameVeTextBox = new System.Windows.Forms.TextBox();
            this.CharTextBox = new System.Windows.Forms.TextBox();
            this.DBCharStatic = new System.Windows.Forms.Label();
            this.DBAuthStatic = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GwTextBox = new System.Windows.Forms.TextBox();
            this.GwLabel = new System.Windows.Forms.Label();
            this.PNameTextBox = new System.Windows.Forms.TextBox();
            this.PathName = new System.Windows.Forms.Label();
            this.PMdTextBox = new System.Windows.Forms.TextBox();
            this.PUrlTextBox = new System.Windows.Forms.TextBox();
            this.PathMd = new System.Windows.Forms.Label();
            this.PathUrl = new System.Windows.Forms.Label();
            this.ShopTextBox = new System.Windows.Forms.TextBox();
            this.ShopUrl = new System.Windows.Forms.Label();
            this.OnLineTextBox = new System.Windows.Forms.TextBox();
            this.UnBanBtn = new System.Windows.Forms.Button();
            this.BanComboBox = new System.Windows.Forms.ComboBox();
            this.BanListLabel = new System.Windows.Forms.Label();
            this.KeyButton = new System.Windows.Forms.Button();
            this.CheckKey = new System.Windows.Forms.CheckBox();
            this.MenuStrip.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSendMsg,
            this.MenuBanIp,
            this.MenuBanKey});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(149, 72);
            // 
            // MenuSendMsg
            // 
            this.MenuSendMsg.Name = "MenuSendMsg";
            this.MenuSendMsg.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.MenuSendMsg.Size = new System.Drawing.Size(148, 24);
            this.MenuSendMsg.Text = "发送通知消息";
            this.MenuSendMsg.Click += new System.EventHandler(this.MenuSendMsg_Click);
            // 
            // MenuBanIp
            // 
            this.MenuBanIp.Name = "MenuBanIp";
            this.MenuBanIp.Size = new System.Drawing.Size(148, 22);
            this.MenuBanIp.Text = "封禁网络地址";
            this.MenuBanIp.Click += new System.EventHandler(this.MenuBanIp_Click);
            // 
            // MenuBanKey
            // 
            this.MenuBanKey.Name = "MenuBanKey";
            this.MenuBanKey.Size = new System.Drawing.Size(148, 22);
            this.MenuBanKey.Text = "封禁机器码";
            this.MenuBanKey.Click += new System.EventHandler(this.MenuBanKey_Click);
            // 
            // ListImages
            // 
            this.ListImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListImages.ImageStream")));
            this.ListImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ListImages.Images.SetKeyName(0, "UserVa.ico");
            this.ListImages.Images.SetKeyName(1, "UserVo.ico");
            // 
            // PortStaticText
            // 
            this.PortStaticText.Location = new System.Drawing.Point(5, 87);
            this.PortStaticText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.PortStaticText.Name = "PortStaticText";
            this.PortStaticText.Size = new System.Drawing.Size(80, 30);
            this.PortStaticText.TabIndex = 11;
            this.PortStaticText.Text = "服务端口";
            this.PortStaticText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBoxPort
            // 
            this.TBoxPort.BackColor = System.Drawing.Color.Linen;
            this.TBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBoxPort.Location = new System.Drawing.Point(93, 92);
            this.TBoxPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.TBoxPort.Name = "TBoxPort";
            this.TBoxPort.Size = new System.Drawing.Size(142, 23);
            this.TBoxPort.TabIndex = 1;
            // 
            // BtnSettings
            // 
            this.BtnSettings.BackColor = System.Drawing.Color.Ivory;
            this.BtnSettings.ForeColor = System.Drawing.Color.Sienna;
            this.BtnSettings.Location = new System.Drawing.Point(851, 51);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(160, 40);
            this.BtnSettings.TabIndex = 7;
            this.BtnSettings.TabStop = false;
            this.BtnSettings.Text = "更新保存当前配置";
            this.BtnSettings.UseVisualStyleBackColor = false;
            this.BtnSettings.Click += new System.EventHandler(this.Btn_setting_Click);
            // 
            // MaxStaticText
            // 
            this.MaxStaticText.Location = new System.Drawing.Point(5, 60);
            this.MaxStaticText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.MaxStaticText.Name = "MaxStaticText";
            this.MaxStaticText.Size = new System.Drawing.Size(80, 30);
            this.MaxStaticText.TabIndex = 10;
            this.MaxStaticText.Text = "最大连接";
            this.MaxStaticText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBoxMaxConn
            // 
            this.TBoxMaxConn.BackColor = System.Drawing.Color.Linen;
            this.TBoxMaxConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBoxMaxConn.Location = new System.Drawing.Point(93, 64);
            this.TBoxMaxConn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.TBoxMaxConn.Name = "TBoxMaxConn";
            this.TBoxMaxConn.Size = new System.Drawing.Size(142, 23);
            this.TBoxMaxConn.TabIndex = 0;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Ivory;
            this.BtnStart.ForeColor = System.Drawing.Color.Green;
            this.BtnStart.Location = new System.Drawing.Point(851, 101);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(160, 40);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.TabStop = false;
            this.BtnStart.Text = "启动服务";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.Btn_run_Click);
            // 
            // ListClients
            // 
            this.ListClients.BackColor = System.Drawing.Color.Gainsboro;
            this.ListClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.NetNum,
            this.NetIpAndPort,
            this.PcKey});
            this.ListClients.ContextMenuStrip = this.MenuStrip;
            this.ListClients.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListClients.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ListClients.FullRowSelect = true;
            this.ListClients.GridLines = true;
            this.ListClients.HideSelection = false;
            this.ListClients.LabelWrap = false;
            this.ListClients.Location = new System.Drawing.Point(261, 288);
            this.ListClients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListClients.Name = "ListClients";
            this.ListClients.Size = new System.Drawing.Size(750, 467);
            this.ListClients.SmallImageList = this.ListImages;
            this.ListClients.TabIndex = 13;
            this.ListClients.TabStop = false;
            this.ListClients.UseCompatibleStateImageBehavior = false;
            this.ListClients.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.Text = "在线列表";
            this.Status.Width = 120;
            // 
            // NetNum
            // 
            this.NetNum.Text = "在线编号";
            this.NetNum.Width = 80;
            // 
            // NetIpAndPort
            // 
            this.NetIpAndPort.Text = "网络地址端口";
            this.NetIpAndPort.Width = 160;
            // 
            // PcKey
            // 
            this.PcKey.Text = "机器码";
            this.PcKey.Width = 360;
            // 
            // DPortStatic
            // 
            this.DPortStatic.Location = new System.Drawing.Point(5, 253);
            this.DPortStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.DPortStatic.Name = "DPortStatic";
            this.DPortStatic.Size = new System.Drawing.Size(80, 30);
            this.DPortStatic.TabIndex = 19;
            this.DPortStatic.Text = "登录端口";
            this.DPortStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZPortStatic
            // 
            this.ZPortStatic.Location = new System.Drawing.Point(5, 225);
            this.ZPortStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.ZPortStatic.Name = "ZPortStatic";
            this.ZPortStatic.Size = new System.Drawing.Size(80, 30);
            this.ZPortStatic.TabIndex = 18;
            this.ZPortStatic.Text = "转发端口";
            this.ZPortStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DPortTextBox
            // 
            this.DPortTextBox.BackColor = System.Drawing.Color.Linen;
            this.DPortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DPortTextBox.Location = new System.Drawing.Point(93, 258);
            this.DPortTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.DPortTextBox.Name = "DPortTextBox";
            this.DPortTextBox.Size = new System.Drawing.Size(142, 23);
            this.DPortTextBox.TabIndex = 16;
            // 
            // ZPortTextBox
            // 
            this.ZPortTextBox.BackColor = System.Drawing.Color.Linen;
            this.ZPortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZPortTextBox.Location = new System.Drawing.Point(93, 230);
            this.ZPortTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.ZPortTextBox.Name = "ZPortTextBox";
            this.ZPortTextBox.Size = new System.Drawing.Size(142, 23);
            this.ZPortTextBox.TabIndex = 15;
            // 
            // BPortStatic
            // 
            this.BPortStatic.Location = new System.Drawing.Point(5, 197);
            this.BPortStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.BPortStatic.Name = "BPortStatic";
            this.BPortStatic.Size = new System.Drawing.Size(80, 30);
            this.BPortStatic.TabIndex = 17;
            this.BPortStatic.Text = "本地端口";
            this.BPortStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BPortTextBox
            // 
            this.BPortTextBox.BackColor = System.Drawing.Color.Linen;
            this.BPortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BPortTextBox.Location = new System.Drawing.Point(93, 202);
            this.BPortTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.BPortTextBox.Name = "BPortTextBox";
            this.BPortTextBox.Size = new System.Drawing.Size(142, 23);
            this.BPortTextBox.TabIndex = 14;
            // 
            // UnicomStatic
            // 
            this.UnicomStatic.Location = new System.Drawing.Point(5, 337);
            this.UnicomStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.UnicomStatic.Name = "UnicomStatic";
            this.UnicomStatic.Size = new System.Drawing.Size(80, 30);
            this.UnicomStatic.TabIndex = 25;
            this.UnicomStatic.Text = "联通地址";
            this.UnicomStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MobileStatic
            // 
            this.MobileStatic.Location = new System.Drawing.Point(5, 309);
            this.MobileStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.MobileStatic.Name = "MobileStatic";
            this.MobileStatic.Size = new System.Drawing.Size(80, 30);
            this.MobileStatic.TabIndex = 24;
            this.MobileStatic.Text = "移动地址";
            this.MobileStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UnicomTextBox
            // 
            this.UnicomTextBox.BackColor = System.Drawing.Color.Linen;
            this.UnicomTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnicomTextBox.Location = new System.Drawing.Point(93, 342);
            this.UnicomTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.UnicomTextBox.Name = "UnicomTextBox";
            this.UnicomTextBox.Size = new System.Drawing.Size(142, 23);
            this.UnicomTextBox.TabIndex = 22;
            // 
            // MobileTextBox
            // 
            this.MobileTextBox.BackColor = System.Drawing.Color.Linen;
            this.MobileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MobileTextBox.Location = new System.Drawing.Point(93, 314);
            this.MobileTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.MobileTextBox.Name = "MobileTextBox";
            this.MobileTextBox.Size = new System.Drawing.Size(142, 23);
            this.MobileTextBox.TabIndex = 21;
            // 
            // TelecomStatic
            // 
            this.TelecomStatic.Location = new System.Drawing.Point(5, 281);
            this.TelecomStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.TelecomStatic.Name = "TelecomStatic";
            this.TelecomStatic.Size = new System.Drawing.Size(80, 30);
            this.TelecomStatic.TabIndex = 23;
            this.TelecomStatic.Text = "电信地址";
            this.TelecomStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelecomTextBox
            // 
            this.TelecomTextBox.BackColor = System.Drawing.Color.Linen;
            this.TelecomTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TelecomTextBox.Location = new System.Drawing.Point(93, 286);
            this.TelecomTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.TelecomTextBox.Name = "TelecomTextBox";
            this.TelecomTextBox.Size = new System.Drawing.Size(142, 23);
            this.TelecomTextBox.TabIndex = 20;
            // 
            // NameListStatic
            // 
            this.NameListStatic.Location = new System.Drawing.Point(5, 368);
            this.NameListStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.NameListStatic.Name = "NameListStatic";
            this.NameListStatic.Size = new System.Drawing.Size(80, 30);
            this.NameListStatic.TabIndex = 27;
            this.NameListStatic.Text = "区服名字";
            this.NameListStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameListTextBox
            // 
            this.NameListTextBox.BackColor = System.Drawing.Color.Linen;
            this.NameListTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameListTextBox.Location = new System.Drawing.Point(93, 370);
            this.NameListTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.NameListTextBox.Name = "NameListTextBox";
            this.NameListTextBox.Size = new System.Drawing.Size(142, 23);
            this.NameListTextBox.TabIndex = 26;
            // 
            // ContentsStatic
            // 
            this.ContentsStatic.Location = new System.Drawing.Point(5, 393);
            this.ContentsStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.ContentsStatic.Name = "ContentsStatic";
            this.ContentsStatic.Size = new System.Drawing.Size(80, 30);
            this.ContentsStatic.TabIndex = 29;
            this.ContentsStatic.Text = "多开数量";
            this.ContentsStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContentsTextBox
            // 
            this.ContentsTextBox.BackColor = System.Drawing.Color.Linen;
            this.ContentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentsTextBox.Location = new System.Drawing.Point(93, 398);
            this.ContentsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.ContentsTextBox.Name = "ContentsTextBox";
            this.ContentsTextBox.Size = new System.Drawing.Size(142, 23);
            this.ContentsTextBox.TabIndex = 28;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ForwardCheckBox);
            this.GroupBox1.Controls.Add(this.Worklabel);
            this.GroupBox1.Controls.Add(this.TimeLt);
            this.GroupBox1.Controls.Add(this.CheckBoxCg);
            this.GroupBox1.Controls.Add(this.CheckBoxSt);
            this.GroupBox1.Controls.Add(this.ContentsTextBox);
            this.GroupBox1.Controls.Add(this.CheckBoxReg);
            this.GroupBox1.Controls.Add(this.ContentsStatic);
            this.GroupBox1.Controls.Add(this.TBoxMaxConn);
            this.GroupBox1.Controls.Add(this.MaxStaticText);
            this.GroupBox1.Controls.Add(this.NameListStatic);
            this.GroupBox1.Controls.Add(this.TBoxPort);
            this.GroupBox1.Controls.Add(this.NameListTextBox);
            this.GroupBox1.Controls.Add(this.UnicomStatic);
            this.GroupBox1.Controls.Add(this.PortStaticText);
            this.GroupBox1.Controls.Add(this.MobileStatic);
            this.GroupBox1.Controls.Add(this.UnicomTextBox);
            this.GroupBox1.Controls.Add(this.BPortTextBox);
            this.GroupBox1.Controls.Add(this.MobileTextBox);
            this.GroupBox1.Controls.Add(this.BPortStatic);
            this.GroupBox1.Controls.Add(this.TelecomStatic);
            this.GroupBox1.Controls.Add(this.ZPortTextBox);
            this.GroupBox1.Controls.Add(this.TelecomTextBox);
            this.GroupBox1.Controls.Add(this.DPortTextBox);
            this.GroupBox1.Controls.Add(this.DPortStatic);
            this.GroupBox1.Controls.Add(this.ZPortStatic);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(242, 480);
            this.GroupBox1.TabIndex = 30;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "网络配置";
            // 
            // ForwardCheckBox
            // 
            this.ForwardCheckBox.Location = new System.Drawing.Point(53, 165);
            this.ForwardCheckBox.Name = "ForwardCheckBox";
            this.ForwardCheckBox.Size = new System.Drawing.Size(142, 24);
            this.ForwardCheckBox.TabIndex = 82;
            this.ForwardCheckBox.TabStop = false;
            this.ForwardCheckBox.Text = "是否开启端口转发";
            this.ForwardCheckBox.UseVisualStyleBackColor = true;
            // 
            // Worklabel
            // 
            this.Worklabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Worklabel.Location = new System.Drawing.Point(7, 127);
            this.Worklabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.Worklabel.Name = "Worklabel";
            this.Worklabel.Size = new System.Drawing.Size(228, 30);
            this.Worklabel.TabIndex = 81;
            this.Worklabel.Text = "工作线程池数: 处理器核心 X 2 + 2";
            this.Worklabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeLt
            // 
            this.TimeLt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.TimeLt.Location = new System.Drawing.Point(7, 23);
            this.TimeLt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.TimeLt.Name = "TimeLt";
            this.TimeLt.Size = new System.Drawing.Size(228, 30);
            this.TimeLt.TabIndex = 80;
            this.TimeLt.Text = "程序运行时间: 0时0分0秒";
            this.TimeLt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckBoxCg
            // 
            this.CheckBoxCg.Location = new System.Drawing.Point(159, 451);
            this.CheckBoxCg.Name = "CheckBoxCg";
            this.CheckBoxCg.Size = new System.Drawing.Size(60, 24);
            this.CheckBoxCg.TabIndex = 28;
            this.CheckBoxCg.TabStop = false;
            this.CheckBoxCg.Text = "改密";
            this.CheckBoxCg.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSt
            // 
            this.CheckBoxSt.Location = new System.Drawing.Point(93, 451);
            this.CheckBoxSt.Name = "CheckBoxSt";
            this.CheckBoxSt.Size = new System.Drawing.Size(60, 24);
            this.CheckBoxSt.TabIndex = 27;
            this.CheckBoxSt.TabStop = false;
            this.CheckBoxSt.Text = "解卡";
            this.CheckBoxSt.UseVisualStyleBackColor = true;
            // 
            // CheckBoxReg
            // 
            this.CheckBoxReg.Location = new System.Drawing.Point(27, 451);
            this.CheckBoxReg.Name = "CheckBoxReg";
            this.CheckBoxReg.Size = new System.Drawing.Size(60, 24);
            this.CheckBoxReg.TabIndex = 26;
            this.CheckBoxReg.TabStop = false;
            this.CheckBoxReg.Text = "注册";
            this.CheckBoxReg.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.HostTextBox);
            this.GroupBox2.Controls.Add(this.DBHostStatic);
            this.GroupBox2.Controls.Add(this.RootTextBox);
            this.GroupBox2.Controls.Add(this.PassTextBox);
            this.GroupBox2.Controls.Add(this.DBRootStatic);
            this.GroupBox2.Controls.Add(this.DBPassStatic);
            this.GroupBox2.Controls.Add(this.PortTextBox);
            this.GroupBox2.Controls.Add(this.DBPortStatic);
            this.GroupBox2.Controls.Add(this.GameVeStatic);
            this.GroupBox2.Controls.Add(this.AuthTextBox);
            this.GroupBox2.Controls.Add(this.GameVeTextBox);
            this.GroupBox2.Controls.Add(this.CharTextBox);
            this.GroupBox2.Controls.Add(this.DBCharStatic);
            this.GroupBox2.Controls.Add(this.DBAuthStatic);
            this.GroupBox2.Location = new System.Drawing.Point(12, 501);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(242, 254);
            this.GroupBox2.TabIndex = 31;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "数据库配置";
            // 
            // HostTextBox
            // 
            this.HostTextBox.BackColor = System.Drawing.Color.Linen;
            this.HostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostTextBox.Location = new System.Drawing.Point(96, 23);
            this.HostTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(139, 23);
            this.HostTextBox.TabIndex = 0;
            // 
            // DBHostStatic
            // 
            this.DBHostStatic.Location = new System.Drawing.Point(8, 19);
            this.DBHostStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBHostStatic.Name = "DBHostStatic";
            this.DBHostStatic.Size = new System.Drawing.Size(80, 30);
            this.DBHostStatic.TabIndex = 10;
            this.DBHostStatic.Text = "数据库地址";
            this.DBHostStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RootTextBox
            // 
            this.RootTextBox.BackColor = System.Drawing.Color.Linen;
            this.RootTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RootTextBox.Location = new System.Drawing.Point(96, 56);
            this.RootTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RootTextBox.Name = "RootTextBox";
            this.RootTextBox.Size = new System.Drawing.Size(139, 23);
            this.RootTextBox.TabIndex = 1;
            // 
            // PassTextBox
            // 
            this.PassTextBox.BackColor = System.Drawing.Color.Linen;
            this.PassTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassTextBox.Location = new System.Drawing.Point(96, 89);
            this.PassTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(139, 23);
            this.PassTextBox.TabIndex = 2;
            // 
            // DBRootStatic
            // 
            this.DBRootStatic.Location = new System.Drawing.Point(8, 52);
            this.DBRootStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBRootStatic.Name = "DBRootStatic";
            this.DBRootStatic.Size = new System.Drawing.Size(80, 30);
            this.DBRootStatic.TabIndex = 11;
            this.DBRootStatic.Text = "用户名";
            this.DBRootStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DBPassStatic
            // 
            this.DBPassStatic.Location = new System.Drawing.Point(8, 84);
            this.DBPassStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBPassStatic.Name = "DBPassStatic";
            this.DBPassStatic.Size = new System.Drawing.Size(80, 30);
            this.DBPassStatic.TabIndex = 12;
            this.DBPassStatic.Text = "密码";
            this.DBPassStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortTextBox
            // 
            this.PortTextBox.BackColor = System.Drawing.Color.Linen;
            this.PortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortTextBox.Location = new System.Drawing.Point(96, 122);
            this.PortTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(139, 23);
            this.PortTextBox.TabIndex = 14;
            // 
            // DBPortStatic
            // 
            this.DBPortStatic.Location = new System.Drawing.Point(8, 118);
            this.DBPortStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBPortStatic.Name = "DBPortStatic";
            this.DBPortStatic.Size = new System.Drawing.Size(80, 30);
            this.DBPortStatic.TabIndex = 17;
            this.DBPortStatic.Text = "端口";
            this.DBPortStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameVeStatic
            // 
            this.GameVeStatic.Location = new System.Drawing.Point(8, 217);
            this.GameVeStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameVeStatic.Name = "GameVeStatic";
            this.GameVeStatic.Size = new System.Drawing.Size(80, 30);
            this.GameVeStatic.TabIndex = 23;
            this.GameVeStatic.Text = "游戏版本";
            this.GameVeStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthTextBox
            // 
            this.AuthTextBox.BackColor = System.Drawing.Color.Linen;
            this.AuthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AuthTextBox.Location = new System.Drawing.Point(96, 155);
            this.AuthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AuthTextBox.Name = "AuthTextBox";
            this.AuthTextBox.Size = new System.Drawing.Size(139, 23);
            this.AuthTextBox.TabIndex = 15;
            // 
            // GameVeTextBox
            // 
            this.GameVeTextBox.BackColor = System.Drawing.Color.Linen;
            this.GameVeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameVeTextBox.Location = new System.Drawing.Point(96, 221);
            this.GameVeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameVeTextBox.Name = "GameVeTextBox";
            this.GameVeTextBox.Size = new System.Drawing.Size(139, 23);
            this.GameVeTextBox.TabIndex = 20;
            // 
            // CharTextBox
            // 
            this.CharTextBox.BackColor = System.Drawing.Color.Linen;
            this.CharTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharTextBox.Location = new System.Drawing.Point(96, 188);
            this.CharTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharTextBox.Name = "CharTextBox";
            this.CharTextBox.Size = new System.Drawing.Size(139, 23);
            this.CharTextBox.TabIndex = 16;
            // 
            // DBCharStatic
            // 
            this.DBCharStatic.Location = new System.Drawing.Point(8, 183);
            this.DBCharStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBCharStatic.Name = "DBCharStatic";
            this.DBCharStatic.Size = new System.Drawing.Size(80, 30);
            this.DBCharStatic.TabIndex = 19;
            this.DBCharStatic.Text = "角色库名";
            this.DBCharStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DBAuthStatic
            // 
            this.DBAuthStatic.Location = new System.Drawing.Point(8, 151);
            this.DBAuthStatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBAuthStatic.Name = "DBAuthStatic";
            this.DBAuthStatic.Size = new System.Drawing.Size(80, 30);
            this.DBAuthStatic.TabIndex = 18;
            this.DBAuthStatic.Text = "账号库名";
            this.DBAuthStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GwTextBox);
            this.GroupBox3.Controls.Add(this.GwLabel);
            this.GroupBox3.Controls.Add(this.PNameTextBox);
            this.GroupBox3.Controls.Add(this.PathName);
            this.GroupBox3.Controls.Add(this.PMdTextBox);
            this.GroupBox3.Controls.Add(this.PUrlTextBox);
            this.GroupBox3.Controls.Add(this.PathMd);
            this.GroupBox3.Controls.Add(this.PathUrl);
            this.GroupBox3.Controls.Add(this.ShopTextBox);
            this.GroupBox3.Controls.Add(this.ShopUrl);
            this.GroupBox3.Location = new System.Drawing.Point(261, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(583, 227);
            this.GroupBox3.TabIndex = 32;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "其他配置";
            // 
            // GwTextBox
            // 
            this.GwTextBox.BackColor = System.Drawing.Color.Linen;
            this.GwTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GwTextBox.Location = new System.Drawing.Point(99, 175);
            this.GwTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GwTextBox.Name = "GwTextBox";
            this.GwTextBox.Size = new System.Drawing.Size(477, 23);
            this.GwTextBox.TabIndex = 26;
            // 
            // GwLabel
            // 
            this.GwLabel.Location = new System.Drawing.Point(11, 170);
            this.GwLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GwLabel.Name = "GwLabel";
            this.GwLabel.Size = new System.Drawing.Size(80, 30);
            this.GwLabel.TabIndex = 27;
            this.GwLabel.Text = "官方网站";
            this.GwLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PNameTextBox
            // 
            this.PNameTextBox.BackColor = System.Drawing.Color.Linen;
            this.PNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNameTextBox.Location = new System.Drawing.Point(99, 43);
            this.PNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PNameTextBox.Name = "PNameTextBox";
            this.PNameTextBox.Size = new System.Drawing.Size(477, 23);
            this.PNameTextBox.TabIndex = 18;
            // 
            // PathName
            // 
            this.PathName.Location = new System.Drawing.Point(11, 39);
            this.PathName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathName.Name = "PathName";
            this.PathName.Size = new System.Drawing.Size(80, 30);
            this.PathName.TabIndex = 21;
            this.PathName.Text = "补丁名";
            this.PathName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PMdTextBox
            // 
            this.PMdTextBox.BackColor = System.Drawing.Color.Linen;
            this.PMdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PMdTextBox.Location = new System.Drawing.Point(99, 76);
            this.PMdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PMdTextBox.Name = "PMdTextBox";
            this.PMdTextBox.Size = new System.Drawing.Size(477, 23);
            this.PMdTextBox.TabIndex = 19;
            // 
            // PUrlTextBox
            // 
            this.PUrlTextBox.BackColor = System.Drawing.Color.Linen;
            this.PUrlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PUrlTextBox.Location = new System.Drawing.Point(99, 109);
            this.PUrlTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PUrlTextBox.Name = "PUrlTextBox";
            this.PUrlTextBox.Size = new System.Drawing.Size(477, 23);
            this.PUrlTextBox.TabIndex = 20;
            // 
            // PathMd
            // 
            this.PathMd.Location = new System.Drawing.Point(11, 72);
            this.PathMd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathMd.Name = "PathMd";
            this.PathMd.Size = new System.Drawing.Size(80, 30);
            this.PathMd.TabIndex = 22;
            this.PathMd.Text = "补丁MD5";
            this.PathMd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathUrl
            // 
            this.PathUrl.Location = new System.Drawing.Point(11, 104);
            this.PathUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathUrl.Name = "PathUrl";
            this.PathUrl.Size = new System.Drawing.Size(80, 30);
            this.PathUrl.TabIndex = 23;
            this.PathUrl.Text = "补丁地址";
            this.PathUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShopTextBox
            // 
            this.ShopTextBox.BackColor = System.Drawing.Color.Linen;
            this.ShopTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShopTextBox.Location = new System.Drawing.Point(99, 142);
            this.ShopTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShopTextBox.Name = "ShopTextBox";
            this.ShopTextBox.Size = new System.Drawing.Size(477, 23);
            this.ShopTextBox.TabIndex = 24;
            // 
            // ShopUrl
            // 
            this.ShopUrl.Location = new System.Drawing.Point(11, 138);
            this.ShopUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShopUrl.Name = "ShopUrl";
            this.ShopUrl.Size = new System.Drawing.Size(80, 30);
            this.ShopUrl.TabIndex = 25;
            this.ShopUrl.Text = "赞助地址";
            this.ShopUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnLineTextBox
            // 
            this.OnLineTextBox.BackColor = System.Drawing.Color.Linen;
            this.OnLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OnLineTextBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.OnLineTextBox.Location = new System.Drawing.Point(261, 257);
            this.OnLineTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OnLineTextBox.Name = "OnLineTextBox";
            this.OnLineTextBox.ReadOnly = true;
            this.OnLineTextBox.Size = new System.Drawing.Size(120, 23);
            this.OnLineTextBox.TabIndex = 34;
            this.OnLineTextBox.TabStop = false;
            this.OnLineTextBox.Text = "当前在线: 0";
            // 
            // UnBanBtn
            // 
            this.UnBanBtn.BackColor = System.Drawing.Color.Ivory;
            this.UnBanBtn.ForeColor = System.Drawing.Color.Green;
            this.UnBanBtn.Location = new System.Drawing.Point(933, 255);
            this.UnBanBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UnBanBtn.Name = "UnBanBtn";
            this.UnBanBtn.Size = new System.Drawing.Size(78, 25);
            this.UnBanBtn.TabIndex = 38;
            this.UnBanBtn.TabStop = false;
            this.UnBanBtn.Text = "解封";
            this.UnBanBtn.UseVisualStyleBackColor = false;
            this.UnBanBtn.Click += new System.EventHandler(this.UnBanBtn_Click);
            // 
            // BanComboBox
            // 
            this.BanComboBox.BackColor = System.Drawing.Color.PeachPuff;
            this.BanComboBox.DropDownHeight = 480;
            this.BanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BanComboBox.DropDownWidth = 130;
            this.BanComboBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BanComboBox.FormattingEnabled = true;
            this.BanComboBox.IntegralHeight = false;
            this.BanComboBox.ItemHeight = 17;
            this.BanComboBox.Location = new System.Drawing.Point(476, 255);
            this.BanComboBox.MaxDropDownItems = 100;
            this.BanComboBox.MaxLength = 32767;
            this.BanComboBox.Name = "BanComboBox";
            this.BanComboBox.Size = new System.Drawing.Size(450, 25);
            this.BanComboBox.TabIndex = 39;
            this.BanComboBox.TabStop = false;
            // 
            // BanListLabel
            // 
            this.BanListLabel.Location = new System.Drawing.Point(389, 254);
            this.BanListLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BanListLabel.Name = "BanListLabel";
            this.BanListLabel.Size = new System.Drawing.Size(80, 25);
            this.BanListLabel.TabIndex = 40;
            this.BanListLabel.Text = "封禁列表";
            this.BanListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyButton
            // 
            this.KeyButton.BackColor = System.Drawing.Color.Ivory;
            this.KeyButton.ForeColor = System.Drawing.Color.Green;
            this.KeyButton.Location = new System.Drawing.Point(851, 197);
            this.KeyButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KeyButton.Name = "KeyButton";
            this.KeyButton.Size = new System.Drawing.Size(160, 37);
            this.KeyButton.TabIndex = 41;
            this.KeyButton.TabStop = false;
            this.KeyButton.Text = "执行加密";
            this.KeyButton.UseVisualStyleBackColor = false;
            this.KeyButton.Click += new System.EventHandler(this.KeyButton_Click);
            // 
            // CheckKey
            // 
            this.CheckKey.Location = new System.Drawing.Point(860, 165);
            this.CheckKey.Name = "CheckKey";
            this.CheckKey.Size = new System.Drawing.Size(142, 24);
            this.CheckKey.TabIndex = 83;
            this.CheckKey.TabStop = false;
            this.CheckKey.Text = "是否使用加密模块";
            this.CheckKey.UseVisualStyleBackColor = true;
            // 
            // HkNetForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 762);
            this.Controls.Add(this.CheckKey);
            this.Controls.Add(this.KeyButton);
            this.Controls.Add(this.BanListLabel);
            this.Controls.Add(this.BanComboBox);
            this.Controls.Add(this.UnBanBtn);
            this.Controls.Add(this.OnLineTextBox);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.BtnSettings);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.ListClients);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HkNetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录器网关";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetForm_FormClosing);
            this.Load += new System.EventHandler(this.NetForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ImageList ListImages;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuSendMsg;
        private System.Windows.Forms.Label PortStaticText;
        private System.Windows.Forms.TextBox TBoxPort;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Label MaxStaticText;
        private System.Windows.Forms.TextBox TBoxMaxConn;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.ListView ListClients;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader NetNum;
        private System.Windows.Forms.ColumnHeader NetIpAndPort;
        private System.Windows.Forms.Label DPortStatic;
        private System.Windows.Forms.Label ZPortStatic;
        private System.Windows.Forms.TextBox DPortTextBox;
        private System.Windows.Forms.TextBox ZPortTextBox;
        private System.Windows.Forms.Label BPortStatic;
        private System.Windows.Forms.TextBox BPortTextBox;
        private System.Windows.Forms.Label UnicomStatic;
        private System.Windows.Forms.Label MobileStatic;
        private System.Windows.Forms.TextBox UnicomTextBox;
        private System.Windows.Forms.TextBox MobileTextBox;
        private System.Windows.Forms.Label TelecomStatic;
        private System.Windows.Forms.TextBox TelecomTextBox;
        private System.Windows.Forms.Label NameListStatic;
        private System.Windows.Forms.TextBox NameListTextBox;
        private System.Windows.Forms.Label ContentsStatic;
        private System.Windows.Forms.TextBox ContentsTextBox;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Label DBHostStatic;
        private System.Windows.Forms.TextBox RootTextBox;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.Label DBRootStatic;
        private System.Windows.Forms.Label DBPassStatic;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label DBPortStatic;
        private System.Windows.Forms.Label GameVeStatic;
        private System.Windows.Forms.TextBox AuthTextBox;
        private System.Windows.Forms.TextBox GameVeTextBox;
        private System.Windows.Forms.TextBox CharTextBox;
        private System.Windows.Forms.Label DBCharStatic;
        private System.Windows.Forms.Label DBAuthStatic;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.TextBox PNameTextBox;
        private System.Windows.Forms.Label PathName;
        private System.Windows.Forms.TextBox PMdTextBox;
        private System.Windows.Forms.TextBox PUrlTextBox;
        private System.Windows.Forms.Label PathMd;
        private System.Windows.Forms.Label PathUrl;
        private System.Windows.Forms.TextBox ShopTextBox;
        private System.Windows.Forms.Label ShopUrl;
        private System.Windows.Forms.CheckBox CheckBoxCg;
        private System.Windows.Forms.CheckBox CheckBoxSt;
        private System.Windows.Forms.CheckBox CheckBoxReg;
        private System.Windows.Forms.TextBox OnLineTextBox;
        private System.Windows.Forms.ToolStripMenuItem MenuBanIp;
        private System.Windows.Forms.Button UnBanBtn;
        private System.Windows.Forms.ComboBox BanComboBox;
        private System.Windows.Forms.Label BanListLabel;
        private System.Windows.Forms.Label TimeLt;
        private System.Windows.Forms.Label Worklabel;
        private System.Windows.Forms.TextBox GwTextBox;
        private System.Windows.Forms.Label GwLabel;
        private System.Windows.Forms.ColumnHeader PcKey;
        private System.Windows.Forms.ToolStripMenuItem MenuBanKey;
        private System.Windows.Forms.CheckBox ForwardCheckBox;
        private System.Windows.Forms.Button KeyButton;
        private System.Windows.Forms.CheckBox CheckKey;
    }
}

