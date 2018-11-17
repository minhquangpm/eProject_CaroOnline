using System;
using System.Drawing;
using System.Threading;

namespace ProjectCaro
{
    partial class Caro
    {
        private void HomeLoad()
        {
            txtSophong.Text = "Enter...";
            txtSophong.ForeColor = Color.Gray;

            txtSophong.GotFocus += new EventHandler(RemoveHint);
            txtSophong.LostFocus += new EventHandler(ShowHint);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            SendCreateRoom(user_id);
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            room_no = txtSophong.Text;
            SendJoinRoom(user_id, room_no);
        }


        private void RemoveHint(object sender, EventArgs e)
        {
            txtSophong.Text = "";
        }

        private void ShowHint(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSophong.Text))
            {
                txtSophong.Text = "Enter...";
            }
        }
        
    }
}
