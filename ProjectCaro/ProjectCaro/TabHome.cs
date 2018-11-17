using System;
using System.Threading;

namespace ProjectCaro
{
    partial class Caro
    {
        private void btnTao_Click(object sender, EventArgs e)
        {
            host_id = user_id;
            CreateRoom(user_id);
            Thread.Sleep(100);
            if (checkCreateRoom)
            {
                //mở map
                MapLoad();
                tabControl.SelectTab(Map);
            }
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            join_id = user_id;
            room_no = txtSophong.Text;
            JoinRoom(user_id, room_no);
            Thread.Sleep(100);

            if (checkJoinRoom)
            {
                //mở map
                MapLoad();
                tabControl.SelectTab(Map);
                lblWaiting.Visible = false;
            }

        }

        
    }
}
