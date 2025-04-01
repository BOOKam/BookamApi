using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Dtos.Routes;
using BookamApi.Interfaces;
using BookamApi.Models;

namespace BookamApi.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;
        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Routes> CreateAsync(Bus busModel)
        {
            throw new NotImplementedException();
        }

        public Task<Routes?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Routes>> GetAllRoutesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Routes?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Routes?> UpdateAsync(int id, UpdateRouteDto updateRouteDto)
        {
            throw new NotImplementedException();
        }
    }
}

    