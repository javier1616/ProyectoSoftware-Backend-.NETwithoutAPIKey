using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.Entities
{
    public class Movies
    {
        public Guid MovieId { get; set; } //PK
        public string Img { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public int GenreId { get; set; }
        public Genres Genre { get; set; }
        public ICollection<CharactersMovies> CharacterMovies { get; set; } // Reference Property

    }
}
