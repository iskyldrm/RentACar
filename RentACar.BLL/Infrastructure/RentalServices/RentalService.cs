using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.CarFactory;
using RentACar.BLL.Infrastructure.ChainOfReponsibility;
using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.Observer;
using RentACar.BLL.Infrastructure.RentalBuilders;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACar.BLL.Infrastructure.RentalServices
{
    public class RentalService : IRentalService
    {
        private readonly IRentalBuilder _rentalBuilder;
        private readonly List<Rental> _rentals;
        private ICarFactory _carFactory;
        private readonly List<IRentalObserver> observers;


        public RentalService(IRentalBuilder rentalBuilder)
        {
            _rentalBuilder = new RentalBuilder();
            _rentals = new List<Rental>();
            observers = new List<IRentalObserver>();
        }

        public Rental RentCar(Car car, Customer customer, DateTime startDate, DateTime endDate)
        {
            var rental = _rentalBuilder
                .SetCar(car)
                .SetCustomer(customer)
                .SetStartDate(startDate)
                .SetEndDate(endDate).Build();


            _rentals.Add(rental);

            foreach (var observer in observers)
            {
                observer.Start(rental);
            }

            return rental;
        }

        public List<Rental> GetRentals()
        {
            return _rentals;
        }

        public void AddObserver(IRentalObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IRentalObserver observer)
        {
            observers.Remove(observer);
        }

        public List<Rental> ChangeRental(Rental rental)
        {
            foreach (var observer in observers)
            {
                observer.ChangePrice(rental);
            }
            foreach (var item in _rentals)
            {
                if (item.Id == rental.Id)
                {
                    item.RentalPrice = rental.RentalPrice;
                }
            }

            return _rentals;
        }

        public List<Rental> HandleRequest()
        {

            IRequestHandler fuelHandler = new FuelRequestHandler();
            IRequestHandler insuranceHandler = new InsuranceRequestHandler();
            // Set the chain of responsibility
            fuelHandler.SetNextHandler(insuranceHandler);

            // Create the rental request
            Request fuelRequest = new FuelRequest();
            Request insuranceRequest = new InsuranceRequest();

            // Process the requests
            _rentals[1] = fuelHandler.HandleRequest(fuelRequest, _rentals[1]);
            _rentals[1] = fuelHandler.HandleRequest(insuranceRequest, _rentals[1]);

            return _rentals;
        }
    }
}
