using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    partial class Caro
    {
        Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);
        

        private void LoginLoad()
        {
            //đổi pass thành *
            txt_Log2.PasswordChar = '*';
            txtPassword.PasswordChar = '*';
            password2.PasswordChar = '*';

            pnlBorderSignup.Visible = false;
            pnlBorderLogin.Visible = true;
            processBar1.Visible = false;
        }



        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //không cho hành động khi chờ response
            txt_Log1.Enabled = false;
            txt_Log2.Enabled = false;
            btnLogin.Enabled = false;


            user_id = txt_Log1.Text;
            string user_pass = txt_Log2.Text;
            bool check = await CaroAPI.Login(txt_Log1.Text, txt_Log2.Text);

            if (check)
            {
                InitClient();

                //Load home
                HomeLoad();

                //check login và chạy hàm load
                processbartime.Start();

                SendUserOnline(user_id);
            }
            else
            {
                try
                {
                    MessageBox.Show(CaroAPI.userReturn.statuscode);
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Cannot connect to server!");
                }

                // cho hành động lại khi thông báo lỗi
                txt_Log1.Enabled = true;
                txt_Log2.Enabled = true;
                btnLogin.Enabled = true;

                CaroAPI.userReturn = null;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            pnlBorderSignup.Visible = true;
            pnlBorderLogin.Visible = false;
        }

        private void processbartime_Tick(object sender, EventArgs e)
        {
            processBar1.Visible = true;
            processBar1.Increment(14);
            if (processBar1.Value == processBar1.Maximum)
            {
                tabControl.SelectTab(Home);
                processbartime.Stop();
            }
        }

        // ấn enter sau khi nhập password để login
        private void txt_Log2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }



        private void txt_Log1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }



        //Form đăng ký
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlBorderSignup.Visible = false;
            pnlBorderLogin.Visible = true;
        }


        private async void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                MessageBox.Show("Full name can not be empty!", "Caro");
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Username can not be empty!", "Caro");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password can not be empty!", "Caro");
            }
            else if (txtPassword.Text != password2.Text)
            {
                MessageBox.Show("Passwords do not match!", "Caro");
            }
            else if (!reg.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Invalid email format!", "Caro");
            }
            else
            {
                bool check = await CaroAPI.SignUp(txtUsername.Text, txtFullname.Text, txtPassword.Text, textBox1.Text);
                if (check)
                {
                    MessageBox.Show("Success", "Caro");
                }
                else
                {
                    MessageBox.Show("Username or Email exists", "Caro");
                }

            }
        }


        private void btnCloseForm1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizeForm1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


    }
}
