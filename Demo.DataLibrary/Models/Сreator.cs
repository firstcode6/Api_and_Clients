namespace Demo.DataLibrary.Models
{
    public class Сreator // Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public ICollection<FilmСreator> FilmСreators { get; set; }
    }
}
