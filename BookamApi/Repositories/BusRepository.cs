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
            bus.BusNumber = updateBusDto.BusNumber;
            bus.ArrivalTime = updateBusDto.ArrivalTime;
            bus.DepartureTime = updateBusDto.DepartureTime;
            bus.Capacity = updateBusDto.Capacity;
            bus.RouteId = updateBusDto.RouteId;

            await _context.SaveChangesAsync();
            return bus;

        }
    }
}