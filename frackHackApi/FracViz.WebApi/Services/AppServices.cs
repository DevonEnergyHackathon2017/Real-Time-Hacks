using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FracViz.WebApi.Hubs;

namespace FracViz.WebApi.Services
{
    public static class AppServices
    {
        public static IPropagatorHub PropagatorHub = new PropagatorHub();
    }
}