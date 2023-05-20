using Microsoft.AspNetCore.Mvc;
using RentACar.API.Models;
using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.CarFactory;
using RentACar.BLL.Infrastructure.CarRentalAbstractFactory;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;

namespace RentACar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        private  CarRentalFactory _carRental;
        private ICarFactory carFactory;
        


        [HttpPost]
        [Route("rental")]
        public ActionResult<Rental> RentCar([FromBody] RentCarRequest request)
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
            return Ok(_carRental.CreateRental(car,customer, request.StartDate,request.EndDate));
        }

    }
}
