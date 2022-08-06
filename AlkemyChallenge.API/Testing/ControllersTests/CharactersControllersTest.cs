using AlkemyChallenge.AccessData;
using AlkemyChallenge.AccessData.Queries;
using AlkemyChallenge.API.Controllers;
using AlkemyChallenge.Application;
using AlkemyChallenge.Domain.Commands;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Testing
{
    public class CharactersControllersTest
    { 

        [Fact]
        public void GetCharacterByName()
        {

            var character = new CharactersDTO()
            {
                CharacterId = 1,
                Img = "http://img.jpg",
                Name = "Mock name",
                Age = 20,
                Weight = 100,
                History = "Mock History"
            };

            CharactersDTO characterNull = null;

            //Moq library
            var mockCharactersService = new Mock<ICharactersService>();
            mockCharactersService.Setup(x => x.GetCharacterByName("Alladin")).Returns(character);

            var charactersController = new CharactersController(mockCharactersService.Object);

            var result = charactersController.GetCharacterByName("Alladin");
            Assert.IsType<ObjectResult>(result);

            mockCharactersService.Setup(x => x.GetCharacterByName("noExiste")).Returns(characterNull);
            var resultNull = charactersController.GetCharacterByName("noExiste");
            Assert.IsType<StatusCodeResult>(resultNull);
        }
    }
}
