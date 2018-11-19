using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    partial class Caro
    {
        Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

        //public void load_login()
        //{
        //    lblUsername.Text = user_id;
        //}



        private async void btnLogin_Click(object sender, EventArgs e)
        {
            user_id = txt_Log1.Text;
            string user_pass = txt_Log2.Text;
            bool check = await CaroAPI.Login(txt_Log1.Text, txt_Log2.Text);

            if (check)
            {
                //không cho hành động khi load form
                txt_Log1.Enabled = false;
                txt_Log2.Enabled = false;
                btnLogin.Enabled = false;


                //Load home
                HomeLoad();

                lblUsername.Text = user_id;
                //check login và chạy hàm load
                processbartime.Start();
                SendUserOnline(user_id);
            }
            else
            {
                MessageBox.Show(CaroAPI.userReturn.statuscode);
                CaroAPI.userReturn = null;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            panelSignup.Visible = true;
        }

        private void processbartime_Tick(object sender, EventArgs e)
        {
            //không cho hành động khi load form 
            processBar1.Visible = true;
            //processBar1.Value = processBar1.Value + 50;
            //if (processBar1.Value >= 199)
            //{
            //    //dừng thanh load
            //    processbartime.Enabled = false;
            //    //mở trang home
            //    HomeLoad();
            //    tabControl.SelectTab(Home);
            //}
            processBar1.Increment(14);
            if (processBar1.Value == processBar1.Maximum)
            {
                tabControl.SelectTab(Home);
                processbartime.Stop();
            }
        }


        //Form đăng ký
        private void btnExit_Click(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
        }


        private async void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                MessageBox.Show("Full name can not be empty!");
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Username can not be empty!");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password can not be empty!");
            }
            else if (txtPassword.Text != password2.Text)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else if (!reg.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Invalid email format!");
            }
            else
            {
                bool check = await CaroAPI.SignUp(txtUsername.Text, txtFullname.Text, txtPassword.Text, textBox1.Text);
                if (check)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Username or Email exists");
                }

            }
        }


    }
}
