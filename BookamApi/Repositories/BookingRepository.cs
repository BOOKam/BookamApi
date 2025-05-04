using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookamApi.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public BookingRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Booking>> GetBookingAsync()
        {
            var bookings = await _context.Booking.Include(c => c.user).Include(c => c.route).Include(c => c.bus).ToListAsync();
            return bookings;
        }
    }
}