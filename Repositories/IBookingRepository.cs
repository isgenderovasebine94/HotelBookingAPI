using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        void Delete(Booking booking);
        Task SaveChangesAsync();
    }
}
