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

            if (!workerRefreshFriend.IsBusy)
            {
                workerRefreshFriend.RunWorkerAsync();
            }


            // căn chỉnh label Username vào giữa panel User Info
            lblUsername.Text = user_id;
            lblUsername.Location = new Point((pnlUserInfo.Width - lblUsername.Width) / 2, 14);

        }


        private void RoomListInit()
        {
            danhsachphong.DefaultCellStyle.NullValue = null;
            danhsachphong.Columns[0].HeaderCell.Style.BackColor = Color.AliceBlue;


            for (int i = 0; i < 15; i++)
            {
                danhsachphong.Rows.Add();
                danhsachphong.Rows[i].ReadOnly = true;
            }
        }
        

        private void btnTao_Click(object sender, EventArgs e)
        {
            room_key = Interaction.InputBox("Create password: ", "Caro", "", -1, -1);

            if (room_key.Length > 0)
            {
                SendCreateRoom(user_id, room_key);
            }
            else if (room_key.Length == 0)
            {
                SendCreateRoom(user_id);
            }
        }


        //private void btnVao_Click(object sender, EventArgs e)
        //{
        //    string input = Interaction.InputBox("Enter room number: ", "Caro", "", -1, -1);
            
        //    if (input.Length > 0)
        //    {
        //        room_no = input;
        //        SendJoinRoom(user_id, room_no);
        //    }
        //}
        


        private void btnVaoNhanh_Click(object sender, EventArgs e)
        {
            SendQuickJoin(user_id);
        }




        // xử lý khi người chơi double click vào phòng
        private void danhsachphong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if ((dgv == null) ||
                (dgv.CurrentRow.Cells[2].Value == null))
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                
                if (dgv.CurrentRow.Cells[1].Value != null)
                {
                    string row_room_key = dgv.CurrentRow.Cells[1].Value.ToString();
                    string input_room_key = Interaction.InputBox("Enter password: ", "Caro", "", -1, -1);
                    if (input_room_key.Length > 0)
                    {
                        if (input_room_key.Equals(row_room_key))
                        {
                            string room_no_selected = dgv.CurrentRow.Cells[2].Value.ToString();
                            room_no = room_no_selected;
                            room_key = input_room_key;
                            SendJoinRoom(user_id, room_no_selected);
                        }
                        else
                        {
                            MessageBox.Show("Wrong password!");
                        }
                    }
                        
                }
                else
                {
                    string room_no_selected = dgv.CurrentRow.Cells[2].Value.ToString();
                    room_no = room_no_selected;
                    room_key = "";
                    SendJoinRoom(user_id, room_no_selected);
                }
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


        private void btnCloseForm2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizeForm2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
