namespace ProjectCaro
{
    partial class Caro
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Login = new System.Windows.Forms.TabPage();
            this.panelSignup = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtSignup = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.formName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txt_Log2 = new System.Windows.Forms.TextBox();
            this.txt_Log1 = new System.Windows.Forms.TextBox();
            this.processBar1 = new System.Windows.Forms.ProgressBar();
            this.Home = new System.Windows.Forms.TabPage();
            this.btnVaoNhanh = new System.Windows.Forms.Button();
            this.danhsachphong = new System.Windows.Forms.DataGridView();
            this.btnVao = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtSophong = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Map = new System.Windows.Forms.TabPage();
            this.lblSophong = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.btnThoatTran = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblJoin = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.pnlChess = new System.Windows.Forms.Panel();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.processbartime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.Login.SuspendLayout();
            this.panelSignup.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.Home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Map.SuspendLayout();
            this.pnlChess.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Login);
            this.tabControl.Controls.Add(this.Home);
            this.tabControl.Controls.Add(this.Map);
            this.tabControl.Location = new System.Drawing.Point(-5, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(894, 562);
            this.tabControl.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login.Controls.Add(this.panelSignup);
            this.Login.Controls.Add(this.panelLogin);
            this.Login.Controls.Add(this.processBar1);
            this.Login.Location = new System.Drawing.Point(4, 22);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3);
            this.Login.Size = new System.Drawing.Size(886, 536);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // panelSignup
            // 
            this.panelSignup.BackColor = System.Drawing.Color.Transparent;
            this.panelSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSignup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSignup.Controls.Add(this.textBox1);
            this.panelSignup.Controls.Add(this.Email);
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
            this.panelSignup.Location = new System.Drawing.Point(235, 43);
            this.panelSignup.Name = "panelSignup";
            this.panelSignup.Size = new System.Drawing.Size(468, 436);
            this.panelSignup.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(104, 314);
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(244, 372);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 45);
            this.btnExit.TabIndex = 44;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // repassword
            // 
            this.repassword.AutoSize = true;
            this.repassword.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.repassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.repassword.Location = new System.Drawing.Point(101, 239);
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
            this.password1.Location = new System.Drawing.Point(101, 180);
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
            this.Signup.Location = new System.Drawing.Point(169, 14);
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
            this.btnSignup.Location = new System.Drawing.Point(104, 372);
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
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txt_Log2);
            this.panelLogin.Controls.Add(this.txt_Log1);
            this.panelLogin.Location = new System.Drawing.Point(235, 43);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(402, 357);
            this.panelLogin.TabIndex = 50;
            // 
            // txtSignup
            // 
            this.txtSignup.AutoSize = true;
            this.txtSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSignup.Location = new System.Drawing.Point(149, 298);
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
            this.btnRegister.Location = new System.Drawing.Point(206, 213);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(121, 45);
            this.btnRegister.TabIndex = 35;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password.Location = new System.Drawing.Point(65, 136);
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
            this.username.Location = new System.Drawing.Point(65, 70);
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
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(68, 213);
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
            this.txt_Log2.Location = new System.Drawing.Point(68, 156);
            this.txt_Log2.Name = "txt_Log2";
            this.txt_Log2.Size = new System.Drawing.Size(259, 26);
            this.txt_Log2.TabIndex = 2;
            // 
            // txt_Log1
            // 
            this.txt_Log1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_Log1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Log1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Log1.Location = new System.Drawing.Point(68, 90);
            this.txt_Log1.Name = "txt_Log1";
            this.txt_Log1.Size = new System.Drawing.Size(259, 26);
            this.txt_Log1.TabIndex = 1;
            // 
            // processBar1
            // 
            this.processBar1.BackColor = System.Drawing.Color.Red;
            this.processBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.processBar1.Location = new System.Drawing.Point(6, 510);
            this.processBar1.MarqueeAnimationSpeed = 20;
            this.processBar1.Maximum = 200;
            this.processBar1.Name = "processBar1";
            this.processBar1.Size = new System.Drawing.Size(874, 23);
            this.processBar1.TabIndex = 49;
            // 
            // Home
            // 
            this.Home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Home.Controls.Add(this.btnVaoNhanh);
            this.Home.Controls.Add(this.danhsachphong);
            this.Home.Controls.Add(this.btnVao);
            this.Home.Controls.Add(this.btnTao);
            this.Home.Controls.Add(this.btnChat);
            this.Home.Controls.Add(this.txtChat);
            this.Home.Controls.Add(this.txtSophong);
            this.Home.Controls.Add(this.chat);
            this.Home.Controls.Add(this.label1);
            this.Home.Controls.Add(this.panel1);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(886, 536);
            this.Home.TabIndex = 1;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // btnVaoNhanh
            // 
            this.btnVaoNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVaoNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaoNhanh.ForeColor = System.Drawing.Color.White;
            this.btnVaoNhanh.Location = new System.Drawing.Point(157, 279);
            this.btnVaoNhanh.Name = "btnVaoNhanh";
            this.btnVaoNhanh.Size = new System.Drawing.Size(131, 45);
            this.btnVaoNhanh.TabIndex = 25;
            this.btnVaoNhanh.Text = "Quick Join";
            this.btnVaoNhanh.UseVisualStyleBackColor = false;
            this.btnVaoNhanh.Click += new System.EventHandler(this.btnVaoNhanh_Click);
            // 
            // danhsachphong
            // 
            this.danhsachphong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.danhsachphong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.danhsachphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachphong.Location = new System.Drawing.Point(11, 47);
            this.danhsachphong.Name = "danhsachphong";
            this.danhsachphong.Size = new System.Drawing.Size(610, 224);
            this.danhsachphong.TabIndex = 24;
            // 
            // btnVao
            // 
            this.btnVao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVao.ForeColor = System.Drawing.Color.White;
            this.btnVao.Location = new System.Drawing.Point(508, 280);
            this.btnVao.Name = "btnVao";
            this.btnVao.Size = new System.Drawing.Size(113, 45);
            this.btnVao.TabIndex = 11;
            this.btnVao.Text = "Join Room";
            this.btnVao.UseVisualStyleBackColor = false;
            this.btnVao.Click += new System.EventHandler(this.btnVao_Click);
            // 
            // btnTao
            // 
            this.btnTao.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao.ForeColor = System.Drawing.Color.White;
            this.btnTao.Location = new System.Drawing.Point(11, 280);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(131, 45);
            this.btnTao.TabIndex = 10;
            this.btnTao.Text = "Create Room";
            this.btnTao.UseVisualStyleBackColor = false;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(113)))), ((int)(((byte)(150)))));
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Location = new System.Drawing.Point(508, 498);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(113, 26);
            this.btnChat.TabIndex = 20;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = false;
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(11, 498);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(491, 26);
            this.txtChat.TabIndex = 21;
            // 
            // txtSophong
            // 
            this.txtSophong.BackColor = System.Drawing.Color.White;
            this.txtSophong.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSophong.Location = new System.Drawing.Point(395, 280);
            this.txtSophong.Name = "txtSophong";
            this.txtSophong.Size = new System.Drawing.Size(107, 44);
            this.txtSophong.TabIndex = 12;
            this.txtSophong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chat
            // 
            this.chat.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(11, 345);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(491, 134);
            this.chat.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "C A R O G A M E";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(197)))));
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.lblRank);
            this.panel1.Controls.Add(this.lblLevel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Level);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(639, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 519);
            this.panel1.TabIndex = 20;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Red;
            this.lblUsername.Location = new System.Drawing.Point(72, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(79, 16);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRank.ForeColor = System.Drawing.Color.Red;
            this.lblRank.Location = new System.Drawing.Point(137, 177);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(49, 20);
            this.lblRank.TabIndex = 15;
            this.lblRank.Text = "1000";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Red;
            this.lblLevel.Location = new System.Drawing.Point(146, 132);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(29, 20);
            this.lblLevel.TabIndex = 14;
            this.lblLevel.Text = "30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(95)))));
            this.label3.Location = new System.Drawing.Point(20, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rank :";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(95)))));
            this.Level.Location = new System.Drawing.Point(20, 132);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(61, 20);
            this.Level.TabIndex = 12;
            this.Level.Text = "Level :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(14, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Map
            // 
            this.Map.Controls.Add(this.lblSophong);
            this.Map.Controls.Add(this.lb1);
            this.Map.Controls.Add(this.btnThoatTran);
            this.Map.Controls.Add(this.lblHost);
            this.Map.Controls.Add(this.lblJoin);
            this.Map.Controls.Add(this.Time);
            this.Map.Controls.Add(this.pnlChess);
            this.Map.Controls.Add(this.button1);
            this.Map.Controls.Add(this.label5);
            this.Map.Controls.Add(this.textBox2);
            this.Map.Location = new System.Drawing.Point(4, 22);
            this.Map.Name = "Map";
            this.Map.Padding = new System.Windows.Forms.Padding(3);
            this.Map.Size = new System.Drawing.Size(886, 536);
            this.Map.TabIndex = 2;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = true;
            // 
            // lblSophong
            // 
            this.lblSophong.AutoSize = true;
            this.lblSophong.BackColor = System.Drawing.Color.Transparent;
            this.lblSophong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblSophong.ForeColor = System.Drawing.Color.Maroon;
            this.lblSophong.Location = new System.Drawing.Point(15, 10);
            this.lblSophong.Name = "lblSophong";
            this.lblSophong.Size = new System.Drawing.Size(60, 25);
            this.lblSophong.TabIndex = 39;
            this.lblSophong.Text = "0000";
            // 
            // lb1
            // 
            this.lb1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(509, 280);
            this.lb1.Name = "lb1";
            this.lb1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb1.Size = new System.Drawing.Size(371, 160);
            this.lb1.TabIndex = 42;
            // 
            // btnThoatTran
            // 
            this.btnThoatTran.Location = new System.Drawing.Point(509, 488);
            this.btnThoatTran.Name = "btnThoatTran";
            this.btnThoatTran.Size = new System.Drawing.Size(371, 42);
            this.btnThoatTran.TabIndex = 55;
            this.btnThoatTran.Text = "thoát trận";
            this.btnThoatTran.UseVisualStyleBackColor = true;
            this.btnThoatTran.Click += new System.EventHandler(this.btnThoatTran_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblHost.ForeColor = System.Drawing.Color.Blue;
            this.lblHost.Location = new System.Drawing.Point(539, 53);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(101, 25);
            this.lblHost.TabIndex = 53;
            this.lblHost.Text = "UserHost";
            // 
            // lblJoin
            // 
            this.lblJoin.AutoSize = true;
            this.lblJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblJoin.Location = new System.Drawing.Point(736, 53);
            this.lblJoin.Name = "lblJoin";
            this.lblJoin.Size = new System.Drawing.Size(98, 25);
            this.lblJoin.TabIndex = 52;
            this.lblJoin.Text = "UserJoin";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.Red;
            this.Time.Location = new System.Drawing.Point(545, 120);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(289, 108);
            this.Time.TabIndex = 49;
            this.Time.Text = "0  :  0";
            // 
            // pnlChess
            // 
            this.pnlChess.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlChess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlChess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChess.Controls.Add(this.lblWaiting);
            this.pnlChess.Location = new System.Drawing.Point(6, 53);
            this.pnlChess.Name = "pnlChess";
            this.pnlChess.Size = new System.Drawing.Size(480, 480);
            this.pnlChess.TabIndex = 43;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Location = new System.Drawing.Point(211, 202);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(26, 13);
            this.lblWaiting.TabIndex = 0;
            this.lblWaiting.Text = "wait";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(818, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 24);
            this.button1.TabIndex = 44;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(104, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 47;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(509, 458);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(303, 24);
            this.textBox2.TabIndex = 45;
            // 
            // processbartime
            // 
            this.processbartime.Tick += new System.EventHandler(this.processbartime_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Caro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Caro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caro_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.panelSignup.ResumeLayout(false);
            this.panelSignup.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Map.ResumeLayout(false);
            this.Map.PerformLayout();
            this.pnlChess.ResumeLayout(false);
            this.pnlChess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.TabPage Login;
        public System.Windows.Forms.Panel panelLogin;
        public System.Windows.Forms.Label txtSignup;
        public System.Windows.Forms.Button btnRegister;
        public System.Windows.Forms.Label password;
        public System.Windows.Forms.Label username;
        public System.Windows.Forms.Label formName;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox txt_Log2;
        public System.Windows.Forms.TextBox txt_Log1;
        public System.Windows.Forms.ProgressBar processBar1;
        public System.Windows.Forms.TabPage Home;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnTao;
        public System.Windows.Forms.Button btnVao;
        public System.Windows.Forms.TextBox txtSophong;
        public System.Windows.Forms.TextBox txtChat;
        public System.Windows.Forms.Button btnChat;
        public System.Windows.Forms.ListBox chat;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblRank;
        public System.Windows.Forms.Label lblLevel;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label Level;
        public System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TabPage Map;
        public System.Windows.Forms.Timer processbartime;
        public System.Windows.Forms.Panel panelSignup;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label Email;
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
        public System.Windows.Forms.Label lblSophong;
        public System.Windows.Forms.Label Time;
        public System.Windows.Forms.Panel pnlChess;
        public System.Windows.Forms.ListBox lb1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Label lblHost;
        public System.Windows.Forms.Label lblJoin;
        public System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Button btnThoatTran;
        public System.Windows.Forms.DataGridView danhsachphong;
        public System.Windows.Forms.Button btnVaoNhanh;
    }
}

