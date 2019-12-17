using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Shifts
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
