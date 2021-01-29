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

        public async Task<double> GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystemModel solarSystem)
        {
            Dictionary<string, int> SolarSystemCount;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SolarSystemCount = await CountOfSolarSystemObjects(solarSystem);
            }
            int totalAmountOfPlanets = SolarSystemCount["Planets"];
            int TotalAmountOfMoons = SolarSystemCount["Moons"];

            return TotalAmountOfMoons / totalAmountOfPlanets;
        }

        public async Task<SolarSystemModel> GetSolarSystemById(int Id)
        {
            SolarSystemModel solarSystem;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                solarSystem = await context.SolarSystems.FindAsync(Id);
            }

            return solarSystem;
        }

        public async Task<List<StarModel>> GetStarsBySolarSystem(SolarSystemModel solarSystem)
        {
            List<StarModel> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.Stars.Where(s => s.SolarSystemId == solarSystem.Id).ToList();
            }

            return await Task.FromResult(list);
        }

        public async Task<int> GetTotalAmountOfBodies(SolarSystemModel solarSystem)
        {
            Dictionary<string, int> SolarSystemCount;
            int sum;

            using (ApplicationDbContext context = new ApplicationDbContext())

            {
                SolarSystemCount = await CountOfSolarSystemObjects(solarSystem);
            }

            sum = SolarSystemCount.Values.Sum();

            return sum;
        }

        public async Task<int> TotalAmountOfMoons(SolarSystemModel solarSystem)
        {
            Dictionary<string, int> SolarSystemCount;
            int TotalAmountOfMoons;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SolarSystemCount = await CountOfSolarSystemObjects(solarSystem);
                TotalAmountOfMoons = SolarSystemCount["Moons"];
            }

            return TotalAmountOfMoons;
        }

        private async Task<Dictionary<string, int>> CountOfSolarSystemObjects(SolarSystemModel solarSystem)
        {
            Dictionary<string, int> Numbers = new Dictionary<string, int>();

            List<StarModel> CurrentStars = await GetStarsBySolarSystem(solarSystem);
            List<PlanetAndDwarfPlanet> CurrentPlanets = await GetPlanetsBySolarSystem(solarSystem);
            var totalAmountOfStars = CurrentStars.Count();
            var totalAmountOfPlanets = CurrentPlanets.Count();
            var totalAmountOfMoons = 0;


            foreach (PlanetAndDwarfPlanet planet in CurrentPlanets)
            {
                totalAmountOfMoons += planet.KnownMoons;
            }


            Numbers.Add("Stars", totalAmountOfStars);
            Numbers.Add("Planets", totalAmountOfPlanets);
            Numbers.Add("Moons", totalAmountOfMoons);

            return Numbers;
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> list = await GetPlanetsBySolarSystem(solarSystem);
            list.OrderBy(p => p.OrbitDistanceInKM).ToList();

            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> list = await GetPlanetsBySolarSystem(solarSystem);
            list.OrderByDescending(p => p.OrbitDistanceInKM).ToList();

            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.PlntAndDPlnt.Where(p => p.SolarSystemId == solarSystem.Id).ToList();
            }

            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> list = await GetPlanetsBySolarSystem(solarSystem);
            list.OrderByDescending(p => p.Name.Count()).ToList();

            return await Task.FromResult(list);
        }

        public async Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id)
        {
            PlanetAndDwarfPlanet planet;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                planet = await context.PlntAndDPlnt.FindAsync(Id);
            }

            return planet;
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2)
        {
            List<PlanetAndDwarfPlanet> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.PlntAndDPlnt.ToList();
            }

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
            return await Task.FromResult(awnser);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType)
        {
            List<PlanetAndDwarfPlanet> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.PlntAndDPlnt.Where(p => p.Type == celestialType).ToList();
            }
            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0()
        {
            List<PlanetAndDwarfPlanet> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.PlntAndDPlnt.Where(p => p.SurfaceTempMax >= 0).ToList();
            }

            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtascending(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> list = await GetPlanetsBySolarSystem(solarSystem);
            list.OrderBy(p => p.Name.Count()).ToList();

            return await Task.FromResult(list);
        }

        public async Task<List<PlanetAndDwarfPlanet>> GetClosestPlanetsBySolarSystem(SolarSystemModel solarSystem)
        {
            List<PlanetAndDwarfPlanet> planetlist = await GetPlanetsBySolarSystem(solarSystem);

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

        public async Task<StarModel> GetStarById(int Id)
        {
            StarModel star;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                star = await context.Stars.FindAsync(Id);
            }

            return star;
        }

        public async Task PrintListOfAvgTempsForTypesBySolarSystem(SolarSystemModel solarSystem)
        {
            Task<List<PlanetAndDwarfPlanet>> dwarfTask = GetByType(CelestialTypeEnum.DwarfPlanet);
            Task<List<PlanetAndDwarfPlanet>> planetTask = GetByType(CelestialTypeEnum.Planet);
            Task<List<StarModel>> sunTask = GetStarsBySolarSystem(solarSystem);

            var EnumTasks = new List<Task> { dwarfTask, planetTask, sunTask };

            List<PlanetAndDwarfPlanet> FilterdDwarfPlanets = null;
            List<PlanetAndDwarfPlanet> FilterdPlanets = null;
            List<StarModel> Filterdsuns = null;

            while (EnumTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(EnumTasks);
                if (finishedTask == dwarfTask)
                {
                    List<PlanetAndDwarfPlanet> dwarfPlanets = dwarfTask.Result;
                    FilterdDwarfPlanets = dwarfPlanets.Where(p => p.SolarSystemToOrbit == solarSystem).ToList();
                }
                else if (finishedTask == planetTask)
                {
                    List<PlanetAndDwarfPlanet> planets = planetTask.Result;
                    FilterdPlanets = planets.Where(p => p.SolarSystemToOrbit == solarSystem).ToList();
                }
                else if (finishedTask == sunTask)
                {
                    List<StarModel> suns = sunTask.Result;
                    Filterdsuns = suns.Where(s => s.solarSystem == solarSystem).ToList();
                }
                if (EnumTasks.TrueForAll(t => t.IsCompletedSuccessfully))
                {
                    break;
                }


                double DpTempsSum = 0;
                double PTempsSum = 0;
                double STempsSum = 0;

                if (FilterdDwarfPlanets != null && FilterdPlanets != null && Filterdsuns != null)
                {
                    foreach (PlanetAndDwarfPlanet dwarfPlanet in FilterdDwarfPlanets)
                    {
                        DpTempsSum += dwarfPlanet.SurfaceTempAvg;
                    }
                    foreach (PlanetAndDwarfPlanet planet in FilterdPlanets)
                    {
                        DpTempsSum += planet.SurfaceTempAvg;
                    }
                    foreach (StarModel sun in Filterdsuns)
                    {
                        DpTempsSum += sun.SurfaceTempAvg;
                    }
                }
                Console.WriteLine($"\nThe average of all dwarf planets combined is : {DpTempsSum / FilterdDwarfPlanets.Count()}");
                Console.WriteLine($"\nThe average of all dwarf planets combined is : {PTempsSum / FilterdPlanets.Count()}");
                Console.WriteLine($"\nThe average of all dwarf planets combined is : {STempsSum / Filterdsuns.Count()}");
            }
        }

        public async Task<List<SolarSystemModel>> GetListOfSolarSystems()
        {
            List<SolarSystemModel> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.SolarSystems.OrderBy(ss => ss.Name).ToList();
            }

            return await Task.FromResult(list);
        }
    }
}
