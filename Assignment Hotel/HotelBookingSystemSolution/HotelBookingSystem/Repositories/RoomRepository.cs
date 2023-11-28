using HotelBookingSystem.Contexts;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repositories
{
    // RoomRepository.cs
    public class RoomRepository : <int, Room>
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int GetAvailableRoomCount(int hotelId)
        {
            return _context.Rooms.Count(r => r.HotelId == hotelId);
        }

        public IEnumerable<Room> GetRoomsByHotelId(int hotelId)
        {
            return _context.Rooms.Where(r => r.HotelId == hotelId).ToList();
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }

}
