using HotelBookingSystem.Models;
using HotelBookingSystem.Models.DTOs;

namespace HotelBookingSystem.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
        IEnumerable<Hotel> SearchHotels(string location, decimal? minPrice, decimal? maxPrice, string amenities);
    }
}
