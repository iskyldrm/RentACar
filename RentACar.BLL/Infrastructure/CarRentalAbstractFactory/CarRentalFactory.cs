using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;

namespace RentACar.BLL.Infrastructure.CarRentalAbstractFactory
{
    public abstract class CarRentalFactory
    {
        public abstract Rental CreateRental(Customer customer, DateTime startDate, DateTime endDate);
    }
}
