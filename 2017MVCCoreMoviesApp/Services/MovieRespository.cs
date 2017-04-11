using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var films = _movieDbContext.Films
                .Include(x=>x.Director)
                .OrderBy(x => x.Title); 

            foreach (var film in films)
            {
                returnVar.Add(_dtoFactory.Map(film));
            }

            return returnVar;
        }

        public FilmDTO GetFilmDTO(int filmid)
        {
            return _dtoFactory.Map(_movieDbContext.Films.Include(x=>x.Director).Single(x => x.Id == filmid));
        }

        public bool SaveFilmDTO(FilmDTO filmDTO)
        {
            Film film;
            
            try
            {
                // Map DTO to entity
                film = _dtoFactory.Map(filmDTO, _movieDbContext.Films.Single(x => x.Id == filmDTO.Id));

                // Update object in context.
                _movieDbContext.Update(film);
            }
            catch
            {
                return false;
            }

            // Let's make sure we only updated 1 record and return record from database if successful.
            switch (_movieDbContext.SaveChanges())
            {
                case 1:
                    return true;
                default:
                    throw new DbUpdateException("Error updating film record.", innerException: null);
            }
        }

        public bool FilmDTOExists(int id)
        {
            return _movieDbContext.Films.Any(x => x.Id == id);
        }
    }
}