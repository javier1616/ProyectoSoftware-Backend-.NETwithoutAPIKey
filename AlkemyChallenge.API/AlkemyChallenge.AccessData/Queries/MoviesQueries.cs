using System;
using System.Collections.Generic;
using System.Linq;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;

namespace AlkemyChallenge.AccessData.Queries
{
    public class MoviesQueries : IMoviesQueries
    {

        private readonly APIDbContext _context;

        public MoviesQueries(APIDbContext context)
        {
            _context = context;
        }

        public List<Movies> GetAllMovies()
        {

            var moviesList = _context.Set<Movies>().ToList();

            return moviesList;

        }

        public Movies GetMovieById(Guid id)
        {

            var moviesList = _context.Set<Movies>().Where(m => m.MovieId == id).FirstOrDefault();

            return moviesList;

        }


        public Movies GetMovieByTitle(string title)
        {
            var movies = _context.Set<Movies>().Where(c => c.Title == title).FirstOrDefault();

            return movies;
        }

        public List<MoviesDTO> GetMoviesByGenreId(int genreId)
        {
            var moviesListDTO = new List<MoviesDTO>();

            var moviesList = _context.Set<Movies>().Where(m => m.GenreId == genreId).ToList();

            if (moviesList != null)
            {
                foreach (Movies movies in moviesList)
                {

                    MoviesDTO moviesDTO = new MoviesDTO()
                    {
                        MovieId = movies.MovieId,
                        Title = movies.Title,
                        Date = movies.Date,
                        Score = movies.Score,
                        Img = movies.Img
                    };

                    moviesListDTO.Add(moviesDTO);
                }

                return moviesListDTO;
            }

            return null;

        }

        public List<MoviesDTO> GetMoviesOrderByDate(string order)
        {

            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();
            List<Movies> moviesList = new List<Movies>();

            if (order == "ASC")
            {
                moviesList = _context.Set<Movies>().OrderBy(m => m.Date).ToList();
            }
            else if (order == "DESC")
            {
                moviesList = _context.Set<Movies>().OrderByDescending(m => m.Date).ToList();
            }
            else
            {
                moviesList = null;
            }

            if (moviesList != null)
            {
                foreach (Movies movies in moviesList)
                {

                    MoviesDTO moviesDTO = new MoviesDTO()
                    {
                        MovieId = movies.MovieId,
                        Title = movies.Title,
                        Date = movies.Date,
                        Score = movies.Score,
                        Img = movies.Img,
                        GenreId = movies.GenreId
                    };


                    moviesDTOList.Add(moviesDTO);
                }

                return moviesDTOList;
            }

            return null;

        }

        public List<MoviesDTO> GetMoviesByTitleGenreId(string title, int genreId)
        {
            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();

            var moviesList = _context.Set<Movies>().Where(m => m.Title == title && m.GenreId == genreId).ToList();

            foreach (var movies in moviesList)
            {

                MoviesDTO moviesDTO = new MoviesDTO()
                {
                    MovieId = movies.MovieId,
                    Title = movies.Title,
                    Score = movies.Score,
                    GenreId = movies.GenreId,
                    Date = movies.Date,
                    Img = movies.Img
                };

                moviesDTOList.Add(moviesDTO);
            }

            return moviesDTOList;

        }


        public List<MoviesDTO> GetMoviesByTitleOrderByDate(string title, string order)
        {
            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();
            List<Movies> moviesList = new List<Movies>();

            if (order == "ASC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.Title == title).OrderBy(m => m.Date).ToList();
            }
            else if (order == "DESC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.Title == title).OrderByDescending(m => m.Date).ToList();
            }
            else
            {
                moviesList = null;
            }

            if (moviesList != null)
            {
                foreach (Movies movies in moviesList)
                {

                    MoviesDTO moviesDTO = new MoviesDTO()
                    {
                        MovieId = movies.MovieId,
                        Title = movies.Title,
                        Date = movies.Date,
                        Score = movies.Score,
                        Img = movies.Img,
                        GenreId = movies.GenreId
                    };


                    moviesDTOList.Add(moviesDTO);
                }

                return moviesDTOList;
            }

            return null;
        }

        public List<MoviesDTO> GetMoviesByGenreIdOrderByDate(int genreId, string order)
        {
            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();
            List<Movies> moviesList = new List<Movies>();

            if (order == "ASC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.GenreId == genreId).OrderBy(m => m.Date).ToList();
            }
            else if (order == "DESC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.GenreId == genreId).OrderByDescending(m => m.Date).ToList();
            }
            else
            {
                moviesList = null;
            }

            if (moviesList != null)
            {
                foreach (Movies movies in moviesList)
                {

                    MoviesDTO moviesDTO = new MoviesDTO()
                    {
                        MovieId = movies.MovieId,
                        Title = movies.Title,
                        Date = movies.Date,
                        Score = movies.Score,
                        Img = movies.Img,
                        GenreId = movies.GenreId
                    };


                    moviesDTOList.Add(moviesDTO);
                }

                return moviesDTOList;
            }

            return null;
        }

        public List<MoviesDTO> GetMoviesByTitleGenreIdOrderByDate(string title, int genreId, string order)
        {
            List<MoviesDTO> moviesDTOList = new List<MoviesDTO>();
            List<Movies> moviesList = new List<Movies>();

            if (order == "ASC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.GenreId == genreId && m.Title == title)
                        .OrderBy(m => m.Date).ToList();
            }
            else if (order == "DESC")
            {
                moviesList = _context.Set<Movies>().Where(m => m.GenreId == genreId && m.Title == title)
                        .OrderByDescending(m => m.Date).ToList();
            }
            else
            {
                moviesList = null;
            }

            if (moviesList != null)
            {
                foreach (Movies movies in moviesList)
                {

                    MoviesDTO moviesDTO = new MoviesDTO()
                    {
                        MovieId = movies.MovieId,
                        Title = movies.Title,
                        Date = movies.Date,
                        Score = movies.Score,
                        Img = movies.Img,
                        GenreId = movies.GenreId
                    };


                    moviesDTOList.Add(moviesDTO);
                }

                return moviesDTOList;
            }

            return null;
        }
    }

}