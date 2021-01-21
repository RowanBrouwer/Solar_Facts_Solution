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
        SolarSystem GetSolarSystemById(int Id);
        int GetTotalAmountOfBodies(SolarSystem solarSystem);
        double GetAverageAmountOfMoonsByPlanetsInSolarSystem(SolarSystem solarSystem);
        int TotalAmountOfMoons(SolarSystem solarSystem);
        List<Star> GetStarsBySolarSystem(SolarSystem solarSystem);

        Star GetStarById(int Id);
        List<PlanetAndDwarfPlanet> GetPlanetsByStar(Star star);
        List<PlanetAndDwarfPlanet> GetByDistanceToSunAscending(Star star);
        List<PlanetAndDwarfPlanet> GetPlanetsByAmountOfMoonsDescending(Star star);
        List<PlanetAndDwarfPlanet> GetByNameLenghtDescending(Star star);
        List<PlanetAndDwarfPlanet> GetByNameLenghtascending(Star star);
        List<PlanetAndDwarfPlanet> GetClosestPlanetsByStar(Star star);

        List<PlanetAndDwarfPlanet> GetByType(CelestialTypeEnum celestialType);
        PlanetAndDwarfPlanet GetByPlanetId(int Id);
        List<PlanetAndDwarfPlanet> GetPlanetsContaining(char char1, char char2);
        List<PlanetAndDwarfPlanet> GetPlanetsByTempAbove0();
        
    }
}
