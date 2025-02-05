using CSIConference.Models;

namespace CSIConference.Data
{
    public interface IConferenceRepository
    {
        IEnumerable<Attendee> GetAllAttendees();
        IEnumerable<Capacity> GetAllCapacities();
        IEnumerable<Attendee> GetAllAttendeesWithCapacity();
        Attendee GetAttendeeByEmail(string email);
        void AddAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void SaveChanges();
    }
}
