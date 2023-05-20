using RentACar.BLL.Entites;

namespace RentACar.BLL.Infrastructure.RentalBuilders.Caculator
{
    public interface IRentalPriceCalculater
    {
        decimal CalculateRentalPrice(DateTime startDate, DateTime endDate, Car car);
    }
}
