using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Models;
using NetCoreDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Controllers
{
    public class MovieController:Controller
    {
        private readonly IMovieService movieServices;
        private readonly ICinemaService cinemaServices;

        public MovieController(IMovieService movieService
            ,ICinemaService cinemaService)
        {
            movieServices = movieService;
            cinemaServices = cinemaService;
        }
        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await cinemaServices.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}这个电影院上映的电影有:";
            ViewBag.CinemaId = cinemaId;

            return View( await movieServices.GetByCinemaAsync(cinemaId));
        }
        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie { CinemaId = cinemaId });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if(ModelState.IsValid)
            {
                await movieServices.AddAsync(movie);
            }
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId});
        }
        public async Task<IActionResult> Edit(int movieId)
        {
            return View(await movieServices.GetByIdAsync(movieId));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie model)
        {
            if(ModelState.IsValid)
            {
                var Movieinfo = await movieServices.GetByIdAsync(model.Id);
                if(Movieinfo == null)
                {
                    return NotFound();
                }
                Movieinfo.Name = model.Name;
                Movieinfo.Starring = model.Starring;
                Movieinfo.ReleaseDate = model.ReleaseDate;
            }
            return RedirectToAction("Index",new { cinemaId = model.Id});
        }
        public async Task<IActionResult> Delete(int movieId)
        {
            int Id = 0;
            if(ModelState.IsValid)
            {
                var movieDetail = await movieServices.GetByIdAsync(movieId);
                Id = movieDetail.CinemaId;
                if(movieDetail == null)
                {
                    return NotFound();
                }
                await movieServices.DeleteAsync(movieDetail);
            }

            return RedirectToAction("Index", new { cinemaId = Id });
        }
    }
}
