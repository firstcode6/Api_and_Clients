namespace Demo.DataLibrary.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Сreator> Сreators { get; set; }
    }
}
