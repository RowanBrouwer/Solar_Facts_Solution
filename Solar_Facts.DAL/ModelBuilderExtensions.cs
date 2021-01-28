using Microsoft.EntityFrameworkCore;
using Solar_Facts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ICollection<Star> starlist = new List<Star>();
            ICollection<PlanetAndDwarfPlanet> planetlist = new List<PlanetAndDwarfPlanet>();

            var TheSun = new Star
            {
                Id = 1,
                Name = "The Sun",
                DiameterInKM = 1392694,
                SurfaceTempMax = 5500,
                SurfaceTempMin = 5500,
                Age = 4600000000,
                CoreTemp = 15000000,
                SolarSystemId = 1
            };
            starlist.Add(TheSun);

            var Mercury = new PlanetAndDwarfPlanet
            {
                Id = 1,
                Name = "Mercury",
                DiameterInKM = 4879,
                SurfaceTempMax = -173,
                SurfaceTempMin = -427,
                KnownMoons = 0,
                OrbitDistanceInKM = 57900000,
                OrbitPeriodInDays = 88,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Mercury);
            var Venus = new PlanetAndDwarfPlanet
            {
                Id = 2,
                Name = "Venus",
                DiameterInKM = 12104,
                SurfaceTempMax = 462,
                SurfaceTempMin = 462,
                KnownMoons = 0,
                OrbitDistanceInKM = 108200000,
                OrbitPeriodInDays = 224.7,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Venus);
            var Earth = new PlanetAndDwarfPlanet
            {
                Id = 3,
                Name = "Earth",
                DiameterInKM = 12756,
                SurfaceTempMax = 58,
                SurfaceTempMin = -88,
                KnownMoons = 1,
                OrbitDistanceInKM = 149600000,
                OrbitPeriodInDays = 365.2,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Earth);
            var Mars = new PlanetAndDwarfPlanet
            {
                Id = 4,
                Name = "Mars",
                DiameterInKM = 6805,
                SurfaceTempMax = -63,
                SurfaceTempMin = -63,
                KnownMoons = 2,
                OrbitDistanceInKM = 227900000,
                OrbitPeriodInDays = 693.96,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Mars);
            var Ceres = new PlanetAndDwarfPlanet
            {
                Id = 5,
                Name = "Ceres",
                DiameterInKM = 950,
                SurfaceTempMax = -105,
                SurfaceTempMin = -105,
                KnownMoons = 0,
                OrbitDistanceInKM = 413700000,
                OrbitPeriodInDays = 1680.11,
                Type = CelestialTypeEnum.DwarfPlanet,
                SolarSystemId = 1
            };
            planetlist.Add(Ceres);
            var Jupiter = new PlanetAndDwarfPlanet
            {
                Id = 6,
                Name = "Jupiter",
                DiameterInKM = 142984,
                SurfaceTempMax = -108,
                SurfaceTempMin = -108,
                KnownMoons = 67,
                OrbitDistanceInKM = 778300000,
                OrbitPeriodInDays = 4346.38,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Jupiter);
            var Saturn = new PlanetAndDwarfPlanet
            {
                Id = 7,
                Name = "Saturn",
                DiameterInKM = 120536,
                SurfaceTempMax = -139,
                SurfaceTempMin = -139,
                KnownMoons = 62,
                OrbitDistanceInKM = 1400000000,
                OrbitPeriodInDays = 10774.65,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Saturn);
            var Uranus = new PlanetAndDwarfPlanet
            {
                Id = 8,
                Name = "Uranus",
                DiameterInKM = 51118,
                SurfaceTempMax = -197,
                SurfaceTempMin = -197,
                KnownMoons = 27,
                OrbitDistanceInKM = 2900000000,
                OrbitPeriodInDays = 30680.37,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Uranus);
            var Neptune = new PlanetAndDwarfPlanet
            {
                Id = 9,
                Name = "Neptune",
                DiameterInKM = 49528,
                SurfaceTempMax = -201,
                SurfaceTempMin = -201,
                KnownMoons = 14,
                OrbitDistanceInKM = 4500000000,
                OrbitPeriodInDays = 60191.96,
                Type = CelestialTypeEnum.Planet,
                SolarSystemId = 1
            };
            planetlist.Add(Neptune);
            var Pluto = new PlanetAndDwarfPlanet
            {
                Id = 10,
                Name = "Pluto",
                DiameterInKM = 2306,
                SurfaceTempMax = -229,
                SurfaceTempMin = -229,
                KnownMoons = 5,
                OrbitDistanceInKM = 5900000000,
                OrbitPeriodInDays = 89849.65,
                Type = CelestialTypeEnum.DwarfPlanet,
                SolarSystemId = 1
            };
            planetlist.Add(Pluto);
            var Haumea = new PlanetAndDwarfPlanet
            {
                Id = 11,
                Name = "Haumea",
                DiameterInKM = 1739,
                SurfaceTempMax = -241,
                SurfaceTempMin = -241,
                KnownMoons = 2,
                OrbitDistanceInKM = 6400000000,
                OrbitPeriodInDays = 103473.20,
                Type = CelestialTypeEnum.DwarfPlanet,
                SolarSystemId = 1
            };
            planetlist.Add(Haumea);
            var Makemake = new PlanetAndDwarfPlanet
            {
                Id = 12,
                Name = "Makemake",
                DiameterInKM = 1434,
                SurfaceTempMax = -241,
                SurfaceTempMin = -241,
                KnownMoons = 0,
                OrbitDistanceInKM = 6900000000,
                OrbitPeriodInDays = 113188.65,
                Type = CelestialTypeEnum.DwarfPlanet,
                SolarSystemId = 1
            };
            planetlist.Add(Makemake);
            var Eris = new PlanetAndDwarfPlanet
            {
                Id = 13,
                Name = "Eris",
                DiameterInKM = 1434,
                SurfaceTempMax = -241,
                SurfaceTempMin = -241,
                KnownMoons = 1,
                OrbitDistanceInKM = 10100000000,
                OrbitPeriodInDays = 204864.52,
                Type = CelestialTypeEnum.DwarfPlanet,
                SolarSystemId = 1
            };
            planetlist.Add(Eris);

            var TheSolarSystem = new SolarSystem
            {
                Id = 1,
                Name = "The Solar system",
            };


            

            modelBuilder.Entity<Star>().HasData(TheSun);

            foreach (PlanetAndDwarfPlanet planet in planetlist)
            {
                modelBuilder.Entity<PlanetAndDwarfPlanet>().HasData(planet);
            }
            
            modelBuilder.Entity<SolarSystem>().HasData(TheSolarSystem);        
        }
    }
}
