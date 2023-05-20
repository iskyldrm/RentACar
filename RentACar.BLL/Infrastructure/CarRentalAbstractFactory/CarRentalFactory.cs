using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;

namespace RentACar.BLL.Infrastructure.CarRentalAbstractFactory
{
    public abstract class CarRentalFactory
    {
        public abstract Rental CreateRental(Car car, Customer customer, DateTime startDate, DateTime endDate);
    }
}
