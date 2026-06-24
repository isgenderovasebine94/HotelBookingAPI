namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Room> Rooms { get; set; } = new();
    }
}
