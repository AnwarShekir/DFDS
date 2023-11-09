using DFDS.Persistence.Interfaces;
using DFDS.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Persistence.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApiContext _context;

        public PassengerRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task Create(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Passenger passenger)
        {
            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task<Passenger> Get(Guid id)
        {
            return await _context.Passengers.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Passenger>> GetAll()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<IEnumerable<Passenger>> GetByBooking(Guid bookingId)
        {
            return await _context.Passengers.Where(s => s.Bookings.Any(c => c.Id == bookingId)).ToListAsync();
        }

        public async Task Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
        }
    }
}
