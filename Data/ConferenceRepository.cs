using Microsoft.EntityFrameworkCore;
using CSIConference.Models;

namespace CSIConference.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ConferenceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddAttendee(Attendee attendee)
        {
            _appDbContext.Attendees.Add(attendee);
        }

        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _appDbContext.Attendees;
        }
        public IEnumerable<Attendee> GetAllAttendeesWithCapacity()
        {
            return _appDbContext.Attendees.Include(a => a.CapacityId);
        }

        public IEnumerable<Capacity> GetAllCapacities()
        {
            return _appDbContext.Capacities;
        }

        public Attendee GetAttendeeByEmail(string email)
        {
            return _appDbContext.Attendees.FirstOrDefault(a => a.Email.ToLower() == email.ToLower());
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public void UpdateAttendee(Attendee attendee)
        {
            _appDbContext.Attendees.Update(attendee);
        }
    }
}
