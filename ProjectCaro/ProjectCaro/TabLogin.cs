﻿using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    partial class Caro
    {
        Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);
        
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


    }
}
