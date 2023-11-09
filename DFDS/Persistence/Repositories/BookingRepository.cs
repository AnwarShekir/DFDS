using DFDS.Persistence.Interfaces;
using DFDS.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApiContext _context;

        public BookingRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Booking> Get(Guid id)
        {
            return await _context.Bookings.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByPassenger(Guid passengerId)
        {
            return await _context.Bookings.Where(s => s.Passengers.Any(c => c.Id == passengerId)).ToListAsync();
        }

        public async Task Update(Booking booking)
        {
            _context.Bookings.Update(booking);
           await _context.SaveChangesAsync();
        }
    }
}
