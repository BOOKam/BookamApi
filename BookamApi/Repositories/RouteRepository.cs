using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Data;
using BookamApi.Dtos.Routes;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookamApi.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;
        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Routes> CreateAsync(Routes routeModel)
        {
            await _context.Routes.AddAsync(routeModel);
            await _context.SaveChangesAsync();
            return routeModel;
        }

        public async Task<Routes?> DeleteAsync(int id)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(c => c.RouteId == id);
            if (route == null)
            {
                return null;
            }
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<List<Routes>> GetAllRoutesAsync()
        {
            return await _context.Routes.Include(c => c.Buses).ToListAsync();
        }

        public async Task<Routes?> GetByIdAsync(int id)
        {
            var route = await _context.Routes.Include(c => c.Buses).FirstOrDefaultAsync(x => x.RouteId == id);
            return route;
        }

        public async Task<List<Routes>?> SearchAsync([FromQuery] string Origin, [FromQuery] string Destination)
        {
            var route = _context.Routes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(Origin))
            {
                route = route.Where(x => x.Origin.Contains(Origin));
            }
            if (!string.IsNullOrWhiteSpace(Destination))
            {
                route = route.Where(x => x.Destination.Contains(Destination));
            }
            return await route.ToListAsync();
        }
        
        public async Task<Routes?> UpdateAsync(int id, UpdateRouteDto updateRouteDto)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
            if (route == null) return null;

            route.Origin = updateRouteDto.Origin;
            route.Destination = updateRouteDto.Destination;
            route.Price = updateRouteDto.Price;
            route.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return route;

        }
    }
}

    