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
        Task<IEnumerable<SolarSystemModel>> GetListOfSolarSystems();
        Task<SolarSystemModel> GetSolarSystemById(int Id);
        Task<int> GetTotalAmountOfBodies(SolarSystemModel solarSystem);
        Task<double> GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystemModel solarSystem);
        Task<int> TotalAmountOfMoons(SolarSystemModel solarSystem);
        Task<IEnumerable<StarModel>> GetStarsBySolarSystem(SolarSystemModel solarSystem);

        Task<StarModel> GetStarById(int Id);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsBySolarSystem(SolarSystemModel solarSystem);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetByDistanceToSunAscending(SolarSystemModel solarSystem);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByAmountOfMoonsDescending(SolarSystemModel solarSystem);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtDescending(SolarSystemModel solarSystem);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetByNameLenghtAscending(SolarSystemModel solarSystem);
        Task<ClosestPlanets> GetClosestPlanetsBySolarSystem(SolarSystemModel solarSystem);
        Task PrintListOfAvgTempsForTypesBySolarSystem(SolarSystemModel solarSystem);

        Task<IEnumerable<PlanetAndDwarfPlanet>> GetByType(CelestialTypeEnum celestialType);
        Task<PlanetAndDwarfPlanet> GetByPlanetId(int Id);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsContaining(char char1, char char2);
        Task<IEnumerable<PlanetAndDwarfPlanet>> GetPlanetsByTempAbove0();

    }
}
