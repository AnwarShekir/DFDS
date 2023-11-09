namespace DFDS.Persistence.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public int PassportNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public List<Booking> Bookings { get; set; } = new();

    }
}
