 using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilder;
using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalBuilders
{
    public class RentalBuilder : IRentalBuilder
    {
        private readonly RentalBuilder _rentalbuilder;
        private Car _car;
        private Customer _customer;
        private DateTime _startDate;
        private DateTime _endDate;

        public RentalBuilder SetCar(Car car)
        {
            _car = car;
            return this._rentalbuilder.SetCar(car);
        }

        public RentalBuilder SetCustomer(Customer customer)
        {
            _customer = customer;
            return this._rentalbuilder.SetCustomer(customer);
        }

        public RentalBuilder SetStartDate(DateTime startDate)
        {
            _startDate = startDate;
            return this._rentalbuilder.SetStartDate(startDate);
        }

        public RentalBuilder SetEndDate(DateTime endDate)
        {
            _endDate = endDate;
            return this._rentalbuilder.SetEndDate(endDate);
        }

        public decimal PriceCalculater()
        {
            var numberOfDays = (int)(_endDate - _startDate).TotalDays;
            var dailyPrice = _car is LuxuryCar ? 100 : 80;
            return numberOfDays*dailyPrice;
        }

        public Rental Build()
        {
            Rental rental = new Rental();
            rental.RentalPrice = PriceCalculater();
            return rental;
        }
    }
}
