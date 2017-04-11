using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models.DTO;
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

        public IActionResult Index()
        {
            var allFilms = _movieRepository.GetAllFilms();

            return View(allFilms);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmDTO = _movieRepository.GetFilmDTO(id.Value);
            if (filmDTO == null)
            {
                return NotFound();
            }

            return View(filmDTO);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmDTO = _movieRepository.GetFilmDTO(id.Value);
            if (filmDTO == null)
            {
                return NotFound();
            }
            return View(filmDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseYear,Director")] FilmDTO filmDTO)
        {
            if (id != filmDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieRepository.SaveFilmDTO(filmDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_movieRepository.FilmDTOExists(filmDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(filmDTO);
        }
    }
}
