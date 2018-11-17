using System;
using System.Threading;

namespace ProjectCaro
{
    partial class Caro
    {
        private void btnTao_Click(object sender, EventArgs e)
        {
            SendCreateRoom(user_id);
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            room_no = txtSophong.Text;
            SendJoinRoom(user_id, room_no);
        }

        
    }
}
