using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModels.Client
{
    public class FindRideViewModel
    {
        /// <summary>
        /// Nazwa przystanku startowego
        /// </summary>
        public string InitialBusStop { get; set; }

        /// <summary>
        /// Nazwa przystanku końcowego
        /// </summary>
        public string FinalBusStop { get; set; }

        /// <summary>
        /// Czas przejazdu od
        /// </summary>
        public DateTime RideTimeFrom { get; set; }
    }
}
