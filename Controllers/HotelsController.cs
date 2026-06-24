using Microsoft.AspNetCore.Http;
using HotelBookingAPI.DTOs;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _hotelService.GetAllAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateHotelDto dto)
        {
            var hotel = await _hotelService.CreateAsync(dto);
            return Ok(hotel);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateHotelDto dto)
        {
            var result = await _hotelService.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok("Hotel updated successfully.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Hotel deleted successfully.");
        }
    }
}
