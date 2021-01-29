using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts
{
    class StringBuilder
    {
        public static async Task<Dictionary<string, string>> GetStringFromChars(Dictionary<string, List<char>> CharAndNumbers)
        {
            string LetterResult = new string(CharAndNumbers["Letters"].ToArray());

            string NumberResult = new string(CharAndNumbers["Numbers"].ToArray());

            Dictionary<string, string> awnser = new Dictionary<string, string>();

            awnser.Add("LetterString", LetterResult);
            awnser.Add("NumberString", NumberResult);

            return await Task.FromResult(awnser);
        }
    }
}
