﻿namespace HotelBookingSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; } 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }

        
        public Room Room { get; set; }
    }
}
