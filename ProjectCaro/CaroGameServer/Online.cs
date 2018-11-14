using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaroGameServer
{
    class Online
    {
        public string user_id { set; get; }
        public IPEndPoint userEP { set; get; }
    }
}
