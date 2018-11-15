using System;
using System.Threading;

namespace ProjectCaro
{
    partial class Form1
    {
        private void btnTao_Click(object sender, EventArgs e)
        {
            Client.host_id = Client.user_id;
            Client.CreateRoom(Client.user_id);
            Thread.Sleep(200);
            if (Client.checkCreateRoom)
            {
                //mở map
                tabControl.SelectTab(Map);
            }
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            Client.join_id = Client.user_id;
            Client.room_no = txtSophong.Text;
            Client.JoinRoom(Client.user_id, Client.room_no);
            Thread.Sleep(1000);

            if (Client.checkJoinRoom)
            {
                //mở map
                tabControl.SelectTab(Map);
            }

        }

        
    }
}
