using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;
using RentACar.BLL.Infrastructure.RentalServices;
using RentACar.BLL.Infrastructure.Singleton;

namespace RentACar.BLL.Infrastructure.CarRentalAbstractFactory
{
    public class EconomyCarRentalFactory : CarRentalFactory
    {
        private readonly IRentalService _rentalService;
        public EconomyCarRentalFactory()
        {
            _rentalService = RentalServiceSingleton.Instance;
        }
        public override Rental CreateRental(Customer customer, DateTime startDate, DateTime endDate)
        {
            return _rentalService.RentCar("Ekonomik", customer, startDate, endDate);
        }
    }
}
