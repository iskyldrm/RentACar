using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public interface IRequestHandler
    {
        void SetNextHandler(IRequestHandler nextHandler);
        Rental HandleRequest(Request request, Rental rental);
    }
}
