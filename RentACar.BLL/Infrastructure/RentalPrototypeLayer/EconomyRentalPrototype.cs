using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilder.Caculator;
using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalPrototypeLayer
{
    public class EconomyRentalPrototype : RentalPrototype
    {
        private readonly Car _car;
        private readonly Customer _customer;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public EconomyRentalPrototype(Car car, Customer customer, DateTime startDate, DateTime endDate)
        {
            _car = car;
            _customer = customer;
            _startDate = startDate;
            _endDate = endDate;
        }

        public override Rental Clone()
        {
            var rental = new Rental
            {
                Car = _car,
                Customer = _customer,
                StartDate = _startDate,
                EndDate = _endDate
            };

            rental.RentalPrice = new RentalPriceCalculater().CalculateRentalPrice(rental.StartDate,rental.EndDate,rental.Car);

            return rental;
        }
    }
}
