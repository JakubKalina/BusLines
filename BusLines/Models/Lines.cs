using System;
using System.Collections.Generic;

namespace BusLines.Models
{
    public partial class Lines
    {
        public Lines()
        {
            Rides = new HashSet<Rides>();
            RouteSections = new HashSet<RouteSections>();
            VisitedBusStops = new HashSet<VisitedBusStops>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rides> Rides { get; set; }
        public virtual ICollection<RouteSections> RouteSections { get; set; }
        public virtual ICollection<VisitedBusStops> VisitedBusStops { get; set; }
    }
}
