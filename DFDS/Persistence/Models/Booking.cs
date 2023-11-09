using DFDS.Utils;

namespace DFDS.Persistence.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public int BookingNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DepatureDate { get; set; }
        public Cities DepartureFrom { get; set; }
        public Cities Destination { get; set; }
        public bool IsPaid { get; set; }
        public decimal Amount { get; set; }
        public List<Passenger> Passengers { get; set; } = new();

    }
}
