using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace CaroGameServer
{
    class Room
    {
        public string host_id { set; get; }
        public string host_avatar { set; get; }
        public TcpClient hostClient { set; get; }
        public string join_id { set; get; }
        public string join_avatar { set; get; }
        public TcpClient joinClient { set; get; }
        public string room_no { set; get; }
        public string room_key { set; get; }
    }

    class RoomDuel : Room
    {
        public RoomDuel()
        {
            this.room_key = "duelyst";
        }
    }


    class Online
    {
        public string user_id { set; get; }
        public TcpClient userClient { set; get; }
    }



    class HandleClient
    {
        // danh sách phòng chơi
        private static List<Room> roomList = new List<Room>();
        private static List<RoomDuel> roomDuelList = new List<RoomDuel>();

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



        public static void Result(string result, string user_id)
        {

        }


        public static void CreateRoom(string user_id, string room_key, string user_avatar, TcpClient userClient)
        {
            Random random = new Random();
            string room_no = Convert.ToString(random.Next(1, 999999));


            Room room = new Room
            {
                host_id = user_id,
                hostClient = userClient,
                host_avatar = user_avatar,
                room_no = room_no,
                room_key = room_key
            };



            // thêm vào danh sách room
            roomList.Add(room);

            // allow create room
            Server.SendData("create:" + room_no, userClient);

            // lưu room vào db
            DataBase.TaoRoom(user_id, room_no, room_key);
        }




        public static void JoinRoom(string user_id, string room_no, string user_avatar, TcpClient userClient)
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
                        room.join_avatar = user_avatar;

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
                        string message_to_join = "join:true:" + room.host_id + ":" + room.room_no + ":" + room.host_avatar + ":" + join_turn;
                        Server.SendData(message_to_join, userClient);
                        //Console.WriteLine("join " + room.join_id + " " + room.joinClient.Client.RemoteEndPoint);

                        // gửi thông tin của join cho host
                        string message_to_host = "host:" + room.host_id + ":" + room.join_id + ":" + room.join_avatar + ":" + host_turn;
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
                        check_room = true;
                        break;
                    }
                }
            }

            if (!check_room)
            {
                Server.SendData("join:false", userClient);
            }
        }



        public static void QuickJoinRoom(string user_id, string user_avatar, TcpClient userClient)
        {
            bool check_room = false;

            foreach (Room room in roomList)
            {
                if (!isFull(room) && room.room_key == null)
                {
                    room.join_id = user_id;
                    room.joinClient = userClient;
                    room.join_avatar = user_avatar;

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
                    string message_to_join = "quickjoin:true:" + room.host_id + ":" + room.room_no + ":" + room.host_avatar + ":" + join_turn;
                    Server.SendData(message_to_join, userClient);
                    //Console.WriteLine("join " + room.join_id + " " + room.joinClient.Client.RemoteEndPoint);

                    // gửi thông tin của join cho host
                    string message_to_host = "host:" + room.host_id + ":" + room.join_id + ":" + user_avatar + ":" + host_turn;
                    Server.SendData(message_to_host, room.hostClient);
                    //Console.WriteLine("host " + room.host_id + " " + room.hostClient.Client.RemoteEndPoint);


                    // update room trong db
                    DataBase.UpdateRoom(room.host_id, user_id, room.room_no);

                    check_room = true;

                    break;
                }
            }

            if (!check_room)
            {
                Server.SendData("quickjoin:false", userClient);
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

            foreach (RoomDuel roomDuel in roomDuelList)
            {
                if (roomDuel.room_no.Equals(room_no))
                {
                    roomDuelList.Remove(roomDuel);

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
            if (onlineList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < onlineList.Count; i++)
            {
                Online userOnline = onlineList[i];
                if (!isConnected(userOnline.userClient))
                {
                    Console.WriteLine("User " + userOnline.user_id + " offline");

                    DataBase.ChangeStatusUser(userOnline.user_id);
                    DataBase.ChangeStatusFriendList(userOnline.user_id);

                    // xử lý khi người chơi disconnect trong room
                    RemoveUserFromRoom(userOnline.user_id);

                    // xóa object
                    onlineList.Remove(userOnline);
                }
            }
        }


        public static void UserOffline(string offline_user)
        {
            // xóa object
            for (int i = 0; i < onlineList.Count; i++)
            {
                Online user = onlineList[i];
                if (user.user_id.Equals(offline_user))
                {

                    Console.WriteLine("User " + user.user_id + " offline");

                    DataBase.ChangeStatusUser(user.user_id);
                    DataBase.ChangeStatusFriendList(user.user_id);

                    onlineList.Remove(user);
                    break;
                }
            }
        }


        // TH1: xử lý khi host disconnect (room chỉ có host)
        // TH2: xử lý khi host disconnect giữa trận
        // TH3: xử lý khi join disconnect giữa trận
        private static void RemoveUserFromRoom(string disconnect_user)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                Room room = roomList[i];
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


        // chat all
        public static void ChatAll(string user_id, string chat_message)
        {
            foreach (Online userOnline in onlineList)
            {
                string message = "chatall:" + user_id + ":" + chat_message;
                Server.SendData(message, userOnline.userClient);
            }
        }




        public static void Chat(string user_id, string room_no, string chat_message)
        {
            foreach (Room room in roomList)
            {
                if (room.room_no.Equals(room_no))
                {
                    string message = "chat:" + user_id + ":" + chat_message;
                    Server.SendData(message, room.joinClient);
                    Server.SendData(message, room.hostClient);

                    break;
                }
            }
        }



        public static void Invite(string user_id, string friend_id, string user_avatar, TcpClient userClient)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                Room room = roomList[i];
                if (room.join_id.Equals(friend_id))
                {
                    Server.SendData("youhostduel:busy:", userClient);
                    return;
                }
            }

            for (int i = 0; i < onlineList.Count; i++)
            {
                Online friend = onlineList[i];
                if (friend.user_id.Equals(friend_id))
                {
                    Random random = new Random();
                    string room_no = Convert.ToString(random.Next(1, 999999));

                    RoomDuel roomDuel = new RoomDuel
                    {
                        host_id = user_id,
                        join_id = friend_id,
                        hostClient = userClient,
                        joinClient = friend.userClient,
                        room_no = room_no
                    };


                    Room room = new Room
                    {
                        host_id = user_id,
                        host_avatar = user_avatar,
                        hostClient = userClient,
                        room_no = room_no,
                        room_key = roomDuel.room_key
                    };


                    // thêm vào danh sách room
                    roomList.Add(room);
                    roomDuelList.Add(roomDuel);

                    // gửi thông tin cho phép user tạo phòng chiến với bạn
                    Server.SendData("youhostduel:true:" + room_no, userClient);

                    // gửi thông tin lời mời cho friend
                    Server.SendData("invitetoduel:" + user_id + ":" + room_no, friend.userClient);

                    // lưu room vào db
                    DataBase.TaoRoom(user_id, room_no, roomDuel.room_key);

                    break;
                }
            }
        }


        public static void DuelAccept(string accept_id, string accept_avatar)
        {
            for (int i = 0; i < roomDuelList.Count; i++)
            {
                RoomDuel roomDuel = roomDuelList[i];
                if (roomDuel.join_id.Equals(accept_id))
                {
                    JoinRoom(accept_id, roomDuel.room_no, accept_avatar, roomDuel.joinClient);
                    break;
                }
            }
        }


        public static void DuelRefuse(string refuse_id)
        {
            for (int i = 0; i < roomDuelList.Count; i++)
            {
                RoomDuel roomDuel = roomDuelList[i];
                if (roomDuel.join_id.Equals(refuse_id))
                {
                    Server.SendData("youhostduel:false:" + refuse_id, roomDuel.hostClient);

                    RemoveRoom(roomDuel.room_no);
                    break;
                }
            }
        }




        public static void AddFriend(string user_id, string friend_id, TcpClient userClient)
        {
            DataBase.KetBan(user_id, friend_id);
            Server.SendData("addfriend:true:" + friend_id, userClient);
        }


        public static void RemoveFriend(string user_id, string friend_id, TcpClient userClient)
        {
            DataBase.XoaBan(user_id, friend_id);
            Server.SendData("removefriend:true:" + friend_id, userClient);
        }
    }
}
