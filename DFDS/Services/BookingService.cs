using DFDS.Dto;
using DFDS.Persistence.Interfaces;
using DFDS.Persistence.Models;
using DFDS.Utils;

namespace DFDS.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IPassengerRepository _passengerRepository;

        public BookingService(IBookingRepository repository, IPassengerRepository passengerRepository)
        {
            _repository = repository;
            _passengerRepository = passengerRepository;
        }

        public async Task Create(BookingDto booking)
        {

            var passengers = (await _passengerRepository.GetAll()).Select(s => s.Id);

            var unknownPassengers = booking.PassengerIds.Except(passengers);

            if (unknownPassengers.Any())
            {
                throw new BadRequestException($"Unknown passenger Ids: {unknownPassengers}");
            }

            var entity = new Booking();

            entity.Amount = booking.Amount;
            entity.BookingDate = booking.BookingDate;
            entity.BookingNumber = booking.BookingNumber;
            entity.DepatureDate = booking.DepatureDate;
            entity.Destination = booking.Destination;
            entity.DepartureFrom = booking.DepartureFrom;
            entity.IsPaid = booking.IsPaid;
            entity.Passengers = (await _passengerRepository.GetAll()).Where(s => booking.PassengerIds.Contains(s.Id)).ToList();
            entity.Id = Guid.NewGuid();

            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Booking with Id: {id} does not exist");
            }
            await _repository.Delete(entity);
        }

        public async Task<BookingDto> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Booking with Id: {id} does not exist");
            }
            return new BookingDto() { Id = entity.Id, Amount = entity.Amount, BookingDate = entity.BookingDate, BookingNumber = entity.BookingNumber,
            DepartureFrom = entity.DepartureFrom, DepatureDate = entity.DepatureDate
            , Destination = entity.Destination
            , IsPaid = entity.IsPaid, PassengerIds = entity.Passengers.Select(p => p.Id).ToList()
            };
        }

        public async Task<IEnumerable<BookingDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var result = new List<BookingDto>();

            foreach (var entity in entities)
            {
                result.Add(new()
                {
                    Amount = entity.Amount,
                    BookingDate = entity.BookingDate,
                    BookingNumber = entity.BookingNumber,
                    DepartureFrom = entity.DepartureFrom,
                    DepatureDate = entity.DepatureDate,
                    Destination = entity.Destination,
                    Id = entity.Id,
                    IsPaid = entity.IsPaid,
                    PassengerIds = entity.Passengers.Select(p => p.Id).ToList()
                });
            }

            return result;
        }

        public async Task<IEnumerable<BookingDto>> GetByPassenger(Guid passengerId)
        {

            var passenger = await _passengerRepository.Get(passengerId);

            if(passenger == null) { throw new NotFoundException($"Passenger wit Id: {passengerId} does not exist"); };

            var entities = await _repository.GetByPassenger(passengerId);
            var result = new List<BookingDto>();

            foreach (var entity in entities)
            {
                result.Add(new()
                {
                    Amount = entity.Amount,
                    BookingDate = entity.BookingDate,
                    BookingNumber = entity.BookingNumber,
                    DepartureFrom = entity.DepartureFrom,
                    DepatureDate = entity.DepatureDate,
                    Destination = entity.Destination,
                    Id = entity.Id,
                    IsPaid = entity.IsPaid,
                    PassengerIds = entity.Passengers.Select(p => p.Id).ToList()
                });
            }

            return result;
        }

        public async Task Update(Guid id, BookingDto booking)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Booking with Id: {id} does not exist");
            }

            var passengers = (await _passengerRepository.GetAll()).Select(s => s.Id);

            var unknownPassengers = booking.PassengerIds.Except(passengers);
            
            if(unknownPassengers.Any())
            {
                throw new BadRequestException($"Unknown passenger Ids: {unknownPassengers}");
            }


            entity.Amount = booking.Amount;
            entity.BookingDate = booking.BookingDate;
            entity.BookingNumber = booking.BookingNumber;
            entity.DepatureDate = booking.DepatureDate;
            entity.Destination = booking.Destination;
            entity.DepartureFrom = booking.DepartureFrom;
            entity.IsPaid = booking.IsPaid;
            entity.Passengers = (await _passengerRepository.GetAll()).Where(s => booking.PassengerIds.Contains(s.Id)).ToList();

            await _repository.Update(entity);
        }
    }
}
