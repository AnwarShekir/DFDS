using DFDS.Persistence.Models;

namespace DFDS.Dto
{
    public class PassengerDto
    {
        public Guid Id { get; set; }
        public int PassportNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public List<Guid> Bookings { get; set; } = new();
    }
}
