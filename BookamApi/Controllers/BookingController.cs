using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Booking;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseApiController
    {
        private readonly IBookingRepository _bookingRepo;
        
        public BookingController(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingRepo.GetBookingAsync();
            return Success(bookings.Select(b => b.bookingDto()), "Operation Successful");
        }
        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            if (booking == null) return Error("Not Found", null, "404");

            return Success(booking.bookingDto(), "Operation Successful");
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateBookingDto create)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            var createBook = create.ToBooking();
            try{
                var booking = await _bookingRepo.createAsync(createBook);
                return Success(booking.bookingDto(), "Operation Successful");
            }
            catch (Exception ex)
            {
                return Error("An error occurred while creating the booking", ex, "500");
            }
        }
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            var booking = await _bookingRepo.UpdateAsync(id, updateBookingDto);
            return Success(booking.bookingDto(), "Operation Successful");
        }
        // [HttpDelete("delete")]
        // public async 
    }
}