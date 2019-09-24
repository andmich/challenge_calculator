﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public static class InputParser
    {
        /// <summary>
        /// Retrieves custom delimiters from input
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>An array of delimiters</returns>
        public static List<string> GetCustomDelimiters(string input)
        {
            List<string> customDelimiters = new List<string>();
            // if string starts with // it contains a delimiter 
            if (input.StartsWith("//"))
            {
                customDelimiters.Add(input.ElementAt(2).ToString());
                return customDelimiters;
            }

            return null;
        }

        /// <summary>
        /// Removes the delimiter(s) from the given input
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>The user input without any custom delimiters</returns>
        public static string RemoveDelimiterFromInput(string input)
        {
            if (input.StartsWith("//"))
            {
                var indexOfNewLine = input.IndexOf("\\n");
                return input.Substring(indexOfNewLine + 2);
            }

            return input;
        }

        /// <summary>
        /// Retrieves the numbers in the given input
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>An array of numbers</returns>
        public static int[] GetNumbers(string input, List<string> delimiters)
        {
            // split string based on delimiters 
            string[] splitInput = input.Split(delimiters.ToArray(), StringSplitOptions.None);
            // convert each string into number 
            List<int> numbers = new List<int>();
            foreach(var str in splitInput)
            {
                int result = 0;
                if (int.TryParse(str, out result))
                {
                    if (result <= 1000)
                    {
                        numbers.Add(result);
                    }
                    else
                    {
                        numbers.Add(0);
                    }
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
