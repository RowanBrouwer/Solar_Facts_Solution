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

        public Task<double> GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystemModel solarSystem) =>
            Task.FromResult(
            context.PlntAndDPlnt
            .Where(p => p.SolarSystemToOrbit == solarSystem)
            .Select(p => p.KnownMoons)
            .Average()
            );

        public async Task<SolarSystemModel> GetSolarSystemById(int Id) =>
             await context.SolarSystems.FindAsync(Id);

        public async Task<IEnumerable<StarModel>> GetStarsBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(
                context.Stars.Where(s => s.SolarSystemId == solarSystem.Id));

        public async Task<int> GetTotalAmountOfBodies(SolarSystemModel solarSystem) =>
           await Task.FromResult(context.SolarSystems
                .Select(ss => ss.Planets.Count() +
                              ss.Stars.Count() +
                              ss.Planets.Select(p => p.KnownMoons).Count())
                .Sum());

        public async Task<int> TotalAmountOfMoons(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .Select(p => p.KnownMoons).Sum());

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderBy(p => p.OrbitDistanceInKM));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderBy(p => p.OrbitDistanceInKM));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemId == solarSystem.Id));


        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderByDescending(p => p.Name.Length));
        

        public async Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id) =>
            await context.PlntAndDPlnt.FindAsync(Id);


        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.Name.Contains(char1) || p.Name.Contains(char2)));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.Type == celestialType));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0() =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SurfaceTempMax >= 0));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtAscending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderBy(p => p.Name));

        public async Task<ClosestPlanets> GetClosestPlanetsBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt
                .SelectMany(p1 => context.PlntAndDPlnt, (p1 ,p2)
                => new { p1, p2})
                .Where(p => p.p1.Id != p.p2.Id)
                .Select(measure => new
                { 
                    planetA = measure.p1,
                    planetB = measure.p2,
                    measuredDistance = Math.Abs(measure.p1.OrbitDistanceInKM > measure.p2.OrbitDistanceInKM ?
                        measure.p1.OrbitDistanceInKM - measure.p2.OrbitDistanceInKM : 
                        measure.p2.OrbitDistanceInKM - measure.p1.OrbitDistanceInKM)
                })
                .OrderBy(d => d.measuredDistance)
                .Select(res => new ClosestPlanets()
                {
                    PlanetA = res.planetA,
                    PlanetB = res.planetB,
                    Distance = res.measuredDistance
                })
                .First());         

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
            //Task<List<PlanetAndDwarfPlanet>> dwarfTask = GetByType(CelestialTypeEnum.DwarfPlanet);
            //Task<List<PlanetAndDwarfPlanet>> planetTask = GetByType(CelestialTypeEnum.Planet);
            //Task<List<StarModel>> sunTask = GetStarsBySolarSystem(solarSystem);

            //var EnumTasks = new List<Task> { dwarfTask, planetTask, sunTask };

            //List<PlanetAndDwarfPlanet> FilterdDwarfPlanets = null;
            //List<PlanetAndDwarfPlanet> FilterdPlanets = null;
            //List<StarModel> Filterdsuns = null;

            //while (EnumTasks.Count > 0)
            //{
            //    Task finishedTask = await Task.WhenAny(EnumTasks);
            //    if (finishedTask == dwarfTask)
            //    {
            //        List<PlanetAndDwarfPlanet> dwarfPlanets = dwarfTask.Result;
            //        FilterdDwarfPlanets = dwarfPlanets.Where(p => p.SolarSystemToOrbit == solarSystem).ToList();
            //    }
            //    else if (finishedTask == planetTask)
            //    {
            //        List<PlanetAndDwarfPlanet> planets = planetTask.Result;
            //        FilterdPlanets = planets.Where(p => p.SolarSystemToOrbit == solarSystem).ToList();
            //    }
            //    else if (finishedTask == sunTask)
            //    {
            //        List<StarModel> suns = sunTask.Result;
            //        Filterdsuns = suns.Where(s => s.solarSystem == solarSystem).ToList();
            //    }
            //    if (EnumTasks.TrueForAll(t => t.IsCompletedSuccessfully))
            //    {
            //        break;
            //    }


            //    double DpTempsSum = 0;
            //    double PTempsSum = 0;
            //    double STempsSum = 0;

            //    if (FilterdDwarfPlanets != null && FilterdPlanets != null && Filterdsuns != null)
            //    {
            //        foreach (PlanetAndDwarfPlanet dwarfPlanet in FilterdDwarfPlanets)
            //        {
            //            DpTempsSum += dwarfPlanet.SurfaceTempAvg;
            //        }
            //        foreach (PlanetAndDwarfPlanet planet in FilterdPlanets)
            //        {
            //            DpTempsSum += planet.SurfaceTempAvg;
            //        }
            //        foreach (StarModel sun in Filterdsuns)
            //        {
            //            DpTempsSum += sun.SurfaceTempAvg;
            //        }
            //    }
            //    Console.WriteLine($"\nThe average of all dwarf planets combined is : {DpTempsSum / FilterdDwarfPlanets.Count()}");
            //    Console.WriteLine($"\nThe average of all dwarf planets combined is : {PTempsSum / FilterdPlanets.Count()}");
            //    Console.WriteLine($"\nThe average of all dwarf planets combined is : {STempsSum / Filterdsuns.Count()}");
            //}
        }

        public async Task<IEnumerable<SolarSystemModel>> GetListOfSolarSystems()
        {
            List<SolarSystemModel> list;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.SolarSystems.OrderBy(ss => ss.Name).ToList();
            }

            return await Task.FromResult(list);
        }



        public async Task<int> GetKnownMoonsCountBySolarSystem(SolarSystemModel solarSystem)
        {
            int totalAmountOfMoons;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
               totalAmountOfMoons = context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem).Select(p => p.KnownMoons).Sum();
            }

            return await Task.FromResult(totalAmountOfMoons);
        }

        public async Task<int> GetPlanetCountBySolarSystem(SolarSystemModel solarSystem)
        {
            int totalAmountofPlanets;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                totalAmountofPlanets = context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem).Count();
            }

            return await Task.FromResult(totalAmountofPlanets);
        }

        public async Task<int> GetStarCountBySolarSystem(SolarSystemModel solarSystem)
        {
            int totalAmountOfStars;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                totalAmountOfStars = context.Stars.Where(s => s.solarSystem == solarSystem).Count();
            }

            return await Task.FromResult(totalAmountOfStars);
        }
    }
}
