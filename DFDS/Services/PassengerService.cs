using DFDS.Dto;
using DFDS.Persistence.Interfaces;
using DFDS.Persistence.Models;
using DFDS.Utils;

namespace DFDS.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _repository;
        private readonly IBookingRepository _bookingRepository;

        public PassengerService(IPassengerRepository repository, IBookingRepository bookingRepository)
        {
            _repository = repository;
            _bookingRepository = bookingRepository;
        }

        public async Task Create(PassengerDto passenger)
        {
            var entity = new Passenger();

            entity.BirthDate = passenger.BirthDate;
            entity.PassportNumber = passenger.PassportNumber;
            entity.Name = passenger.Name;
            entity.Id = Guid.NewGuid();

            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Passenger with Id: {id} does not exist");
            }
            await _repository.Delete(entity);
        }

        public async Task<PassengerDto> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Passenger with Id: {id} does not exist");
            }

            return new PassengerDto() { Id = entity.Id, BirthDate =  entity.BirthDate
                , Bookings = entity.Bookings.Select(s => s.Id).ToList()
                , Name = entity.Name, PassportNumber = entity.PassportNumber};
        }

        public async Task<IEnumerable<PassengerDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var result = new List<PassengerDto>();

            foreach (var entity in entities)
            {
                result.Add(new PassengerDto() { Id = entity.Id, Name = entity.Name, BirthDate = entity.BirthDate,
                Bookings = entity.Bookings.Select(s => s.Id).ToList()
                , PassportNumber = entity.PassportNumber});
            }

            return result;
        }

        public async Task<IEnumerable<PassengerDto>> GetByBooking(Guid bookingId)
        {
            var booking = await _bookingRepository.Get(bookingId);

            if(booking == null)
            {
                throw new NotFoundException($"Booking with Id: {bookingId} does not exist");
            }

            var entities = await _repository.GetByBooking(bookingId);
            var result = new List<PassengerDto>();

            foreach (var entity in entities)
            {
                result.Add(new PassengerDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    BirthDate = entity.BirthDate,
                    Bookings = entity.Bookings.Select(s => s.Id).ToList()
                ,
                    PassportNumber = entity.PassportNumber
                });
            }

            return result;
        }

        public async Task Update(Guid id, PassengerDto passenger)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Passenger with Id: {id} does not exist");
            }

            entity.BirthDate = passenger.BirthDate;
            entity.Name = passenger.Name;
            entity.PassportNumber = passenger.PassportNumber;
            await _repository.Update(entity);
        }
    }
}
