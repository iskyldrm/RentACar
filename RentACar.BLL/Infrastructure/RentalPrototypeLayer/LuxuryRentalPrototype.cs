using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalPrototypeLayer
{
    public class LuxuryRentalPrototype : RentalPrototype
    {
        private readonly Rental _rental;

        public LuxuryRentalPrototype(Rental rental)
        {
            _rental = rental;
        }

        public override Rental Clone()
        {
            var rental = new Rental
            {
                Car = _rental.Car,
                Customer = _rental.Customer,
                StartDate = _rental.StartDate,
                EndDate = _rental.EndDate,
                FillFuelTank = _rental.FillFuelTank,
                Id = _rental.Id,
                Insurance = _rental.Insurance,
                NotifyForCar = _rental.NotifyForCar,
                NotifyForCustomer = _rental.NotifyForCustomer,
                ObserverStarted = _rental.ObserverStarted,
                PriceHistoryForCar = _rental.PriceHistoryForCar,
                PriceHistoryForCustomer = _rental.PriceHistoryForCustomer,
                RentalPrice = _rental.RentalPrice
            };

            

            return rental;
        }
    }
}
