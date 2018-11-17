using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using ProjectCaro.Properties;

namespace ProjectCaro
{
    partial class Caro
    {
        // xac dinh so dong so cot
        private const int CHESS_WIDTH = 30;
        private const int CHESS_HEIGHT = 30;

        private const int BOARD_HEIGHT = 20;
        private const int BOARD_WIDTH = 20;

        // player turn
        public static int turn = -1;
        public static int player_turn = 0;

        private static List<int> playerX = new List<int>();
        private static List<int> playerO = new List<int>();
        public static List<Button> btnList = new List<Button>();


        //dem gio
        private DateTime da;

        public void MapLoad()
        {
            InitMap();
            DrawChessBoard();

        }


        private void InitMap()
        {
            lblSophong.Text = room_no;
            lblHost.Text = host_id;
            lblJoin.Text = join_id;

            // thực thi nếu người chơi là host
            if (host_id.Equals(user_id))
            {
                lblWaiting.Text = "Chờ người chơi...";

                // chạy thread chờ người chơi join
                if (!workerWaitForPlayer.IsBusy)
                {
                    workerWaitForPlayer.RunWorkerAsync();
                }
            }

            // chạy thread đổi màu tên người chơi khi đến lượt
            if (!workerChangeTurn.IsBusy)
            {
                workerChangeTurn.RunWorkerAsync();
            }
        }


        public void DrawChessBoard()
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    int x = j * CHESS_WIDTH;
                    int y = i * CHESS_HEIGHT;
                    int vi_tri = (x + y * BOARD_WIDTH + CHESS_WIDTH) / CHESS_HEIGHT - 1;

                    Button btn = new Button()
                    {
                        Width = CHESS_WIDTH,
                        Height = CHESS_HEIGHT,
                        Location = new Point(x, y),
                        //Text = Convert.ToString(vi_tri)
                    };

                    btn.Click += btn_Click;

                    btnList.Add(btn);

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
            int vi_tri = (btn.Location.X + btn.Location.Y * BOARD_WIDTH + CHESS_WIDTH) / CHESS_HEIGHT - 1;

            if ((turn % 2 == 0) && (player_turn == 1))
            {
                btn.BackgroundImage = Resources.x;
                playerX.Add(vi_tri);

                SendPlay(user_id, room_no, vi_tri);

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

                SendPlay(user_id, room_no, vi_tri);

                bool win = CheckWin(playerO, vi_tri);
                if (win)
                {
                    MessageBox.Show("Player " + player_turn + " won");
                }

                turn++;
            }
        }



        public static void opponent_btnClick(Button btn)
        {
            // lưu vị trí theo thứ tự 1-> 81 vào List
            int vi_tri = (btn.Location.X + btn.Location.Y * BOARD_WIDTH + CHESS_WIDTH) / CHESS_HEIGHT;

            //SoundPlayer sound = new SoundPlayer(Resources.DanhCoSound);

            if (player_turn == 2)
            {
                btn.BackgroundImage = Resources.x;
                playerX.Add(vi_tri);
                //sound.Play();

                bool win = CheckWin(playerX, vi_tri);
                if (win)
                {
                    MessageBox.Show("Player " + player_turn + " won");
                }

                turn++;
            }
            else if (player_turn == 1)
            {
                btn.BackgroundImage = Resources.o;
                playerO.Add(vi_tri);
                //sound.Play();

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


        private void btnThoatTran_Click(object sender, EventArgs e)
        {
            //  thoát trước khi vào trận sẽ không trừ điểm
            if ((host_id != null) && (join_id == null))
            {
                QuitBeforeMatch();
            }
            // thoát khi đang trong trận sẽ bị trừ điểm
            else if ((host_id != null) && (join_id != null))
            {
                QuitInMatch();
            }
            
        }



        private void QuitBeforeMatch()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Quiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendRemoveRoom(room_no);

                    tabControl.SelectTab(Home);

                    NewGame();
                    break;
                case DialogResult.No:
                    break;
            }
        }



        private void QuitInMatch()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?\n\nIf Yes, your point will be reduced", "Quiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendQuitRoom(user_id, room_no);

                    tabControl.SelectTab(Home);

                    NewGame();
                    break;
                case DialogResult.No:
                    break;
            }
        }



        private void NewGame()
        {
            player_turn = 0;
            turn = -1;

            host_id = null;
            join_id = null;
            room_no = null;

            playerO.Clear();
            playerX.Clear();

            btnList.Clear();

            pnlChess.Controls.Clear();
        }


        private void ReGame()
        {
            player_turn = 0;
            turn = -1;
            host_id = null;
            join_id = null;

            playerO.Clear();
            playerX.Clear();

            btnList.Clear();

            pnlChess.Controls.Clear();
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(da);
            Time.Text = span.Minutes.ToString() + " : " + span.Seconds.ToString();
        }
    }
}
