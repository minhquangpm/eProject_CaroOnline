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

            RoomListInit();


            if (!workerRefreshRoom.IsBusy)
            {
                workerRefreshRoom.RunWorkerAsync();
            }

        }


        private void RoomListInit()
        {
            for (int i = 0; i < 10; i++)
            {
                danhsachphong.Rows.Add();
                danhsachphong.Rows[i].ReadOnly = true;
            }
        }



        private void btnTao_Click(object sender, EventArgs e)
        {
            SendCreateRoom(user_id);
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            var input = Interaction.InputBox("Nhập số phòng : ", "Caro", "", -1, -1);
            room_no = input;
            SendJoinRoom(user_id, room_no);
        }



        private void btnVaoNhanh_Click(object sender, EventArgs e)
        {
            SendQuickJoin(user_id);
        }


        //private void RemoveHint(object sender, EventArgs e)
        //{
        //    txtSophong.Text = "";
        //}

        //private void ShowHint(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtSophong.Text))
        //    {
        //        txtSophong.Text = "Enter...";
        //    }
        //}

    }
}
