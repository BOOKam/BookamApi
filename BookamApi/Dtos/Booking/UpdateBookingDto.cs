using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Booking
{
    public class UpdateBookingDto
    {
        public string?  UserId {get; set;}
        public int BusId{get; set;}
        public int RouteId {get; set;}
        public int SeatNumber {get; set;}
    }
}