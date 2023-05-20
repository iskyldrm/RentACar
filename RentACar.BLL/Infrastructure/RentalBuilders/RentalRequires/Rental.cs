using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;

namespace RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires
{
    public class Rental
    {
        public Rental()
        {

        }
        
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalPrice { get; set; }
        public string NotifyForCustomer { get; set; }
        public string NotifyForCar { get; set; }

        public string SomeEventForCustomer(IRentalMediator _rentalMediator)
        {
            return _rentalMediator.Notify("Message to customer", "Customer");
        }
        public string SomeEventForCar(IRentalMediator _rentalMediator)
        {
            return _rentalMediator.Notify("Message to rental car", "RentalCar");
        }

    }
}
