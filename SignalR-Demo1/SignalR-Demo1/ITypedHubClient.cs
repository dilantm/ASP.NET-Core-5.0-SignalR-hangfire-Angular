using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Demo1
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);

    }
}
