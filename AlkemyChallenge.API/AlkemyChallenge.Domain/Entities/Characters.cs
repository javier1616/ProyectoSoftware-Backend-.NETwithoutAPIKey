using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.Entities
{
    public class Characters
    {
        public int CharacterId { get; set; } //PK
        public string Img { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public ICollection<CharactersMovies> CharacterMovies { get; set; }  //Reference Property

    }
}
