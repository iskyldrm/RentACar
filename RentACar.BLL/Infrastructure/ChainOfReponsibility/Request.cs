using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public abstract class Request
    {
        public abstract string RequestType { get; }
    }
}
