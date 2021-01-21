using Solar_Facts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Services
{
    public class SolarSystemInterface : ISolarSystem
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public double GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystem solarSystem)
        {
            var SolarSystemCount = CountOfSolarSystemObjects(solarSystem);

            int totalAmountOfPlanets = SolarSystemCount["Planets"];
            int TotalAmountOfMoons = SolarSystemCount["Moons"];

            return TotalAmountOfMoons / totalAmountOfPlanets;
        }

        public SolarSystem GetSolarSystemById(int Id)
        {
            return context.SolarSystems.Find(Id);
        }

        public List<Star> GetStarsBySolarSystem(SolarSystem solarSystem)
        {
            return context.Stars.Where(s => s.SolarSystemId == solarSystem.Id).ToList();
        }

        public int GetTotalAmountOfBodies(SolarSystem solarSystem)
        {
            var SolarSystemCount = CountOfSolarSystemObjects(solarSystem);
            return SolarSystemCount.Values.Sum();
        }

        public int TotalAmountOfMoons(SolarSystem solarSystem)
        {
            var SolarSystemCount = CountOfSolarSystemObjects(solarSystem);
            int TotalAmountOfMoons = SolarSystemCount["Moons"];

            return TotalAmountOfMoons;
        }

        private Dictionary<string, int> CountOfSolarSystemObjects(SolarSystem solarSystem)
        {
            Dictionary<string, int> Numbers = new Dictionary<string, int>();

            List<Star> CurrentStars = GetStarsBySolarSystem(solarSystem);

            var totalAmountOfStars = CurrentStars.Count();
            var totalAmountOfPlanets = 0;
            var totalAmountOfMoons = 0;

            foreach (Star star in CurrentStars)
            {
                totalAmountOfPlanets = GetPlanetsByStar(star).Count();
                
                foreach (PlanetAndDwarfPlanet planet in star.Planets)
                {
                    totalAmountOfMoons += planet.KnownMoons;
                }
            }

            Numbers.Add("Stars", totalAmountOfStars);
            Numbers.Add("Planets", totalAmountOfPlanets);
            Numbers.Add("Moons", totalAmountOfMoons);

            return Numbers;
        }

        public List<PlanetAndDwarfPlanet> GetByDistanceToSunAscending(Star star)
        {
            return GetPlanetsByStar(star).OrderBy(p => p.OrbitDistanceInKM).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetPlanetsByAmountOfMoonsDescending(Star star)
        {
            return GetPlanetsByStar(star).OrderByDescending(p => p.KnownMoons).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetPlanetsByStar(Star star)
        {
            return context.PlntAndDPlnt.Where(p => p.StarId == star.Id).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetByNameLenghtDescending(Star star)
        {
            return GetPlanetsByStar(star).OrderByDescending(p => p.Name.Count()).ToList();
        }

        public PlanetAndDwarfPlanet GetByPlanetId(int Id)
        {
            return context.PlntAndDPlnt.Find(Id);
        }

        public List<PlanetAndDwarfPlanet> GetPlanetsContaining(char char1, char char2)
        {
            var list = context.PlntAndDPlnt.ToList();
            List<PlanetAndDwarfPlanet> awnser = new List<PlanetAndDwarfPlanet>();
            foreach (var listitem in list)
            {
                if (listitem.Name.Contains(char1))
                {
                    awnser.Add(listitem);
                }
                if (listitem.Name.Contains(char2))
                {
                    awnser.Add(listitem);
                }
            }
            return  awnser;
        }

        public List<PlanetAndDwarfPlanet> GetByType(CelestialTypeEnum celestialType)
        {
            return context.PlntAndDPlnt.Where(p => p.Type == celestialType).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetPlanetsByTempAbove0()
        {
            return context.PlntAndDPlnt.Where(p => p.SurfaceTempMax >= 0).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetByNameLenghtascending(Star star)
        {
            return GetPlanetsByStar(star).OrderBy(p => p.Name.Count()).ToList();
        }

        public List<PlanetAndDwarfPlanet> GetClosestPlanetsByStar(Star star)
        {
            var planetlist = GetPlanetsByStar(star);

            planetlist.OrderBy(p => p.OrbitDistanceInKM);

            PlanetAndDwarfPlanet planetA = null;
            PlanetAndDwarfPlanet planetB = null;

            long? smallestDiff = null;

            foreach (var planet1 in planetlist)
            {
                foreach (var planet2 in planetlist)
                {
                    long latestDiff;
                    if (planet2.OrbitDistanceInKM > planet1.OrbitDistanceInKM)
                    {
                        latestDiff = planet2.OrbitDistanceInKM - planet1.OrbitDistanceInKM;
                    }
                    else
                    {
                        latestDiff = planet1.OrbitDistanceInKM - planet2.OrbitDistanceInKM;
                    }
                    if (planet1 != planet2)
                    {
                        if (smallestDiff.HasValue && latestDiff <= smallestDiff)
                        {
                            smallestDiff = latestDiff;
                            planetA = planet1;
                            planetB = planet2;
                        }
                        if (smallestDiff == null)
                        {
                            smallestDiff = latestDiff;
                        }
                    }
                }
            }

            List<PlanetAndDwarfPlanet> Awnser = new List<PlanetAndDwarfPlanet>();

            Awnser.Add(planetA);
            Awnser.Add(planetB);

            return Awnser;

        }

        public Star GetStarById(int Id)
        {
            return context.Stars.Find(Id);
        }
    }
}
