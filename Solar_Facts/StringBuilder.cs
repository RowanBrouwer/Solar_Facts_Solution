using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts
{
    class StringBuilder
    {
        public static Dictionary<string, string> GetStringFromChars(Dictionary<string, List<char>> CharAndNumbers)
        {
            var LetterResult = CharAndNumbers["Letters"]
                .Select(c => c.ToString())
                .ToString();

            var NumberResult = CharAndNumbers["Numbers"]
                .Select(c => c.ToString())
                .ToString();

            Dictionary<string, string> awnser = new Dictionary<string, string>();

            awnser.Add("LetterString", LetterResult);
            awnser.Add("LetterString", NumberResult);

            return awnser;
        }
    }
}
