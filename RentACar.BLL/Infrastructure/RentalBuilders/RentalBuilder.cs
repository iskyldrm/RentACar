 using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalBuilders
{
    public class RentalBuilder : IRentalBuilder
    {
        private Car _car;
        private Customer _customer;
        private DateTime _startDate;
        private DateTime _endDate;


        public IRentalBuilder SetCar(Car car)
        {
            if (car is  LuxuryCar)
            {
                this._car = new LuxuryCar();
                this._car = car;
            }
            if (car is EconomyCar)
            {
                this._car = new EconomyCar();
                this._car = car;
            }
            
            return this;
        }

        public IRentalBuilder SetCustomer(Customer customer)
        {
            this._customer = customer;
            return this;
        }

        public IRentalBuilder SetStartDate(DateTime startDate)
        {
            this._startDate = startDate;
            return this;
        }

        public IRentalBuilder SetEndDate(DateTime endDate)
        {
            this._endDate = endDate;
            return this;
        }


        public decimal PriceCalculater()
        {
            var numberOfDays = (int)(_endDate - _startDate).TotalDays;
            var dailyPrice = _car is LuxuryCar ? 100 : 80;
            return numberOfDays*dailyPrice;
        }

        public Rental Build()
        {
            if (_car == null)
            {
                throw new Exception("Car is required to create rental.");
            }

            if (_customer == null)
            {
                throw new Exception("Customer is required to create rental.");
            }

            if (_startDate == default(DateTime))
            {
                throw new Exception("Start date is required to create rental.");
            }

            if (_endDate == default(DateTime))
            {
                throw new Exception("End date is required to create rental.");
            }

            var rental = new Rental
            {
                Id = Guid.NewGuid(),
                Car = _car,
                Customer = _customer,
                StartDate = _startDate,
                EndDate = _endDate,
                RentalPrice = PriceCalculater()
            };

            return rental;
        }
    }
}
