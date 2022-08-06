using System;
using System.Collections.Generic;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;

namespace AlkemyChallenge.Domain.Queries
{
    public interface ICharactersQueries
    {
        public List<Characters> GetAllCharacters();
        public Characters GetCharacterById(int CharacterId);
        public CharactersDTO GetCharacterByName(string name);
        public List<CharactersDTO> GetCharactersByAge(int age);
        public List<CharactersDTO> GetCharactersByMovieId(Guid movieId);
        public List<CharactersDTO> GetCharactersByNameAge(string name, int age);
        public List<CharactersDTO> GetCharactersByAgeMovieId(int age, Guid movieId);
        public List<CharactersDTO> GetCharactersByNameMovieId(string name, Guid movieId);
        public List<CharactersDTO> GetCharactersByNameAgeMovieId(string name, int age, Guid movieId);   

    }
}
