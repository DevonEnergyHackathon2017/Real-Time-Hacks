using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FracViz.WebApi.Hubs
{
    [HubName("propagator")]
    public class PropagatorHub : Hub, IPropagatorHub
    {
        public void Push<T>(T data, string method)
        {
            var proxy = Clients.All as IClientProxy;
            proxy?.Invoke(method, data);
        }
    }
}