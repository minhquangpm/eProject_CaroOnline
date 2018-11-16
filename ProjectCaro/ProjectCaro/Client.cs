using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

        // kiểm tra
        public static bool checkLogin = false;
        public static bool checkRegister = false;
        public static bool checkCreateRoom = false;
        public static bool checkJoinRoom = false;


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

            // thêm công việc cho worker
            workerListener.DoWork += DoReceiver;
            workerWaitForPlayer.DoWork += DoWaitForPlayer;
            workerChangeTurn.DoWork += DoChangeTurn;
            workerRefreshRoom.DoWork += DoRefreshRoom;

            // start worker
            workerListener.RunWorkerAsync();
        }



        public static void Play(string user_id, string room_no, int vi_tri)
        {
            string message = "play:" + user_id + ":" + room_no + ":" + vi_tri;
            SendData(message);
        }

        public static void CreateRoom(string user_id)
        {
            Random random = new Random();
            room_no = Convert.ToString(random.Next(1, 10000));
            string message = "create:" + user_id + ":" + room_no;
            SendData(message);
        }

        public static void JoinRoom(string user_id, string room_no)
        {
            string message = "join:" + user_id + ":" + room_no;
            SendData(message);
        }


        public static void QuitRoom(string user_id, string room_no)
        {

        }



        public static void UserOnline(string user_id)
        {
            string message = "online:" + user_id;
            SendData(message);
        }



        private static void RefreshRoom()
        {
            string message = "refreshroom";
            SendData(message);
        }


        private static void SendData(string message)
        {
            // gửi dữ liệu lên server
            // chuyển dữ liệu từ string thành bytes
            byte[] data = Encoding.ASCII.GetBytes(message);

            // tạo 1 stream để để đọc ghi
            NetworkStream stream = client.GetStream();

            // gửi
            stream.Write(data, 0, data.Length);
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
                /// play:user_session:user_id:x:y
                /// login:user_id:user_pass
                /// register:user_id:user_pass
                /// </summary>
                switch (rp[0])
                {
                    case "play":
                        int vi_tri = Convert.ToInt32(rp[1]);

                        opponent_btnClick(btnList[vi_tri]);

                        break;
                    case "login":
                        if (rp[1].Equals("true"))
                        {
                            checkLogin = true;
                        }
                        break;
                    case "register":
                        if (rp[1].Equals("true"))
                        {
                            checkRegister = true;
                        }
                        break;
                    case "create":
                        if (rp[1].Equals("true"))
                        {
                            checkCreateRoom = true;
                        }
                        break;
                    case "join":
                        if (rp[1].Equals("true"))
                        {
                            host_id = rp[2];

                            // set player turn
                            player_turn = Convert.ToInt32(rp[3]);

                            // set turn = 0 (bắt đầu game)
                            turn = 0;

                            checkJoinRoom = true;
                        }
                        else
                        {
                            MessageBox.Show("No room match!");
                        }
                        break;
                    case "host":
                        if (rp[1].Equals(user_id))
                        {
                            join_id = rp[2];

                            // set player turn
                            player_turn = Convert.ToInt32(rp[3]);
                        }
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
                    // xóa dòng "Chờ người chơi"
                    lblWaiting.Text = "";

                    // hiện tên người chơi vào phòng

                    lblJoin.Text = join_id;

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
            }
        }



    }
}
