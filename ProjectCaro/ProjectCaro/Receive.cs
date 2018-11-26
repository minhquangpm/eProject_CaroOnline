using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro
    {
        private void RecvPlay(string recv_vi_tri)
        {
            int vi_tri = Convert.ToInt32(recv_vi_tri);

            opponent_btnClick(btnList[vi_tri]);
        }


        private void RecvCreateRoom(string recv_room_no)
        {
            host_id = user_id;
            room_no = recv_room_no;

            Invoke(new Action(() =>
            {
                txtChat2.Enabled = false;

                //mở map
                MapLoad();
                tabControl.SelectTab(Map);
            }));
        }



        private void RecvJoinRoom(string recv_host_id, string recv_room_no, string recv_player_turn)
        {
            host_id = recv_host_id;

            join_id = user_id;

            room_no = recv_room_no;

            // set player turn
            player_turn = Convert.ToInt32(recv_player_turn);

            // set turn = 0 (bắt đầu game)
            turn = 0;

            // check đối thủ có trong friend list
            bool check_friend = false;
            foreach (FriendList friend in CaroAPI.getFriendList.data)
            {
                if (friend.name.Equals(host_id))
                {
                    check_friend = true;
                }
            }
            if (!check_friend)
            {
                Invoke(new Action(() =>
                {
                    btnAddHost.Visible = true;
                }));
            }


            Invoke(new Action(() =>
            {
                //mở map
                MapLoad();
                tabControl.SelectTab(Map);
                lblWaiting.Visible = false;

                // start timer
                da = DateTime.Now;
                timer1.Start();
            }));
        }


        private void RecvQuickJoin(string recv_host_id, string recv_room_no, string recv_player_turn)
        {
            host_id = recv_host_id;

            join_id = user_id;

            room_no = recv_room_no;

            // set player turn
            player_turn = Convert.ToInt32(recv_player_turn);

            // set turn = 0 (bắt đầu game)
            turn = 0;

            Invoke(new Action(() =>
            {
                //mở map
                MapLoad();
                tabControl.SelectTab(Map);
                lblWaiting.Visible = false;

                // start timer
                da = DateTime.Now;
                timer1.Start();
            }));
        }



        private void RecvSomeoneJoin(string recv_user_id, string recv_join_id, string recv_player_turn)
        {
            if (recv_user_id.Equals(user_id))
            {
                join_id = recv_join_id;

                // set player turn
                player_turn = Convert.ToInt32(recv_player_turn);
            }
        }


        private void RecvInviteToDuel(string recv_host_id)
        {
            Invoke(new Action(() =>
            {
                lblInviteName.Text = recv_host_id;
                lblInviteName.Location = new Point((pnlInvite.Width - lblInviteName.Width) / 2, 10);

                //pnlHome.Enabled = false;
                danhsachphong.Enabled = false;
                danhsachban.Enabled = false;
                btnCreatePrivate.Enabled = false;
                btnCreatePublic.Enabled = false;
                btnVaoNhanh.Enabled = false;

                pnlInvite.Visible = true;
            }));
            

           
        }


        private void RecvRefuseInvite(string refuse_id)
        {
            DialogResult result = MessageBox.Show("User " + refuse_id + " chose being a loser.", "", MessageBoxButtons.OK);
            switch (result)
            {
                case DialogResult.OK:
                    SendRemoveRoom(room_no);

                    Invoke(new Action(() =>
                    {
                        tabControl.SelectTab(Home);
                        NewGame("newroom");
                    }));

                    break;
            }
        }




        private void RecvPlayerQuit(string recv_who_quit)
        {
            if (recv_who_quit.Equals("join"))
            {
                DialogResult result = MessageBox.Show("User " + join_id + " has quited. Do you want to quit?", "Caro", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        SendRemoveRoom(room_no);

                        Invoke(new Action(() =>
                        {
                            tabControl.SelectTab(Home);
                            NewGame("newroom");
                        }));

                        break;
                    case DialogResult.No:
                        Invoke(new Action(() =>
                        {
                            NewGame("refreshroom");
                            MapLoad();
                        }));
                        break;
                }
            }
            else if (recv_who_quit.Equals("host"))
            {
                DialogResult result = MessageBox.Show("User " + host_id + " has quited. Do you want to quit?", "", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        SendRemoveRoom(room_no);

                        Invoke(new Action(() =>
                        {
                            tabControl.SelectTab(Home);
                            NewGame("newroom");
                        }));

                        break;
                    case DialogResult.No:
                        Invoke(new Action(() =>
                        {
                            NewGame("refreshroom");
                            MapLoad();
                        }));

                        break;
                }
            }
        }


        private void RecvChatAll(string chat_id, string chat_message)
        {
            string message = chat_id + ": " + chat_message;

            Invoke(new Action(() =>
            {
                listboxchat.Items.Add(message);
            }));
        }


        private void RecvChat(string chat_id, string chat_message)
        {
            string message = chat_id + ": " + chat_message;

            Invoke(new Action(() =>
            {
                listboxchat2.Items.Add(message);
            }));
        }


        private void RecvAddFriend(string check, string friend_id)
        {
            if (check.Equals("true"))
            {
                if (friend_id.Equals(host_id))
                {
                    Invoke(new Action(() =>
                    {
                        btnAddHost.Text = "Added";
                        btnAddHost.Enabled = false;
                    }));
                }
                else if (friend_id.Equals(join_id))
                {
                    Invoke(new Action(() =>
                    {
                        btnAddJoin.Text = "Added";
                        btnAddJoin.Enabled = false;
                    }));
                }
                else
                {

                }
            }
        }

    }
}
