using Solar_Facts.DAL;
using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using Solar_Facts.ParsingServices;
using Solar_Facts.UIPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solar_Facts
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string input = null;
            string LetterString = null;
            Dictionary<string, string> StringDictionary = null;
            int Numbers = 0;
            SolarSystemModel ChosenSolarSystem = null;

            while (true)
            {
                if (ChosenSolarSystem != null)
                {
                    input = null;
                    input = Console.ReadLine();
                }

                if (input != null)
                {
                    StringDictionary = await StringToList.ConvertToSepperateValues(input);
                    LetterString = StringDictionary["LetterString"];
                    Numbers = await Parser.GetNumberStringParsed(StringDictionary);
                }

                while (ChosenSolarSystem == null)
                {
                    ISolarSystem Context = new SolarSystemInterface();

                    Console.WriteLine("Choose a solar system by Id!");

                    List<SolarSystemModel> solarSystems = await Context.GetListOfSolarSystems();

                    foreach (var solarSystem in solarSystems)
                    {
                        Console.WriteLine($"Name: |{solarSystem.Name}| Id:|{solarSystem.Id}|");
                    }

                    input = null;
                    input = Console.ReadLine();

                    if (input != null)
                    {
                        StringDictionary = await StringToList.ConvertToSepperateValues(input);
                        Numbers = await Parser.GetNumberStringParsed(StringDictionary);
                    }

                    if (Numbers != 0)
                    {
                        ChosenSolarSystem = await Context.GetSolarSystemById(Numbers);
                        Console.WriteLine($"{ChosenSolarSystem.Name} set as solar system to work with!");
                    }
                }

                if (LetterString != null)
                {
                    if (ChosenSolarSystem != null)
                    {
                        if (LetterString == "planeten")
                        {
                            PlanetRenderer.PlanetPageRendering(StringDictionary, ChosenSolarSystem);
                        }
                    }

                    else if (LetterString == "q")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
