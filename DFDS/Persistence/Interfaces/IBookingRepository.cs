using DFDS.Persistence.Models;

namespace DFDS.Persistence.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> Get(Guid id);
        Task Update(Booking booking);
        Task Create(Booking booking);
        Task Delete(Booking booking);
        Task<IEnumerable<Booking>> GetAll();
        Task<IEnumerable<Booking>> GetByPassenger(Guid passengerId);
    }
}
