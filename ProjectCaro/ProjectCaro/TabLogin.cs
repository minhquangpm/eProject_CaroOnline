using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Media;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    class TabLogin : Form1
    {
        public TabLogin ()
        {
            Client.InitClient();
        }
        public void btnLogin_Click()
        {
            
            //Client.user_id = txt_Log1.Text;
            //string user_pass = txt_Log2.Text;
            //bool check = await CaroAPI.Login(txt_Log1.Text, txt_Log2.Text);

            //if (check)
            //{
            //    //check login và chạy hàm load
            //    processbartime.Enabled = true;
            //    Client.UserOnline(Client.user_id);
            //}
            //else
            //{
            //    MessageBox.Show(CaroAPI.userReturn.statuscode);
            //    CaroAPI.userReturn = null;
            //}
        }

        public void processbar_Tick()
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

        public void btnSignup_Click()
        {
            panelSignup.Visible = true;
        }
    }
}
