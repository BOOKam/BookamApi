using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.EntityFrameworkCore;

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

        public Task<Bus?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bus>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Bus?> GetByIdAsync(int id)
        {
            return await _context.Bus.FirstOrDefaultAsync(c => c.BusId == id);
        }

        // public async Task<Bus?> GetByIdAsync(int id)
        // {
        //     // return await _context.Bus.ToListAsync();
        // }

        public Task<Bus?> UpdateAsync(int id, Bus busModel)
        {
            throw new NotImplementedException();
        }
    }
}