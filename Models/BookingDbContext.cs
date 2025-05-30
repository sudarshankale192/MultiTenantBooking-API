using System.Data.Entity;

namespace MultiTenantBookingAPI.Models
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext() : base("name=BookingDbContext") {}
        public DbSet<Booking> Bookings { get; set; }
    }
}