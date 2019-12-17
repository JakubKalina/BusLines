using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Tickets
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RideId { get; set; }
        public int InitialBusStopId { get; set; }
        public int FinalBusStopId { get; set; }

        public virtual BusStops FinalBusStop { get; set; }
        public virtual BusStops InitialBusStop { get; set; }
        public virtual Rides Ride { get; set; }
    }
}
