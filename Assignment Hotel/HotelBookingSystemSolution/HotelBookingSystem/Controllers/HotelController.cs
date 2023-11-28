using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    // HotelController.cs
    [ApiController]
    [Route("api/hotels")]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly HotelRepository _hotelRepository;
        private readonly RoomRepository _roomRepository;
        private RoomRepository? roomRepository;

        public HotelController(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
        }
        [HttpGet("{hotelId}/room/count")]
        public ActionResult<int> GetAvailableRoomCount(int hotelId)
        {
            var count = _roomRepository.GetAvailableRoomCount(hotelId);
            return Ok(count);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels()
        {
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult AddHotel(Hotel hotel)
        {
            _hotelRepository.AddHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, Hotel hotel)
        {
            if (id != hotel.HotelId)
                return BadRequest();

            _hotelRepository.UpdateHotel(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
            return NoContent();
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<Hotel>> SearchHotels(
        [FromQuery] string location,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] string amenities)
        {
            var filteredHotels = _hotelRepository.SearchHotels(location, minPrice, maxPrice, amenities);
            return Ok(filteredHotels);
        }
    }

}
