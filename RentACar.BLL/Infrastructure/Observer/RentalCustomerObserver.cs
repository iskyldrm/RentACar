using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.Observer
{
    public class RentalCustomerObserver : IRentalObserver
    {
        public Rental ChangePrice(Rental rental)
        {
            rental.PriceHistoryForCustomer = "Müşteriye bilgi: fiyat değiştirildi";
            return rental;
        }

        public Rental Start(Rental rental)
        {
            rental.ObserverStarted = true;
            return rental;
        }
    }
}
