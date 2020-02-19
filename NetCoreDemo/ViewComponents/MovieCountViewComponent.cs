using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.ViewComponents
{
    public class MovieCountViewComponent:ViewComponent
    {
        private readonly IMovieService movieServices;

        public MovieCountViewComponent(IMovieService movieServices)
        {
            this.movieServices = movieServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int cinemaId)
        {
            var movies = await movieServices.GetByCinemaAsync(cinemaId);
            var count = movies.Count();

            return View(count);
        }
    }
}
