using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilder.Caculator;
using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;

namespace RentACar.BLL.Infrastructure.RentalBuilders
{
    public interface IRentalBuilder
    {
        public RentalBuilder SetCar(Car car);
        public RentalBuilder SetCustomer(Customer customer);
        public RentalBuilder SetStartDate(DateTime startDate);
        public RentalBuilder SetEndDate(DateTime endDate);
        public decimal PriceCalculater();
        public Rental Build();
    }
}
