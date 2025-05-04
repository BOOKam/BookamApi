using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingAsync();
    }
}