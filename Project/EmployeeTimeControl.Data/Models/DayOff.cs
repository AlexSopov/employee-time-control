using Newtonsoft.Json;
using System;

namespace EmployeeTimeControl.Data.Models
{
    public class DayOff
    {
        // Data properties
        public int DayOffId { get; set; }
        public DateTime DayOffDate { get; set; }
        public DayOffType DayOffType { get; set; }
        public int EmployeeId { get; set; }

        // Navifation properties
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }
}
