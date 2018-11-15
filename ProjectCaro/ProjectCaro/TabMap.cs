using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Form1
    {
        //public static Banco bc;
        //public static Graphics grs;

        // xac dinh so dong so cot
        private int soDong = 28;
        private int soCot = 22;

        // player turn
        public static int turn = -1;
        public static int player_turn = 0;
        public List<int> KeHuyDiet = new List<int>();

        //public Form1()
        //{
        //    bc = new Banco(soDong, soCot);
        //    grs = pnlChess.CreateGraphics();
        //}

        public void LoadMap()
        {
            //loadmap
            lblSophong.Text = Client.room_no;
            lblHost.Text = Client.host_id;
            lblJoin.Text = Client.join_id;

            // thực thi nếu người chơi là host
            if (Client.host_id.Equals(Client.user_id))
            {
                label7.Text = "Chờ người chơi...";

                // chạy thread chờ người chơi join
                if (!Client.workerWaitForPlayer.IsBusy)
                {
                    Client.workerWaitForPlayer.RunWorkerAsync();
                }
            }

            // chạy thread đổi màu tên người chơi khi đến lượt
            if (!Client.workerChangeTurn.IsBusy)
            {
                Client.workerChangeTurn.RunWorkerAsync();
            }
        }


        public void Danhco(object sender, MouseEventArgs e)
        {
            // Debug
            if ((turn % 2 == 0) && (player_turn == 1)) //if turn is even
            {
                // hiển thị nước đánh
                Point point = e.Location;
                int vi_tri = Banco.DanhCo(point.X, point.Y, player_turn, grs);

                // kiểm tra win
                if (vi_tri != 0)
                {
                    // gửi thông tin cho người chơi còn lại biết mày vừa đánh ở đâu
                    Client.Play(Client.user_id, Client.room_no, point.X, point.Y);

                    bool win = Banco.CheckWin(player_turn, vi_tri);
                    KeHuyDiet.Add(vi_tri);
                    turn++;

                    if (win)
                    {
                        // hiển thị nếu mày là người chiến thắng
                        MessageBox.Show("Win", "Caro", MessageBoxButtons.OK);
                    }
                }
            }
            else if ((turn % 2 != 0) && (player_turn == 2))
            {
                Point point = e.Location;
                int vi_tri = Banco.DanhCo(point.X, point.Y, player_turn, grs);

                if (vi_tri != 0)
                {
                    // gửi thông tin cho người chơi còn lại biết mày vừa đánh ở đâu
                    Client.Play(Client.user_id, Client.room_no, point.X, point.Y);

                    bool win = Banco.CheckWin(player_turn, vi_tri);
                    KeHuyDiet.Add(vi_tri);
                    turn++;

                    if (win)
                    {
                        // hiển thị nếu người chiến thắng
                        MessageBox.Show("wwin");
                    }
                }
            }
        }

        internal void Danhco()
        {
            throw new NotImplementedException();
        }
    }
}
