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

        private static void SendCreateRoom(string user_id)
        {
            Random random = new Random();
            room_no = Convert.ToString(random.Next(1, 10000));
            string message = "create:" + user_id + ":" + room_no;
            SendData(message);
        }

        private static void SendJoinRoom(string user_id, string room_no)
        {
            string message = "join:" + user_id + ":" + room_no;
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



        private static void SendRefreshRoom()
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
    }
}
