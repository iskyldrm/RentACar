﻿using RentACar.BLL.Entites;
using RentACar.BLL.Infrastructure.Mediator;
using RentACar.BLL.Infrastructure.RentalBuilders.Caculator;

namespace RentACar.BLL.Infrastructure.RentalBuilders.RentalRequires
{
    public class Rental
    {
        public Rental()
        {

        }

        public Guid Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalPrice { get; set; }
        public string NotifyForCustomer { get; set; }
        public string NotifyForCar { get; set; }
        public bool ObserverStarted { get; set; } = false;
        public string PriceHistoryForCustomer { get; set; }
        public string PriceHistoryForCar { get; set; }
        public bool FillFuelTank { get; set; } = false;
        public bool Insurance { get; set; } = false;

        public string SomeEventForCustomer(IRentalMediator _rentalMediator)
        {
            return _rentalMediator.Notify("Message to customer", "Customer");
        }
        public string SomeEventForCar(IRentalMediator _rentalMediator)
        {
            return _rentalMediator.Notify("Message to rental car", "RentalCar");
        }

    }
}
