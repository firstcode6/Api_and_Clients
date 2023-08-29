namespace Demo.DataLibrary.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Budget { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<FilmСreator> FilmСreators { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
