using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.UIParts
{
    class SolarSystemUIComponents
    {
        public static async Task PrintSolarSystems()
        {
            ISolarSystem Context = new SolarSystemInterface();

            Console.WriteLine("Choose a solar system by Id!");

            IEnumerable<SolarSystemModel> solarSystems = await Context.GetListOfSolarSystems();

            foreach (var solarSystem in solarSystems)
            {
                Console.WriteLine($"Name: |{solarSystem.Name}| Id:|{solarSystem.Id}|");
            }
        }

        public static async Task<SolarSystemModel> SetChosenSolarSystem((int, string) result)
        {
            SolarSystemModel ChosenSolarSystem = null;

            ISolarSystem Context = new SolarSystemInterface();

            int Numbers = result.Item1;

            if (Numbers != 0)
            {
                ChosenSolarSystem = await Context.GetSolarSystemById(Numbers);
                Console.WriteLine($"{ChosenSolarSystem.Name} set as solar system to work with!");
            }

            return ChosenSolarSystem;
        }
    }
}
