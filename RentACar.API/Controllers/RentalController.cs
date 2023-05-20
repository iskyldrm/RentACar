using Microsoft.AspNetCore.Mvc;
using RentACar.API.Models;
using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.CarFactory;
using RentACar.BLL.Infrastructure.CarRentalAbstractFactory;
using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
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
        public RentalController()
        {
            _rentalService = RentalServiceSingleton.Instance;
            _rentals = new List<Rental>();
        }




        [HttpPost]
        [Route("rental")]
        public IActionResult RentCar([FromBody] RentCarRequest request)
        {
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
            IRentalMediator customerMediator = new RentalCustomerMediator();
            IRentalMediator carMediator = new RentalCarMediator();

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

    }
}
