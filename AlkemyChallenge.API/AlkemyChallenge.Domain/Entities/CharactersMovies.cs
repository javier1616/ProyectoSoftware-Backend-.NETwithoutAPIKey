using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.Entities
{
    public class CharactersMovies
    {
        public Guid CharactersMoviesId { get; set; } //PK
        public int CharactersCharacterId { get; set; }
        //public Guid MoviesMoviesId { get; set; }
        public Guid MoviesId { get; set; }
        public Characters Character { get; set; }
        public Movies Movie { get; set; }
        
    }
}
