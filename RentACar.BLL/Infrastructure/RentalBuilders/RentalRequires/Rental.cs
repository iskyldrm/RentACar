using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;

namespace RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires
{
    public class Rental
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalPrice { get; set; }
        
    }
}
