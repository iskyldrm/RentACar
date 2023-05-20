using RentACar.BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.CarFactory
{
    public class LuxuryCarFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new LuxuryCar
            {

                Make = "Mercedes",
                Model = "c180",
                Color = "Beyaz",
                Year = 2016,
                HasLeatherSeats = true,
                HasSunroof = true

            };
        }
    }
}
