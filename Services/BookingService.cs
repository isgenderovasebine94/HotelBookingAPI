using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repositories;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingService(
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public async Task<List<Booking>> GetAllAsync()
            => await _bookingRepository.GetAllAsync();

        public async Task<Booking?> GetByIdAsync(int id)
            => await _bookingRepository.GetByIdAsync(id);

        public async Task<Booking?> CreateAsync(CreateBookingDto dto, int userId)
        {
            var room = await _roomRepository.GetByIdAsync(dto.RoomId);

            if (room == null)
                return null;

            var existingBookings = await _bookingRepository.GetAllAsync();

            bool isOverlapping = existingBookings.Any(b =>
                b.RoomId == dto.RoomId &&
                (
                    (dto.CheckIn >= b.CheckIn && dto.CheckIn < b.CheckOut) ||
                    (dto.CheckOut > b.CheckIn && dto.CheckOut <= b.CheckOut) ||
                    (dto.CheckIn <= b.CheckIn && dto.CheckOut >= b.CheckOut)
                )
            );

            if (isOverlapping)
                return null;

            var booking = new Booking
            {
                RoomId = dto.RoomId,
                UserId = userId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut
            };

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();

            room.IsAvailable = false;
            _roomRepository.Update(room);
            await _roomRepository.SaveChangesAsync();

            return booking;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);

            if (booking == null)
                return false;

            var room = await _roomRepository.GetByIdAsync(booking.RoomId);

            if (room != null)
            {
                room.IsAvailable = true;
                _roomRepository.Update(room);
                await _roomRepository.SaveChangesAsync();
            }

            _bookingRepository.Delete(booking);
            await _bookingRepository.SaveChangesAsync();

            return true;
        }
    }
}
