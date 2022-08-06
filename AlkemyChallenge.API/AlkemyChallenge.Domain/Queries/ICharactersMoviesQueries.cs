using System;
using System.Collections.Generic;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;

namespace AlkemyChallenge.Domain.Queries
{
    public interface ICharactersMoviesQueries
    {
        public List<CharactersMovies> GetCharactersByMovieId(Guid movieId);
        public List<CharactersMovies> GetCharactersMoviesByCharactersId(int id);
    }
}
