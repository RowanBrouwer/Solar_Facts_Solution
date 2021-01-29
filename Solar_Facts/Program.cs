﻿using Solar_Facts.UIPages;
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
            string NumberString = null;
            Dictionary<string, string> StringDictionary = null;
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
                    if (LetterString == "p")
                    {
                        PlanetRenderer.PlanetPageRendering(StringDictionary);
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
