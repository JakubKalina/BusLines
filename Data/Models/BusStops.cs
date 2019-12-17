using System.Collections.Generic;

namespace Data.Models
{
    public partial class BusStops
    {
        public BusStops()
        {
            RouteSections = new HashSet<RouteSections>();
            TicketsFinalBusStop = new HashSet<Tickets>();
            TicketsInitialBusStop = new HashSet<Tickets>();
            VisitedBusStops = new HashSet<VisitedBusStops>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RouteSections> RouteSections { get; set; }
        public virtual ICollection<Tickets> TicketsFinalBusStop { get; set; }
        public virtual ICollection<Tickets> TicketsInitialBusStop { get; set; }
        public virtual ICollection<VisitedBusStops> VisitedBusStops { get; set; }
    }
}
