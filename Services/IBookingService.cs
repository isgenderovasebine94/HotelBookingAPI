using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking?> CreateAsync(CreateBookingDto dto, int userId);
        Task<bool> DeleteAsync(int id);
    }
}
