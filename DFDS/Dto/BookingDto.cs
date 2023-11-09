using DFDS.Persistence.Models;
using DFDS.Utils;

namespace DFDS.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public int BookingNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DepatureDate { get; set; }
        public Cities DepartureFrom { get; set; }
        public Cities Destination { get; set; }
        public bool IsPaid { get; set; }
        public decimal Amount { get; set; }
        public List<Guid> PassengerIds { get; set; } = new();
    }
}
