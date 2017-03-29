using Microsoft.AspNetCore.Mvc;
using Movies.Web.Services;

namespace MoviesApp.Controllers
{
    public class FilmController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public FilmController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allFilms = _movieRepository.GetAllFilms();

            return View(allFilms);
        }
    }
}
