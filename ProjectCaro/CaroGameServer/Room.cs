using System.Net.Sockets;

namespace CaroGameServer
{
    class Room
    {
        public string host_id { set; get; }
        public TcpClient hostClient { set; get; }
        public string room_no { set; get; }
        public string join_id { set; get; }
        public TcpClient joinClient { set; get; }
    }
}
