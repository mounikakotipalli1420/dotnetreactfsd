using HotelBookingSystem.Interfaces;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;

namespace HotelBookingSystem.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        public void AddHotel(Hotel hotel)
        {
            hotelRepository.AddHotel(hotel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _hotelRepository.UpdateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public IEnumerable<Hotel> SearchHotels(string location, decimal? minPrice, decimal? maxPrice, string amenities)
        {
            return _hotelRepository.SearchHotels(location, minPrice, maxPrice, amenities);
        }
    }

}
    