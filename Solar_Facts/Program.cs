using Solar_Facts.DAL;
using Solar_Facts.DAL.Models;
using Solar_Facts.DAL.Services;
using Solar_Facts.ParsingServices;
using Solar_Facts.UIPages;
using Solar_Facts.UIParts;
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
            (int, string) result = (0, null) ;
            string input = null;
            string LetterString = null;
            SolarSystemModel ChosenSolarSystem = null;
            int Numbers = 0;
            bool running = true;

            while (running)
            {
                result = await InputUiParts.GetInputAndParse(input);
                Numbers = result.Item1;
                LetterString = result.Item2;

                while (ChosenSolarSystem == null)
                {
                    result = await InputUiParts.GetInputAndParse(input);

                    ChosenSolarSystem = await SolarSystemUIComponents.SetChosenSolarSystem(result);
                }

                if (ChosenSolarSystem != null)
                {
                    result = await InputUiParts.GetInputAndParse(input);
                    Numbers = result.Item1;
                    LetterString = result.Item2;
                }

                if (LetterString != null)
                {
                    if (ChosenSolarSystem != null)
                    {
                        InputUiParts.MainMenuComp(LetterString, ChosenSolarSystem);
                    }
                }
            }
        }
    }
}
