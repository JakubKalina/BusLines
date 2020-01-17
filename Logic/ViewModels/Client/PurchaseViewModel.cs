using System;
using System.Collections.Generic;

namespace Logic.ViewModels.Client
{
    public class PurchaseViewModel
    {
        public int InitialBusStopId { get; set; }
        public int FinalBusStopId { get; set; }
        public int RideId { get; set; }
        public PassengerViewModel Passenger { get; set; }
    }
}