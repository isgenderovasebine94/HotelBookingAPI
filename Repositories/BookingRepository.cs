using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync()
            => await _context.Bookings.ToListAsync();

        public async Task<Booking?> GetByIdAsync(int id)
            => await _context.Bookings.FindAsync(id);

        public async Task AddAsync(Booking booking)
            => await _context.Bookings.AddAsync(booking);

        public void Delete(Booking booking)
            => _context.Bookings.Remove(booking);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
