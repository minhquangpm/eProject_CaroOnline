using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    public partial class Form1 : Form
    {
        private static TabLogin tabLog = new TabLogin();
        private static TabHome tabHome = new TabHome();
        private static TabMap tabMap = new TabMap();
        //private static TabLogin tabLog = new TabLogin();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSignup.Visible = false;

            //loadmap
            lblSophong.Text = Client.room_no;
            lblHost.Text = Client.host_id;
            lblJoin.Text = Client.join_id;

            // thực thi nếu người chơi là host
            if (Client.host_id.Equals(Client.user_id))
            {
                label7.Text = "Chờ người chơi...";

                // chạy thread chờ người chơi join
                if (!Client.workerWaitForPlayer.IsBusy)
                {
                    Client.workerWaitForPlayer.RunWorkerAsync();
                }
            }

            // chạy thread đổi màu tên người chơi khi đến lượt
            if (!Client.workerChangeTurn.IsBusy)
            {
                Client.workerChangeTurn.RunWorkerAsync();
            }
        }

        //////Form LOgin
        private void btnLogin_Click(object sender, EventArgs e)
        {
            tabLog.btnLogin_Click();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            tabLog.btnSignup_Click();
        }
        

        private void txtSignin_Click(object sender, EventArgs e)
        {

        }


        //FORM HOME
        private void btnTao_Click(object sender, EventArgs e)
        {
            tabHome.btnTao_Click();
        }

        private void btnVao_Click(object sender, EventArgs e)
        {
            tabHome.btnVao_Click();
        }


        //FORM MAP
        private void pnlChess_MouseClick(object sender, MouseEventArgs e)
        {
            tabMap.Danhco();
        }

        

    }
}
