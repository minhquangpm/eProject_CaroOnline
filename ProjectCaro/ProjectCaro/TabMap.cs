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
        private static int turn = -1;
        private static int player_turn = 0;

        // thông tin user
        private static string user_id;
        private static string host_id;
        private static string join_id;
        private static string room_no;
        private static string room_key;

        private static List<int> playerX = new List<int>();
        private static List<int> playerO = new List<int>();
        private static List<int> winChessList = new List<int>();
        private static List<Button> btnList = new List<Button>();

        private DateTime da;

        public void MapLoad()
        {
            InitRoom();
            DrawChessBoard();
        }


        private void InitRoom()
        {
            // hiển thị thông tin phòng
            lblSophong.Text = room_no;
            lblKey.Text = room_key;
            lblHost.Text = host_id;
            lblJoin.Text = join_id;



            // thực thi nếu người chơi là host
            if (host_id.Equals(user_id))
            {
                lblWaiting.Text = "Wait for player...";

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

                SendPlay(user_id, room_no, vi_tri);

                Play(playerX, vi_tri, 1);
            }
            else if ((turn % 2 > 0) && (player_turn == 2))
            {
                btn.BackgroundImage = Resources.o;

                SendPlay(user_id, room_no, vi_tri);

                Play(playerO, vi_tri, 2);
            }
        }



        public void opponent_btnClick(Button btn)
        {
            // lưu vị trí theo thứ tự 1-> 81 vào List
            int vi_tri = (btn.Location.X + btn.Location.Y * BOARD_WIDTH + CHESS_WIDTH) / CHESS_HEIGHT - 1;

            //SoundPlayer sound = new SoundPlayer(Resources.DanhCoSound);

            if (player_turn == 2)
            {
                btn.BackgroundImage = Resources.x;
                Play(playerX, vi_tri, 1);
            }
            else if (player_turn == 1)
            {
                btn.BackgroundImage = Resources.o;
                Play(playerO, vi_tri, 2);
            }
        }


        private void Play(List<int> player, int vi_tri, int play_turn)
        {
            player.Add(vi_tri);

            int win = CheckWin(player, vi_tri);
            if (win > 0)
            {
                DrawBtnWin(win, play_turn);
                if (play_turn == player_turn)
                {
                    SendWin(user_id, room_no);
                    WonGame();
                }
                else
                {
                    LostGame();
                }
            }

            bool draw = CheckDraw();
            if (draw)
            {

            }

            turn++;
        }


        // check thắng
        private static int CheckWin(List<int> checkPlayer, int vi_tri)
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
                    winChessList.Add(vi_tri + i);
                    winChessList.Add(vi_tri + i + 1);
                    winChessList.Add(vi_tri + i + 2);
                    winChessList.Add(vi_tri + i + 3);
                    winChessList.Add(vi_tri + i + 4);
                    return 1;
                }

                // check hàng chéo phải sang trái
                if (checkPlayer.Contains(vi_tri + i * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (BOARD_WIDTH - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (BOARD_WIDTH - 1)))
                {
                    winChessList.Add(vi_tri + i * (BOARD_WIDTH - 1));
                    winChessList.Add(vi_tri + (i + 1) * (BOARD_WIDTH - 1));
                    winChessList.Add(vi_tri + (i + 2) * (BOARD_WIDTH - 1));
                    winChessList.Add(vi_tri + (i + 3) * (BOARD_WIDTH - 1));
                    winChessList.Add(vi_tri + (i + 4) * (BOARD_WIDTH - 1));
                    return 2;
                }

                // check hàng dọc
                if (checkPlayer.Contains(vi_tri + i * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 1) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 2) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 3) * BOARD_WIDTH) &&
                checkPlayer.Contains(vi_tri + (i + 4) * BOARD_WIDTH))
                {
                    winChessList.Add(vi_tri + i * BOARD_WIDTH);
                    winChessList.Add(vi_tri + (i + 1) * BOARD_WIDTH);
                    winChessList.Add(vi_tri + (i + 2) * BOARD_WIDTH);
                    winChessList.Add(vi_tri + (i + 3) * BOARD_WIDTH);
                    winChessList.Add(vi_tri + (i + 4) * BOARD_WIDTH);
                    return 3;
                }

                // check hàng chéo trái sang phải
                if (checkPlayer.Contains(vi_tri + i * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (BOARD_WIDTH + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (BOARD_WIDTH + 1)))
                {
                    winChessList.Add(vi_tri + i * (BOARD_WIDTH + 1));
                    winChessList.Add(vi_tri + (i + 1) * (BOARD_WIDTH + 1));
                    winChessList.Add(vi_tri + (i + 2) * (BOARD_WIDTH + 1));
                    winChessList.Add(vi_tri + (i + 3) * (BOARD_WIDTH + 1));
                    winChessList.Add(vi_tri + (i + 4) * (BOARD_WIDTH + 1));
                    return 4;
                }
            }

            return 0;
        }


        private bool CheckDraw()
        {
            int chessPlayedCount = playerO.Count + playerX.Count;
            int chessBoardCount = BOARD_WIDTH * BOARD_HEIGHT;
            if (chessPlayedCount == chessBoardCount) {
                return true;
            }
            return false;
        }


        private void DrawBtnWin(int win_status, int player_turn)
        {
            Bitmap draw = null;

            if (win_status == 1 && player_turn == 1)
            {
                draw = Resources.x_over;
            }
            else if (win_status == 2 && player_turn == 1)
            {
                draw = Resources.x_slash;
            }
            else if (win_status == 3 && player_turn == 1)
            {
                draw = Resources.x_cut;
            }
            else if (win_status == 4 && player_turn == 1)
            {
                draw = Resources.x_slash1;
            }
            else if (win_status == 1 && player_turn == 2)
            {
                draw = Resources.o_over;
            }
            else if (win_status == 2 && player_turn == 2) 
            {
                draw = Resources.o_slash;
            }
            else if (win_status == 3 && player_turn == 2)
            {
                draw = Resources.o_cut;
            }
            else if (win_status == 4 && player_turn ==2)
            {
                draw = Resources.o_slash1;
            }
 

            foreach (int index in winChessList)
            {
                btnList[index].BackgroundImage = draw;
            }
            winChessList.Clear();
        }



        private void WonGame()
        {
            // show  YOU WON
            lblGameStatus.Text = "YOU WON";
            lblGameStatus.ForeColor = Color.Gold;
            lblGameStatus.Visible = true;

            // enable replay btn
            btnReplay.Enabled = true;

            // không cho người chơi đánh tiếp
            pnlChess.Enabled = false;
        }


        private void LostGame()
        {
            Invoke(new Action(() =>
            {
                // show YOU LOST from other thread
                lblGameStatus.Text = "YOU LOST";
                lblGameStatus.ForeColor = Color.Red;
                lblGameStatus.Visible = true;

                // enable replay btn
                btnReplay.Enabled = true;

                // không cho người chơi đánh tiếp
                pnlChess.Enabled = false;
            }));
        }


        private void QuitBeforeMatch()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Caro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendRemoveRoom(room_no);

                    tabControl.SelectTab(Home);

                    NewGame("newroom");
                    break;
                case DialogResult.No:
                    break;
            }
        }



        private void QuitInMatch()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?\n\nIf Yes, your point will be reduced", "Caro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendQuitRoom(user_id, room_no);

                    tabControl.SelectTab(Home);

                    NewGame("newroom");
                    break;
                case DialogResult.No:
                    break;
            }
        }


        private void QuitFinishMatch()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Caro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SendQuitRoom(user_id, room_no);

                    tabControl.SelectTab(Home);

                    NewGame("newroom");
                    break;
                case DialogResult.No:
                    break;
            }
        }



        private void NewGame(string check)
        {
            switch(check)
            {
                case "newroom":
                    player_turn = 0;
                    turn = -1;

                    host_id = null;
                    join_id = null;
                    room_no = null;
                    room_key = null;

                    break;
                case "refreshroom":
                    player_turn = 0;
                    turn = -1;

                    host_id = user_id;
                    join_id = null;

                    break;
                case "playagain":
                    // đổi player turn
                    if (player_turn == 1)
                    {
                        player_turn = 2;
                    }
                    else if (player_turn == 2)
                    {
                        player_turn = 1;
                    }

                    turn = 0;
                    break;
            }

            pnlHost.BackColor = Color.Transparent;
            pnlJoin.BackColor = Color.Transparent;
            lblGameStatus.Visible = false;

            btnAddHost.Text = "Add";
            btnAddHost.Enabled = true;
            btnAddHost.Visible = false;
            btnAddJoin.Text = "Add";
            btnAddJoin.Enabled = true;
            btnAddJoin.Visible = false;

            listboxchat2.Items.Clear();

            btnReplay.Enabled = false;
            pnlChess.Enabled = true;

            playerO.Clear();
            playerX.Clear();

            btnList.Clear();

            pnlChess.Controls.Clear();
        }


        private void btnChat2_Click(object sender, EventArgs e)
        {
            if (txtChat2.Text.Length > 0)
            {
                SendChat(user_id, room_no, txtChat2.Text);
                txtChat2.Text = "";
            }
        }



        private void txtChat2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChat2.PerformClick();
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(da);
            Time.Text = span.Minutes.ToString() + " : " + span.Seconds.ToString();
        }



        private void btnMinimizeForm3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCloseForm3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnReplay_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJoin_Click(object sender, EventArgs e)
        {
            SendAddFriend(user_id, join_id);
        }

        private void btnAddHost_Click(object sender, EventArgs e)
        {
            SendAddFriend(user_id, host_id);
        }


        private void btnThoatTran_Click(object sender, EventArgs e)
        {
            LoadInfo();
            //  thoát trước khi vào trận sẽ không trừ điểm
            if ((host_id != null) && (join_id == null))
            {
                QuitBeforeMatch();
            }
            // thoát khi đang trong trận sẽ bị trừ điểm
            else if ((host_id != null) && (join_id != null))
            {
                if (!lblGameStatus.Visible)
                {
                    QuitInMatch();
                }
                else
                {
                    QuitFinishMatch();
                }
            }

        }

    }
}
