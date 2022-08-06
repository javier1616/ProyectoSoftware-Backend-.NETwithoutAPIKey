using AlkemyChallenge.Domain.Commands;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;
using System;
using System.Collections.Generic;

namespace AlkemyChallenge.Application
{
    public class MoviesService : IMoviesService
    {
        private readonly IGenericsRepository _repository;
        private readonly IMoviesQueries _moviesQueries;
        private readonly ICharactersMoviesQueries _charactersMoviesQueries;
        private readonly ICharactersQueries _charactersQueries;

        public MoviesService(IGenericsRepository repository, IMoviesQueries moviesqueries, ICharactersMoviesQueries charactersMoviesQueries, ICharactersQueries charactersQueries)
        {
            _repository = repository;
            _moviesQueries = moviesqueries;
            _charactersMoviesQueries = charactersMoviesQueries;
            _charactersQueries = charactersQueries;
        }


        public List<MoviesDTOReduced> GetAllMovies()
        {
    
            List<MoviesDTOReduced> moviesDTOList = new List<MoviesDTOReduced>();

            var moviesList = _moviesQueries.GetAllMovies();

            foreach (var m in moviesList)
            {

                var movie = new MoviesDTOReduced
                {
                    Img = m.Img,
                    Title = m.Title,
                    Date = m.Date
                };

                moviesDTOList.Add(movie);

            }

            return moviesDTOList;
        }

        public List<MoviesDTO> GetAllMoviesDTO()
        {

            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();
            var moviesList = _moviesQueries.GetAllMovies();

            foreach (var m in moviesList)
            {

                var movie = new MoviesDTO
                {
                    MovieId = m.MovieId,
                    Img = m.Img,
                    Title = m.Title,
                    Date = m.Date,
                    Score = m.Score,
                    GenreId = m.GenreId
                };

                moviesDTOList.Add(movie);

            }

            return moviesDTOList;
        }

        public List<MoviesDTO> GetAllMoviesAndCharacters()
        {
        
            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();

            var moviesList = _moviesQueries.GetAllMovies();

            foreach (var m in moviesList)
            {

                var movie = new MoviesDTO
                {
                    MovieId = m.MovieId,
                    Img = m.Img,
                    Title = m.Title,
                    Date = m.Date,
                    Score = m.Score,
                    Character = new List<CharactersDTO>(),
                    GenreId = m.GenreId
                };

                var characterMoviesList = _charactersMoviesQueries.GetCharactersByMovieId(m.MovieId);

                foreach (var c in characterMoviesList)
                {
                    var characters = _charactersQueries.GetCharacterById(c.CharactersCharacterId);

                    var charactersDTO = new CharactersDTO()
                    {
                        CharacterId = characters.CharacterId,
                        Name = characters.Name,
                        Img = characters.Img,
                        History = characters.History,
                        Age = characters.Age,
                        Weight = characters.Weight,
                    };

                    movie.Character.Add(charactersDTO);

                }

                moviesDTOList.Add(movie);

            }

            return moviesDTOList;
        }

        public List<MoviesDTO> GetMovieByIdAndCharacters(Guid movieId)
        {
            var movies = new List<MoviesDTO>();

            return movies;
        
        }

        public Movies CreateMovie(MoviesDTO moviesDTO)
        {

            var entity = new Movies
            {
                MovieId = moviesDTO.MovieId,
                Img = moviesDTO.Img,
                Title = moviesDTO.Title,
                Date = moviesDTO.Date,
                Score = moviesDTO.Score,
                GenreId = moviesDTO.GenreId
            };

            _repository.Add<Movies>(entity);

            return entity;

        }


        public bool RemoveMovie(Guid id)
        {

            bool flagDeBorrado = false;
            var entity = _moviesQueries.GetMovieById(id);
            if (entity != null)
            {
                _repository.Remove<Movies>(entity);
                flagDeBorrado = true;
            }
            return flagDeBorrado;
        }

        public Movies UpdateMovie(Guid id, MoviesDTO moviesDTO)
        {

            var entity = _moviesQueries.GetMovieById(id);

            if (entity != null)
            {
                entity.Img = moviesDTO.Img;
                entity.Title = moviesDTO.Title;
                entity.Date = moviesDTO.Date;
                entity.Score = moviesDTO.Score;
                entity.GenreId = moviesDTO.GenreId;
                
                _repository.Update<Movies>(entity);

            }

            return entity;
        }

        public MoviesDTO GetMovieByTitle(string title)
        {

            var movie = _moviesQueries.GetMovieByTitle(title);

            if (movie != null)
            {
                MoviesDTO moviesDTO = new MoviesDTO()
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    Date = movie.Date,
                    Score = movie.Score,
                    Img = movie.Img,
                    GenreId = movie.GenreId
                };

                return moviesDTO;
            }

            return null;

        }

        public List<MoviesDTO> GetMoviesByGenreId(int genreId)
        {

            var moviesList = _moviesQueries.GetMoviesByGenreId(genreId);

            return moviesList;

        }

        public List<MoviesDTO> GetMoviesOrderByDate(string order)
        {

            var moviesList = _moviesQueries.GetMoviesOrderByDate(order);

            return moviesList;

        }

        public List<MoviesDTO> GetMoviesByTitleGenreId(string title, int genreId)
        {
            var moviesList = _moviesQueries.GetMoviesByTitleGenreId(title, genreId);

            return moviesList;

        }

        public List<MoviesDTO> GetMoviesByTitleOrderByDate(string title, string order)
        {
            var moviesList = _moviesQueries.GetMoviesByTitleOrderByDate(title, order);

            return moviesList;

        }

        public List<MoviesDTO> GetMoviesByGenreIdOrderByDate(int genreId, string order)
        {
            var moviesList = _moviesQueries.GetMoviesByGenreIdOrderByDate(genreId, order);

            return moviesList;

        }

        public List<MoviesDTO> GetMoviesByTitleGenreIdOrderByDate(string title, int genreId, string order)
        {
            var moviesList = _moviesQueries.GetMoviesByTitleGenreIdOrderByDate(title, genreId, order);

            return moviesList;

        }
    }
}
