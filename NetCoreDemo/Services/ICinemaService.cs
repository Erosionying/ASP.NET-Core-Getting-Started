using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDemo.Models;
namespace NetCoreDemo.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema model);
        Task DeleteAsync(Cinema cinema);
    }
}
