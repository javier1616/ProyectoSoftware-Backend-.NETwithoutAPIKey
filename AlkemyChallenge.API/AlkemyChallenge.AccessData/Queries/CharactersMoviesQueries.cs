using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyChallenge.AccessData.Queries
{
    public class CharactersMoviesQueries : ICharactersMoviesQueries
    {

        private readonly APIDbContext _context;

        public CharactersMoviesQueries(APIDbContext context)
        {
            _context = context;
        }

        public List<CharactersMovies> GetCharactersByMovieId(Guid movieId)
        {

            var charactersMovies = _context.Set<CharactersMovies>().Where(c => c.MoviesId == movieId).ToList();

            return charactersMovies;

        }

        public List<CharactersMovies> GetCharactersMoviesByCharactersId(int id)
        {

            var charactersMovies = _context.Set<CharactersMovies>().Where(c => c.CharactersCharacterId == id).ToList();

            return charactersMovies;

        }
    }
}