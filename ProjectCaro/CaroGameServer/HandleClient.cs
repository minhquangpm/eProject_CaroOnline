using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace CaroGameServer
{
    class HandleClient
    {
        // danh sách phòng chơi
        private static List<Room> roomList = new List<Room>();

        // danh sách người chơi online
        private static List<Online> onlineList = new List<Online>();



        public static void Play(string user_id, string room_no, int vi_tri)
        {
            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    string message_to_player = "play:" + vi_tri;
                    if (user_id.Equals(room.host_id))
                    {
                        Server.SendData(message_to_player, room.joinClient);
                        //Console.WriteLine("play " + user_id + " " + room.joinClient.Client.RemoteEndPoint);
                    }
                    else if (user_id.Equals(room.join_id))
                    {
                        Server.SendData(message_to_player, room.hostClient);
                        //Console.WriteLine("play " + user_id + " " + room.hostClient.Client.RemoteEndPoint);
                    }
                    break;
                }
            }
        }



        public static void CreateRoom(string user_id, string room_no, TcpClient userClient)
        {
            Room room = new Room
            {
                host_id = user_id,
                hostClient = userClient,
                room_no = room_no
            };

            // thêm vào danh sách room
            roomList.Add(room);

            // allow create room
            Server.SendData("create:true", userClient);

            // lưu room vào db
            DataBase.TaoRoom(user_id, room_no);
        }




        public static void JoinRoom(string user_id, string room_no, TcpClient userClient)
        {
            bool check_room = false;

            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    if (!isFull(room))
                    {
                        room.join_id = user_id;
                        room.joinClient = userClient;

                        Random random = new Random();
                        int host_turn = random.Next(1, 3);
                        int join_turn = 0;
                        if (host_turn == 1)
                        {
                            join_turn = 2;
                        }
                        else
                        {
                            join_turn = 1;
                        }

                        // gửi thông tin của host cho join
                        string message_to_join = "join:true:" + room.host_id + ":" + join_turn;
                        Server.SendData(message_to_join, userClient);
                        //Console.WriteLine("join " + room.join_id + " " + room.joinClient.Client.RemoteEndPoint);

                        // gửi thông tin của join cho host
                        string message_to_host = "host:" + room.host_id + ":" + room.join_id + ":" + host_turn;
                        Server.SendData(message_to_host, room.hostClient);
                        //Console.WriteLine("host " + room.host_id + " " + room.hostClient.Client.RemoteEndPoint);


                        // update room trong db
                        DataBase.UpdateRoom(room.host_id, user_id, room_no);

                        check_room = true;
                        break;
                    }
                    else
                    {
                        Server.SendData("join:full", userClient);
                        break;
                    }
                }
            }

            if (!check_room)
            {
                Server.SendData("join:false", userClient);
            }
        }



        public static void QuickJoinRoom(string user_id, TcpClient userClient)
        {
            foreach (Room room in roomList)
            {
                if (!isFull(room))
                {
                    room.join_id = user_id;
                    room.joinClient = userClient;

                    Random random = new Random();
                    int host_turn = random.Next(1, 3);
                    int join_turn = 0;
                    if (host_turn == 1)
                    {
                        join_turn = 2;
                    }
                    else
                    {
                        join_turn = 1;
                    }

                    // gửi thông tin của host cho join
                    string message_to_join = "quickjoin:" + room.host_id + ":" + room.room_no + ":" + join_turn;
                    Server.SendData(message_to_join, userClient);
                    //Console.WriteLine("join " + room.join_id + " " + room.joinClient.Client.RemoteEndPoint);

                    // gửi thông tin của join cho host
                    string message_to_host = "host:" + room.host_id + ":" + room.join_id + ":" + host_turn;
                    Server.SendData(message_to_host, room.hostClient);
                    //Console.WriteLine("host " + room.host_id + " " + room.hostClient.Client.RemoteEndPoint);


                    // update room trong db
                    DataBase.UpdateRoom(room.host_id, user_id, room.room_no);

                    break;
                }
            }
        }


        private static bool isFull(Room room)
        {
            if (room.join_id != null && room.joinClient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // do some trick here.
        // nếu host quit thì gửi thông báo cho join và ngược lại
        public static void QuitRoom(string user_quitting, string room_no)
        {
            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    if (room.host_id.Equals(user_quitting))
                    {
                        Server.SendData("otherquit:host", room.joinClient);
                        room.host_id = room.join_id;
                        room.hostClient = room.joinClient;
                        room.join_id = null;
                        room.joinClient = null;

                        // update db
                        DataBase.UpdateRoom(room.host_id, null, room_no);

                        break;
                    }
                    else if (room.join_id.Equals(user_quitting))
                    {
                        Server.SendData("otherquit:join", room.hostClient);
                        room.join_id = null;
                        room.joinClient = null;

                        //update db
                        DataBase.UpdateRoom(room.host_id, null, room_no);

                        break;
                    }
                }
            }
        }



        // xóa room khi chủ phòng (host) thoát
        public static void RemoveRoom(string room_no)
        {
            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    // xóa phòng trong db
                    DataBase.XoaRoom(room.host_id);

                    roomList.Remove(room);

                    break;
                }
            }
        }


        // thêm user vào online list
        public static void UserOnline(string user_id, TcpClient userClient)
        {
            Online userOnline = new Online
            {
                user_id = user_id,
                userClient = userClient
            };

            // thêm user vào online list
            onlineList.Add(userOnline);

            Console.WriteLine("User " + user_id + " online");
        }



        // xóa user khỏi online list
        public static void UserOffline()
        {
            foreach (Online userOnline in onlineList)
            {
                if (!isConnected(userOnline.userClient))
                {
                    Console.WriteLine("User " + userOnline.user_id + " offline");
                    ChangeStatusUser(userOnline.user_id);
                    ChangeStatusFriendList(userOnline.user_id);

                    // xử lý khi người chơi disconnect trong room
                    RemoveUserFromRoom(userOnline.user_id);

                    // xóa object
                    onlineList.Remove(userOnline);
                    break;
                }
            }
        }


        // TH1: xử lý khi host disconnect (room chỉ có host)
        // TH2: xử lý khi host disconnect giữa trận
        // TH3: xử lý khi join disconnect giữa trận
        private static void RemoveUserFromRoom(string disconnect_user)
        {
            //try
            //{
                foreach (Room room in roomList)
                {
                    if (disconnect_user.Equals(room.host_id) && room.join_id == null)
                    {
                        Console.WriteLine("User " + disconnect_user + " disconnect while waiting join");

                        RemoveRoom(room.room_no);
                        break;
                    }
                    else if (disconnect_user.Equals(room.host_id) && room.join_id != null)
                    {
                        Console.WriteLine("User " + disconnect_user + " disconnect between match");

                        QuitRoom(disconnect_user, room.room_no);
                        break;
                    }
                    else if (disconnect_user.Equals(room.join_id))
                    {
                        Console.WriteLine("User " + disconnect_user + " disconnect between match");

                        QuitRoom(disconnect_user, room.room_no);
                        break;
                    }
                }
            //}
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("NULL ERROR: " + disconnect_user + " " + roomList.Count);
            //}
            
        }


        public static void ChangeStatusUser(string user_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = $"UPDATE user SET status = @status WHERE userName = '" + user_id + "';";
                MyCommand.Parameters.AddWithValue("@status", SqlDbType.Int).Value = 0;
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Dispose();
                conn.Close();
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }




        private static bool isConnected(TcpClient client)
        {
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    /* pear to the documentation on Poll:
                     * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                     * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                     * -or- true if data is available for reading; 
                     * -or- true if the connection has been closed, reset, or terminated; 
                     * otherwise, returns false
                     */

                    // Detect if client disconnected
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            // Client disconnected
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public static void ChangeStatusFriendList(string user_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = $"UPDATE friendlist SET status = @status WHERE name = '" + user_id + "';";
                MyCommand.Parameters.AddWithValue("@status", SqlDbType.Int).Value = 0;
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }
    }
}
