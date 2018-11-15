using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCaro
{
    class TabMap : Form1
    {
        public static Banco bc;
        public static Graphics grs;

        // xac dinh so dong so cot
        private int soDong = 28;
        private int soCot = 22;

        // player turn
        public static int turn = -1;
        public static int player_turn = 0;
        public List<int> KeHuyDiet = new List<int>();

        public TabMap()
        {
            InitializeComponent();
            bc = new Banco(soDong, soCot);
            grs = pnlChess.CreateGraphics();
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
