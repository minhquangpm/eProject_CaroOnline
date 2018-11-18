using System;
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
        private static TcpClient client = new TcpClient(serverIp, serverPort);


        // thông tin user
        public static string user_id;   
        public static string host_id;
        public static string join_id;
        public static string room_no;


        // khai báo worker
        public BackgroundWorker workerListener = null;
        public BackgroundWorker workerWaitForPlayer = null;
        public BackgroundWorker workerChangeTurn = null;
        public BackgroundWorker workerRefreshRoom = null;
        public BackgroundWorker workerRefreshFriend = null;

        public void InitClient()
        {
            // tạo udpclient
            //client = new UdpClient();

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
                catch (IOException ex)
                {
                    MessageBox.Show("Disconnected from server");
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
                    case "create":
                        RecvCreateRoom(code[1]);
                        break;
                    case "join":
                        string check = code[1];
                        if (check.Equals("true"))
                        {
                            RecvJoinRoom(code[2], code[3]);
                        }
                        else if (check.Equals("full"))
                        {
                            MessageBox.Show("Room is full.");
                        }
                        else
                        {
                            MessageBox.Show("No room match!");
                        }
                        break;
                    case "quickjoin":
                        RecvQuickJoin(code[1], code[2], code[3]);
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
            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerWaitForPlayer.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


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
                    }));
                    

                    // set turn = 0 (bắt đầu game)
                    turn = 0;

                    // dừng worker
                    workerWaitForPlayer.CancelAsync();
                }

                Thread.Sleep(100);
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



        private async void DoRefreshRoom(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerRefreshRoom.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                // do something to refresh roomlist here
                await Task.Run(() =>
                {
                    CaroAPI.Room().GetAwaiter().GetResult();
                });

                //Invoke(new Action(() =>
                //{
                //    danhsachphong.Rows.Clear();
                //}));

                foreach (RoomGame room in CaroAPI.getRoom.data)
                {
                    string[] row = { room.room_no, "", room.host_id, room.join_id };
                    Invoke(new Action(() =>
                    {
                        danhsachphong.Rows.Add(row);
                    }));
                    
                }

                Thread.Sleep(5000);
            }

        }


            private async void DoRefreshFriend(object sender, DoWorkEventArgs e)
        {
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


                foreach (FriendList friend in CaroAPI.getFriendList.data)
                {
                    //MessageBox.Show(friend.idUser.ToString() + " " + friend.name + " " + friend.status.ToString());
                }



                Thread.Sleep(1000);
            }
        }



    }
}
