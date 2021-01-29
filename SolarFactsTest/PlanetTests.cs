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
        public async void PlanetFilterByChar()
        {
            List<PlanetAndDwarfPlanet> queryResults = await ISolar.GetPlanetsContaining('p', 't');
            foreach (var result in queryResults)
            {
                Assert.True(result.Name.Contains('p') || result.Name.Contains('t'));
            }
        }

        [Fact]
        public async void GetPlanetbyId()
        {
            PlanetAndDwarfPlanet planetWithId4 = await ISolar.GetByPlanetId(4);
            Assert.Equal(4, planetWithId4.Id);
        }

        [Fact]
        public async void GetAverageTempOfSinglePlanet()
        {
            PlanetAndDwarfPlanet Earth = await ISolar.GetByPlanetId(3);
            Assert.Equal(-15, Earth.SurfaceTempAvg);
        }

        [Fact]
        public async void GetPlanetsByTypePlanet()
        {
            List<PlanetAndDwarfPlanet> result = await ISolar.GetByType(CelestialTypeEnum.Planet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.Planet, planet.Type);
            }
        }

        [Fact]
        public async void GetPlanetsByTypeDwarfPlanet()
        {
            List<PlanetAndDwarfPlanet> result = await ISolar.GetByType(CelestialTypeEnum.DwarfPlanet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.DwarfPlanet, planet.Type);
            }
        }

        [Fact]
        public async void GetPlanetsAbove0()
        {
            List<PlanetAndDwarfPlanet> result = await ISolar.GetPlanetsByTempAbove0();
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.True(planet.SurfaceTempMax > 0);
            }
        }
    }
}
