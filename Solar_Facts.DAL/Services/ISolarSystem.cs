using Solar_Facts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Services
{
    public interface ISolarSystem
    {
        Task<SolarSystem> GetSolarSystemById(int Id);
        Task<int> GetTotalAmountOfBodies(SolarSystem solarSystem);
        Task<double> GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystem solarSystem);
        Task<int> TotalAmountOfMoons(SolarSystem solarSystem);
        Task<List<Star>> GetStarsBySolarSystem(SolarSystem solarSystem);

        Task<Star> GetStarById(int Id);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystem solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystem solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystem solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystem solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtascending(SolarSystem solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetClosestPlanetsBySolarSystem(SolarSystem solarSystem);
        Task PrintListOfAvgTempsForTypesBySolarSystem(SolarSystem solarSystem);

        Task<List<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType);
        Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0();
        
        
    }
}
