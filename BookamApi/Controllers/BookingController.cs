using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseApiController
    {
        private readonly IBookingRepository _bookingRepository;
        
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetBookingAsync();
            return Success(bookings, "Operation Successful");
        }
        
    }
}