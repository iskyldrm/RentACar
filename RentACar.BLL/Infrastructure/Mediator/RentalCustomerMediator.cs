using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.Mediator
{
    public class RentalCustomerMediator : IRentalMediator
    {
        public string Notify(string message, string receiver)
        {
            return message + " " + receiver;
        }
    }
}
