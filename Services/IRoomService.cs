using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task<Room> CreateAsync(CreateRoomDto dto);
        Task<bool> UpdateAsync(int id, CreateRoomDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
