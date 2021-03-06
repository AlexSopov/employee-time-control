﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeTimeControl.Data.Models
{
    public class VisitingRule
    {
        // Data properties
        public int VisitingRuleId { get; set; }
        public string Description { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<DayVisitingRule> DayRules { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

        public VisitingRule()
        {
            DayRules = new List<DayVisitingRule>();
            Employees = new List<Employee>();
        }
    }
}
