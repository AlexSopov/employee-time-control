using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeTimeControl.Data.Models
{
    public class Employee
    {
        // Data properties
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int VisitingRuleId { get; set; }
        public string JobTitle { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Card> Cards { get; set; }
        [JsonIgnore]
        public virtual VisitingRule VisitingRule { get; set; }

        public Employee()
        {
            Cards = new List<Card>();
        }
    }
}
