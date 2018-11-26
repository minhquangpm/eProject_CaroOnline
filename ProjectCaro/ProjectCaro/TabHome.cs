using Microsoft.VisualBasic;
using ProjectCaro.Properties;
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
            lblUsername.Location = new Point((pnlUserInfo.Width - lblUsername.Width) / 2, 10);

        }

        #region roomlist
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
                    if (row_room_key.Equals("duelyst"))
                    {
                        MessageBox.Show("You can not join a duel like this. Wait for Watch function coming soon!");
                        return;
                    }

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

        #endregion


        #region friendlist
        private void FriendListInit()
        {
            danhsachban.ScrollBars = ScrollBars.None;

            DataGridViewImageColumn danhsachban_arrow = new DataGridViewImageColumn
            {
                Name = "danhsachban_arrow",
                HeaderText = "",
                Width = 30
            };

            DataGridViewTextBoxColumn danhsachban_name = new DataGridViewTextBoxColumn
            {
                Name = "danhsachban_name",
                HeaderText = "Friend",
                Width = 153
            };

            DataGridViewImageColumn danhsachban_status = new DataGridViewImageColumn
            {
                Name = "danhsachban_status",
                HeaderText = "",
                Width = 30
            };

            danhsachban.Columns.Add(danhsachban_arrow);
            danhsachban.Columns.Add(danhsachban_name);
            danhsachban.Columns.Add(danhsachban_status);

            for (int i = 0; i < danhsachban.Columns.Count; i++)
            {
                danhsachban.Columns[i].HeaderCell.Style.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                danhsachban.Columns[i].HeaderCell.Style.BackColor = Color.LightSlateGray;
                danhsachban.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                danhsachban.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                danhsachban.Columns[i].Resizable = DataGridViewTriState.False;
                danhsachban.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                danhsachban.Columns[i].DefaultCellStyle.NullValue = null;
                danhsachban.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                danhsachban.Columns[i].ReadOnly = true;
            }
        }

        /*
         *  load friend info into pnlFriendInfo here
         * 
         */
        private void danhsachban_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataGridView dgv = sender as DataGridView;

            if (dgv.CurrentRow.Selected)
            {
                dgv.CurrentRow.Cells[0].Value = Resources.right_arrow;
                lblFriendName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            }

            danhsachban.Enabled = false;


            if (dgv.CurrentRow.Cells[2].Value == null)
            {
                btnInviteFriend.BackColor = Color.Gray;
                btnInviteFriend.Enabled = false;
            }
            else
            {
                btnInviteFriend.BackColor = Color.LightSalmon;
                btnInviteFriend.Enabled = true;
            }

            pnlFriendInfo.Visible = true;
        }

        private void btnCloseFriendInfo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in danhsachban.Rows)
            {
                string friend_name_in_list = row.Cells[1].Value.ToString();
                if (friend_name_in_list.Equals(lblFriendName.Text))
                {
                    row.Cells[0].Value = Resources.left_arrow;
                    break;
                }
            }


            lblFriendName.Text = "";

            pnlFriendInfo.Visible = false;

            danhsachban.Enabled = true;
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


        private void btnInviteFriend_Click(object sender, EventArgs e)
        {
            SendInviteFriend(user_id, lblFriendName.Text);
            btnCloseFriendInfo.PerformClick();
        }


        private void btnDeleteFriend_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this friend?", "Caro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendRemoveFriend(user_id, lblFriendName.Text);

                    for (int i = 0; i < danhsachban.RowCount; i++)
                    {
                        string friend_name_in_list = danhsachban.Rows[i].Cells[1].Value.ToString();

                        if (friend_name_in_list.Equals(lblFriendName.Text)) {
                            danhsachban.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    pnlFriendInfo.Visible = false;
                    danhsachban.Enabled = true;
                    break;
                case DialogResult.No:

                    break;
            }
        }
        #endregion

        #region invitation
        private void btnAcceptFight_Click(object sender, EventArgs e)
        {
            SendAcceptInvite(user_id);
            pnlInvite.Visible = false;

            danhsachphong.Enabled = true;
            danhsachban.Enabled = true;
            btnCreatePrivate.Enabled = true;
            btnCreatePublic.Enabled = true;
            btnVaoNhanh.Enabled = true;
        }

        private void btnRefuseFight_Click(object sender, EventArgs e)
        {
            SendRefuseInvite(user_id);
            pnlInvite.Visible = false;

            danhsachphong.Enabled = true;
            danhsachban.Enabled = true;
            btnCreatePrivate.Enabled = true;
            btnCreatePublic.Enabled = true;
            btnVaoNhanh.Enabled = true;
        }
        #endregion



        #region chat all
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
        #endregion


        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Caro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendUserOffline(user_id);

                    // reset all fields
                    Logout();

                    // return Login tab
                    tabControl.SelectTab(Login);
                    break;
                case DialogResult.No:
                    break;
            }
        }


        private void Logout()
        {
            txt_Log1.Text = "";
            txt_Log1.Enabled = true;
            txt_Log2.Text = "";
            txt_Log2.Enabled = true;
            btnLogin.Enabled = true;

            user_id = "";

            processBar1.Visible = false;
            processBar1.Value = 0;
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
