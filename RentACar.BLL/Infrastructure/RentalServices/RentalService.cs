using RentACar.BLL.Infrastructure.CarFactory;
using RentACar.BLL.Infrastructure.RentalBuilders;
using RentACar.BLL.Infrastructure.RentalBuilder.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalServices
{
    public class RentalService
    {
        private readonly IRentalBuilder _rentalBuilder;
        private readonly List<Rental> _rentals;
        private ICarFactory _carFactory;

        public RentalService(IRentalBuilder rentalBuilder)
        {
            _rentalBuilder = rentalBuilder;
            _rentals = new List<Rental>();
        }

        public Rental RentCar(string carType, Customer customer, DateTime startDate, DateTime endDate)
        {
            if (carType == "Ekonomik")
            {
                _carFactory = new EconomyCarFactory();
            }
            else if (carType == "Lüks")
            {
                _carFactory = new LuxuryCarFactory();
            }
            else
            {
                throw new FormatException("Araba tipi hatalı");
            }
            var car = _carFactory.CreateCar();
            var mycustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
            var rental = _rentalBuilder
                .SetCar(car)
                .SetCustomer(customer)
                .SetStartDate(startDate)
                .SetEndDate(endDate).Build();
            _rentals.Add(rental);
            return rental;
        }

        public List<Rental> GetRentals()
        {
            return _rentals;
        }

    }
}
