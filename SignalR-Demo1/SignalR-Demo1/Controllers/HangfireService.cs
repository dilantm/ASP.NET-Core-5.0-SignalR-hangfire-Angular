using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_Demo1.Controllers
{
    public class HangfireService
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private NotifyHub notifyHub = new NotifyHub();

       

        public HangfireService(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }
     
        
        public void ProcessJob()
        {
            var message = new Message() { Type = "warning", Information = "test message " + Guid.NewGuid().ToString() };
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int progressPercentage = 0;
            var random = new Random();

            // iterate through a loop 10 times, waiting a random number of milliseconds before updating the progress bar
            for (int i = 0; i < 10; i++)
            {
                int waitTimeMilliseconds = random.Next(100, 2500);
                Thread.Sleep(waitTimeMilliseconds);
            }

            stopwatch.Stop();
            _hubContext.Clients.All.BroadcastMessage(message);
        }
    }
}
