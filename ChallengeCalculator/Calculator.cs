using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public static class Calculator
    {
        public static int MaxNumbers = 2;
        /// <summary>
        /// Adds the numbers in the array 
        /// </summary>
        /// <param name="numbers">An array of numbers</param>
        /// <returns>Returns sum of numbers</returns>
        public static int Add(int[] numbers)
        {
            if (numbers.Length > MaxNumbers)
            {
                throw new Exception($"Only a max of {MaxNumbers} allowed");
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
