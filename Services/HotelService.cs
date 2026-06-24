using HotelBookingAPI.DTOs;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repositories;

namespace HotelBookingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _hotelRepository.GetAllAsync();
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public async Task<Hotel> CreateAsync(CreateHotelDto dto)
        {
            var hotel = new Hotel
            {
                Name = dto.Name,
                Location = dto.Location,
                Description = dto.Description
            };

            await _hotelRepository.AddAsync(hotel);
            await _hotelRepository.SaveChangesAsync();

            return hotel;
        }

        public async Task<bool> UpdateAsync(int id, CreateHotelDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel == null)
                return false;

            hotel.Name = dto.Name;
            hotel.Location = dto.Location;
            hotel.Description = dto.Description;

            _hotelRepository.Update(hotel);
            await _hotelRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel == null)
                return false;

            _hotelRepository.Delete(hotel);
            await _hotelRepository.SaveChangesAsync();

            return true;
        }
    }
}
