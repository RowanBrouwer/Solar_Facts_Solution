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
        public async void GetPlanetsByStar()
        {
            Star star = await ISolar.GetStarById(1);
            Assert.Equal(1, star.Id);
        }

        [Fact]
        public async void GetByDistanceToSunAscending()
        {
            long? lastDistance = null;
            SolarSystem solarSystem = await ISolar.GetSolarSystemById(1);
            List<PlanetAndDwarfPlanet> result = await ISolar.GetByDistanceToSunAscending(solarSystem);
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
        public async void GetPlanetsByAmountOfMoonsDescending()
        {
            int? LastAmountOfMoons = null;
            SolarSystem solarSystem = await ISolar.GetSolarSystemById(1);
            List<PlanetAndDwarfPlanet> result = await ISolar.GetClosestPlanetsBySolarSystem(solarSystem);
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
        public async void GetByNameLenghtDescending()
        {
            int? LastNameLenght = null;
            SolarSystem solarSystem = await ISolar.GetSolarSystemById(1);
            List<PlanetAndDwarfPlanet> result = await ISolar.GetClosestPlanetsBySolarSystem(solarSystem);

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
        public async void GetByNameLenghtascending()
        {
            int? LastNameLenght = null;
            SolarSystem solarSystem = await ISolar.GetSolarSystemById(1);
            List<PlanetAndDwarfPlanet> result = await ISolar.GetClosestPlanetsBySolarSystem(solarSystem);

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
        public async void GetClosestPlanetsByStar()
        {
            SolarSystem solarSystem = await ISolar.GetSolarSystemById(1);
            List<PlanetAndDwarfPlanet> result = await ISolar.GetClosestPlanetsBySolarSystem(solarSystem);

            Assert.Equal("Earth", result[0].Name);
            Assert.Equal("Venus", result[1].Name);
        }
    }
}
