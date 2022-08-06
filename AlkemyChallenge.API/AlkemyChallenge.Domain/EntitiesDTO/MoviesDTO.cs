using AlkemyChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.EntitiesDTO
{
    public class MoviesDTO
    {
        public Guid MovieId { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public int GenreId { get; set; }
        public ICollection<CharactersDTO> Character { get; set; } 

    }
}
