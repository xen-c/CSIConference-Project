using System.ComponentModel.DataAnnotations;

namespace CSIConference.Models
{
    public class Capacity
    {
        public int CapacityId { get; set; }

        [Required]
        public string CapacityName { get; set; }

        //Navigation property
        public ICollection<Attendee> Attendee { get; set; }
    }
}
