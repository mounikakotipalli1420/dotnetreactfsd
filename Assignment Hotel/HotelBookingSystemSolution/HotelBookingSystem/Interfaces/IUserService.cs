using HotelBookingSystem.Models.DTOs;

namespace HotelBookingSystem.Interfaces
{


    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}
