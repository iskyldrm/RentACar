using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;

namespace RentACar.BLL.Infrastructure.RentalBuilders
{
    public interface IRentalBuilder
    {
        IRentalBuilder SetCar(Car car);
        IRentalBuilder SetCustomer(Customer customer);
        IRentalBuilder SetStartDate(DateTime startDate);
        IRentalBuilder SetEndDate(DateTime endDate);
        Rental Build();
    }
}
