using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro
    {
        private void HomeLoad()
        {
            RoomListInit();
            
            if (!workerRefreshRoom.IsBusy)
            {
                workerRefreshRoom.RunWorkerAsync();
            }

        }


        private void RoomListInit()
        {
            for (int i = 0; i < 15; i++)
            {
                danhsachphong.Rows.Add();
                danhsachphong.Rows[i].ReadOnly = true;
            }
        }
        

        private void btnTao_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Create password : ", "Caro", "", -1, -1);

            if (input.Length == 0)
            {
                SendCreateRoom(user_id);
            }
            else
            {

            }
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter room number: ", "Caro", "", -1, -1);
            
            if (input.Length > 0)
            {
                room_no = input;
                SendJoinRoom(user_id, room_no);
            }
        }
        


        private void btnVaoNhanh_Click(object sender, EventArgs e)
        {
            SendQuickJoin(user_id);
        }




        // xử lý khi người chơi double click vào phòng
        private void danhsachphong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if ((dgv == null) ||
                (dgv.CurrentRow.Cells[0].Value == null))
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                string room_no_selected = dgv.CurrentRow.Cells[0].Value.ToString();
                room_no = room_no_selected;
                SendJoinRoom(user_id, room_no_selected);
            }
        }


        private void btnChat_Click(object sender, EventArgs e)
        {
            if (txtChat.Text.Length > 0)
            {
                SendChat(user_id, txtChat.Text);
                txtChat.Text = "";
            }
        }



        // xử lý chat
        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChat.PerformClick();
            }
        }
    }
}
