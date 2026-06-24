using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync()
            => await _context.Rooms.ToListAsync();

        public async Task<Room?> GetByIdAsync(int id)
            => await _context.Rooms.FindAsync(id);

        public async Task AddAsync(Room room)
            => await _context.Rooms.AddAsync(room);

        public void Update(Room room)
            => _context.Rooms.Update(room);

        public void Delete(Room room)
            => _context.Rooms.Remove(room);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
