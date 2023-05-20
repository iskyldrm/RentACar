using RentACar.BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.CarFactory
{
    public class EconomyCarFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new EconomyCar
            {
                Make = "Tofaş",
                Model = "Uzun",
                Color = "Kırmızı",
                Year = 1990,
                IsElectric = false,
                HasHatchback = false
            };
        }
    }
}
