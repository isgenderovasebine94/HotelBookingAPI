using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IUserService
    {
        Task<User?> RegisterAsync(RegisterDto dto);

        Task<string?> LoginAsync(LoginDto dto);
    }
}
