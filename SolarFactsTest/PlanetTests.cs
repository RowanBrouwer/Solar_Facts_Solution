using Microsoft.Data.SqlClient;
using Solar_Facts.DAL;
using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SolarFactsTest
{
    public class PlanetTests
    {
        public ISolarSystem ISolar = new SolarSystemInterface();

        [Fact]
        public async Task PlanetFilterByChar()
        {
            IEnumerable<PlanetAndDwarfPlanet> queryResults = await ISolar.GetPlanetsContaining('p', 't');
            foreach (var result in queryResults)
            {
                Assert.True(result.Name.Contains('p') || result.Name.Contains('t'));
            }
        }

        [Fact]
        public async Task GetPlanetbyId()
        {
            PlanetAndDwarfPlanet planetWithId4 = await ISolar.GetByPlanetId(4);
            Assert.Equal(4, planetWithId4.Id);
        }

        [Fact]
        public async Task GetAverageTempOfSinglePlanet()
        {
            PlanetAndDwarfPlanet Earth = await ISolar.GetByPlanetId(3);
            Assert.Equal(-15, Earth.SurfaceTempAvg);
        }

        [Fact]
        public async Task GetPlanetsByTypePlanet()
        {
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetByType(CelestialTypeEnum.Planet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.Planet, planet.Type);
            }
        }

        [Fact]
        public async Task GetPlanetsByTypeDwarfPlanet()
        {
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetByType(CelestialTypeEnum.DwarfPlanet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.DwarfPlanet, planet.Type);
            }
        }

        [Fact]
        public async Task GetPlanetsAbove0()
        {
            IEnumerable<PlanetAndDwarfPlanet> result = await ISolar.GetPlanetsByTempAbove0();
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.True(planet.SurfaceTempMax > 0);
            }
        }
    }
}
