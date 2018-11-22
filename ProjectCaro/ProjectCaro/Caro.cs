using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro : Form
    {
        public Caro()
        {
            InitializeComponent();
            InitClient();

            HideTab();

            FullWindow();

            //đổi pass thành *
            txt_Log2.PasswordChar = '*';
            txtPassword.PasswordChar = '*';
            password2.PasswordChar = '*';

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlBorderSignup.Visible = false;
            pnlBorderLogin.Visible = true;
            processBar1.Visible = false;
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            //workerWaitForPlayer.CancelAsync();
        }

        private void HideTab()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }


        private void FullWindow()
        {
            FormBorderStyle = FormBorderStyle.None;
            tabControl.Dock = DockStyle.Fill;
        }
    }
}
