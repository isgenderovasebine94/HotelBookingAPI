namespace HotelBookingAPI.DTOs
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal PricePerNight { get; set; }
        public int HotelId { get; set; }
    }
}
