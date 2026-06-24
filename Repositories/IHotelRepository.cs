using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);
        Task AddAsync(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
        Task SaveChangesAsync();
    }
}
