using System;
using System.Collections.Generic;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;

namespace AlkemyChallenge.Domain.Queries
{
    public interface IMoviesQueries
    {
        public List<Movies> GetAllMovies();
        public Movies GetMovieById(Guid id);
        public Movies GetMovieByTitle(string title);
        public List<MoviesDTO> GetMoviesByGenreId(int genreId);
        public List<MoviesDTO> GetMoviesOrderByDate(string order);
        public List<MoviesDTO> GetMoviesByTitleGenreId(string title, int genreId);
        public List<MoviesDTO> GetMoviesByTitleOrderByDate(string title, string order);
        public List<MoviesDTO> GetMoviesByGenreIdOrderByDate(int genreId, string order);
        public List<MoviesDTO> GetMoviesByTitleGenreIdOrderByDate(string title, int genreId, string order);
    }
}
