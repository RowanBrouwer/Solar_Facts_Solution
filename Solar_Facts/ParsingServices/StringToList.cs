using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts
{
    class StringToList
    {
        public static async Task<Dictionary<string, string>> ConvertToSepperateValues(string input)
        {
            List<char> CharInput = new List<char>();
            Dictionary<string, string> NumAndLetString = new Dictionary<string, string>();

            foreach (char inchar in input)
            {
                CharInput.Add(inchar);
            }

            Task<Dictionary<string, List<char>>> filterdCharsTask = FilterChars.CharInOutFilterdCharLists(CharInput);

            if (filterdCharsTask.IsCompleted)
            {
                NumAndLetString = await StringBuilder.GetStringFromChars(await filterdCharsTask);
            }

            //Console.WriteLine($"{NumAndLetString["LetterString"]}");
            //Console.WriteLine($"{NumAndLetString["NumberString"]}");

            return await Task.FromResult(NumAndLetString);
        }
    }
}
