using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts
{
    public class FilterChars
    {
        public static Dictionary<string, List<char>> CharInOutFilterdCharLists(char[] CharInput)
        {

            List<char> LetterInput = new List<char>();
            List<char> IntInput = new List<char>();

            Dictionary<string, List<char>> CharAndNumbers = new Dictionary<string, List<char>>();


            foreach (char charinp in CharInput)
            {
                if (char.IsLetter(charinp))
                {
                    LetterInput.Add(charinp);
                }
                else if (char.IsNumber(charinp))
                {
                    IntInput.Add(charinp);
                }
            }
            CharAndNumbers.Add("Letters", LetterInput);
            CharAndNumbers.Add("Numbers", IntInput);

            return CharAndNumbers;
        }
    }
}
