using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheChase.Classes;

namespace TheChase.Client
{
    public class ClientConnection : Connection
    {
        public ClientConnection(string name, Func<Connection, Exception, Task> callback) : base(name, callback)
        {
            this.Receieved += ClientConnection_Receieved;
        }

        public Task Connect(IPAddress addr)
        {
            return Client.ConnectAsync(addr, PORT);
        }

        private void ClientConnection_Receieved(object sender, string e)
        {
            var packet = new Packet(e);
        }
    }
}
