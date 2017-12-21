using Newtonsoft.Json;
using System;

namespace EmployeeTimeControl.Data.Models
{
    public class AccessAttemption
    {
        // Data properties
        public int AccessAttemptionId { get; set; }
        public int CardId { get; set; }
        public int PassagePointId { get; set; }
        public bool SuccessStatus { get; set; }
        public bool IsEnter { get; set; }
        public DateTime AttemptionTime { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Card Card { get; set; }
        [JsonIgnore]
        public virtual PassagePoint PassagePoint { get; set; }
    }
}
