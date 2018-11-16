using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CaroGameServer
{
    class Online
    {
        public string user_id { set; get; }
        public TcpClient userClient { set; get; }
    }
}
