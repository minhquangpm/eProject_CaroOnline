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
        private void ReceivePlay(string rc_vi_tri)
        {
            int vi_tri = Convert.ToInt32(rc_vi_tri);
            opponent_btnClick(btnList[vi_tri]);
        }


        private void ReceiveCreateRoom(string check)
        {
            if (check.Equals("true"))
            {
                // set thông tin phòng
                host_id = user_id;

                // mở tab Map
                Invoke(new Action(() =>
                {
                    MapLoad();
                    tabControl.SelectTab(Map);
                }));
            }
        }


        private void ReceiveJoinRoom(string rc_host_id, string rc_player_turn)
        {
            // set thông tin phòng
            join_id = user_id;


            host_id = rc_host_id;

            // set player turn
            player_turn = Convert.ToInt32(rc_player_turn);

            // set turn = 0 (bắt đầu game)
            turn = 0;

            // mở tab Map
            Invoke(new Action(() =>
            {
                MapLoad();
                tabControl.SelectTab(Map);

                da = DateTime.Now;
                timer1.Start();
            }));
        }


        private void ReceiveJoinRoom(string check)
        {
            switch (check)
            {
                case "false":
                    MessageBox.Show("No room match!");
                    break;
                case "full":
                    MessageBox.Show("Room is full!");
                    break;
            }
        }


        private void ReceiveSomeoneJoin(string rc_user_id, string rc_join_id, string rc_player_turn)
        {
            if (rc_user_id.Equals(user_id))
            {
                join_id = rc_join_id;

                // set player turn
                player_turn = Convert.ToInt32(rc_player_turn);
            }
        }


        private void ReceiveOtherQuit(string rc_someone_quit)
        {
            if (rc_someone_quit.Equals("join"))
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
                            host_id = user_id;
                            MapLoad();
                        }));
                        break;
                }
            }
            else if (rc_someone_quit.Equals("host"))
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
                            host_id = user_id;
                            MapLoad();
                        }));
                        break;
                }
            }

        }




    }
}
