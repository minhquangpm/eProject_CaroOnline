using System;
using System.Threading;

namespace ProjectCaro
{
    partial class Caro
    {
        private void btnTao_Click(object sender, EventArgs e)
        {
            // gửi thông tin tạo phòng lên server
            SendCreateRoom(user_id);
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            // gửi thông tin vào phòng lên server
            room_no = txtSophong.Text;

            SendJoinRoom(user_id, room_no);
        }





    }
}
