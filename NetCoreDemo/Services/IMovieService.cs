using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public interface IMovieService
    {
        Task AddAsync(Movie model);
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaid);
        Task<Movie> GetByIdAsync(int id);
        Task DeleteAsync(Movie movie);
    }
}
