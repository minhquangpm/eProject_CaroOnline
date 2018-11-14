namespace ProjectCaro
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Map = new System.Windows.Forms.TabPage();
            this.Login = new System.Windows.Forms.TabPage();
            this.processbartime = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listfriend = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chat = new System.Windows.Forms.ListBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.danhsachphong = new System.Windows.Forms.DataGridView();
            this.txtSophong = new System.Windows.Forms.TextBox();
            this.btnVao = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Home = new System.Windows.Forms.TabPage();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtSignup = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.formName = new System.Windows.Forms.Label();
            this.txtChecklog = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txt_Log2 = new System.Windows.Forms.TextBox();
            this.txt_Log1 = new System.Windows.Forms.TextBox();
            this.panelSignup = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.txtSignin = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.repassword = new System.Windows.Forms.Label();
            this.password2 = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.fullname1 = new System.Windows.Forms.Label();
            this.password1 = new System.Windows.Forms.Label();
            this.username1 = new System.Windows.Forms.Label();
            this.Signup = new System.Windows.Forms.Label();
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.Login.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listfriend)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).BeginInit();
            this.Home.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelSignup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Login);
            this.tabControl.Controls.Add(this.Home);
            this.tabControl.Controls.Add(this.Map);
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1157, 742);
            this.tabControl.TabIndex = 0;
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(4, 22);
            this.Map.Name = "Map";
            this.Map.Padding = new System.Windows.Forms.Padding(3);
            this.Map.Size = new System.Drawing.Size(1149, 716);
            this.Map.TabIndex = 2;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login.Controls.Add(this.panelSignup);
            this.Login.Controls.Add(this.panelLogin);
            this.Login.Controls.Add(this.progressBar1);
            this.Login.Location = new System.Drawing.Point(4, 22);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3);
            this.Login.Size = new System.Drawing.Size(1149, 716);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // processbartime
            // 
            this.processbartime.Tick += new System.EventHandler(this.processbartime_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Red;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(24, 625);
            this.progressBar1.MarqueeAnimationSpeed = 1000;
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1072, 23);
            this.progressBar1.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(197)))));
            this.panel1.Controls.Add(this.lblRank);
            this.panel1.Controls.Add(this.lblLevel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Level);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.listfriend);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(876, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 710);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(44, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(192, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // listfriend
            // 
            this.listfriend.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listfriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listfriend.Location = new System.Drawing.Point(0, 274);
            this.listfriend.Name = "listfriend";
            this.listfriend.Size = new System.Drawing.Size(276, 482);
            this.listfriend.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblUsername);
            this.panel4.Location = new System.Drawing.Point(19, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 47);
            this.panel4.TabIndex = 11;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Red;
            this.lblUsername.Location = new System.Drawing.Point(97, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 31);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Zin";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(95)))));
            this.Level.Location = new System.Drawing.Point(15, 211);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(83, 25);
            this.Level.TabIndex = 12;
            this.Level.Text = "Level :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(95)))));
            this.label3.Location = new System.Drawing.Point(15, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rank :";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Red;
            this.lblLevel.Location = new System.Drawing.Point(133, 211);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(38, 25);
            this.lblLevel.TabIndex = 14;
            this.lblLevel.Text = "30";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRank.ForeColor = System.Drawing.Color.Red;
            this.lblRank.Location = new System.Drawing.Point(133, 247);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(64, 25);
            this.lblRank.TabIndex = 15;
            this.lblRank.Text = "1000";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtChat);
            this.panel2.Controls.Add(this.btnChat);
            this.panel2.Controls.Add(this.chat);
            this.panel2.Location = new System.Drawing.Point(-14, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 205);
            this.panel2.TabIndex = 21;
            // 
            // chat
            // 
            this.chat.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(12, 3);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(841, 173);
            this.chat.TabIndex = 19;
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(113)))), ((int)(((byte)(150)))));
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Location = new System.Drawing.Point(760, 176);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(93, 28);
            this.btnChat.TabIndex = 20;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = false;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(12, 182);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(732, 20);
            this.txtChat.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnTao);
            this.panel3.Controls.Add(this.btnVao);
            this.panel3.Controls.Add(this.txtSophong);
            this.panel3.Controls.Add(this.danhsachphong);
            this.panel3.Location = new System.Drawing.Point(3, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(853, 406);
            this.panel3.TabIndex = 22;
            // 
            // danhsachphong
            // 
            this.danhsachphong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.danhsachphong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.danhsachphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachphong.Location = new System.Drawing.Point(3, 3);
            this.danhsachphong.Name = "danhsachphong";
            this.danhsachphong.Size = new System.Drawing.Size(827, 335);
            this.danhsachphong.TabIndex = 9;
            // 
            // txtSophong
            // 
            this.txtSophong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSophong.Location = new System.Drawing.Point(3, 354);
            this.txtSophong.Name = "txtSophong";
            this.txtSophong.Size = new System.Drawing.Size(557, 35);
            this.txtSophong.TabIndex = 12;
            // 
            // btnVao
            // 
            this.btnVao.BackColor = System.Drawing.Color.GreenYellow;
            this.btnVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnVao.ForeColor = System.Drawing.Color.White;
            this.btnVao.Location = new System.Drawing.Point(703, 354);
            this.btnVao.Name = "btnVao";
            this.btnVao.Size = new System.Drawing.Size(133, 39);
            this.btnVao.TabIndex = 11;
            this.btnVao.Text = "Vào phòng";
            this.btnVao.UseVisualStyleBackColor = false;
            // 
            // btnTao
            // 
            this.btnTao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnTao.ForeColor = System.Drawing.Color.White;
            this.btnTao.Location = new System.Drawing.Point(575, 354);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(125, 39);
            this.btnTao.TabIndex = 10;
            this.btnTao.Text = "Tạo phòng";
            this.btnTao.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "C A R O G A M E";
            // 
            // Home
            // 
            this.Home.Controls.Add(this.label1);
            this.Home.Controls.Add(this.panel3);
            this.Home.Controls.Add(this.panel2);
            this.Home.Controls.Add(this.panel1);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(1149, 716);
            this.Home.TabIndex = 1;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.txtSignup);
            this.panelLogin.Controls.Add(this.btnRegister);
            this.panelLogin.Controls.Add(this.password);
            this.panelLogin.Controls.Add(this.username);
            this.panelLogin.Controls.Add(this.formName);
            this.panelLogin.Controls.Add(this.txtChecklog);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txt_Log2);
            this.panelLogin.Controls.Add(this.txt_Log1);
            this.panelLogin.Location = new System.Drawing.Point(347, 145);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(468, 320);
            this.panelLogin.TabIndex = 50;
            // 
            // txtSignup
            // 
            this.txtSignup.AutoSize = true;
            this.txtSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSignup.Location = new System.Drawing.Point(125, 281);
            this.txtSignup.Name = "txtSignup";
            this.txtSignup.Size = new System.Drawing.Size(95, 13);
            this.txtSignup.TabIndex = 36;
            this.txtSignup.Text = "Forget Password ?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Red;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(242, 224);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(121, 45);
            this.btnRegister.TabIndex = 35;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password.Location = new System.Drawing.Point(101, 136);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(66, 17);
            this.password.TabIndex = 34;
            this.password.Text = "Password";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username.Location = new System.Drawing.Point(101, 70);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(69, 17);
            this.username.TabIndex = 33;
            this.username.Text = "Username";
            // 
            // formName
            // 
            this.formName.AutoSize = true;
            this.formName.BackColor = System.Drawing.Color.Transparent;
            this.formName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline);
            this.formName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.formName.Location = new System.Drawing.Point(176, 14);
            this.formName.Name = "formName";
            this.formName.Size = new System.Drawing.Size(86, 33);
            this.formName.TabIndex = 32;
            this.formName.Text = "Login";
            // 
            // txtChecklog
            // 
            this.txtChecklog.AutoSize = true;
            this.txtChecklog.BackColor = System.Drawing.Color.Transparent;
            this.txtChecklog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChecklog.ForeColor = System.Drawing.Color.Red;
            this.txtChecklog.Location = new System.Drawing.Point(125, 197);
            this.txtChecklog.Name = "txtChecklog";
            this.txtChecklog.Size = new System.Drawing.Size(27, 15);
            this.txtChecklog.TabIndex = 30;
            this.txtChecklog.Text = "null";
            this.txtChecklog.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(104, 224);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(121, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txt_Log2
            // 
            this.txt_Log2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_Log2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Log2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Log2.Location = new System.Drawing.Point(104, 157);
            this.txt_Log2.Name = "txt_Log2";
            this.txt_Log2.Size = new System.Drawing.Size(237, 26);
            this.txt_Log2.TabIndex = 2;
            // 
            // txt_Log1
            // 
            this.txt_Log1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_Log1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Log1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Log1.Location = new System.Drawing.Point(104, 90);
            this.txt_Log1.Name = "txt_Log1";
            this.txt_Log1.Size = new System.Drawing.Size(237, 26);
            this.txt_Log1.TabIndex = 1;
            // 
            // panelSignup
            // 
            this.panelSignup.BackColor = System.Drawing.Color.Transparent;
            this.panelSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSignup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSignup.Controls.Add(this.textBox1);
            this.panelSignup.Controls.Add(this.Email);
            this.panelSignup.Controls.Add(this.txtSignin);
            this.panelSignup.Controls.Add(this.btnExit);
            this.panelSignup.Controls.Add(this.repassword);
            this.panelSignup.Controls.Add(this.password2);
            this.panelSignup.Controls.Add(this.txtFullname);
            this.panelSignup.Controls.Add(this.fullname1);
            this.panelSignup.Controls.Add(this.password1);
            this.panelSignup.Controls.Add(this.username1);
            this.panelSignup.Controls.Add(this.Signup);
            this.panelSignup.Controls.Add(this.btnSignup);
            this.panelSignup.Controls.Add(this.txtPassword);
            this.panelSignup.Controls.Add(this.txtUsername);
            this.panelSignup.Location = new System.Drawing.Point(347, 282);
            this.panelSignup.Name = "panelSignup";
            this.panelSignup.Size = new System.Drawing.Size(468, 299);
            this.panelSignup.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(102, 314);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 26);
            this.textBox1.TabIndex = 48;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Email.Location = new System.Drawing.Point(101, 294);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(42, 17);
            this.Email.TabIndex = 47;
            this.Email.Text = "Email";
            // 
            // txtSignin
            // 
            this.txtSignin.AutoSize = true;
            this.txtSignin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSignin.Location = new System.Drawing.Point(172, 410);
            this.txtSignin.Name = "txtSignin";
            this.txtSignin.Size = new System.Drawing.Size(90, 13);
            this.txtSignin.TabIndex = 44;
            this.txtSignin.Text = "click here to login";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(242, 351);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 45);
            this.btnExit.TabIndex = 44;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // repassword
            // 
            this.repassword.AutoSize = true;
            this.repassword.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.repassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.repassword.Location = new System.Drawing.Point(104, 239);
            this.repassword.Name = "repassword";
            this.repassword.Size = new System.Drawing.Size(86, 17);
            this.repassword.TabIndex = 40;
            this.repassword.Text = "Re-Password";
            // 
            // password2
            // 
            this.password2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.password2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.password2.Location = new System.Drawing.Point(104, 259);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(261, 26);
            this.password2.TabIndex = 39;
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFullname.Location = new System.Drawing.Point(104, 87);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(261, 26);
            this.txtFullname.TabIndex = 38;
            // 
            // fullname1
            // 
            this.fullname1.AutoSize = true;
            this.fullname1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname1.ForeColor = System.Drawing.Color.Black;
            this.fullname1.Location = new System.Drawing.Point(101, 71);
            this.fullname1.Name = "fullname1";
            this.fullname1.Size = new System.Drawing.Size(69, 17);
            this.fullname1.TabIndex = 37;
            this.fullname1.Text = "Full name";
            // 
            // password1
            // 
            this.password1.AutoSize = true;
            this.password1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.password1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password1.Location = new System.Drawing.Point(103, 180);
            this.password1.Name = "password1";
            this.password1.Size = new System.Drawing.Size(66, 17);
            this.password1.TabIndex = 34;
            this.password1.Text = "Password";
            // 
            // username1
            // 
            this.username1.AutoSize = true;
            this.username1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.username1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username1.Location = new System.Drawing.Point(101, 126);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(69, 17);
            this.username1.TabIndex = 33;
            this.username1.Text = "Username";
            // 
            // Signup
            // 
            this.Signup.AutoSize = true;
            this.Signup.BackColor = System.Drawing.Color.Transparent;
            this.Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Signup.Location = new System.Drawing.Point(158, 15);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(124, 33);
            this.Signup.TabIndex = 32;
            this.Signup.Text = "Register";
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(102, 351);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(121, 45);
            this.btnSignup.TabIndex = 43;
            this.btnSignup.Text = "Sign up";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(104, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(259, 26);
            this.txtPassword.TabIndex = 40;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUsername.Location = new System.Drawing.Point(104, 146);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(259, 26);
            this.txtUsername.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 741);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listfriend)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).EndInit();
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelSignup.ResumeLayout(false);
            this.panelSignup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.TabPage Login;
        public System.Windows.Forms.Panel panelSignup;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label Email;
        public System.Windows.Forms.Label txtSignin;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Label repassword;
        public System.Windows.Forms.TextBox password2;
        public System.Windows.Forms.TextBox txtFullname;
        public System.Windows.Forms.Label fullname1;
        public System.Windows.Forms.Label password1;
        public System.Windows.Forms.Label username1;
        public System.Windows.Forms.Label Signup;
        public System.Windows.Forms.Button btnSignup;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.Panel panelLogin;
        public System.Windows.Forms.Label txtSignup;
        public System.Windows.Forms.Button btnRegister;
        public System.Windows.Forms.Label password;
        public System.Windows.Forms.Label username;
        public System.Windows.Forms.Label formName;
        public System.Windows.Forms.Label txtChecklog;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox txt_Log2;
        public System.Windows.Forms.TextBox txt_Log1;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.TabPage Home;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnTao;
        public System.Windows.Forms.Button btnVao;
        public System.Windows.Forms.TextBox txtSophong;
        public System.Windows.Forms.DataGridView danhsachphong;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtChat;
        public System.Windows.Forms.Button btnChat;
        public System.Windows.Forms.ListBox chat;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblRank;
        public System.Windows.Forms.Label lblLevel;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label Level;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.DataGridView listfriend;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TabPage Map;
        public System.Windows.Forms.Timer processbartime;
    }
}

