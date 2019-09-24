using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public static class InputParser
    {
        public static int[] GetNumbers(string input)
        {
            // split string based on delimiters 
            string[] splitInput = input.Split(Program.Delimiters, StringSplitOptions.None);
            // convert each string into number 
            List<int> numbers = new List<int>();
            foreach(var str in splitInput)
            {
                int result = 0;
                if (int.TryParse(str, out result))
                {
                    numbers.Add(result);
                }
                else
                {
                    numbers.Add(0);
                }
            }

            return numbers.ToArray();
        }
    }
}
