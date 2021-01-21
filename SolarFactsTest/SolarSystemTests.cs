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
        public void GetSolarSystemById()
        {
            var solarSystem = ISolar.GetSolarSystemById(1);
            Assert.Equal(1, solarSystem.Id);
        }

        [Fact]
        public void GetTotalAmountOfBodysInSolarSystem()
        {
            var solarSystem = ISolar.GetSolarSystemById(1);
            int result = ISolar.GetTotalAmountOfBodies(solarSystem);
            Assert.Equal(195, result);
        }

        [Fact]
        public void GetAverageAmountOfMoonsByPlanetInSolarSystem()
        {
            var solarSystem = ISolar.GetSolarSystemById(1);
            double result = ISolar.GetAverageAmountOfMoonsByPlanetsInSolarSystem(solarSystem);
            Assert.Equal(13, result, 1);
        }

        [Fact]
        public void GetTotalAmountOfMoons()
        {
            var solarSystem = ISolar.GetSolarSystemById(1);
            int result = ISolar.TotalAmountOfMoons(solarSystem);
            Assert.Equal(181, result);
        }

        [Fact]
        public void GetStarsBySolarSystem()
        {
            var solarSystem = ISolar.GetSolarSystemById(1);
            List<Star> result = ISolar.GetStarsBySolarSystem(solarSystem);
            Assert.True(result.Count == 1);
            Assert.Equal(1, result[0].Id);
        }
    }
}
