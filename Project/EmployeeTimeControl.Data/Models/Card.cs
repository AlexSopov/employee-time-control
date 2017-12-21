using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeTimeControl.Data.Models
{
    public class Card
    {
        // Data properties
        public int CardId { get; set; }
        public int CardOwnerId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Employee CardOwner { get; set; }
        [JsonIgnore]
        public virtual ICollection<CardAccess> CardPassagePoints { get; set; }

        public Card()
        {
            CardPassagePoints = new List<CardAccess>();
        }
    }
}
