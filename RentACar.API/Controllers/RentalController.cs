﻿using Microsoft.AspNetCore.Mvc;
using RentACar.API.Models;
using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.CarFactory;
using RentACar.BLL.Infrastructure.CarRentalAbstractFactory;
using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.Observer;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using RentACar.BLL.Infrastructure.RentalPrototypeLayer;
using RentACar.BLL.Infrastructure.RentalServices;
using RentACar.BLL.Infrastructure.Singleton;

namespace RentACar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        private CarRentalFactory _carRental;
        private ICarFactory carFactory;
        private List<Rental> _rentals;
        private readonly IRentalService _rentalService;
        IRentalObserver carObserver;
        IRentalObserver customerObserver;
        public RentalController()
        {
            _rentalService = RentalServiceSingleton.Instance;
            _rentals = new List<Rental>();
        }




        [HttpPost]
        [Route("rental")]
        public IActionResult RentCar([FromBody] RentCarRequest request)
        {
            carObserver = new RentalCarObserver();
            customerObserver = new RentalCustomerObserver();
            _rentalService.AddObserver(carObserver);
            _rentalService.AddObserver(customerObserver);


            Car car = null;
            Customer customer = new Customer();
            customer.FirstName = request.CustomerName;
            customer.LastName = "Yıldırım";
            customer.Email = "225112047";
            customer.PhoneNumber = "225112047";

            if (request.CarType == "Lüks")
            {
                _carRental = new LuxuryCarRentalFactory();
                carFactory = new LuxuryCarFactory();

            }
            else
            {
                _carRental = new EconomyCarRentalFactory();
                carFactory = new EconomyCarFactory();

            }
            car = carFactory.CreateCar();
            var rental = _carRental.CreateRental(car, customer, request.StartDate, request.EndDate);


             



            return Ok(rental);
        }

        [HttpGet("process")]
        public ActionResult<Rental> RentalInProcess()
        {
            _rentals = _rentalService.GetRentals();
            IRentalMediator customerMediator  = new RentalCustomerMediator();
            IRentalMediator carMediator  = new RentalCarMediator();

            foreach (var item in _rentals)
            {
                item.NotifyForCar = item.SomeEventForCar(carMediator);
                item.NotifyForCustomer = item.SomeEventForCustomer(customerMediator);
            }
            

            return Ok(_rentals);
        }


        [HttpGet("rentals")]
        public ActionResult<List<Rental>> GetRentals()
        {
            
            return Ok(_rentalService.GetRentals());
        }

        [HttpGet("changerental")]
        public ActionResult<List<Rental>> ChangeRental()
        {
            _rentals = _rentalService.GetRentals();
            _rentals[0].RentalPrice = 40;

            _rentalService.ChangeRental(_rentals[0]);
            return Ok(_rentals);
        }

        [HttpGet("requesthandle")]
        public ActionResult<List<Rental>> HandleRequest()
        {
            _rentals = _rentalService.HandleRequest();

            return Ok(_rentals);
        }

        [HttpGet("clone")]
        public ActionResult<Rental> Clone(string id)
        {
            RentalPrototype rentalPrototype = null;
            _rentals = _rentalService.GetRentals();
            Rental rental = new Rental();
            foreach (var item in _rentals)
            {
                if (item.Id.ToString() == id)
                {
                    rental = item;
                }
            }
            if (rental.Car is EconomyCar)
            {
                rentalPrototype = new EconomyRentalPrototype(rental);
            }
            else if(rental.Car is LuxuryCar)
            {
                rentalPrototype = new LuxuryRentalPrototype(rental);
            }
            else
            {
                throw new FormatException("hatalı Id");
            }

            return Ok(rentalPrototype.Clone());
        }

    }
}
