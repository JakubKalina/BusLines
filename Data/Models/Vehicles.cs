using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Vehicles
    {
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public string RegistrationNumber { get; set; }
        public string YearOfProduction { get; set; }

        public virtual Rides Rides { get; set; }
    }
}
