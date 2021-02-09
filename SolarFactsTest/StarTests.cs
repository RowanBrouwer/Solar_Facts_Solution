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
    public class StarTests
    {
        public ISolarSystem ISolar = new SolarSystemInterface();

        [Fact]
        public async Task GetPlanetsByStar()
        {
            StarModel star = await ISolar.GetStarById(1);
            Assert.Equal(1, star.Id);
        }

        [Fact]
        public async Task GetByDistanceToSunAscending()
        {
            long? lastDistance = null;
            SolarSystemModel solarSystem = await ISolar.GetSolarSystemById(1);
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetByDistanceToSunAscending(solarSystem);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                if (lastDistance == null)
                {
                    lastDistance = planet.OrbitDistanceInKM;
                }
                else
                {
                    Assert.True(planet.OrbitDistanceInKM >= lastDistance);
                    lastDistance = planet.OrbitDistanceInKM;
                }   
            }
        }

        [Fact]
        public async Task GetPlanetsByAmountOfMoonsDescending()
        {
            int? LastAmountOfMoons = null;
            SolarSystemModel solarSystem = await ISolar.GetSolarSystemById(1);
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetPlanetsByAmountOfMoonsDescending(solarSystem);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                if (LastAmountOfMoons == null)
                {
                    LastAmountOfMoons = planet.KnownMoons;
                }
                else
                {
                    Assert.True(planet.KnownMoons <= LastAmountOfMoons);
                    LastAmountOfMoons = planet.KnownMoons;
                } 
            }
        }

        [Fact]
        public async Task GetByNameLenghtDescending()
        {
            int? LastNameLenght = null;
            SolarSystemModel solarSystem = await ISolar.GetSolarSystemById(1);
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetByNameLenghtDescending(solarSystem);

            foreach (PlanetAndDwarfPlanet planet in result)
            {
                if (LastNameLenght == null)
                {
                    LastNameLenght = planet.Name.Count();
                }
                else
                {
                    Assert.True(planet.Name.Count() <= LastNameLenght);
                    LastNameLenght = planet.Name.Count();
                }
            }
        }

        [Fact]
        public async Task GetByNameLenghtascending()
        {
            int? LastNameLenght = null;
            SolarSystemModel solarSystem = await ISolar.GetSolarSystemById(1);
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetByNameLenghtAscending(solarSystem);

            foreach (PlanetAndDwarfPlanet planet in result)
            {
                if (LastNameLenght == null)
                {
                    LastNameLenght = planet.Name.Count();
                }
                else
                {
                    Assert.True(planet.Name.Count() >= LastNameLenght);
                    LastNameLenght = planet.Name.Count();
                }
            }
        }

        [Fact]
        public async Task GetClosestPlanetsByStar()
        {
            SolarSystemModel solarSystem = await ISolar.GetSolarSystemById(1);
            ClosestPlanets result = await ISolar.GetClosestPlanetsBySolarSystem(solarSystem);

            Assert.Equal("earth", result.PlanetA.Name.ToLower());
            Assert.Equal("venus", result.PlanetB.Name.ToLower());
        }
    }
}
