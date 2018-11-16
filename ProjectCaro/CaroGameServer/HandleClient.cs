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

            // log
            //Console.WriteLine("User " + user_id + " create room ");
        }




        public static void JoinRoom(string user_id, string room_no, TcpClient userClient)
        {
            bool check_room = false;

            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
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


                    check_room = true;
                    break;
                }
            }

            if (!check_room)
            {
                Server.SendData("join:false", userClient);
            }
        }



        public static void RemoveRoom(string room_no)
        {
            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    roomList.Remove(room);
                }
            }
        }



        public static void RefreshRoom()
        {

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

            //Console.WriteLine("User " + user_id + " online");
        }


        //// xóa user khỏi online list
        public static void UserOffline(TcpClient userClient)
        {
            foreach (Online userOnline in onlineList)
            {
                if (userOnline.userClient.Equals(userClient))
                {
                    onlineList.Remove(userOnline);
                    break;
                }
            }
        }
    }
}
