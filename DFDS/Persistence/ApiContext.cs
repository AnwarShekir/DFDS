using DFDS.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Persistence
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; } 
    }
}
