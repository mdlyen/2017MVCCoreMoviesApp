using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Web.Models;

namespace _2017MVCCoreMoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _movieDbContext;

        public HomeController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Films()
        {
            return View(_movieDbContext.Films.OrderBy(x => x.Title));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
