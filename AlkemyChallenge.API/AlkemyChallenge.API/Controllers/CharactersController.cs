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
    [Route("/characters")]
    public class CharactersController : ControllerBase
    {

        private readonly ICharactersService _service;
        public CharactersController(ICharactersService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllCharacters()
        {

            var characters = _service.GetAllCharacters();       

            if (characters != null)
            {
                return StatusCode(200,characters);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("details")]
        public IActionResult GetCharactersDetails([FromQuery(Name = "id")] int id)
        {

            var characters = _service.GetCharactersDetails(id);

           

            if (characters != null)
            {
                //evita object cycle
                var json = JsonConvert.SerializeObject(characters, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                return Ok(json);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateCharacter([FromBody] CharactersDTO characterDTO)
        {

            var character = _service.CreateCharacter(characterDTO);

            if (character != null)
            {
                return StatusCode(201,character);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult RemoveCharacter([FromQuery(Name = "id")] int id)
        {
            
            var character = _service.RemoveCharacter(id);

            if (character)
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
        public IActionResult UpdateCharacter([FromQuery(Name = "id")] int id, [FromBody] CharactersDTO characterDTO)
        {

            var character = _service.UpdateCharacter(id,characterDTO);

            if (character != null)
            {
                return StatusCode(201,character);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("name")]
        public IActionResult GetCharacterByName([FromQuery(Name = "name")] string name)
        {

            var character = _service.GetCharacterByName(name);

            if (character != null)
            {
                return StatusCode(200, character);
            } 
            else
            {
                return StatusCode(404);
            }

        }

        [Authorize]
        [HttpGet("age")]
        public IActionResult GetCharactersByAge([FromQuery(Name = "age")] int age)
        {

            var character = _service.GetCharactersByAge(age);

            if (character != null)
            {
                return StatusCode(200,character);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("movie")]
        public IActionResult GetCharactersByMovieId([FromQuery(Name = "movieId")] Guid movieId)
        {

            var character = _service.GetCharactersByMovieId(movieId);

            if (character != null)
            {
                return StatusCode(200,character);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpGet("search")]
        public IActionResult GetCharactersByNameAgeOrMovies([FromQuery(Name = "name")] string name,
                                                            [FromQuery(Name = "age")] int age,
                                                        [FromQuery(Name = "movieId")] Guid movieId)

        {

            List<CharactersDTO> charactersList = new List<CharactersDTO>(); ;

            if (name != null && age != 0 && movieId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                charactersList = _service.GetCharactersByNameAgeMovieId(name, age, movieId);
            }
            else if (name != null && age != 0)
            {
                charactersList = _service.GetCharactersByNameAge(name, age);
            }
            else if (name != null && movieId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                charactersList = _service.GetCharactersByNameMovieId(name, movieId);
            }
            else if (age != 0 && movieId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                charactersList = _service.GetCharactersByAgeMovieId(age, movieId);
            }
            else if (name != null)
            {
                var character = _service.GetCharacterByName(name);
                if(character != null) charactersList.Add(character);
            }
            else if (age != 0)
            {
                var characters = _service.GetCharactersByAge(age);
                foreach(CharactersDTO c in characters)
                {
                    charactersList.Add(c);
                }
            }

            else if (movieId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                charactersList = _service.GetCharactersByMovieId(movieId);
            }


           //var json = "{name:" + name +",age:"+age.ToString()+",movieId:"+movieId.ToString()+"}";
            
            if (charactersList != null && charactersList.Count() > 0)
            {
                return Ok(charactersList);
            }
            else
            {
                return StatusCode(400);
            }

        }

    }

}
