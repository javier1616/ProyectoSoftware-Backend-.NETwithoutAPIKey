using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace AlkemyChallenge.Application
{
    public interface ICharactersService
    {
        public List<CharactersDTOReduced> GetAllCharacters();
        public CharactersDTOMovies GetCharactersDetails(int id);
        public Characters CreateCharacter(CharactersDTO characterDTO);
        public bool RemoveCharacter(int id);
        public CharactersDTO UpdateCharacter(int id,CharactersDTO characterDTO);
        public CharactersDTO GetCharacterByName(string name);
        public List<CharactersDTO> GetCharactersByAge(int age);
        public List<CharactersDTO> GetCharactersByMovieId(Guid movieId);
        public List<CharactersDTO> GetCharactersByNameAgeMovieId(string name, int age, Guid movieId);
        public List<CharactersDTO> GetCharactersByNameAge(string name, int age);
        public List<CharactersDTO> GetCharactersByNameMovieId(string name,Guid movieId);
        public List<CharactersDTO> GetCharactersByAgeMovieId(int age, Guid movieId);

    }
}
