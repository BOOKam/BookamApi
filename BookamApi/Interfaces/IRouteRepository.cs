using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Routes;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface IRouteRepository
    {
        Task<List<Routes>> GetAllRoutesAsync();
        Task<Routes?> GetByIdAsync(int id);
        Task<Routes> CreateAsync(Bus busModel);
        Task<Routes?> UpdateAsync(int id, UpdateRouteDto updateRouteDto);
        Task<Routes?> DeleteAsync(int id);
    }
}