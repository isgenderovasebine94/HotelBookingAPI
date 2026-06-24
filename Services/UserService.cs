using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repositories;

namespace HotelBookingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            var existingUser =
                await _userRepository.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
                return null;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user =
                await _userRepository.GetByUsernameAsync(dto.Username);

            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash
            );

            if (!isValid)
                return null;

            return _jwtService.GenerateToken(
                user.Id,
                user.Username
            );
        }
    }
}
