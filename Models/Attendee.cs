using System.ComponentModel.DataAnnotations;

namespace CSIConference.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50, MinimumLength =2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please select the capacity in which you will be attending")]
        public int CapacityId { get; set; } //Foreign Key

        //Navigation property
        public Capacity Capacity { get; set; }
    }
}
