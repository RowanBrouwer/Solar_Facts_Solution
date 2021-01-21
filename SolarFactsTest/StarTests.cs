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
        public void GetPlanetsByStar()
        {
            Star star = ISolar.GetStarById(1);
            Assert.Equal(1, star.Id);
        }

        [Fact]
        public void GetByDistanceToSunAscending()
        {
            long? lastDistance = null;
            Star star = ISolar.GetStarById(1);
            List<PlanetAndDwarfPlanet> result = ISolar.GetByDistanceToSunAscending(star);
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
        public void GetPlanetsByAmountOfMoonsDescending()
        {
            int? LastAmountOfMoons = null;
            Star star = ISolar.GetStarById(1);
            List<PlanetAndDwarfPlanet> result = ISolar.GetPlanetsByAmountOfMoonsDescending(star);
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
        public void GetByNameLenghtDescending()
        {
            int? LastNameLenght = null;
            Star star = ISolar.GetStarById(1);
            List<PlanetAndDwarfPlanet> result = ISolar.GetByNameLenghtDescending(star);

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
        public void GetByNameLenghtascending()
        {
            int? LastNameLenght = null;
            Star star = ISolar.GetStarById(1);
            List<PlanetAndDwarfPlanet> result = ISolar.GetByNameLenghtascending(star);

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
        public void GetClosestPlanetsByStar()
        {
            Star star = ISolar.GetStarById(1);
            List<PlanetAndDwarfPlanet> result = ISolar.GetClosestPlanetsByStar(star);

            Assert.Equal("Earth", result[0].Name);
            Assert.Equal("Venus", result[1].Name);
        }
    }
}
