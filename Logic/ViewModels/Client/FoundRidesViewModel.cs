using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModels.Client
{
    public class FoundRidesViewModel
    {
        /// <summary>
        /// Przystanek początkowy
        /// </summary>
        public BusStopViewModel InitialBusStop { get; set; }

        /// <summary>
        /// Przystanek końcowy
        /// </summary>
        public BusStopViewModel FinalBusStop { get; set; }

        /// <summary>
        /// Czas przejazdu od
        /// </summary>
        public DateTime RideTimeFrom { get; set; }

        /// <summary>
        /// Znalezione przejazdy
        /// </summary>
        public List<RideViewModel> Rides { get; set; }
    }
}
