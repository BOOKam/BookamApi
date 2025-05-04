using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Dtos.Bus;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BookamApi.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDbContext _context;
        public BusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bus> CreateAsync(Bus busModel)
        {
            await _context.Bus.AddAsync(busModel);
            // Generate FreeSeats based on capacity
            busModel.AvailableSeats = Enumerable.Range(1, busModel.Capacity).ToList();

            busModel.SeatsRemaining = busModel.AvailableSeats.Count();
            // Optionally initialize BookedSeats as empty
            busModel.BookedSeats = new List<int>();
            await _context.SaveChangesAsync();
            return busModel;
            
        }

        public async Task<Bus?> DeleteAsync(int id)
        {
            var bus = await _context.Bus.FirstOrDefaultAsync(x => x.BusId == id);
            if (bus == null) return null;
            _context.Bus.Remove(bus);
            await _context.SaveChangesAsync();
            return bus;

        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _context.Bus.ToListAsync();
        }

        public async Task<Bus?> GetByIdAsync(int id)
        {
            return await _context.Bus.FirstOrDefaultAsync(c => c.BusId == id);
        }

        public async Task<Bus?> UpdateAsync(int id, UpdateBusDto updateBusDto)
        {
            var bus = await _context.Bus.FirstOrDefaultAsync( x => x.BusId == id);

            if (bus == null) return null;
            if (!string.IsNullOrWhiteSpace(updateBusDto.BusNumber))
                bus.BusNumber = updateBusDto.BusNumber;
        
            if (updateBusDto.ArrivalTime != default)
                bus.ArrivalTime = updateBusDto.ArrivalTime;
                
            if (updateBusDto.DepartureTime != default)
                bus.DepartureTime = updateBusDto.DepartureTime;
                
            if (updateBusDto.Capacity != default)
                bus.Capacity = updateBusDto.Capacity;
                
            if (updateBusDto.RouteId != default)
                bus.RouteId = updateBusDto.RouteId;

            await _context.SaveChangesAsync();
            return bus;

        }
    }
}