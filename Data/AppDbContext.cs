using Microsoft.EntityFrameworkCore;
using CSIConference.Models;

namespace CSIConference.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Capacity> Capacities { get; set; }
    }
}
