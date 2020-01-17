using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModels.Client
{
    public class BusStopViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Miasto
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Dokłady adres przystanku
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Nazwa przystanku
        /// </summary>
        public string Name { get; set; }
    }
}
