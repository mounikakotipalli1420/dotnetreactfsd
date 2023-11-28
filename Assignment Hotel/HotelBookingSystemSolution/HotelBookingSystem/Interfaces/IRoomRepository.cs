using HotelBookingSystem.Models;

namespace HotelBookingSystem.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRoomsByHotel(int hotelId);
        void AddRoom(Room room);
        int GetAvailableRoomCount(int hotelId);
        // Add other room-related methods as needed
    }
}
