using System;
using System.Collections.Generic;
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


        private void RecvCreateRoom(string check)
        {
            if (check.Equals("true"))
            {
                host_id = user_id;

                Invoke(new Action(() =>
                {
                    //mở map
                    MapLoad();
                    tabControl.SelectTab(Map);
                }));
            }
        }



        private void RecvJoinRoom(string recv_host_id, string recv_player_turn)
        {
            host_id = recv_host_id;

            join_id = user_id;

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



        private void RecvPlayerQuit(string recv_who_quit)
        {
            if (recv_who_quit.Equals("join"))
            {
                DialogResult result = MessageBox.Show("User " + join_id + " has quited. Do you want to quit?", "", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        SendRemoveRoom(room_no);

                        Invoke(new Action(() =>
                        {
                            tabControl.SelectTab(Home);
                            NewGame();
                        }));

                        break;
                    case DialogResult.No:
                        Invoke(new Action(() =>
                        {
                            ReGame();
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
                            NewGame();
                        }));

                        break;
                    case DialogResult.No:
                        Invoke(new Action(() =>
                        {
                            ReGame();
                            MapLoad();
                        }));

                        break;
                }
            }
        }

    }
}
