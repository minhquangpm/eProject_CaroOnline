using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    partial class Caro
    {
        Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

        public void load_Login()
        {
            panelSignup.Visible = false;
            txt_Log2.PasswordChar = '*';
            txtPassword.PasswordChar = '*';
            txtpassword2.PasswordChar = '*';
        }
       
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            user_id = txt_Log1.Text;
            string user_pass = txt_Log2.Text;
            bool check = await CaroAPI.Login(txt_Log1.Text, txt_Log2.Text);

            if (check)
            {
                //check login và chạy hàm load
                processbartime.Enabled = true;

                lblUsername.Text = CaroAPI.user.name;
            }
            else
            {
                MessageBox.Show(CaroAPI.userReturn.statuscode);
                CaroAPI.userReturn = null;
            }
        }
        

        private void processbartime_Tick(object sender, EventArgs e)
        {
            //không cho hành động khi load form 
            progressBar1.Visible = true;
            progressBar1.Value = progressBar1.Value + 50;
            if (progressBar1.Value >= 999)
            {
                //dừng thanh load
                processbartime.Enabled = false;
                //không cho hành động khi load form
                txt_Log1.Enabled = false;
                txt_Log2.Enabled = false;
                btnLogin.Enabled = false;
                panelLogin.Visible = false;
                //mở trang home
                tabControl.SelectTab(Home);
            }

        }
        //mở form đăng ký
        private void btnRegister_Click(object sender, EventArgs e)
        {
            panelSignup.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close();
            UserOffline(user_id);
        }


        //Form đăng ký
        private void txtSignin_Click(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
        }


        private async void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                MessageBox.Show("Chưa có full name");
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Chưa có username");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Chưa có password");
            }
            else if (txtPassword.Text != txtpassword2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng nhau");
            }
            else if (!reg.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Email chưa đúng định dạng");
            }
            else
            {
                bool check = await CaroAPI.SignUp(txtUsername.Text, txtFullname.Text, txtPassword.Text, txtEmail.Text);
                if (check)
                {
                    MessageBox.Show("Thành Công");
                }
                else
                {
                    MessageBox.Show("username hoặc email đã tồn tại");
                }

            }
        }


    }
}
