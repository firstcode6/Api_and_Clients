using Demo.DataLibrary.Models;

namespace Demo.ClientBlazorApp.Interfaces
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
    }
}
