using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FracViz.WebApi.Hubs;
using FracViz.WebApi.Services;
using Microsoft.AspNet.SignalR.Hubs;

namespace FracViz.WebApi.Controllers
{
    [RoutePrefix("api/propagator")]
    public class PropagatorController : ApiController
    {
        private readonly IPropagatorHub _hub;

        public PropagatorController(IPropagatorHub hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public IHttpActionResult Propagate([FromBody] string data, [FromUri] string method = null)
        {
            _hub.Push(data, method ?? "newData");

            return Ok();
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult Test()
        {
            return Ok("success");
        }
    }
}
