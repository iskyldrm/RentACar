using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public class FuelRequestHandler : BaseRequestHandler
    {
        public override Rental HandleRequest(Request request, Rental rental)
        {
            if (request.RequestType == "Fuel")
            {
                rental.FillFuelTank = true;
                return rental;
            }
            else if (nextHandler != null)
            {
                return nextHandler.HandleRequest(request,rental);
            }
            else
            {
                return rental;
            }
        }
    }
}
