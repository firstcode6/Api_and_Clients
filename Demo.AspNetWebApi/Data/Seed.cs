using Demo.DataLibrary.Models;

namespace Demo.AspNetWebApi.Data
{
    public class Seed
    {
        private readonly ApiDbContext _context;
        public Seed(ApiDbContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.FilmСreators.Any())
            {
                var filmСreators = new List<FilmСreator>()
                {
                    new FilmСreator()
                    {
                        Film = new Film()
                        {
                            Name = "Schindler's List",
                            Date = new DateTime(1993,11,30),
                            Budget = "$22 000 000",
                            FilmCategories = new List<FilmCategory>()
                            {
                                new FilmCategory { Category = new Category() { Name = "Drama"}},
                                new FilmCategory { Category = new Category() { Name = "History"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Schindler's List",Text = "I have wanted to watch \"Schindler's List\" for years, but could not bring myself to do so because I don't want to be disappointed. \"Schindler's List\" is phenomenally powerful and effective in portraying the historical atrocities.", Rating = 10,
                                Reviewer = new Reviewer(){ FirstName = "Steven", LastName = "Davidtz" } },
                                new Review { Title="Schindler's List", Text = "The movie started out pretty innocently, and for the first 20 minutes, I was wondering where the movie was going. Then it started to happen.", Rating = 9,
                                Reviewer = new Reviewer(){ FirstName = "Ralph", LastName = "Keneally" } },
                                new Review { Title="Schindler's List",Text = "This was, and will forever be, one of the best films ever made, not just the ultimate story of The Holocaust, but truly as masterpiece, one of the best.", Rating = 8,
                                Reviewer = new Reviewer(){ FirstName = "Sleepin", LastName = "Dragon" } },
                            }
                        },
                        Сreator = new Сreator()
                        {
                            FirstName = "Steven",
                            LastName = "Spielberg",
                            Country = new Country()
                            {
                                Name = "USA"
                            }
                        }
                    },
                    new FilmСreator()
                    {
                        Film = new Film()
                        {
                            Name = "Interstellar",
                            Date = new DateTime(2014,11,6),
                            Budget = "$165 000 000",
                            FilmCategories = new List<FilmCategory>()
                            {
                                new FilmCategory { Category = new Category() { Name = "Fantastic"}},
                                new FilmCategory { Category = new Category() { Name = "Drama"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Interstellar", Text = "Interstellar, though ambitious and thrilling at points, is too complicated and doesn't reach its full potential.", Rating = 10,
                                Reviewer = new Reviewer(){ FirstName = "Dwight", LastName = "Brown" } },
                                new Review { Title= "Interstellar",Text = "It’s a contemplative adventure and an emotional exploration that captivated me from its opening moments.", Rating = 9,
                                Reviewer = new Reviewer(){ FirstName = "Keith", LastName = "Garlington" } },
                                new Review { Title= "Interstellar", Text = "…uses sci-fi to go beyond into the philosophical and spiritual beyond that few other epics can reach….", Rating = 9,
                                Reviewer = new Reviewer(){ FirstName = "Eddie", LastName = "Harrison" } },
                            }
                        },
                        Сreator = new Сreator()
                        {
                            FirstName = "Christopher",
                            LastName = "Nolan",
                            Country = new Country()
                            {
                                Name = "United Kingdom"
                            }
                        }
                    },
                     
                };
                _context.FilmСreators.AddRange(filmСreators);
                _context.SaveChanges();
            }

        }


    }
}
