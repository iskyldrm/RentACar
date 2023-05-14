using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;
using RentACar.BLL.Infrastructure.RentalServices;
using RentACar.BLL.Infrastructure.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.CarRentalAbstractFactory
{
    public class LuxuryCarRentalFactory : CarRentalFactory
    {
        private readonly IRentalService _rentalService;
        public LuxuryCarRentalFactory()
        {
            _rentalService = RentalServiceSingleton.Instance;
        }
        public override Rental CreateRental(Customer customer, DateTime startDate, DateTime endDate)
        {
            return _rentalService.RentCar("Lüks", customer, startDate, endDate);
        }
    }
}
