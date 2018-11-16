using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using ProjectCaro.Properties;

namespace ProjectCaro
{
    partial class Form1
    {
        // xac dinh so dong so cot
        private const int CHESS_WIDTH = 24;
        private const int CHESS_HEIGHT = 24;

        private const int BOARD_HEIGHT = 20;
        private const int BOARD_WIDTH = 20;

        // player turn
        public static int turn = -1;
        public static int player_turn = 0;

        private static List<int> playerX = new List<int>();
        private static List<int> playerO = new List<int>();

        //dem gio
        public void map_Load()
        {
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



        public void DrawChessBoard()
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = CHESS_WIDTH,
                        Height = CHESS_HEIGHT,
                        Location = new Point(i * CHESS_WIDTH, j * CHESS_HEIGHT)
                    };

                    btn.Click += btn_Click;

                    pnlChess.Controls.Add(btn);
                }
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
            {
                return;
            }
            

            // lưu vị trí theo thứ tự 1-> 81 vào List
            int vi_tri = (btn.Location.X + btn.Location.Y * BOARD_WIDTH + CHESS_WIDTH) / CHESS_HEIGHT;

            if ((turn % 2 == 0) && (player_turn == 1))
            {
                btn.BackgroundImage = Resources.x;
                playerX.Add(vi_tri);

                bool win = CheckWin(playerX, vi_tri);
                if (win)
                {
                    MessageBox.Show("Player " + player_turn + " won");
                }

                turn++;
            }
            else if ((turn % 2 > 0) && (player_turn == 2))
            {
                btn.BackgroundImage = Resources.o;
                playerO.Add(vi_tri);

                bool win = CheckWin(playerO, vi_tri);
                if (win)
                {
                    MessageBox.Show("Player " + player_turn + " won");
                }

                turn++;
            }
        }


        // check thắng
        public static bool CheckWin(List<int> checkPlayer, int vi_tri)
        {
            for (int i = -4; i < 1; i++)
            {
                // check hàng checkPlayer
                if (checkPlayer.Contains(vi_tri + i) &&
                checkPlayer.Contains(vi_tri + i + 1) &&
                checkPlayer.Contains(vi_tri + i + 2) &&
                checkPlayer.Contains(vi_tri + i + 3) &&
                checkPlayer.Contains(vi_tri + i + 4))
                {
                    return true;
                }

                // check hàng chéo phải sang trái
                if (checkPlayer.Contains(vi_tri + i * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (BOARD_WIDTH - 1)))
                {
                    return true;
                }

                // check hàng dọc
                if (checkPlayer.Contains(vi_tri + i * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 1) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 2) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 3) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 4) * BOARD_WIDTH))
                {
                    return true;
                }

                // check hàng chéo trái sang phải
                if (checkPlayer.Contains(vi_tri + i * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (BOARD_WIDTH + 1)))
                {
                    return true;
                }
            }

            return false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(da);
            Time.Text = span.Minutes.ToString() + " : " + span.Seconds.ToString();
        }
    }
}
