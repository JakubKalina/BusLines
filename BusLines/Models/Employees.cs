using System;
using System.Collections.Generic;

namespace BusLines.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Rides = new HashSet<Rides>();
            Shifts = new HashSet<Shifts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Rides> Rides { get; set; }
        public virtual ICollection<Shifts> Shifts { get; set; }
    }
}
