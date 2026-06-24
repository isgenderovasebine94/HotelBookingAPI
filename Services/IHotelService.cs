using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);
        Task<Hotel> CreateAsync(CreateHotelDto dto);
        Task<bool> UpdateAsync(int id, CreateHotelDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
