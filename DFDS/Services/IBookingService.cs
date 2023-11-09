using DFDS.Dto;

namespace DFDS.Services
{
    public interface IBookingService
    {
        Task<BookingDto> Get(Guid id);
        Task Update(Guid id, BookingDto booking);
        Task Create(BookingDto booking);
        Task Delete(Guid id);
        Task<IEnumerable<BookingDto>> GetAll();
        Task<IEnumerable<BookingDto>> GetByPassenger(Guid passengerId);
    }
}
