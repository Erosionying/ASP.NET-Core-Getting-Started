using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class CinemaMemoryService:ICinemaService
    {
        private readonly List<Cinema> cinemas = new List<Cinema>();
        public CinemaMemoryService()
        {
            cinemas.Add(new Cinema
            {
                Id = 1,
                Name = "City Cinema",
                Location = "Road ABC, No.123",
                Capacity = 1000
            });
            cinemas.Add(new Cinema
            {
                Id = 2,
                Name = "Fly Cinema",
                Location = "Road Hello, No.1024",
                Capacity = 500
            });
        }

        public Task AddAsync(Cinema model)
        {
            var MaxId = cinemas.Max(x => x.Id);
            model.Id = MaxId + 1;
            cinemas.Add(model);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Cinema cinema)
        {

            return Task.Run(() => cinemas.Remove(cinema));
        }

        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return Task.Run(() => cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => cinemas.FirstOrDefault(x => x.Id == id));
        }

    }
}
