using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using RentACar.BLL.Infrastructure.RentalServices;
using RentACar.BLL.Infrastructure.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.CarRentalAbstractFactory
{
    public class LuxuryCarRentalFactory: CarRentalFactory
    {
        private readonly IRentalService _rentalService;
        public LuxuryCarRentalFactory()
        {
            _rentalService = RentalServiceSingleton.Instance;
        }
        public override Rental CreateRental(Car car, Customer customer, DateTime startDate, DateTime endDate)
        {
            return _rentalService.RentCar(car, customer, startDate, endDate);
        }

        public override List<Rental> GetRentals()
        {
            return _rentalService.GetRentals();
        }
    }
}
