using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Entites
{
    public class EconomyCar:Car
    {
        public bool HasHatchback { get; set; }
        public bool IsElectric { get; set; }
    }
}
