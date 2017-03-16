using Microsoft.AspNetCore.Mvc;
using Movies.Web.Services;

namespace _2017MVCCoreMoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Films()
        {
            var allFilms = _movieRepository.GetAllFilms();

            return View(allFilms);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
