using System;
using System.Drawing;
using System.Threading;
using Microsoft.VisualBasic;

namespace ProjectCaro
{
    partial class Caro
    {
        private void HomeLoad()
        {
            //txtSophong.Text = "Enter...";
            //txtSophong.ForeColor = Color.Gray;

            //txtSophong.GotFocus += new EventHandler(RemoveHint);
            //txtSophong.LostFocus += new EventHandler(ShowHint);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            SendCreateRoom(user_id);
        }

        private void btnVao_Click(object sender, EventArgs e)
        {
            //room_no = txtSophong.Text;
            //SendJoinRoom(user_id, room_no);
            var input = Interaction.InputBox("Nhập số phòng : ", "Caro", "", -1, -1);
            room_no = input;
            SendJoinRoom(user_id, room_no);
        }

    }
}