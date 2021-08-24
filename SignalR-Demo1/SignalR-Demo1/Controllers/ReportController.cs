using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_Demo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private NotifyHub notifyHub = new NotifyHub();
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
        public HangfireService hangfireService;
        public ReportController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
            hangfireService = new HangfireService(_hubContext);
        }

        [HttpGet]
        public string Get()
        {
            string retMessage = string.Empty;
            try
            {
                BackgroundJob.Enqueue(() => hangfireService.ProcessJob());
               
                
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }


        [HttpGet]
        [Route("ToSpecificUser")]
        public string Get(string id)
        {
            string retMessage = string.Empty;
            try
            {
                string _con = _connections.GetConnections(id).FirstOrDefault();
                var message = new Message() { Type = "warning", Information = "test message " + Guid.NewGuid().ToString() };
                _hubContext.Clients.Client(id).BroadcastMessage(message);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }

        [HttpPost]
        public string Post(Message message)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.BroadcastMessage(message);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }


        [HttpGet]
        [Route("GetConnection")]
        public List<string> GetConnection()
        {
            List<string> _users = new List<string>();
            try
            {
                _users = ConnectedUser.Ids;
                return _users;
            }
            catch (Exception e)
            {
                _users[0] = e.ToString();
            }
            return _users;
        }


    }
}
