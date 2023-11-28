using HotelBookingSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using HotelBookingSystem.Contexts;

using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repositories
{
    public class HotelRepository : IRepository<string, Hotel>
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _context.Hotels.Find(id);
        }

        public void AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if(hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Hotel> SearchHotels(string location, decimal? minPrice, decimal? maxPrice, string amenities)
        {
            var query = _context.Hotels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(h => h.Location.Contains(location, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(h => h.Rooms.Any(r => r.Price >= minPrice.Value));
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(h => h.Rooms.Any(r => r.Price <= maxPrice.Value));
            }

            if (!string.IsNullOrWhiteSpace(amenities))
            {
                // Add logic to filter by amenities
                // For example: query = query.Where(h => h.Amenities.Contains(amenities));
            }

            return query.ToList();
        }

        public Hotel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }

}
