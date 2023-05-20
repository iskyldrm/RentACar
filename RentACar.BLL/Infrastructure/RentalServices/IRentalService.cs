using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.Observer;
using RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalServices
{
    public interface IRentalService
    {
        public Rental RentCar(Car car, Customer customer, DateTime startDate, DateTime endDate);
        public List<Rental> GetRentals();

        public List<Rental> ChangeRental(Rental rental);

        public void AddObserver(IRentalObserver observer);

        public void RemoveObserver(IRentalObserver observer);
    }
}
