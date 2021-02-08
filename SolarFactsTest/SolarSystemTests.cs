using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolarFactsTest
{
    public class SolarSystemTests
    {
        public ISolarSystem ISolar = new SolarSystemInterface();

        [Fact]
        public async Task GetSolarSystemById()
        {
            var solarSystem = await ISolar.GetSolarSystemById(1);
            Assert.Equal(1, solarSystem.Id);
        }

        [Fact]
        public async Task GetTotalAmountOfBodysInSolarSystem()
        {
            var solarSystem = await ISolar.GetSolarSystemById(1);
            int result = await ISolar.GetTotalAmountOfBodies(solarSystem);
            Assert.Equal(195, result);
        }

        [Fact]
        public async Task GetAverageAmountOfMoonsByPlanetInSolarSystem()
        {
            var solarSystem = await ISolar.GetSolarSystemById(1);
            double result = await ISolar.GetAverageAmountOfMoonsByPlanetsInSolarSystem(solarSystem);
            Assert.Equal(13, result, 1);
        }

        [Fact]
        public async Task GetTotalAmountOfMoons()
        {
            var solarSystem = await ISolar.GetSolarSystemById(1);
            int result = await ISolar.TotalAmountOfMoons(solarSystem);
            Assert.Equal(181, result);
        }

        [Fact]
        public async Task GetStarsBySolarSystem()
        {
            var solarSystem = await ISolar.GetSolarSystemById(1);
            List<StarModel> result = await ISolar.GetStarsBySolarSystem(solarSystem);
            Assert.True(result.Count == 1);
            Assert.Equal(1, result[0].Id);
        }
    }
}
