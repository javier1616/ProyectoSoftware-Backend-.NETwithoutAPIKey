using AlkemyChallenge.Application;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.API.Controllers
{
    [ApiController]
    [Route("/movies")]
    public class MoviesController : ControllerBase
    {

        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllMovies()
        {

            var movies = _service.GetAllMovies();            

            if (movies != null)
            {
                return Ok(movies);
            }
            else
            {
                return StatusCode(404);
            }

        }

        [Authorize]
        [HttpGet("details")]
        public IActionResult GetAllMoviesAndCharacters()
        {

            var movies = _service.GetAllMoviesAndCharacters();

            if (movies != null)
            {
                return Ok(movies);
            }
            else
            {
                return StatusCode(404);
            }

        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MoviesDTO moviesDTO)
        {

            var movie = _service.CreateMovie(moviesDTO);

            if (movie != null)
            {
                return StatusCode(201, movie);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult RemoveMovie([FromQuery(Name = "id")] Guid id)
        {

            var movie = _service.RemoveMovie(id);

            if (movie)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateMovie([FromQuery(Name = "id")] Guid id, [FromBody] MoviesDTO moviesDTO)
        {

            var movie = _service.UpdateMovie(id, moviesDTO);

            if (movie != null)
            {
                return StatusCode(201, movie);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("title")]
        public IActionResult GetMovieByTitle([FromQuery(Name = "title")] string title)
        {

            var movie = _service.GetMovieByTitle(title);

            if (movie != null)
            {
                return StatusCode(200, movie);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("genre")]
        public IActionResult GetMovieByGenreId([FromQuery(Name = "genreId")] int genreId)
        {

            var movies = _service.GetMoviesByGenreId(genreId);

            if (movies != null)
            {
                return StatusCode(200, movies);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("search")]
        public IActionResult GetMoviesByTitleGenreIdOrderByDate([FromQuery(Name = "title")] string title,
                                                            [FromQuery(Name = "genreId")] int genreId,
                                                        [FromQuery(Name = "order")] string order)

        {

            List<MoviesDTO> moviesList = new List<MoviesDTO>(); ;

            if (title != null && genreId > 0 && order != null)
            {
                moviesList = _service.GetMoviesByTitleGenreIdOrderByDate(title, genreId, order);
            }
            else if (title != null && genreId > 0)
            {
                moviesList = _service.GetMoviesByTitleGenreId(title, genreId);
            }
            else if (title != null && order != null)
            {
                moviesList = _service.GetMoviesByTitleOrderByDate(title, order);
            }
            else if (genreId > 0 && order != null)
            {
                moviesList = _service.GetMoviesByGenreIdOrderByDate(genreId, order);
            }
            else if (title != null)
            {
                var movie = _service.GetMovieByTitle(title);
                if (movie != null) moviesList.Add(movie);
            }
            else if (genreId > 0)
            {
                var movies = _service.GetMoviesByGenreId(genreId);
                foreach (MoviesDTO m in movies)
                {
                    moviesList.Add(m);
                }
            }

            else if (order != null)
            {
                moviesList = _service.GetMoviesOrderByDate(order);
            }
            else
            {
                moviesList = this._service.GetAllMoviesDTO();
            }


            //var json = "{name:" + name +",age:"+age.ToString()+",movieId:"+movieId.ToString()+"}";

            if (moviesList != null)
            {
                return Ok(moviesList);
            }
            else
            {
                return StatusCode(400);
            }
        }

}
}
