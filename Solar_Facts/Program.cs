using System;
using System.Collections.Generic;
using System.Linq;

namespace Solar_Facts
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Take(2);
            char[] CharInput = input.Select(c => Convert.ToChar(c)).ToArray();

            Dictionary<string, List<char>> filterdChars = FilterChars.CharInOutFilterdCharLists(CharInput);



            while (true)
            {
                switch (inputChar)
                {
                    case 'p':
                        break;
                    case 'as':
                        break;
                    case "adp":
                        break;
                    case "a":
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }









            }
        }
    }
}
