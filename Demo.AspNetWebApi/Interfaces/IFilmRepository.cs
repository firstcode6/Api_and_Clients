using Demo.AspNetWebApi.Dto;
using Demo.DataLibrary.Models;

namespace Demo.AspNetWebApi.Interfaces
{
    public interface IFilmRepository
    {
        Task<ICollection<Film>> GetFilms();
        Task<Film?> GetFilm(int id);
        decimal GetFilmRating(int filmId);
        bool FilmExists(int filmId);
        bool CreateFilm(int creatorId, int categoryId, Film film);
        bool UpdateFilm(int creatorId, int categoryId, Film film);
        bool DeleteFilm(Film film);
        bool Save();

        //Task<Film> GetFilmTrimToUpper(FilmDto filmCreate);
    }
}
