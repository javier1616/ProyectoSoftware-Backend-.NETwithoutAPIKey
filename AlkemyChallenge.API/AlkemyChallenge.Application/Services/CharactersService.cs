using AlkemyChallenge.Domain.Commands;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyChallenge.Application
{
    public class CharactersService : ICharactersService
    {

        private readonly IGenericsRepository _repository;
        private readonly ICharactersQueries _charactersQueries;
        private readonly IMoviesQueries _moviesQueries;
        private readonly ICharactersMoviesQueries _charactersMoviesQueries;


        public CharactersService(IGenericsRepository repository, ICharactersQueries characterQueries, ICharactersMoviesQueries charactersMoviesQueries, IMoviesQueries moviesQueries)
        {
            _repository = repository;
            _charactersQueries = characterQueries;
            _moviesQueries = moviesQueries;
            _charactersMoviesQueries = charactersMoviesQueries;

        }

        public List<CharactersDTOReduced> GetAllCharacters()
        {

            List<Characters> charactersList;
            List<CharactersDTOReduced> charactersDTOList = new List<CharactersDTOReduced>();

            charactersList = _charactersQueries.GetAllCharacters();

            foreach (Characters c in charactersList)
            {

                CharactersDTOReduced characterDTO = new CharactersDTOReduced
                {
                    Img = c.Img,
                    Name = c.Name
                };

                charactersDTOList.Add(characterDTO);
                
            }

            return charactersDTOList;

         }

        public CharactersDTOMovies GetCharactersDetails(int id)
        {         

            var character = _charactersQueries.GetCharacterById(id);

            if (character != null)
            {

                var charactersMovies = _charactersMoviesQueries.GetCharactersMoviesByCharactersId(id);


                var entity = new CharactersDTOMovies()
                {
                    CharacterId = character.CharacterId,
                    Img = character.Img,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    History = character.History,
                    Movies = new List<Movies>()
                };


                foreach (CharactersMovies c in charactersMovies)
                {

                    var movie = _moviesQueries.GetMovieById(c.MoviesId);

                    entity.Movies.Add(movie);

                }

                return entity;

            }

            return null;

        }

        public Characters CreateCharacter(CharactersDTO characterDTO)
         {


            var entity = new Characters
            {
                Img = characterDTO.Img,
                Name = characterDTO.Name,
                Age = characterDTO.Age,
                Weight = characterDTO.Weight,
                History = characterDTO.History
            };

            _repository.Add<Characters>(entity);
            
            return entity;

         }


         public bool RemoveCharacter(int id)
         {

            bool flagDeBorrado = false;
            var entity = _charactersQueries.GetCharacterById(id);
            if (entity != null)
            {
                _repository.Remove<Characters>(entity);
                flagDeBorrado = true;
            }
            return flagDeBorrado;
         }        
        
         public CharactersDTO UpdateCharacter(int id,CharactersDTO characterDTO)
         {

            var entity = _charactersQueries.GetCharacterById(id);   //Se fija si existe

            if (entity != null)
            {
                entity.Img = characterDTO.Img;
                entity.Name = characterDTO.Name;
                entity.Age = characterDTO.Age;
                entity.Weight = characterDTO.Weight;
                entity.History = characterDTO.History;

                _repository.Update<Characters>(entity);

                characterDTO.CharacterId = id;

                return characterDTO;

            }

            return null;
         }

         public CharactersDTO GetCharacterByName(string name)
         {
            CharactersDTO character;

            character = _charactersQueries.GetCharacterByName(name);
            
            return character;

         }

        public List<CharactersDTO> GetCharactersByAge(int age)
        {
            var charactersList = _charactersQueries.GetCharactersByAge(age);

            if (charactersList.Count() > 0)
            {
                return charactersList;
            }
            else return null;

        }

        public List<CharactersDTO> GetCharactersByMovieId(Guid movieId)
        {
            var charactersList = _charactersQueries.GetCharactersByMovieId(movieId);

            return charactersList;
        }

        public List<CharactersDTO> GetCharactersByAgeMovieId(int age, Guid movieId)
        {
            var charactersList = _charactersQueries.GetCharactersByMovieId(movieId);

            return charactersList;

        }

        public List<CharactersDTO> GetCharactersByNameAge(string name, int age)
        {
            var charactersList = _charactersQueries.GetCharactersByNameAge(name, age);

            return charactersList;

        }

        public List<CharactersDTO> GetCharactersByNameMovieId(string name, Guid movieId)
        {
            var charactersList = _charactersQueries.GetCharactersByNameMovieId(name, movieId);

            return charactersList;

        }

        public List<CharactersDTO> GetCharactersByNameAgeMovieId(string name, int age,Guid movieId)
        {
            var charactersList = _charactersQueries.GetCharactersByNameAgeMovieId(name, age, movieId);

            return charactersList;

        }
    }

}
