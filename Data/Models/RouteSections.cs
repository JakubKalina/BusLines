using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class RouteSections
    {
        public int Distance { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
        public int LineId { get; set; }
        public int BusStopId { get; set; }
        public int RecordNumber { get; set; }

        public virtual BusStops BusStop { get; set; }
        public virtual Lines Line { get; set; }
    }
}
