using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.ParsingServices
{
    class Parser
    {
        public static async Task<int> GetNumberStringParsed(Dictionary<string, string> StringDictionary)
        {
            int Numbers = 0;

            string NumberString = StringDictionary["NumberString"];
            if (NumberString.Count() > 0)
            {
                try
                {
                    Numbers = int.Parse(NumberString);
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
            return await Task.FromResult(Numbers);
        }
    }
}
