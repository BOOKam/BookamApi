using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Booking;
using BookamApi.Dtos.Bus;
using BookamApi.Dtos.Routes;
using BookamApi.Dtos.User;
using BookamApi.Models;

namespace BookamApi.Mappers
{
    public static class BookingMapper
    {
        public static Booking ToBooking (this CreateBookingDto create)
        {
            return new Booking {
                UserId = create.UserId,
                BusId = create.BusId,
                RouteId = create.RouteId,
                SeatNumber = create.SeatNumber
            };
        }

        public static BookingDto bookingDto (this Booking booking)
        {
            return new BookingDto{
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                BusId =  booking.BusId,
                RouteId = booking.RouteId,
                SeatNumber = booking.SeatNumber,
                Completed = booking.Completed,
                CheckedIn = booking.CheckedIn,
                BookingDate = booking.BookingDate,
                user = booking.user != null ? new List<BookUserDto> { booking.user.ToBookUserDto() } : new List<BookUserDto>(),
                bus = booking.bus != null ? new List<BookBusDto> { booking.bus.ToBookBusDto() } : new List<BookBusDto>(),
                routes = booking.route != null ? new List<BookRouteDto> { booking.route.ToBookRouteDto() } : new List<BookRouteDto>()
            };
        }
    }
}