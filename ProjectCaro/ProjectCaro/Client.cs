using ProjectCaro.Properties;
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
        //private static string serverIp = "127.0.0.1";
        // real server
        private const string serverIp = "159.89.193.234";
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
                    case "join":
                        string check_join = code[1];
                        if (check_join.Equals("true"))
                        {
                            RecvJoinRoom(code[2], code[3]);
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
                            RecvQuickJoin(code[2], code[3], code[4]);
                        }
                        else if (check_quick_join.Equals("false")) {
                            MessageBox.Show("No public room to join!");
                        }
                        break;
                    case "host":
                        RecvSomeoneJoin(code[1], code[2], code[3]);
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
                        lblHost.BackColor = Color.Green;

                        lblJoin.BackColor = Color.Transparent;
                    }

                    if (user_id.Equals(join_id))
                    {
                        // đổi màu nền tên người chơi
                        lblJoin.BackColor = Color.Green;

                        lblHost.BackColor = Color.Transparent;
                    }

                }
                else if (((player_turn == 1) && (turn % 2 > 0)) ||
                  ((player_turn == 2) && (turn % 2 == 0)))
                {
                    if (user_id.Equals(host_id))
                    {
                        // đổi màu nền tên người chơi
                        lblHost.BackColor = Color.Transparent;

                        lblJoin.BackColor = Color.Red;
                    }

                    if (user_id.Equals(join_id))
                    {
                        // đổi màu nền tên người chơi
                        lblJoin.BackColor = Color.Transparent;

                        lblHost.BackColor = Color.Red;
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

                for (int i = 0; i < server_room; i++)
                {
                    RoomGame room = CaroAPI.getRoom.data[i];
                    if (room.room_key != null)
                    {
                        danhsachphong.Rows[i].Cells[0].Value = Resources.key;
                        danhsachphong.Rows[i].Cells[1].Value = room.room_key;
                    }
                    danhsachphong.Rows[i].Cells[2].Value = room.room_no;
                    danhsachphong.Rows[i].Cells[3].Value = room.roomname;
                    danhsachphong.Rows[i].Cells[4].Value = room.host_id;
                    danhsachphong.Rows[i].Cells[5].Value = room.join_id;
                }

                // quét những phòng đã xóa
                List<int> row_remove_list = new List<int>();

                if (server_room == 0)
                {
                    for (int j = 0; j < client_room; j++)
                    {
                        Invoke(new Action(() =>
                        {
                            danhsachphong.Rows.RemoveAt(j);
                        }));
                    }
                }

                if (server_room < client_room)
                {
                    for (int k = 0; k < client_room; k++)
                    {
                        DataGridViewRow row = danhsachphong.Rows[k];

                        foreach(RoomGame room in CaroAPI.getRoom.data)
                        {
                            if (!row.Cells[2].Value.Equals(room.room_no))
                            {
                                row_remove_list.Add(row.Index);
                                break;
                            }
                        }
                    }
                }

                // xóa những phòng quét được trên danhsachphong
                foreach (int row_remove_index in row_remove_list)
                {
                    Invoke(new Action(() =>
                    {
                        danhsachphong.Rows.RemoveAt(row_remove_index);
                    }));
                }


                // lưu số lượng phòng mới vào biến tạm thời trên client
                client_room = server_room;

                Thread.Sleep(2000);
            }

        }
        #endregion

        private async void DoRefreshFriend(object sender, DoWorkEventArgs e)
        {
            int server_friend = 0;
            int client_friend = 0;

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


                // đếm số friend và nhét vào danhsachban
                server_friend = CaroAPI.getFriendList.data.Count;
                for (int i = 0; i < server_friend; i++)
                {
                    FriendList friend = CaroAPI.getFriendList.data[i];

                    
                    if (server_friend > client_friend)
                    {
                        Invoke(new Action(() =>
                        {
                            danhsachban.Rows.Add();
                        }));
                    }
                    

                    danhsachban.Rows[i].Cells[0].Value = friend.name;
                    
                    if (friend.status == 1)
                    {
                        danhsachban.Rows[i].Cells[1].Value = Resources.online;
                    }
                }

                // quét friend đã xóa
                List<int> row_remove_list = new List<int>();

                if (server_friend == 0)
                {
                    for (int j = 0; j < client_friend; j++)
                    {
                        Invoke(new Action(() =>
                        {
                            danhsachban.Rows.RemoveAt(j);
                        }));
                    }
                }

                if (server_friend < client_friend)
                {
                    for (int k = 0; k < client_friend; k++)
                    {
                        DataGridViewRow row = danhsachban.Rows[k];

                        foreach (FriendList friend in CaroAPI.getFriendList.data)
                        {
                            if (!row.Cells[0].Value.Equals(friend.name))
                            {
                                row_remove_list.Add(row.Index);
                                break;
                            }
                        }
                    }
                }

                // xóa những friend quét được trên danhsachban
                foreach (int row_remove_index in row_remove_list)
                {
                    Invoke(new Action(() =>
                    {
                        danhsachban.Rows.RemoveAt(row_remove_index);
                    }));
                }

                client_friend = server_friend;

                Thread.Sleep(1000);
            }
        }



    }
}
