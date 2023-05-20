using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalPrototypeLayer
{
    public abstract class RentalPrototype
    {
        public abstract Rental Clone();
    }
}
