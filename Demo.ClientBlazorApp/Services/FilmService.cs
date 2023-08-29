using Demo.ClientBlazorApp.Interfaces;
using Demo.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ClientBlazorApp.Services
{
    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Film>> GetFilms()
        {
            //_httpClient.PostAsync("api/Film", film);
            //_httpClient.DeleteAsync("api/Film" + id);
            //_httpClient.PutAsync("api/Film" + id);
            return await _httpClient.GetFromJsonAsync<List<Film>>("api/Film");
        }

    }
}
