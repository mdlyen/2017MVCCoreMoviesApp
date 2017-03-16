using System.Collections.Generic;
using System.Linq;
using Movies.Models.DTO;
using Movies.Web.Models;

namespace Movies.Web.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDTOFactory _dtoFactory;
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext, IDTOFactory dtoFactory)
        {
            _movieDbContext = movieDbContext;
            _dtoFactory = dtoFactory;
        }

        public IEnumerable<FilmDTO> GetAllFilms()
        {
            var returnVar = new List<FilmDTO>();
            var films = _movieDbContext.Films.OrderBy(x => x.Title); 

            foreach (var film in films)
            {
                returnVar.Add(_dtoFactory.Map(film));
            }

            return returnVar;
        }

        public FilmDTO GetFilmDTO(int filmid)
        {
            return _dtoFactory.Map(_movieDbContext.Films.Single(x => x.Id == filmid));
        }
    }
}