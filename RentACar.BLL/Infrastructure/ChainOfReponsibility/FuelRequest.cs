using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public class FuelRequest : Request
    {
        public override string RequestType => "Fuel";
    }
}
