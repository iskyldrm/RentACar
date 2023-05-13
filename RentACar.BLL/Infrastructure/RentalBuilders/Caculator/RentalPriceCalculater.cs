using RentACar.BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.RentalBuilder.Caculator
{
    public class RentalPriceCalculater : IRentalPriceCalculater
    {
        public decimal CalculateRentalPrice(DateTime startDate, DateTime endDate, Car car)
        {
            var numberOfDays = (int)(endDate - startDate).TotalDays;
            var dailyPrice = car is LuxuryCar ? 100 : 80;
            return numberOfDays * dailyPrice;
        }
    }
}
