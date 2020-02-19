using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class MovieMemoryService : IMovieService
    {
        private readonly List<Movie> movies = new List<Movie>();
        public MovieMemoryService()
        {
            movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 1,
                Name = "Superman",
                ReleaseDate = new DateTime(2020,01,01),
                Starring = "Nick"
            });
            movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 2,
                Name = "Ghost",
                ReleaseDate = new DateTime(2019, 12, 12),
                Starring = "Michael Jackson"
            });
            movies.Add(new Movie
            {
                CinemaId = 2,
                Id = 3,
                Name = "Fight",
                ReleaseDate = new DateTime(2020, 01, 01),
                Starring = "Tommy"
            });
        }
        public Task AddAsync(Movie model)
        {
            var MaxId = movies.Max(x => x.Id);
            model.Id = MaxId + 1;
            movies.Add(model);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Movie movie)
        {
            return Task.Run(() => movies.Remove(movie));
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaid)
        {
            return Task.Run(() => movies.Where(x => x.CinemaId == cinemaid));
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            return Task.Run(() => movies.FirstOrDefault(x => x.Id == id));
        }
    }
}
