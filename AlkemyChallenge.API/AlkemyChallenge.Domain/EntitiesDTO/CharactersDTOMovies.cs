using AlkemyChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.EntitiesDTO
{
    public class CharactersDTOMovies
    {
        public int CharacterId { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public List<Movies> Movies { get; set; }

    }
}
