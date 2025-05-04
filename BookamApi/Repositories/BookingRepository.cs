using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Dtos.Booking;
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

        public async Task<Booking?> GetByIdAsync(int id)
        {
            var booking = await _context.Booking.Include(c => c.user).Include(c => c.route).Include(c => c.bus).FirstOrDefaultAsync(x => x.BookingId == id);
            return booking;
        }
       public async Task<Booking> createAsync(Booking create)
        {

            var user = await _context.Users.FindAsync(create.UserId);
            if (user == null)
                throw new Exception("User not found");
            var bus = await _context.Bus.FindAsync(create.BusId);
            if (bus == null)
                throw new Exception("Bus not found");

            // Validate seat availability
            if (!bus.AvailableSeats.Contains(create.SeatNumber))
                throw new Exception("Selected seat is not available");

            // Move seat from AvailableSeats to BookedSeats
            bus.AvailableSeats.Remove(create.SeatNumber);
            bus.BookedSeats.Add(create.SeatNumber);

            // Update SeatsRemaining
            bus.SeatsRemaining = bus.AvailableSeats.Count;

            // Complete the booking
            create.BookingDate = DateTime.UtcNow;
            create.Completed = true;

            await _context.Booking.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }


        public async Task<Booking?> UpdateAsync(int id, UpdateBookingDto updateBookingDto)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == id);
            if (booking == null) return null;
            booking.UserId = updateBookingDto.UserId;
            booking.BusId = updateBookingDto.BusId;
            booking.RouteId = updateBookingDto.RouteId;
            booking.SeatNumber = updateBookingDto.SeatNumber;
            booking.BookingDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> DeleteAsync(int id)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == id);
            if (booking == null) return null;
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}