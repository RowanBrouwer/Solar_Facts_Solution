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
               await GetPlanetCountBySolarSystem(solarSystem) + 
               await GetStarCountBySolarSystem(solarSystem) + 
               await GetKnownMoonsCountBySolarSystem(solarSystem);

        public async Task<int> TotalAmountOfMoons(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .Select(p => p.KnownMoons).Sum());

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderBy(p => p.OrbitDistanceInKM));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderByDescending(p => p.KnownMoons));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemId == solarSystem.Id));


        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderByDescending(p => p.Name.Length));
        

        public async Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id) =>
            await context.PlntAndDPlnt.FindAsync(Id);


        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.Name.ToLower().Contains(char1.ToString()) ||
                                                                  p.Name.ToLower().Contains(char2.ToString())));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.Type == celestialType));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0() =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SurfaceTempMax >= 0));

        public async Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtAscending(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .OrderBy(p => p.Name.Length));

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

        public async Task<StarModel> GetStarById(int Id) =>
            await context.Stars.FindAsync(Id);

        public async Task<(double, double, double)> PrintListOfAvgTempsForTypesBySolarSystem(SolarSystemModel solarSystem) =>
                await Task.FromResult((context.PlntAndDPlnt
                    .Where(p => p.SolarSystemToOrbit == solarSystem && 
                    p.Type == CelestialTypeEnum.DwarfPlanet)
                    .Select(p => p.SurfaceTempAvg).Average(),
                    
                    context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem &&
                    p.Type == CelestialTypeEnum.Planet)
                    .Select(p => p.SurfaceTempAvg).Average(),
                    
                    context.Stars.Where(s => s.solarSystem == solarSystem)
                    .Select(s => s.SurfaceTempAvg).Average()));

        public async Task<IEnumerable<SolarSystemModel>> GetListOfSolarSystems() =>
            await Task.FromResult(context.SolarSystems.OrderBy(ss => ss.Name));

        public async Task<int> GetKnownMoonsCountBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem)
                .Select(p => p.KnownMoons).Sum());

        public async Task<int> GetPlanetCountBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.PlntAndDPlnt.Where(p => p.SolarSystemToOrbit == solarSystem).Count());

        public async Task<int> GetStarCountBySolarSystem(SolarSystemModel solarSystem) =>
            await Task.FromResult(context.Stars.Where(s => s.solarSystem == solarSystem).Count());
    }
}
