using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.RentalBuilders;
using RentACar.BLL.Infrastructure.RentalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Infrastructure.Singleton
{
    public static class RentalServiceSingleton
    {
        private static readonly object lockObject = new object();
        private static RentalService instance;
        private static IRentalBuilder _rentalBuilder;


        public static RentalService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new RentalService(_rentalBuilder);
                        }
                    }
                }

                return instance;
            }
        }
    }
}
