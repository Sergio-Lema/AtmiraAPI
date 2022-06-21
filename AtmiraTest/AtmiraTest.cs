using AtmiraAPI.Controllers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace AtmiraWebAPITest
{
    public class AtmiraTest
    {
        readonly Dictionary<string, string> inMemorySettings = new()
        {
            { "ApiSettings:baseUrl", "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=DEMO_KEY" },
            { "ApiSettings:token", "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb" }
        };


        [Fact]
        public async void GetListAsteroid_ShouldReturnNotFoundObject_IfPlanetNameIsEmpty()
        {
            //Arrange
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
            string? planetName = string.Empty;

            //Act
            var controller = new RootController(configuration);
            var result = await controller.GetListAsteroid(planetName);

            //Assert
            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundObjectResult>();
        }

        [Fact]
        public async void GetListAsteroid_ShouldReturnOKObject_IfPlanetNameIsEarth()
        {
            //Arrange
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
            string? planetName = "Earth";

            //Act
            var controller = new RootController(configuration);
            var result = await controller.GetListAsteroid(planetName);

            //Assert
            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkObjectResult>();
        }

        [Fact]
        public async void GetListAsteroid_ShouldReturnBadRequest_IfBaseUrlIsWrong()
        {
            //Arrange
            Dictionary<string, string> inWrongMemorySettings = new()
            {
                {"ApiSettings:baseUrl", "hhtps://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key" }

            };

            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(inWrongMemorySettings).Build();
            string? planetName = "Earth";

            //Act
            var controller = new RootController(configuration);
            var result = await controller.GetListAsteroid(planetName);

            //Assert
            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>();
        }
    }
}