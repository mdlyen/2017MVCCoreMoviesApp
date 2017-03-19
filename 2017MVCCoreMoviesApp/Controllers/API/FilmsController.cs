using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Movies.Models.DTO;
using Movies.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApp.Controllers.API
{
    [Route("api/films")]
    public class FilmsController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public FilmsController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<FilmDTO> Get()
        {
            return _movieRepository.GetAllFilms();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public FilmDTO Get(int id)
        {
            return _movieRepository.GetFilmDTO(id);
        }
    }
}
