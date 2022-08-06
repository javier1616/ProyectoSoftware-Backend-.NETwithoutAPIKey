using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.Entities
{
    public class Genres
    {
        public int GenreId { get; set; } //PK
        public string Img { get; set; }
        public string Name { get; set; }
        public ICollection<Movies> Movies { get; set; } // Reference Property
    }
}
