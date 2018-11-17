using System;
using System.ComponentModel;
using System.Drawing;
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
        private static string user_id;
        private static string host_id;
        private static string join_id;
        private static string room_no;


        // khai báo worker
        private BackgroundWorker workerListener = null;
        private BackgroundWorker workerWaitForPlayer = null;
        private BackgroundWorker workerChangeTurn = null;
        private BackgroundWorker workerRefreshRoom = null;
        private BackgroundWorker workerRefreshFriend = null;

        private void InitClient()
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

                NetworkStream stream = client.GetStream();

                // đọc dữ liệu nhận về
                string response = string.Empty;
                int bytes = stream.Read(data, 0, data.Length);
                response = Encoding.ASCII.GetString(data, 0, bytes);
                string[] rp = response.Split(':');

                /// <summary>
                /// Xử lý thông tin nhận được từ server.
                /// Giao tiếp giữa server và client thông qua tcp socket.
                /// Client và server giao tiếp với nhau thông qua string.
                /// </summary>
                switch (rp[0])
                {
                    case "play":
                        ReceivePlay(rp[1]);
                        break;
                    case "create":
                        ReceiveCreateRoom(rp[1]);
                        break;
                    case "join":
                        string check = rp[1];
                        switch (check)
                        {
                            case "true":
                                ReceiveJoinRoom(rp[2], rp[3]);
                                break;
                            default:
                                ReceiveJoinRoom(check);
                                break;
                        }
                        break;
                    case "host":
                        ReceiveSomeoneJoin(rp[1], rp[2], rp[3]);
                        break;
                    case "otherquit":
                        ReceiveOtherQuit(rp[1]);
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
                        //đếm giờ
                        da = DateTime.Now;
                        timer1.Start();

                    // hiện tên người chơi vào phòng
                        lblWaiting.Text = "";

                        // hiện tên người chơi vào phòng
                        lblJoin.Text = join_id;

                        // bắt đầu timer
                        da = DateTime.Now;
                        timer1.Start();
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



        private void DoRefreshRoom(object sender, DoWorkEventArgs e)
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
                SendRefreshRoom();


            }
        }


        private async void DoRefreshFriend(object sender, DoWorkEventArgs e)
        {
            await Task.Run(() =>
            {
                CaroAPI.FriendList().GetAwaiter().GetResult();
            });
            while (true)
            {
                // cancel worker nếu có tín hiệu cancel gửi đến
                if (workerRefreshFriend.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                // do something to refresh friendlist here
                //SendRefreshFriend();
            }
        }



    }
}
