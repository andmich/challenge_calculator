using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public static class Calculator
    {
        public static bool DenyNegatives = true;
        /// <summary>
        /// Adds the numbers in the array 
        /// </summary>
        /// <param name="numbers">An array of numbers</param>
        /// <returns>Returns sum of numbers</returns>
        public static int Add(int[] numbers)
        {
            // get negative numbers 
            var negativeNumbers = numbers.Where(number => number < 0);
            if (DenyNegatives && negativeNumbers.Any())
            {
                throw new Exception($"\nNegative numbers are not allowed: {string.Join(",", negativeNumbers.ToArray())}");
            }

            int sum = 0;
            foreach(var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
