using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FracViz.WebApi.Hubs
{
    public interface IPropagatorHub
    {
        void Push<T>(T data, string method);
    }
}
