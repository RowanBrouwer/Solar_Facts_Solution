using Microsoft.Data.SqlClient;
using Solar_Facts.DAL;
using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolarFactsTest
{
    public class PlanetTests
    {
        public ISolarSystem ISolar = new SolarSystemInterface();

        [Fact]
        public void PlanetFilterByChar()
        {
            List<PlanetAndDwarfPlanet> queryResults = ISolar.GetPlanetsContaining('p', 't');
            foreach (var result in queryResults)
            {
                Assert.True(result.Name.Contains('p') || result.Name.Contains('t'));
            }
        }

        [Fact]
        public void GetPlanetbyId()
        {
            PlanetAndDwarfPlanet planetWithId4 = ISolar.GetByPlanetId(4);
            Assert.Equal(4, planetWithId4.Id);
        }

        [Fact]
        public void GetAverageTempOfSinglePlanet()
        {
            PlanetAndDwarfPlanet Earth = ISolar.GetByPlanetId(3);
            Assert.Equal(-15, Earth.SurfaceTempAvg);
        }

        [Fact]
        public void GetPlanetsByTypePlanet()
        {
            List<PlanetAndDwarfPlanet> result = ISolar.GetByType(CelestialTypeEnum.Planet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.Planet, planet.Type);
            }
        }

        [Fact]
        public void GetPlanetsByTypeDwarfPlanet()
        {
            List<PlanetAndDwarfPlanet> result = ISolar.GetByType(CelestialTypeEnum.DwarfPlanet);
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.Equal(CelestialTypeEnum.DwarfPlanet, planet.Type);
            }
        }

        [Fact]
        public void GetPlanetsAbove0()
        {
            List<PlanetAndDwarfPlanet> result = ISolar.GetPlanetsByTempAbove0();
            foreach (PlanetAndDwarfPlanet planet in result)
            {
                Assert.True(planet.SurfaceTempMax > 0);
            }
        }
    }
}
