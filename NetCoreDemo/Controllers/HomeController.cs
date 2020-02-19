using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Models;
using NetCoreDemo.Services;
using System.Threading.Tasks;

namespace NetCoreDemo.Controllers
{
    public class HomeController:Controller
    {
        private readonly ICinemaService cinemaServices;

        public HomeController(ICinemaService cinemaServices)
        {
            this.cinemaServices = cinemaServices;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.title = "电影院列表";
            return View(await cinemaServices.GetAllAsync());
        }
        public IActionResult Add()
        {
            ViewBag.title = "添加电影院";
            return View(new Cinema());
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if(ModelState.IsValid)
            {
                await cinemaServices.AddAsync(model);
                
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int cinemaId)
        {
            return View( await cinemaServices.GetByIdAsync(cinemaId));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema model)
        {
            if(ModelState.IsValid)
            {
                var exist = await cinemaServices.GetByIdAsync(model.Id);
                if(exist == null)
                {
                    return NotFound();
                }
                exist.Name = model.Name;
                exist.Location = model.Location;
                exist.Capacity = model.Capacity;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int cinemaId)
        {
            if(ModelState.IsValid)
            {
                var cinemaInfo = await cinemaServices.GetByIdAsync(cinemaId);
                await cinemaServices.DeleteAsync(cinemaInfo);
            }
            return RedirectToAction("Index");
        }
    }
}
