namespace HotelBookingAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = null!; // Single, Double, Suite
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = new();
    }
}
