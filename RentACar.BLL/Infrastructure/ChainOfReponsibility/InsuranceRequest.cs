using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.ChainOfReponsibility
{
    public class InsuranceRequest : Request
    {
        public override string RequestType => "Insurance";
    }
}
