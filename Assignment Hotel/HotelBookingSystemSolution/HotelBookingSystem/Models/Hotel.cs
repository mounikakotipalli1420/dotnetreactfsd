﻿namespace HotelBookingSystem.Models
{
    public class Hotel
    {
       
            public int HotelId { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            
            public List<Room> Rooms { get; set; }
        
    }
}
