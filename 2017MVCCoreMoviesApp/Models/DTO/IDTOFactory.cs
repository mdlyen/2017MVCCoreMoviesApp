using Movies.Web.Models;

namespace Movies.Models.DTO
{
    public interface IDTOFactory
    {
        FilmDTO Map(Film film);
        Film Map(FilmDTO filmDTO, Film film);
    }
}