using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Media;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    public partial class TabLogin : Form1
    {
        Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);
        public TabLogin()
        {
            Client.InitClient();
        }
        public async void btnLogin_Click()
        {

            Client.user_id = txt_Log1.Text;
            string user_pass = txt_Log2.Text;
            bool check = await CaroAPI.Login(txt_Log1.Text, txt_Log2.Text);

            if (check)
            {
                //check login và chạy hàm load
                //processbartime.Enabled = true;
                Client.UserOnline(Client.user_id);
                tabControl.SelectTab(Home);
            }
            else
            {
                MessageBox.Show(CaroAPI.userReturn.statuscode);
                CaroAPI.userReturn = null;
            }
        }
        

        public void btnSignup_Click()
        {
            //panelSignup.Visible = false;
        }
        
        public async void btnResgister_click()
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
            else if (txtPassword.Text != password2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng nhau");
            }
            else if (!reg.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Email chưa đúng định dạng");
            }
            else
            {
                bool check = await CaroAPI.SignUp(txtUsername.Text, txtFullname.Text, txtPassword.Text, textBox1.Text);
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
