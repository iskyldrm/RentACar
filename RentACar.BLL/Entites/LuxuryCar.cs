using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Entites
{
    public class LuxuryCar : Car
    {
        public bool HasLeatherSeats { get; set; }
        public bool HasSunroof { get; set; }
    }
}
