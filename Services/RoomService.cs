using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repositories;

namespace HotelBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<Room>> GetAllAsync()
            => await _roomRepository.GetAllAsync();

        public async Task<Room?> GetByIdAsync(int id)
            => await _roomRepository.GetByIdAsync(id);

        public async Task<Room> CreateAsync(CreateRoomDto dto)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                Type = dto.Type,
                PricePerNight = dto.PricePerNight,
                HotelId = dto.HotelId,
                IsAvailable = true
            };

            await _roomRepository.AddAsync(room);
            await _roomRepository.SaveChangesAsync();

            return room;
        }

        public async Task<bool> UpdateAsync(int id, CreateRoomDto dto)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return false;

            room.RoomNumber = dto.RoomNumber;
            room.Type = dto.Type;
            room.PricePerNight = dto.PricePerNight;
            room.HotelId = dto.HotelId;

            _roomRepository.Update(room);
            await _roomRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return false;

            _roomRepository.Delete(room);
            await _roomRepository.SaveChangesAsync();

            return true;
        }
    }
}
