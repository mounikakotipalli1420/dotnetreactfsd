using HotelBookingSystem.Models;

namespace HotelBookingSystem.Interfaces
{
    // IUserRepository.cs
    public interface IUserRepository : IRepository<string, User>
    {
        // Additional user-specific methods if needed
    }

}
