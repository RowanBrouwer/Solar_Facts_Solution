using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.UIPages
{
    public class PlanetRenderer
    {
        public static async void PlanetPageRendering(Dictionary<string, string> StringDictionary)
        {
            string input = null;
            string LetterString = null;
            string NumberString = null;
            long Numbers;

            while (true)
            {
                input = null;
                input = Console.ReadLine();

                if (input != null)
                {
                    StringDictionary = await StringToList.ConvertToSepperateValues(input);

                    LetterString = StringDictionary["LetterString"];
                    NumberString = StringDictionary["NumberString"];
                    if (NumberString.Count() > 0)
                    {
                        try
                        {
                            Numbers = long.Parse(NumberString);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Unable to parse '{NumberString}'");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"Number to big or too small to use '{NumberString}'");
                        }
                    }
                }

                if (LetterString != null)
                {
                    if (LetterString == "q")
                    {
                        break;
                    }
                }
            }
        }
    }
}
