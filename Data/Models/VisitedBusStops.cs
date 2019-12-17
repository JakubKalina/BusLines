using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class VisitedBusStops
    {
        public int Id { get; set; }
        public int RidesId { get; set; }
        public int LineId { get; set; }
        public int BusStopId { get; set; }
        public DateTime? TimeOfArrival { get; set; }

        public virtual BusStops BusStop { get; set; }
        public virtual Lines Line { get; set; }
        public virtual Rides Rides { get; set; }
    }
}
