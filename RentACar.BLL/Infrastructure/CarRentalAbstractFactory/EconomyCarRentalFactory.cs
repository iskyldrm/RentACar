using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
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
