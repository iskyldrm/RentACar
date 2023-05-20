namespace RentACar.API.Models
{
    public class RentCarRequest
    {
        public string CarType { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
