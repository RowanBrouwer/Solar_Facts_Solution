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
        Task<List<SolarSystemModel>> GetListOfSolarSystems();
        Task<SolarSystemModel> GetSolarSystemById(int Id);
        Task<int> GetTotalAmountOfBodies(SolarSystemModel solarSystem);
        Task<double> GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystemModel solarSystem);
        Task<int> TotalAmountOfMoons(SolarSystemModel solarSystem);
        Task<List<StarModel>> GetStarsBySolarSystem(SolarSystemModel solarSystem);

        Task<StarModel> GetStarById(int Id);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystemModel solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystemModel solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystemModel solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystemModel solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetByNameLenghtascending(SolarSystemModel solarSystem);
        Task<List<PlanetAndDwarfPlanet>> GetClosestPlanetsBySolarSystem(SolarSystemModel solarSystem);
        Task PrintListOfAvgTempsForTypesBySolarSystem(SolarSystemModel solarSystem);

        Task<List<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType);
        Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2);
        Task<List<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0();
        
        
    }
}
