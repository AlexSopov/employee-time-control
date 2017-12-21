﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeTimeControl.Data.Models
{
    public class PassagePoint
    {
        // Data properties
        public int PassagePointId { get; set; }
        public string Address { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<CardAccess> CardPassagePoints { get; set; }

        public PassagePoint()
        {
            CardPassagePoints = new List<CardAccess>();
        }
    }
}
