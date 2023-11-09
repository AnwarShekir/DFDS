using DFDS.Persistence.Models;

namespace DFDS.Persistence.Interfaces
{
    public interface IPassengerRepository
    {
        Task<Passenger> Get(Guid id);
        Task Update(Passenger passenger);
        Task Create(Passenger passenger);
        Task Delete(Passenger passenger);
        Task<IEnumerable<Passenger>> GetAll();
        Task<IEnumerable<Passenger>> GetByBooking(Guid bookingId);

    }
}
