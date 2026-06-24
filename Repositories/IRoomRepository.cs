using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Room room);
        void Update(Room room);
        void Delete(Room room);
        Task SaveChangesAsync();
    }
}
