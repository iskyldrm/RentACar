using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public abstract class BaseRequestHandler : IRequestHandler
    {
        protected IRequestHandler nextHandler;

        public void SetNextHandler(IRequestHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public abstract Rental HandleRequest(Request request,Rental rental);
    }
}
