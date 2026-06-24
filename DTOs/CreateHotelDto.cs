namespace HotelBookingAPI.DTOs
{
    public class CreateHotelDto
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
