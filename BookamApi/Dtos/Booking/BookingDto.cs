using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Dtos.Routes;
using BookamApi.Dtos.User;

namespace BookamApi.Dtos.Booking
{
    public class BookingDto
    {
        public int BookingId {get; set;}
        public string?  UserId {get; set;}
        public List<BookUserDto> user {get; set;} = new List<BookUserDto>(); 
        public int BusId{get; set;}
        public List<BookBusDto> bus {get; set;} = new List<BookBusDto>();
        public int RouteId {get; set;}
        public List<BookRouteDto> routes {get; set;} = new List<BookRouteDto>();
        public int SeatNumber {get; set;}
        public bool Completed {get; set;}
        public bool CheckedIn {get; set;}
        public DateTime BookingDate {get; set;}
    }
}