﻿using Newtonsoft.Json;
using System;

namespace EmployeeTimeControl.Data.Models
{
    public class DayVisitingRule
    {
        // Data properties
        public int DayVisitingRuleId { get; set; }
        public int VisitingRuleId { get; set; }
        public DateTimeOffset StartWorkingDay { get; set; }
        public DateTimeOffset EndWorkingDay { get; set; }
        public int DayNormal { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual VisitingRule VisitingRule { get; set; }
    }
}
