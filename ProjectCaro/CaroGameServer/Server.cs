using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CaroGameServer
{
    class Server
    {
        // mở port listen
        private const int serverPort = 12345;
        //private static UdpClient server = new UdpClient(serverPort);
        private static TcpListener server = new TcpListener(IPAddress.Any, serverPort);



        public static void SendData(string message, TcpClient client)
        {
            try
            {
                // gửi response về client
                byte[] data = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Send: " + message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("socket has been shutdown");
            }
                
        }




        public static void Listener()
        {
            int counter = 0;
            Server sv = new Server();

            // reset database
            DataBase.ClearRoom();
            DataBase.ResetUser();

            server.Start();

            while (true)
            {
                counter++;

                // xử lý data gửi từ client
                TcpClient client = server.AcceptTcpClient();

                Thread userThread = new Thread(new ThreadStart(() => sv.User(client)));
                userThread.Start();
            }
        }


        public void User(TcpClient client)
        {
            int i;

            string data;

            NetworkStream stream = null;

            try
            {
                byte[] bytes = new byte[1024];  

                stream = client.GetStream();

                i = stream.Read(bytes, 0, bytes.Length);

                while (i > 0)
                {

                    data = Encoding.ASCII.GetString(bytes, 0, i);

                    Console.WriteLine("Receive: " + data);

                    string[] code = data.Split(':');

                    switch (code[0])
                    {
                        case "play":
                            string user_id = code[1];
                            string room_no = code[2];
                            int vi_tri = Convert.ToInt32(code[3]);
                            HandleClient.Play(user_id, room_no, vi_tri);
                            break;
                        case "chat":
                            HandleClient.Chat(code[1], code[2], code[3]);
                            break;
                        case "chatall":
                            HandleClient.ChatAll(code[1], code[2]);
                            break;
                        case "addfriend":
                            HandleClient.AddFriend(code[1], code[2]);
                            break;
                        case "removefriend":
                            HandleClient.RemoveFriend(code[1], code[2]);
                            break;
                        case "create":
                            if (code[2].Equals("true"))
                            {
                                HandleClient.CreateRoom(code[1], code[3], client);
                            }
                            else if (code[2].Equals("false"))
                            {
                                HandleClient.CreateRoom(code[1], null, client);
                            }
                            break;
                        case "join":
                            HandleClient.JoinRoom(code[1], code[2], client);
                            break;
                        case "quickjoin":
                            HandleClient.QuickJoinRoom(code[1], client);
                            break;
                        case "online":
                            HandleClient.UserOnline(code[1], client);
                            break;
                        case "quit":
                            HandleClient.QuitRoom(code[1], code[2]);
                            break;
                        case "removeroom":
                            HandleClient.RemoveRoom(code[1]);
                            break;
                    }

                    i = stream.Read(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                if (ex is IOException || ex is InvalidOperationException)
                {
                    //Console.WriteLine("Client disconnected");
                    HandleClient.UserOffline();


                    //stream.Close();
                    //client.Close();
                }
            }
        }
    }
}
