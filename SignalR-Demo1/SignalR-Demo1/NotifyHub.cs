using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Demo1
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
        public override Task OnConnectedAsync()
        {

            //_connections.Add(name, Context.ConnectionId);
            ConnectedUser.Ids.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

    }
}
