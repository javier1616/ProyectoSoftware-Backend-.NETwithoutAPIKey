using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyChallenge.AccessData.Queries
{
    public class CharactersQueries : ICharactersQueries
    {

        private readonly APIDbContext _context;

        public CharactersQueries(APIDbContext context)
        {
            _context = context;
        }


        public List<Characters> GetAllCharacters()
        {

            var characters = _context.Set<Characters>().ToList();

            return characters;
        }

        public Characters GetCharacterById(int characterId)
        {

            var characters = _context.Set<Characters>().Where(c => c.CharacterId == characterId).FirstOrDefault();

            return characters;

        }

        public CharactersDTO GetCharacterByName(string name)
        {

            var characters = _context.Set<Characters>().Where(c => c.Name == name).FirstOrDefault();

            if (characters != null)
            {
                CharactersDTO charactersDTO = new CharactersDTO()
                {
                    CharacterId = characters.CharacterId,
                    Name = characters.Name,
                    Age = characters.Age,
                    History = characters.History,
                    Weight = characters.Weight,
                    Img = characters.Img
                };

                return charactersDTO;

            }

            return null;

        }

        public List<CharactersDTO> GetCharactersByAge(int age)
        {
            var charactersListDTO = new List<CharactersDTO>();

            var charactersList = _context.Set<Characters>().Where(c => c.Age == age).ToList();
            
            if (charactersList != null)
            {
                foreach (Characters characters in charactersList)
                {

                        CharactersDTO charactersDTO = new CharactersDTO()
                        {
                            CharacterId = characters.CharacterId,
                            Name = characters.Name,
                            Age = characters.Age,
                            History = characters.History,
                            Weight = characters.Weight,
                            Img = characters.Img
                        };

                        charactersListDTO.Add(charactersDTO);
                }

                return charactersListDTO;
            }

            return null;

        }

        public List<CharactersDTO> GetCharactersByMovieId(Guid movieId)
        {

            List<CharactersDTO> characterList = new List<CharactersDTO>();
            var listCharacterMovies = _context.Set<CharactersMovies>().Where(cm => cm.MoviesId == movieId).ToList();

            if (listCharacterMovies != null)
            {
                foreach (CharactersMovies elem in listCharacterMovies)
                {
                    var characters = _context.Set<Characters>().Where(c => c.CharacterId == elem.CharactersCharacterId).FirstOrDefault();

                    CharactersDTO charactersDTO = new CharactersDTO()
                    {
                        CharacterId = characters.CharacterId,
                        Name = characters.Name,
                        Age = characters.Age,
                        History = characters.History,
                        Weight = characters.Weight,
                        Img = characters.Img
                    };


                    characterList.Add(charactersDTO);
                }

                return characterList;
            }

            return null;

            
        }


        public List<CharactersDTO> GetCharactersByNameAge(string name, int age)
        {
            List<CharactersDTO> charactersDTOList = new List<CharactersDTO>();

            var charactersList = _context.Set<Characters>().Where(c => c.Age == age && c.Name == name).ToList();

            foreach (var characters in charactersList)
            {

                CharactersDTO charactersDTO = new CharactersDTO()
                {
                    CharacterId = characters.CharacterId,
                    Name = characters.Name,
                    Age = characters.Age,
                    History = characters.History,
                    Weight = characters.Weight,
                    Img = characters.Img
                };

                charactersDTOList.Add(charactersDTO);
            }

                return charactersDTOList;

        }


        public List<CharactersDTO> GetCharactersByAgeMovieId(int age, Guid movieId)
        {
            var charactersListAgeMovieId = new List<CharactersDTO>();

            var charactersList = this.GetCharactersByMovieId(movieId);

            foreach (CharactersDTO character in charactersList)
            {
                if (character.Age == age) charactersListAgeMovieId.Add(character);
            }

            return charactersListAgeMovieId;

        }

        public List<CharactersDTO> GetCharactersByNameMovieId(string name, Guid movieId)
        {
            var charactersListNameMovieId = new List<CharactersDTO>();

            var charactersList = this.GetCharactersByMovieId(movieId);

            foreach (CharactersDTO character in charactersList)
            {
                if (character.Name == name) charactersListNameMovieId.Add(character);
            }

            return charactersListNameMovieId;

        }

        public List<CharactersDTO> GetCharactersByNameAgeMovieId(string name, int age, Guid movieId)
        {
            var charactersListNameAgeMovieId = new List<CharactersDTO>();

            var charactersList = this.GetCharactersByNameMovieId(name, movieId);

            foreach (CharactersDTO character in charactersList)
            {
                if (character.Age == age) charactersListNameAgeMovieId.Add(character);
            }

            return charactersListNameAgeMovieId;

        }

    }
}