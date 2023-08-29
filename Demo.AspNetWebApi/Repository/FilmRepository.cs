using Demo.AspNetWebApi.Data;
using Demo.AspNetWebApi.Dto;
using Demo.AspNetWebApi.Interfaces;
using Demo.DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.AspNetWebApi.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApiDbContext _context;

        public FilmRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Film>> GetFilms()
        {
            return await _context.Films.OrderBy(f => f.Id).ToListAsync();
        }

        public async Task<Film?> GetFilm(int id)
        {
            //return await _context.Films.Where(f => f.Id == id).FirstOrDefaultAsync();
            return await _context.Films.FindAsync(id);
        }

        public decimal GetFilmRating(int filmId)
        {
            var review = _context.Reviews.Where(f => f.Film.Id == filmId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }
        public bool FilmExists(int filmId)
        {
            return _context.Films.Any(f => f.Id == filmId);
        }

        public bool CreateFilm(int creatorId, int categoryId, Film film)
        {
            var filmCreatorEntity = _context.Creators.Where(a => a.Id == creatorId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var filmCreator = new FilmСreator()
            {
                Сreator = filmCreatorEntity,
                Film = film,
            };

            _context.Add(filmCreator);

            var filmCategory = new FilmCategory()
            {
                Category = category,
                Film = film,
            };

            _context.Add(filmCategory);

            _context.Add(film);

            return Save();
        }

        public bool UpdateFilm(int creatorId, int categoryId, Film film)
        {
            _context.Update(film);
            return Save();
        }

        public bool DeleteFilm(Film film)
        {
            _context.Remove(film);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //public async Task<Film> GetFilmTrimToUpper(FilmDto filmCreate)
        //{
        //    var result = await GetFilms();
        //    return result.FirstOrDefault(c => c.Name.Trim().ToUpper() == filmCreate.Name.TrimEnd().ToUpper());
        //}

    }
}
