using System.Collections.Generic;
using Movies.Models.DTO;

namespace Movies.Web.Services
{
    public interface IMovieRepository
    {
        IEnumerable<FilmDTO> GetAllFilms();
        FilmDTO GetFilmDTO(int filmid);
    }
}