using DFDS.Dto;

namespace DFDS.Services
{
    public interface IPassengerService
    {
        Task<PassengerDto> Get(Guid id);
        Task Update(Guid id, PassengerDto passenger);
        Task Create(PassengerDto passenger);
        Task Delete(Guid id);
        Task<IEnumerable<PassengerDto>> GetAll();
        Task<IEnumerable<PassengerDto>> GetByBooking(Guid bookingId);
    }
}
