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
            FriendListInit();
            LoadAvatar();


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
            // custom scrollbar
            danhsachphong.ScrollBars = ScrollBars.None;

            // custom column header
            DataGridViewImageColumn danhsachphong_lock = new DataGridViewImageColumn
            {
                Name = "danhsachphong_lock",
                HeaderText = "Lock",
                Width = 50
            };

            DataGridViewTextBoxColumn danhsachphong_pass = new DataGridViewTextBoxColumn
            {
                Name = "danhsachphong_pass",
                HeaderText = "Pass",
                Width = 50,
                Visible = false
            };

            DataGridViewTextBoxColumn danhsachphong_no = new DataGridViewTextBoxColumn
            {
                Name = "danhsachphong_no",
                HeaderText = "Number",
                Width = 100
            };

            DataGridViewTextBoxColumn danhsachphong_name = new DataGridViewTextBoxColumn
            {
                Name = "danhsachphong_name",
                HeaderText = "Name",
                Width = 169
            };

            DataGridViewTextBoxColumn danhsachphong_host = new DataGridViewTextBoxColumn
            {
                Name = "danhsachphong_host",
                HeaderText = "Host",
                Width = 140
            };

            DataGridViewTextBoxColumn danhsachphong_join = new DataGridViewTextBoxColumn
            {
                Name = "danhsachphong_join",
                HeaderText = "Join",
                Width = 140
            };

            danhsachphong.Columns.Add(danhsachphong_lock);
            danhsachphong.Columns.Add(danhsachphong_pass);
            danhsachphong.Columns.Add(danhsachphong_no);
            danhsachphong.Columns.Add(danhsachphong_name);
            danhsachphong.Columns.Add(danhsachphong_host);
            danhsachphong.Columns.Add(danhsachphong_join);

            for (int i = 0; i < danhsachphong.Columns.Count; i++)
            {
                danhsachphong.Columns[i].HeaderCell.Style.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
                danhsachphong.Columns[i].HeaderCell.Style.BackColor = Color.LightSlateGray;
                danhsachphong.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                danhsachphong.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                danhsachphong.Columns[i].Resizable = DataGridViewTriState.False;
                danhsachphong.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                danhsachphong.Columns[i].DefaultCellStyle.NullValue = null;
                danhsachphong.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            


            for (int i = 0; i < 15; i++)
            {
                danhsachphong.Rows.Add();
                danhsachphong.Rows[i].ReadOnly = true;
            }
        }


        private void FriendListInit()
        {
            danhsachban.ScrollBars = ScrollBars.None;
        }


        private void btnCreatePublic_Click(object sender, EventArgs e)
        {
            SendCreateRoom(user_id);
        }


        private void btnCreatePrivate_Click(object sender, EventArgs e)
        {
            room_key = Interaction.InputBox("Create password: ", "Caro", "", -1, -1);
            if (room_key.Length > 0)
            {
                SendCreateRoom(user_id, room_key);
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


        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            danhsachphong.FirstDisplayedScrollingRowIndex = vScrollBar1.Value;
        }


        private void danhsachphong_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (danhsachphong.RowCount > 6)
            {
                vScrollBar1.Enabled = true;
            }

            vScrollBar1.Maximum = danhsachphong.RowCount + 5;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            danhsachban.FirstDisplayedScrollingRowIndex = vScrollBar2.Value;
        }


        private void danhsachban_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (danhsachban.RowCount > 7)
            {
                vScrollBar2.Enabled = true;
            }

            vScrollBar2.Maximum = danhsachban.RowCount + 3;
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
