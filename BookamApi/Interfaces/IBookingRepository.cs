using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Booking;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingAsync();
        Task<Booking> createAsync(Booking create);
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking?> UpdateAsync(int id, UpdateBookingDto updateBookingDto);
        Task<Booking?> DeleteAsync(int id);
    }
}