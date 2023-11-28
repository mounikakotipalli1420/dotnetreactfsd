namespace HotelBookingSystem.Models.DTOs
{
    
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public decimal Price { get; set; }
        
        public RoomDTO(Room room)
        {
            RoomId = room.RoomId;
            RoomNumber = room.RoomNumber;
            Price = room.Price;
            
        }

        
        public RoomDTO(int roomId, string roomNumber, decimal price)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            Price = price;
            
        }
    }

}
