using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.Mediator
{
    public interface IRentalMediator
    {
        string Notify(string message, string receiver);
    }
}
