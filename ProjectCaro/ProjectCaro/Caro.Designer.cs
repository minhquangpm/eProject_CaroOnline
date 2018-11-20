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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Login = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblRoomList = new System.Windows.Forms.Label();
            this.btnVaoNhanh = new System.Windows.Forms.Button();
            this.danhsachphong = new System.Windows.Forms.DataGridView();
            this.danhsachphong_room_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhsachphong_room_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhsachphong_room_host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhsachphong_player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVao = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.listboxchat = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.Map = new System.Windows.Forms.TabPage();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSophong = new System.Windows.Forms.Label();
            this.listboxchat2 = new System.Windows.Forms.ListBox();
            this.btnThoatTran = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblJoin = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.pnlChess = new System.Windows.Forms.Panel();
            this.picWinLose = new System.Windows.Forms.PictureBox();
            this.btnChat2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChat2 = new System.Windows.Forms.TextBox();
            this.processbartime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.Login.SuspendLayout();
            this.panelSignup.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.Home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).BeginInit();
            this.panel1.SuspendLayout();
            this.Map.SuspendLayout();
            this.pnlChess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWinLose)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Login);
            this.tabControl.Controls.Add(this.Home);
            this.tabControl.Controls.Add(this.Map);
            this.tabControl.Location = new System.Drawing.Point(-5, -2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(894, 570);
            this.tabControl.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(231)))), ((int)(((byte)(201)))));
            this.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login.Controls.Add(this.label2);
            this.Login.Controls.Add(this.panelSignup);
            this.Login.Controls.Add(this.panelLogin);
            this.Login.Controls.Add(this.processBar1);
            this.Login.Location = new System.Drawing.Point(4, 22);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3);
            this.Login.Size = new System.Drawing.Size(886, 544);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(313, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 33);
            this.label2.TabIndex = 51;
            this.label2.Text = "C A R O G A M E";
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
            this.panelSignup.Location = new System.Drawing.Point(235, 68);
            this.panelSignup.Name = "panelSignup";
            this.panelSignup.Size = new System.Drawing.Size(402, 436);
            this.panelSignup.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(68, 314);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 26);
            this.textBox1.TabIndex = 42;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Email.Location = new System.Drawing.Point(65, 294);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(44, 16);
            this.Email.TabIndex = 47;
            this.Email.Text = "Email";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(208, 372);
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
            this.repassword.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.repassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.repassword.Location = new System.Drawing.Point(65, 239);
            this.repassword.Name = "repassword";
            this.repassword.Size = new System.Drawing.Size(89, 16);
            this.repassword.TabIndex = 40;
            this.repassword.Text = "Re-Password";
            // 
            // password2
            // 
            this.password2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.password2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.password2.Location = new System.Drawing.Point(68, 259);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(261, 26);
            this.password2.TabIndex = 41;
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFullname.Location = new System.Drawing.Point(68, 89);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(261, 26);
            this.txtFullname.TabIndex = 38;
            // 
            // fullname1
            // 
            this.fullname1.AutoSize = true;
            this.fullname1.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname1.ForeColor = System.Drawing.Color.Black;
            this.fullname1.Location = new System.Drawing.Point(65, 69);
            this.fullname1.Name = "fullname1";
            this.fullname1.Size = new System.Drawing.Size(70, 16);
            this.fullname1.TabIndex = 37;
            this.fullname1.Text = "Full name";
            // 
            // password1
            // 
            this.password1.AutoSize = true;
            this.password1.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.password1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password1.Location = new System.Drawing.Point(65, 180);
            this.password1.Name = "password1";
            this.password1.Size = new System.Drawing.Size(68, 16);
            this.password1.TabIndex = 34;
            this.password1.Text = "Password";
            // 
            // username1
            // 
            this.username1.AutoSize = true;
            this.username1.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.username1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username1.Location = new System.Drawing.Point(65, 126);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(70, 16);
            this.username1.TabIndex = 33;
            this.username1.Text = "Username";
            // 
            // Signup
            // 
            this.Signup.AutoSize = true;
            this.Signup.BackColor = System.Drawing.Color.Transparent;
            this.Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Signup.Location = new System.Drawing.Point(138, 23);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(124, 33);
            this.Signup.TabIndex = 32;
            this.Signup.Text = "Register";
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(130)))), ((int)(((byte)(197)))));
            this.btnSignup.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(68, 372);
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
            this.txtPassword.Location = new System.Drawing.Point(68, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(259, 26);
            this.txtPassword.TabIndex = 40;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUsername.Location = new System.Drawing.Point(68, 146);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(261, 26);
            this.txtUsername.TabIndex = 39;
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
            this.panelLogin.Location = new System.Drawing.Point(235, 98);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(402, 357);
            this.panelLogin.TabIndex = 50;
            // 
            // txtSignup
            // 
            this.txtSignup.AutoSize = true;
            this.txtSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignup.Location = new System.Drawing.Point(149, 298);
            this.txtSignup.Name = "txtSignup";
            this.txtSignup.Size = new System.Drawing.Size(95, 13);
            this.txtSignup.TabIndex = 36;
            this.txtSignup.Text = "Forget Password ?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(155)))), ((int)(((byte)(210)))));
            this.btnRegister.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.password.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password.Location = new System.Drawing.Point(65, 136);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(68, 16);
            this.password.TabIndex = 34;
            this.password.Text = "Password";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold);
            this.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username.Location = new System.Drawing.Point(65, 70);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(70, 16);
            this.username.TabIndex = 33;
            this.username.Text = "Username";
            // 
            // formName
            // 
            this.formName.AutoSize = true;
            this.formName.BackColor = System.Drawing.Color.Transparent;
            this.formName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline);
            this.formName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.formName.Location = new System.Drawing.Point(158, 11);
            this.formName.Name = "formName";
            this.formName.Size = new System.Drawing.Size(86, 33);
            this.formName.TabIndex = 32;
            this.formName.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogin.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txt_Log2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Log2_KeyDown);
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
            this.processBar1.Location = new System.Drawing.Point(235, 510);
            this.processBar1.Name = "processBar1";
            this.processBar1.Size = new System.Drawing.Size(402, 23);
            this.processBar1.Step = 5;
            this.processBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.processBar1.TabIndex = 49;
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.Pink;
            this.Home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Home.Controls.Add(this.lblRoomList);
            this.Home.Controls.Add(this.btnVaoNhanh);
            this.Home.Controls.Add(this.danhsachphong);
            this.Home.Controls.Add(this.btnVao);
            this.Home.Controls.Add(this.btnTao);
            this.Home.Controls.Add(this.btnChat);
            this.Home.Controls.Add(this.txtChat);
            this.Home.Controls.Add(this.listboxchat);
            this.Home.Controls.Add(this.label1);
            this.Home.Controls.Add(this.panel1);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(886, 544);
            this.Home.TabIndex = 1;
            this.Home.Text = "Home";
            // 
            // lblRoomList
            // 
            this.lblRoomList.AutoSize = true;
            this.lblRoomList.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomList.ForeColor = System.Drawing.Color.White;
            this.lblRoomList.Location = new System.Drawing.Point(11, 54);
            this.lblRoomList.Name = "lblRoomList";
            this.lblRoomList.Size = new System.Drawing.Size(94, 23);
            this.lblRoomList.TabIndex = 26;
            this.lblRoomList.Text = "List room";
            // 
            // btnVaoNhanh
            // 
            this.btnVaoNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVaoNhanh.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaoNhanh.ForeColor = System.Drawing.Color.White;
            this.btnVaoNhanh.Location = new System.Drawing.Point(142, 307);
            this.btnVaoNhanh.Name = "btnVaoNhanh";
            this.btnVaoNhanh.Size = new System.Drawing.Size(125, 45);
            this.btnVaoNhanh.TabIndex = 25;
            this.btnVaoNhanh.Text = "Quick Join";
            this.btnVaoNhanh.UseVisualStyleBackColor = false;
            this.btnVaoNhanh.Click += new System.EventHandler(this.btnVaoNhanh_Click);
            // 
            // danhsachphong
            // 
            this.danhsachphong.AllowUserToAddRows = false;
            this.danhsachphong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.danhsachphong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.danhsachphong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.danhsachphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachphong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danhsachphong_room_no,
            this.danhsachphong_room_name,
            this.danhsachphong_room_host,
            this.danhsachphong_player});
            this.danhsachphong.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.danhsachphong.DefaultCellStyle = dataGridViewCellStyle1;
            this.danhsachphong.GridColor = System.Drawing.SystemColors.ControlText;
            this.danhsachphong.Location = new System.Drawing.Point(11, 77);
            this.danhsachphong.MultiSelect = false;
            this.danhsachphong.Name = "danhsachphong";
            this.danhsachphong.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.DarkTurquoise;
            this.danhsachphong.RowTemplate.Height = 30;
            this.danhsachphong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.danhsachphong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.danhsachphong.Size = new System.Drawing.Size(603, 224);
            this.danhsachphong.TabIndex = 24;
            this.danhsachphong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.danhsachphong_CellDoubleClick);
            // 
            // danhsachphong_room_no
            // 
            this.danhsachphong_room_no.HeaderText = "Number";
            this.danhsachphong_room_no.Name = "danhsachphong_room_no";
            // 
            // danhsachphong_room_name
            // 
            this.danhsachphong_room_name.HeaderText = "Name";
            this.danhsachphong_room_name.Name = "danhsachphong_room_name";
            this.danhsachphong_room_name.Width = 160;
            // 
            // danhsachphong_room_host
            // 
            this.danhsachphong_room_host.HeaderText = "Host";
            this.danhsachphong_room_host.Name = "danhsachphong_room_host";
            this.danhsachphong_room_host.Width = 140;
            // 
            // danhsachphong_player
            // 
            this.danhsachphong_player.HeaderText = "Players";
            this.danhsachphong_player.Name = "danhsachphong_player";
            this.danhsachphong_player.Width = 150;
            // 
            // btnVao
            // 
            this.btnVao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVao.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVao.ForeColor = System.Drawing.Color.White;
            this.btnVao.Location = new System.Drawing.Point(489, 307);
            this.btnVao.Name = "btnVao";
            this.btnVao.Size = new System.Drawing.Size(125, 45);
            this.btnVao.TabIndex = 11;
            this.btnVao.Text = "Join Room";
            this.btnVao.UseVisualStyleBackColor = false;
            this.btnVao.Click += new System.EventHandler(this.btnVao_Click);
            // 
            // btnTao
            // 
            this.btnTao.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnTao.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao.ForeColor = System.Drawing.Color.White;
            this.btnTao.Location = new System.Drawing.Point(11, 307);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(125, 45);
            this.btnTao.TabIndex = 10;
            this.btnTao.Text = "Create Room";
            this.btnTao.UseVisualStyleBackColor = false;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(113)))), ((int)(((byte)(150)))));
            this.btnChat.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Location = new System.Drawing.Point(489, 494);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(125, 32);
            this.btnChat.TabIndex = 20;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(11, 498);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(472, 26);
            this.txtChat.TabIndex = 21;
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // listboxchat
            // 
            this.listboxchat.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.listboxchat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(226)))), ((int)(((byte)(193)))));
            this.listboxchat.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold);
            this.listboxchat.FormattingEnabled = true;
            this.listboxchat.ItemHeight = 18;
            this.listboxchat.Location = new System.Drawing.Point(11, 358);
            this.listboxchat.Name = "listboxchat";
            this.listboxchat.Size = new System.Drawing.Size(603, 130);
            this.listboxchat.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
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
            this.panel1.Controls.Add(this.lblLevel);
            this.panel1.Controls.Add(this.Level);
            this.panel1.Location = new System.Drawing.Point(634, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 519);
            this.panel1.TabIndex = 20;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(54, 6);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(132, 32);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Red;
            this.lblLevel.Location = new System.Drawing.Point(120, 54);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(32, 25);
            this.lblLevel.TabIndex = 14;
            this.lblLevel.Text = "30";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Font = new System.Drawing.Font("Papyrus", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.ForeColor = System.Drawing.Color.Red;
            this.Level.Location = new System.Drawing.Point(17, 54);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(71, 30);
            this.Level.TabIndex = 12;
            this.Level.Text = "Level :";
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Map.Controls.Add(this.lblWaiting);
            this.Map.Controls.Add(this.label3);
            this.Map.Controls.Add(this.lblSophong);
            this.Map.Controls.Add(this.listboxchat2);
            this.Map.Controls.Add(this.btnThoatTran);
            this.Map.Controls.Add(this.lblHost);
            this.Map.Controls.Add(this.lblJoin);
            this.Map.Controls.Add(this.Time);
            this.Map.Controls.Add(this.pnlChess);
            this.Map.Controls.Add(this.btnChat2);
            this.Map.Controls.Add(this.label5);
            this.Map.Controls.Add(this.txtChat2);
            this.Map.Location = new System.Drawing.Point(4, 22);
            this.Map.Name = "Map";
            this.Map.Padding = new System.Windows.Forms.Padding(3);
            this.Map.Size = new System.Drawing.Size(886, 544);
            this.Map.TabIndex = 2;
            this.Map.Text = "Map";
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.ForeColor = System.Drawing.Color.DarkSalmon;
            this.lblWaiting.Location = new System.Drawing.Point(611, 253);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(167, 24);
            this.lblWaiting.TabIndex = 0;
            this.lblWaiting.Text = "Wait for player ...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 56;
            this.label3.Text = "Room :";
            // 
            // lblSophong
            // 
            this.lblSophong.AutoSize = true;
            this.lblSophong.BackColor = System.Drawing.Color.Transparent;
            this.lblSophong.Font = new System.Drawing.Font("Kristen ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSophong.ForeColor = System.Drawing.Color.Red;
            this.lblSophong.Location = new System.Drawing.Point(106, 13);
            this.lblSophong.Name = "lblSophong";
            this.lblSophong.Size = new System.Drawing.Size(64, 28);
            this.lblSophong.TabIndex = 39;
            this.lblSophong.Text = "0000";
            // 
            // listboxchat2
            // 
            this.listboxchat2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listboxchat2.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxchat2.FormattingEnabled = true;
            this.listboxchat2.ItemHeight = 18;
            this.listboxchat2.Location = new System.Drawing.Point(509, 292);
            this.listboxchat2.Name = "listboxchat2";
            this.listboxchat2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listboxchat2.Size = new System.Drawing.Size(364, 148);
            this.listboxchat2.TabIndex = 42;
            // 
            // btnThoatTran
            // 
            this.btnThoatTran.BackColor = System.Drawing.Color.IndianRed;
            this.btnThoatTran.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatTran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThoatTran.Location = new System.Drawing.Point(509, 488);
            this.btnThoatTran.Name = "btnThoatTran";
            this.btnThoatTran.Size = new System.Drawing.Size(364, 42);
            this.btnThoatTran.TabIndex = 55;
            this.btnThoatTran.Text = "Quit game";
            this.btnThoatTran.UseVisualStyleBackColor = false;
            this.btnThoatTran.Click += new System.EventHandler(this.btnThoatTran_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Kristen ITC", 15F, System.Drawing.FontStyle.Bold);
            this.lblHost.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblHost.Location = new System.Drawing.Point(542, 49);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(113, 28);
            this.lblHost.TabIndex = 53;
            this.lblHost.Text = "UserHost";
            // 
            // lblJoin
            // 
            this.lblJoin.AutoSize = true;
            this.lblJoin.Font = new System.Drawing.Font("Kristen ITC", 15F, System.Drawing.FontStyle.Bold);
            this.lblJoin.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblJoin.Location = new System.Drawing.Point(741, 49);
            this.lblJoin.Name = "lblJoin";
            this.lblJoin.Size = new System.Drawing.Size(108, 28);
            this.lblJoin.TabIndex = 52;
            this.lblJoin.Text = "UserJoin";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Papyrus", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.Red;
            this.Time.Location = new System.Drawing.Point(545, 120);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(281, 151);
            this.Time.TabIndex = 49;
            this.Time.Text = "0  :  0";
            // 
            // pnlChess
            // 
            this.pnlChess.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlChess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlChess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChess.Controls.Add(this.picWinLose);
            this.pnlChess.Location = new System.Drawing.Point(13, 49);
            this.pnlChess.Name = "pnlChess";
            this.pnlChess.Size = new System.Drawing.Size(480, 480);
            this.pnlChess.TabIndex = 43;
            // 
            // picWinLose
            // 
            this.picWinLose.Image = global::ProjectCaro.Properties.Resources.win;
            this.picWinLose.Location = new System.Drawing.Point(21, 22);
            this.picWinLose.Name = "picWinLose";
            this.picWinLose.Size = new System.Drawing.Size(433, 434);
            this.picWinLose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWinLose.TabIndex = 1;
            this.picWinLose.TabStop = false;
            this.picWinLose.Click += new System.EventHandler(this.picWinLose_Click);
            // 
            // btnChat2
            // 
            this.btnChat2.Location = new System.Drawing.Point(811, 459);
            this.btnChat2.Name = "btnChat2";
            this.btnChat2.Size = new System.Drawing.Size(62, 24);
            this.btnChat2.TabIndex = 44;
            this.btnChat2.Text = "Send";
            this.btnChat2.UseVisualStyleBackColor = true;
            this.btnChat2.Click += new System.EventHandler(this.btnChat2_Click);
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
            // txtChat2
            // 
            this.txtChat2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat2.Location = new System.Drawing.Point(509, 458);
            this.txtChat2.Name = "txtChat2";
            this.txtChat2.Size = new System.Drawing.Size(296, 24);
            this.txtChat2.TabIndex = 45;
            this.txtChat2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat2_KeyDown);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Caro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caro_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.panelSignup.ResumeLayout(false);
            this.panelSignup.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachphong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Map.ResumeLayout(false);
            this.Map.PerformLayout();
            this.pnlChess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWinLose)).EndInit();
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
        public System.Windows.Forms.TextBox txtChat;
        public System.Windows.Forms.Button btnChat;
        public System.Windows.Forms.ListBox listboxchat;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblLevel;
        public System.Windows.Forms.Label Level;
        public System.Windows.Forms.Label lblUsername;
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
        public System.Windows.Forms.ListBox listboxchat2;
        public System.Windows.Forms.Button btnChat2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtChat2;
        public System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Label lblHost;
        public System.Windows.Forms.Label lblJoin;
        public System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Button btnThoatTran;
        public System.Windows.Forms.DataGridView danhsachphong;
        public System.Windows.Forms.Button btnVaoNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhsachphong_room_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhsachphong_room_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhsachphong_room_host;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhsachphong_player;
        private System.Windows.Forms.Label lblRoomList;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picWinLose;
        public System.Windows.Forms.Label label2;
    }
}

