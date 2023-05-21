using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public class InsuranceRequestHandler : BaseRequestHandler
    {
        public override Rental HandleRequest(Request request, Rental rental)
        {
            if (request.RequestType == "Insurance")
            {
                rental.Insurance = true;
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
