using Solar_Facts.DAL.Models;
using Solar_Facts.ParsingServices;
using Solar_Facts.UIPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.UIParts
{
    public class InputUiParts
    {
        public static async Task<(int, string)> GetInputAndParse(string input)
        {
            string LetterString = null;
            Dictionary<string, string> StringDictionary = null;
            int Numbers = 0;

            input = null;
            input = Console.ReadLine();

            if (input != null)
            {
                StringDictionary = await StringToList.ConvertToSepperateValues(input);
                LetterString = StringDictionary["LetterString"];
                Numbers = await Parser.GetNumberStringParsed(StringDictionary);
            }

            return (Numbers, LetterString);
        }

        public static void MainMenuComp(string LetterString, SolarSystemModel ChosenSolarSystem)
        {
            switch (LetterString.ToLower())
            {
                case "planeten":
                    PlanetRenderer.PlanetPageRendering(ChosenSolarSystem);
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("The chosen command was not recognized! please try again.");
                    break;
            }
        }

    }
}

