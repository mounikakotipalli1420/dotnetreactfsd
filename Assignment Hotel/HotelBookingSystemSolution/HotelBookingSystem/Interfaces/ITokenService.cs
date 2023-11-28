using HotelBookingSystem.Models.DTOs;

namespace HotelBookingSystem.Interfaces
{



    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
