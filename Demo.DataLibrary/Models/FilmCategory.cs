﻿namespace Demo.DataLibrary.Models
{
    public class FilmCategory
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }
        public Film Film { get; set; }
        public Category Category { get; set; }
    }
}
