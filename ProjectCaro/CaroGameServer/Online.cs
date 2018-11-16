using System.Net.Sockets;

namespace CaroGameServer
{
    class Online
    {
        public string user_id { set; get; }
        public TcpClient userClient { set; get; }
    }
}
