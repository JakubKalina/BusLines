using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Rides
    {
        public Rides()
        {
            Tickets = new HashSet<Tickets>();
            VisitedBusStops = new HashSet<VisitedBusStops>();
        }

        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public int OccupiedSeats { get; set; }
        public int LineId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Vehicles IdNavigation { get; set; }
        public virtual Lines Line { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual ICollection<VisitedBusStops> VisitedBusStops { get; set; }
    }
}
