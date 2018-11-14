using System.Net;

namespace CaroGameServer
{
    class Room
    {
        public string host_id { set; get; }
        public IPEndPoint hostEP { set; get; }
        public string room_no { set; get; }
        public string join_id { set; get; }
        public IPEndPoint joinEP { set; get; }
    }
}
