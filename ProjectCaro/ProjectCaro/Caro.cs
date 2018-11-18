using System;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro : Form
    {
        public Caro()
        {
            InitializeComponent();
            InitClient();
            //đổi pass thành *
            txt_Log2.PasswordChar = '*';
            txtPassword.PasswordChar = '*';
            password2.PasswordChar = '*';
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
            processBar1.Visible = false;
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UserOffline(user_id);
        }

        private void btnVaoNhanh_Click(object sender, EventArgs e)
        {

        }
    }
}
