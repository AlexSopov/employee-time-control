using Newtonsoft.Json;

namespace EmployeeTimeControl.Data.Models
{
    public class CardAccess
    {
        // Data properties
        public int CardAccessId { get; set; }
        public int CardId { get; set; }
        public int PassagePointId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Card Card { get; set; }
        [JsonIgnore]
        public virtual PassagePoint PassagePoint { get; set; }
    }
}
