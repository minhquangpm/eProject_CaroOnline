﻿using ProjectCaro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro
    {
        // khai báo thông tin server
        //debug
        private static string serverIp = "127.0.0.1";
        // real server
        //private const string serverIp = "159.89.193.234";
        private const int serverPort = 12345;

        // tạo endpoint(điểm cuối giao tiếp) gồm ip và port của server
        //private static IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
        private static TcpClient client = null;


        // khai báo worker
        public BackgroundWorker workerListener = null;
        public BackgroundWorker workerWaitForPlayer = null;
        public BackgroundWorker workerChangeTurn = null;
        public BackgroundWorker workerRefreshRoom = null;
        public BackgroundWorker workerRefreshFriend = null;

        public void InitClient()
        {
            // tạo udpclient
            try
            {
                client = new TcpClient(serverIp, serverPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to connect to server!");
            }

            // cho phép cancel worker
            workerListener = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            workerWaitForPlayer = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            workerChangeTurn = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            workerRefreshRoom = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            workerRefreshFriend = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            // thêm công việc cho worker
            workerListener.DoWork += DoReceiver;
            workerWaitForPlayer.DoWork += DoWaitForPlayer;
            workerChangeTurn.DoWork += DoChangeTurn;
            workerRefreshRoom.DoWork += DoRefreshRoom;
            workerRefreshFriend.DoWork += DoRefreshFriend;

            // start worker
            workerListener.RunWorkerAsync();
        }


        private void DoReceiver(object sender, DoWorkEventArgs e)
        {
            NetworkStream stream = null;

            int bytes = 0;

            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerListener.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                // nhận dữ liệu từ server
                // tạo buffer lưu trữ dữ liệu nhận đc
                byte[] data = new byte[256];


                try
                {
                    stream = client.GetStream();

                    // đọc dữ liệu nhận về
                    bytes = stream.Read(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Disconnected from server", "Caro");
                    tabControl.SelectTab(Login);

                    // cancel listener
                    workerListener.CancelAsync();
                    return;
                }
                

                string response = string.Empty;

                response = Encoding.ASCII.GetString(data, 0, bytes);
                string[] code = response.Split(':');

                /// <summary>
                /// play:user_session:user_id:x:y
                /// login:user_id:user_pass
                /// register:user_id:user_pass
                /// </summary>
                switch (code[0])
                {
                    case "play":
                        RecvPlay(code[1]);
                        break;
                    case "chat":
                        RecvChat(code[1], code[2]);
                        break;
                    case "chatall":
                        RecvChatAll(code[1], code[2]);
                        break;
                    case "create":
                        RecvCreateRoom(code[1]);
                        break;
                    case "addfriend":
                        RecvAddFriend(code[1], code[2]);
                        break;
                    case "removefriend":
                        MessageBox.Show("Friend deleted");
                        break;
                    case "join":
                        string check_join = code[1];
                        if (check_join.Equals("true"))
                        {
                            RecvJoinRoom(code[2], code[3], code[4], code[5]);
                        }
                        else if (check_join.Equals("full"))
                        {
                            MessageBox.Show("Room is full.", "Caro");
                        }
                        else
                        {
                            MessageBox.Show("No room match!", "Caro");
                        }
                        break;
                    case "quickjoin":
                        string check_quick_join = code[1];
                        if (check_quick_join.Equals("true")) {
                            RecvQuickJoin(code[2], code[3], code[4], code[5]);
                        }
                        else if (check_quick_join.Equals("false")) {
                            MessageBox.Show("No public room to join!");
                        }
                        break;
                    case "host":
                        RecvSomeoneJoin(code[1], code[2], code[3], code[4]);
                        break;
                    case "youhostduel":
                        string check_duel = code[1];
                        if (check_duel.Equals("true"))
                        {
                            RecvCreateRoom(code[2]);
                        }
                        else if (check_duel.Equals("busy"))
                        {
                            MessageBox.Show("Friend is busy");
                        }
                        else if (check_duel.Equals("false"))
                        {
                            RecvRefuseInvite(code[2]);
                        }
                        break;
                    case "invitetoduel":
                        RecvInviteToDuel(code[1]);
                        break;
                    case "otherquit":
                        RecvPlayerQuit(code[1]);
                        break;
                }
            }
        }




        private void DoWaitForPlayer(object sender, DoWorkEventArgs e)
        {
            int count = 0;

            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerWaitForPlayer.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                // make color: đổi màu lblwaiting khi đợi người chơi join
                List<Color> color_list = new List<Color>();
                color_list.Add(Color.DarkGreen);
                color_list.Add(Color.DarkKhaki);
                color_list.Add(Color.DarkMagenta);
                color_list.Add(Color.DarkOrange);
                color_list.Add(Color.DarkRed);
                color_list.Add(Color.DarkSalmon);

                int i = count % 5;

                try
                {
                    Invoke(new Action(() => {
                        lblWaiting.ForeColor = color_list[i];
                    }));
                }
                catch (Exception ex)
                {
                    
                }


                // xử lý thông tin khi người chơi vào phòng
                if (join_id != null)
                {
                    Invoke(new Action(() => {
                        // xóa dòng "Chờ người chơi"
                        lblWaiting.Text = "";

                        // start timer
                        da = DateTime.Now;
                        timer1.Start();

                        // hiện tên người chơi vào phòng
                        lblJoin.Text = join_id;

                        // cho phép chat
                        txtChat2.Enabled = true;
                    }));


                    // check đối thủ có trong friend list
                    bool check_friend = false;
                    foreach (FriendList friend in CaroAPI.getFriendList.data)
                    {
                        if (friend.name.Equals(join_id))
                        {
                            check_friend = true;
                        }
                    }
                    if (!check_friend)
                    {
                        Invoke(new Action(() =>
                        {
                            btnAddJoin.Visible = true;
                        }));
                    }


                    // set turn = 0 (bắt đầu game)
                    turn = 0;

                    // dừng worker
                    workerWaitForPlayer.CancelAsync();
                }

                count++;

                Thread.Sleep(300);
            }
        }




        private void DoChangeTurn(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerChangeTurn.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (((player_turn == 1) && (turn % 2 == 0)) ||
                    ((player_turn == 2) && (turn % 2 > 0)))
                {
                    if (user_id.Equals(host_id))
                    {
                        // đổi màu nền tên người chơi
                        pnlHost.BackColor = Color.LightSeaGreen;

                        pnlJoin.BackColor = Color.Transparent;
                    }

                    if (user_id.Equals(join_id))
                    {
                        // đổi màu nền tên người chơi
                        pnlJoin.BackColor = Color.LightSeaGreen;

                        pnlHost.BackColor = Color.Transparent;
                    }

                }
                else if (((player_turn == 1) && (turn % 2 > 0)) ||
                  ((player_turn == 2) && (turn % 2 == 0)))
                {
                    if (user_id.Equals(host_id))
                    {
                        // đổi màu nền tên người chơi
                        pnlHost.BackColor = Color.Transparent;

                        pnlJoin.BackColor = Color.Red;
                    }

                    if (user_id.Equals(join_id))
                    {
                        // đổi màu nền tên người chơi
                        pnlJoin.BackColor = Color.Transparent;

                        pnlHost.BackColor = Color.Red;
                    }
                }

                // chạy kiểm tra mỗi 0.1s
                Thread.Sleep(100);
            }
        }


        #region refresh_room
        private async void DoRefreshRoom(object sender, DoWorkEventArgs e)
        {
            int server_room = 0;
            int client_room = 0;

            List<string> oldRoom_no = new List<string>();

            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerRefreshRoom.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                // lấy danh sách phòng trên server
                await Task.Run(() =>
                {
                    CaroAPI.Room().GetAwaiter().GetResult();
                });


                // đếm số phòng nhận được từ server và nhét vào danhsachphong
                server_room = CaroAPI.getRoom.data.Count;


                // quét và xóa những phòng đã thoát

                if (server_room == 0)
                {
                    for (int i = 0; i < client_room; i++)
                    {
                        Invoke(new Action(() =>
                        {
                            danhsachphong.Rows[i].Cells[0].Value = null;
                            danhsachphong.Rows[i].Cells[1].Value = null;
                            danhsachphong.Rows[i].Cells[2].Value = null;
                            danhsachphong.Rows[i].Cells[3].Value = null;
                            danhsachphong.Rows[i].Cells[4].Value = null;
                            danhsachphong.Rows[i].Cells[5].Value = null;
                        }));
                    }
                }

                if (server_room < client_room && server_room != 0)
                {
                    for (int i = 0; i < client_room; i++)
                    {
                        DataGridViewRow row = danhsachphong.Rows[i];

                        foreach(string roomold in oldRoom_no)
                        {
                            if (!row.Cells[2].Value.Equals(roomold))
                            {
                                Invoke(new Action(() =>
                                {
                                    danhsachphong.Rows[row.Index].Cells[0].Value = null;
                                    danhsachphong.Rows[row.Index].Cells[1].Value = null;
                                    danhsachphong.Rows[row.Index].Cells[2].Value = null;
                                    danhsachphong.Rows[row.Index].Cells[3].Value = null;
                                    danhsachphong.Rows[row.Index].Cells[4].Value = null;
                                    danhsachphong.Rows[row.Index].Cells[5].Value = null;
                                }));

                                break;
                            }
                            
                        }
                    }
                    oldRoom_no.Clear();
                }


                // lưu số lượng phòng mới vào biến tạm thời trên client
                client_room = server_room;
                

                for (int i = 0; i < server_room; i++)
                {
                    RoomGame room = CaroAPI.getRoom.data[i];
                    
                    if (room.room_key != null)
                    {
                        if (room.room_key.Equals("duelyst"))
                        {
                            danhsachphong.Rows[i].Cells[0].Value = Resources.duel;
                            danhsachphong.Rows[i].Cells[1].Value = room.room_key;
                        }
                        else
                        {
                            danhsachphong.Rows[i].Cells[0].Value = Resources.key;
                            danhsachphong.Rows[i].Cells[1].Value = room.room_key;
                        }
                    }
                    danhsachphong.Rows[i].Cells[2].Value = room.room_no;
                    danhsachphong.Rows[i].Cells[3].Value = room.roomname;
                    danhsachphong.Rows[i].Cells[4].Value = room.host_id;
                    danhsachphong.Rows[i].Cells[5].Value = room.join_id;
                    oldRoom_no.Add(room.room_no);
                }
                Thread.Sleep(3000);
            }

        }
        #endregion

        private async void DoRefreshFriend(object sender, DoWorkEventArgs e)
        {
            int server_friend = 0;
            int client_friend = 0;

            //List<string> oldFriend_name = new List<string>();

            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerRefreshFriend.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                // do something to refresh friendlist here
                await Task.Run(() =>
                {
                    CaroAPI.FriendList().GetAwaiter().GetResult();
                });


                // đếm số friend
                server_friend = CaroAPI.getFriendList.data.Count;

                // nhét friend nhận đc từ server vào danh sách bạn
                if (server_friend > client_friend)
                {
                    for (int i = 0; i < (server_friend - client_friend); i++)
                    {
                        Invoke(new Action(() =>
                        {
                            danhsachban.Rows.Add();
                        }));
                    }
                }

                for (int i = 0; i < server_friend; i++)
                {
                    FriendList friend = CaroAPI.getFriendList.data[i];

                    if (danhsachban.Rows[i].Cells[0].Value == null)
                    {
                        danhsachban.Rows[i].Cells[0].Value = Resources.left_arrow;
                    }
                    
                    danhsachban.Rows[i].Cells[1].Value = friend.name;

                    if (friend.status == 1)
                    {
                        danhsachban.Rows[i].Cells[2].Value = Resources.online;
                    }
                    else
                    {
                        danhsachban.Rows[i].Cells[2].Value = null;
                    }

                    danhsachban.Rows[i].Cells[3].Value = friend.user.avatar;
                    danhsachban.Rows[i].Cells[4].Value = Convert.ToString(friend.thongke.win);
                    danhsachban.Rows[i].Cells[5].Value = Convert.ToString(friend.thongke.draw);
                    danhsachban.Rows[i].Cells[6].Value = Convert.ToString(friend.thongke.lose);

                    //oldFriend_name.Add(friend.name);
                }


                client_friend = server_friend;

                Thread.Sleep(10000);
            }
        }
    }
}
