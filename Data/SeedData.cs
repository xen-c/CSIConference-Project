using CSIConference.Models;
using Microsoft.EntityFrameworkCore;

namespace CSIConference.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Capacities.Any())
            {
                context.Capacities.AddRange(
                    new Capacity { CapacityName = "Student" },
                    new Capacity { CapacityName = "Lecturer" },
                    new Capacity { CapacityName = "Researcher" }
                    );
            }
            context.SaveChanges();

            if(!context.Attendees.Any())
            {
                context.Attendees.AddRange(
                    new Attendee
                    {
                        CapacityId = 1,
                        Name = "Ariana",
                        Email = "ariana@gmail.com",
                        PhoneNumber = "0115676666"
                    },
                    new Attendee
                    {
                        CapacityId = 1,
                        Name = "John",
                        Email = "john@hotmail.co.za",
                        PhoneNumber = "0123564544"
                    },
                   new Attendee
                   {
                       CapacityId = 1,
                       Name = "Anna",
                       Email = "anna@hotmail.co.za",
                       PhoneNumber = "0384441332"
                   },
                   new Attendee
                   {
                       CapacityId = 1,
                       Name = "Thabo",
                       Email = "thabo@gmail.com",
                       PhoneNumber = "0666889999"
                   },
                   new Attendee
                   {
                       CapacityId = 1,
                       Name = "Steve",
                       Email = "steve@gmail.co.za",
                       PhoneNumber = "0248732873"
                   },
                   new Attendee
                   {
                       CapacityId = 1,
                       Name = "Bonga",
                       Email = "bonga@hotmail.co.za",
                       PhoneNumber = "08929893444"
                   }
                   );
            }
            context.SaveChanges();
        }
    }
}
