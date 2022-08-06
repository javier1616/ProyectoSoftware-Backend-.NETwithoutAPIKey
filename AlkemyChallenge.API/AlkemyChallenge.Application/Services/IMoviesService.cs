using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace AlkemyChallenge.Application
{
    public interface IMoviesService
    {
        public List<MoviesDTOReduced> GetAllMovies();
        public List<MoviesDTO> GetMovieByIdAndCharacters(Guid movieId);
        public List<MoviesDTO> GetAllMoviesAndCharacters();
        public Movies CreateMovie(MoviesDTO moviesDTO);
        public bool RemoveMovie(Guid id);
        public Movies UpdateMovie(Guid id, MoviesDTO moviesDTO);

        public List<MoviesDTO> GetMoviesByTitleGenreIdOrderByDate(string title, int genreId, string order);
        public List<MoviesDTO> GetMoviesByTitleGenreId(string title, int genreId);
        public List<MoviesDTO> GetMoviesByTitleOrderByDate(string title, string order);
        public List<MoviesDTO> GetMoviesByGenreIdOrderByDate(int genreId, string order);
        public MoviesDTO GetMovieByTitle(string title);
        public List<MoviesDTO> GetMoviesByGenreId(int genreId);
        public List<MoviesDTO> GetMoviesOrderByDate(string order);
        public List<MoviesDTO> GetAllMoviesDTO();

    }
}
