namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
      
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
        public object Hotel { get; internal set; }
        public decimal Price { get; internal set; }
    }
}
