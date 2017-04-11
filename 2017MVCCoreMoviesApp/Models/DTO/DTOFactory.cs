using Movies.Web.Models;
using Movies.Web.Shared;

namespace Movies.Models.DTO
{
    public class DTOFactory : IDTOFactory
    {
        public FilmDTO Map(Film film)
        {
            //TODO: Replace with Automapper?
            return new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                ReleaseYear = film.ReleaseDate.Year(),
                Director = film.Director?.FullName
            };
        }

        public Film Map(FilmDTO filmDTO, Film film)
        {
            //TODO: Finish mapping all of filmDTO
            film.Title = filmDTO.Title;

            return film;
        }
    }
}