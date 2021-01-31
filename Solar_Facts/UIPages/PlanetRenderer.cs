using Solar_Facts.DAL.Models;
using Solar_Facts.UIParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.UIPages
{
    public class PlanetRenderer
    {
        public static async void PlanetPageRendering(SolarSystemModel ChosenSolarSystem)
        {
            string input = null;
            string LetterString = null;
            string NumberString = null;
            long Numbers;

            while (true)
            {
                (int, string) result = await InputUiParts.GetInputAndParse(input);
                Numbers = result.Item1;
                LetterString = result.Item2;

                if (LetterString != null)
                {
                    if (LetterString == "q")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
