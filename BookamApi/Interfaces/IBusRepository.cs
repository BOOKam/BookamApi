using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface IBusRepository
    {
        Task<List<Bus>> GetAllAsync();
        Task<Bus?> GetByIdAsync(int id);
        Task<Bus> CreateAsync(Bus busModel);
        Task<Bus?> UpdateAsync(int id, Bus busModel);
        Task<Bus?> DeleteAsync(int id);
    }
}