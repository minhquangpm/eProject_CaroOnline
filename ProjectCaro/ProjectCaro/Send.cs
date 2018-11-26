using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaro
{
    partial class Caro
    {
        private static void SendPlay(string user_id, string room_no, int vi_tri)
        {
            string message = "play:" + user_id + ":" + room_no + ":" + vi_tri;
            SendData(message);
        }


        private static void SendResult(string result, string user_id)
        {
            string message = "result:" + result + ":" + user_id;
            SendData(message);
        }



        private static void SendChat(string user_id, string chat_message)
        {
            string message = "chatall:" + user_id + ":" + chat_message;
            SendData(message);
        }


        private static void SendChat(string user_id, string room_no, string chat_message)
        {
            string message = "chat:" + user_id + ":" + room_no + ":" + chat_message;
            SendData(message);
        }


        private static void SendAddFriend(string user_id, string friend_id)
        {
            string message = "addfriend:" + user_id + ":" + friend_id;
            SendData(message);
        }


        private static void SendRemoveFriend(string user_id, string friend_id)
        {
            string message = "removefriend:" + user_id + ":" + friend_id;
            SendData(message);

        }


        private static void SendInviteFriend(string user_id, string friend_id)
        {
            string message = "invite:" + user_id + ":" + friend_id;
            SendData(message);
        }


        private static void SendAcceptInvite(string user_id)
        {
            string message = "duelaccept:" + user_id;
            SendData(message);
        }


        private static void SendRefuseInvite(string user_id)
        {
            string message = "duelrefuse:" + user_id;
            SendData(message);
        }


        private static void SendCreateRoom(string user_id)
        {
            string message = "create:" + user_id + ":false";
            SendData(message);
        }


        private static void SendCreateRoom(string user_id, string room_key)
        {
            string message = "create:" + user_id + ":true:" + room_key;
            SendData(message);
        }



        private static void SendJoinRoom(string user_id, string room_no)
        {
            string message = "join:" + user_id + ":" + room_no;
            SendData(message);
        }


        private static void SendQuickJoin(string user_id)
        {
            string message = "quickjoin:" + user_id;
            SendData(message);
        }


        private static void SendQuitRoom(string user_id, string room_no)
        {
            string message = "quit:" + user_id + ":" + room_no;
            SendData(message);
        }


        private static void SendRemoveRoom(string room_no)
        {
            string message = "removeroom:" + room_no;
            SendData(message);
        }


        private static void SendUserOnline(string user_id)
        {
            string message = "online:" + user_id;
            SendData(message);
        }


        private static void SendUserOffline(string user_id)
        {
            string message = "offline:" + user_id;
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
    }
}
