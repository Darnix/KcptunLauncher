namespace KcptunLauncher.View
{
    partial class ConfigForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.ackNoDelayCB = new System.Windows.Forms.CheckBox();
            this.remotePortBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.localPortBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.keepAliveBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.sockBufBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ncBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.resendBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.intervalBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.noDelayBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.autoExpireBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.serverNameBox = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.nocompCB = new System.Windows.Forms.CheckBox();
            this.dscpBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.parityshardBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.datashardBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rcvwndBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.modeCB = new System.Windows.Forms.ComboBox();
            this.sndwndBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mtuBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.connBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cryptCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.remoteIpBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.localIpBox = new System.Windows.Forms.TextBox();
            this.localaddrLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.mServerList = new System.Windows.Forms.ListBox();
            this.removeServerBtn = new System.Windows.Forms.Button();
            this.addServerBtn = new System.Windows.Forms.Button();
            this.moveDownBtn = new System.Windows.Forms.Button();
            this.moveUpBtn = new System.Windows.Forms.Button();
            this.serverGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverGroupBox.Controls.Add(this.ackNoDelayCB);
            this.serverGroupBox.Controls.Add(this.remotePortBox);
            this.serverGroupBox.Controls.Add(this.label21);
            this.serverGroupBox.Controls.Add(this.localPortBox);
            this.serverGroupBox.Controls.Add(this.label20);
            this.serverGroupBox.Controls.Add(this.keepAliveBox);
            this.serverGroupBox.Controls.Add(this.label16);
            this.serverGroupBox.Controls.Add(this.sockBufBox);
            this.serverGroupBox.Controls.Add(this.label17);
            this.serverGroupBox.Controls.Add(this.ncBox);
            this.serverGroupBox.Controls.Add(this.label18);
            this.serverGroupBox.Controls.Add(this.resendBox);
            this.serverGroupBox.Controls.Add(this.label19);
            this.serverGroupBox.Controls.Add(this.intervalBox);
            this.serverGroupBox.Controls.Add(this.label9);
            this.serverGroupBox.Controls.Add(this.noDelayBox);
            this.serverGroupBox.Controls.Add(this.label13);
            this.serverGroupBox.Controls.Add(this.autoExpireBox);
            this.serverGroupBox.Controls.Add(this.label15);
            this.serverGroupBox.Controls.Add(this.serverNameBox);
            this.serverGroupBox.Controls.Add(this.nameLbl);
            this.serverGroupBox.Controls.Add(this.nocompCB);
            this.serverGroupBox.Controls.Add(this.dscpBox);
            this.serverGroupBox.Controls.Add(this.label12);
            this.serverGroupBox.Controls.Add(this.parityshardBox);
            this.serverGroupBox.Controls.Add(this.label11);
            this.serverGroupBox.Controls.Add(this.datashardBox);
            this.serverGroupBox.Controls.Add(this.label10);
            this.serverGroupBox.Controls.Add(this.rcvwndBox);
            this.serverGroupBox.Controls.Add(this.label8);
            this.serverGroupBox.Controls.Add(this.modeCB);
            this.serverGroupBox.Controls.Add(this.sndwndBox);
            this.serverGroupBox.Controls.Add(this.label7);
            this.serverGroupBox.Controls.Add(this.mtuBox);
            this.serverGroupBox.Controls.Add(this.label6);
            this.serverGroupBox.Controls.Add(this.connBox);
            this.serverGroupBox.Controls.Add(this.label5);
            this.serverGroupBox.Controls.Add(this.cryptCB);
            this.serverGroupBox.Controls.Add(this.label4);
            this.serverGroupBox.Controls.Add(this.label3);
            this.serverGroupBox.Controls.Add(this.keyBox);
            this.serverGroupBox.Controls.Add(this.label2);
            this.serverGroupBox.Controls.Add(this.remoteIpBox);
            this.serverGroupBox.Controls.Add(this.label1);
            this.serverGroupBox.Controls.Add(this.localIpBox);
            this.serverGroupBox.Controls.Add(this.localaddrLbl);
            this.serverGroupBox.Location = new System.Drawing.Point(172, 8);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(423, 379);
            this.serverGroupBox.TabIndex = 0;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "服务器";
            // 
            // ackNoDelayCB
            // 
            this.ackNoDelayCB.AutoSize = true;
            this.ackNoDelayCB.Location = new System.Drawing.Point(305, 311);
            this.ackNoDelayCB.Name = "ackNoDelayCB";
            this.ackNoDelayCB.Size = new System.Drawing.Size(96, 16);
            this.ackNoDelayCB.TabIndex = 50;
            this.ackNoDelayCB.Text = "Ack No Delay";
            this.ackNoDelayCB.UseVisualStyleBackColor = true;
            // 
            // remotePortBox
            // 
            this.remotePortBox.Location = new System.Drawing.Point(305, 73);
            this.remotePortBox.Name = "remotePortBox";
            this.remotePortBox.Size = new System.Drawing.Size(100, 21);
            this.remotePortBox.TabIndex = 48;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(228, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 49;
            this.label21.Text = "Remote Port";
            // 
            // localPortBox
            // 
            this.localPortBox.Location = new System.Drawing.Point(305, 46);
            this.localPortBox.Name = "localPortBox";
            this.localPortBox.Size = new System.Drawing.Size(100, 21);
            this.localPortBox.TabIndex = 47;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(228, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 46;
            this.label20.Text = "Local Port";
            // 
            // keepAliveBox
            // 
            this.keepAliveBox.Location = new System.Drawing.Point(305, 261);
            this.keepAliveBox.Name = "keepAliveBox";
            this.keepAliveBox.Size = new System.Drawing.Size(100, 21);
            this.keepAliveBox.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(228, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 45;
            this.label16.Text = "Keep Alive";
            // 
            // sockBufBox
            // 
            this.sockBufBox.Location = new System.Drawing.Point(305, 234);
            this.sockBufBox.Name = "sockBufBox";
            this.sockBufBox.Size = new System.Drawing.Size(100, 21);
            this.sockBufBox.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(228, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 44;
            this.label17.Text = "Sockbuf";
            // 
            // ncBox
            // 
            this.ncBox.Location = new System.Drawing.Point(305, 207);
            this.ncBox.Name = "ncBox";
            this.ncBox.Size = new System.Drawing.Size(100, 21);
            this.ncBox.TabIndex = 39;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(228, 210);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 43;
            this.label18.Text = "Nc";
            // 
            // resendBox
            // 
            this.resendBox.Location = new System.Drawing.Point(305, 181);
            this.resendBox.Name = "resendBox";
            this.resendBox.Size = new System.Drawing.Size(100, 21);
            this.resendBox.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(228, 182);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 42;
            this.label19.Text = "Resend";
            // 
            // intervalBox
            // 
            this.intervalBox.Location = new System.Drawing.Point(305, 153);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(100, 21);
            this.intervalBox.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 37;
            this.label9.Text = "Interval";
            // 
            // noDelayBox
            // 
            this.noDelayBox.Location = new System.Drawing.Point(305, 126);
            this.noDelayBox.Name = "noDelayBox";
            this.noDelayBox.Size = new System.Drawing.Size(100, 21);
            this.noDelayBox.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 36;
            this.label13.Text = "No Delay";
            // 
            // autoExpireBox
            // 
            this.autoExpireBox.Location = new System.Drawing.Point(305, 100);
            this.autoExpireBox.Name = "autoExpireBox";
            this.autoExpireBox.Size = new System.Drawing.Size(100, 21);
            this.autoExpireBox.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(228, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "Auto Expire";
            // 
            // serverNameBox
            // 
            this.serverNameBox.Location = new System.Drawing.Point(112, 19);
            this.serverNameBox.Name = "serverNameBox";
            this.serverNameBox.Size = new System.Drawing.Size(293, 21);
            this.serverNameBox.TabIndex = 0;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(17, 22);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(29, 12);
            this.nameLbl.TabIndex = 29;
            this.nameLbl.Text = "Name";
            // 
            // nocompCB
            // 
            this.nocompCB.AutoSize = true;
            this.nocompCB.Location = new System.Drawing.Point(305, 288);
            this.nocompCB.Name = "nocompCB";
            this.nocompCB.Size = new System.Drawing.Size(60, 16);
            this.nocompCB.TabIndex = 10;
            this.nocompCB.Text = "nocomp";
            this.nocompCB.UseVisualStyleBackColor = true;
            // 
            // dscpBox
            // 
            this.dscpBox.Location = new System.Drawing.Point(112, 343);
            this.dscpBox.Name = "dscpBox";
            this.dscpBox.Size = new System.Drawing.Size(100, 21);
            this.dscpBox.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "dscp";
            // 
            // parityshardBox
            // 
            this.parityshardBox.Location = new System.Drawing.Point(112, 316);
            this.parityshardBox.Name = "parityshardBox";
            this.parityshardBox.Size = new System.Drawing.Size(100, 21);
            this.parityshardBox.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "parityshard";
            // 
            // datashardBox
            // 
            this.datashardBox.Location = new System.Drawing.Point(112, 289);
            this.datashardBox.Name = "datashardBox";
            this.datashardBox.Size = new System.Drawing.Size(100, 21);
            this.datashardBox.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "datashard";
            // 
            // rcvwndBox
            // 
            this.rcvwndBox.Location = new System.Drawing.Point(112, 262);
            this.rcvwndBox.Name = "rcvwndBox";
            this.rcvwndBox.Size = new System.Drawing.Size(100, 21);
            this.rcvwndBox.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "rcvwnd";
            // 
            // modeCB
            // 
            this.modeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeCB.FormattingEnabled = true;
            this.modeCB.Items.AddRange(new object[] {
            "fast",
            "fast2",
            "fast3",
            "normal"});
            this.modeCB.Location = new System.Drawing.Point(112, 154);
            this.modeCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modeCB.Name = "modeCB";
            this.modeCB.Size = new System.Drawing.Size(100, 20);
            this.modeCB.TabIndex = 5;
            // 
            // sndwndBox
            // 
            this.sndwndBox.Location = new System.Drawing.Point(112, 235);
            this.sndwndBox.Name = "sndwndBox";
            this.sndwndBox.Size = new System.Drawing.Size(100, 21);
            this.sndwndBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "sndwnd";
            // 
            // mtuBox
            // 
            this.mtuBox.Location = new System.Drawing.Point(112, 208);
            this.mtuBox.Name = "mtuBox";
            this.mtuBox.Size = new System.Drawing.Size(100, 21);
            this.mtuBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mtu";
            // 
            // connBox
            // 
            this.connBox.Location = new System.Drawing.Point(112, 181);
            this.connBox.Name = "connBox";
            this.connBox.Size = new System.Drawing.Size(100, 21);
            this.connBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Conn";
            // 
            // cryptCB
            // 
            this.cryptCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cryptCB.FormattingEnabled = true;
            this.cryptCB.Items.AddRange(new object[] {
            "aes",
            "aes-128",
            "aes-192",
            "salsa20",
            "blowfish",
            "twofish",
            "cast5",
            "3des",
            "tea",
            "xtea",
            "xor",
            "none"});
            this.cryptCB.Location = new System.Drawing.Point(112, 126);
            this.cryptCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cryptCB.Name = "cryptCB";
            this.cryptCB.Size = new System.Drawing.Size(100, 20);
            this.cryptCB.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Crypt";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(112, 100);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(100, 21);
            this.keyBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // remoteIpBox
            // 
            this.remoteIpBox.Location = new System.Drawing.Point(112, 73);
            this.remoteIpBox.Name = "remoteIpBox";
            this.remoteIpBox.Size = new System.Drawing.Size(100, 21);
            this.remoteIpBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remote Address";
            // 
            // localIpBox
            // 
            this.localIpBox.Location = new System.Drawing.Point(112, 46);
            this.localIpBox.Name = "localIpBox";
            this.localIpBox.Size = new System.Drawing.Size(100, 21);
            this.localIpBox.TabIndex = 1;
            // 
            // localaddrLbl
            // 
            this.localaddrLbl.AutoSize = true;
            this.localaddrLbl.Location = new System.Drawing.Point(17, 49);
            this.localaddrLbl.Name = "localaddrLbl";
            this.localaddrLbl.Size = new System.Drawing.Size(83, 12);
            this.localaddrLbl.TabIndex = 0;
            this.localaddrLbl.Text = "Local Address";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(520, 392);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmBtn.Location = new System.Drawing.Point(434, 392);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 29;
            this.confirmBtn.Text = "确认";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // mServerList
            // 
            this.mServerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mServerList.DisplayMember = "Name";
            this.mServerList.FormattingEnabled = true;
            this.mServerList.ItemHeight = 12;
            this.mServerList.Location = new System.Drawing.Point(12, 18);
            this.mServerList.Name = "mServerList";
            this.mServerList.Size = new System.Drawing.Size(144, 328);
            this.mServerList.TabIndex = 1;
            this.mServerList.SelectedIndexChanged += new System.EventHandler(this.mServerList_SelectedIndexChanged);
            // 
            // removeServerBtn
            // 
            this.removeServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeServerBtn.Location = new System.Drawing.Point(86, 363);
            this.removeServerBtn.Name = "removeServerBtn";
            this.removeServerBtn.Size = new System.Drawing.Size(70, 23);
            this.removeServerBtn.TabIndex = 32;
            this.removeServerBtn.Text = "删除(&D)";
            this.removeServerBtn.UseVisualStyleBackColor = true;
            this.removeServerBtn.Click += new System.EventHandler(this.removeServerBtn_Click);
            // 
            // addServerBtn
            // 
            this.addServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addServerBtn.Location = new System.Drawing.Point(10, 363);
            this.addServerBtn.Name = "addServerBtn";
            this.addServerBtn.Size = new System.Drawing.Size(70, 23);
            this.addServerBtn.TabIndex = 31;
            this.addServerBtn.Text = "添加(&A)";
            this.addServerBtn.UseVisualStyleBackColor = true;
            this.addServerBtn.Click += new System.EventHandler(this.addServerBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDownBtn.Location = new System.Drawing.Point(86, 392);
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(70, 23);
            this.moveDownBtn.TabIndex = 34;
            this.moveDownBtn.Text = "下移(&O)";
            this.moveDownBtn.UseVisualStyleBackColor = true;
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // moveUpBtn
            // 
            this.moveUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveUpBtn.Location = new System.Drawing.Point(10, 392);
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(70, 23);
            this.moveUpBtn.TabIndex = 33;
            this.moveUpBtn.Text = "上移(&U)";
            this.moveUpBtn.UseVisualStyleBackColor = true;
            this.moveUpBtn.Click += new System.EventHandler(this.moveUpBtn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.moveDownBtn);
            this.Controls.Add(this.moveUpBtn);
            this.Controls.Add(this.removeServerBtn);
            this.Controls.Add(this.addServerBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.mServerList);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.serverGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑服务器";
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.TextBox localIpBox;
        private System.Windows.Forms.Label localaddrLbl;
        private System.Windows.Forms.ComboBox modeCB;
        private System.Windows.Forms.TextBox sndwndBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mtuBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox connBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cryptCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox remoteIpBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox datashardBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox rcvwndBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dscpBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox parityshardBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox nocompCB;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.ListBox mServerList;
        private System.Windows.Forms.Button removeServerBtn;
        private System.Windows.Forms.Button addServerBtn;
        private System.Windows.Forms.Button moveDownBtn;
        private System.Windows.Forms.Button moveUpBtn;
        private System.Windows.Forms.TextBox serverNameBox;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox keepAliveBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox sockBufBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox ncBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox resendBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox intervalBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox noDelayBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox remotePortBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox localPortBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ackNoDelayCB;
        private System.Windows.Forms.TextBox autoExpireBox;
        private System.Windows.Forms.Label label15;
    }
}

