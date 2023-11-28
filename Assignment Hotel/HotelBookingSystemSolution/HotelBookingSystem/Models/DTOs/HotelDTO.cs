namespace HotelBookingSystem.Models.DTOs
{
    public class HotelDTO
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public List<RoomDTO> Rooms { get; set; }
    }

}