using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public class Program
    {
        public static HashSet<string> DefaultDelimiters = new HashSet<string>
        {
            ",", "\\n"
        };

        static void Main(string[] args)
        {
            // configure calculator
            ConfigureCalculator();

            while (true)
            {
                Console.Write("Please enter the numbers to add: ");

                var userInput = Console.ReadLine();

                // get custom delimiter 
                var customDelimiters = InputParser.GetCustomDelimiters(userInput);
                customDelimiters.AddRange(DefaultDelimiters);

                // ensure user input does not include custom delimiters 
                userInput = InputParser.RemoveDelimiterFromInput(userInput);

                // get numbers 
                var numbers = InputParser.GetNumbers(userInput, customDelimiters);

                try
                {
                    var result = Calculator.Add(numbers);

                    Console.WriteLine($"\n{string.Join("+", numbers)} = {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("\n");
            }
        }

        public static void ConfigureCalculator()
        {
            Console.Write(@"Allow \n as a delimiter? (y/n): ");
            var allowNewLineDelimiter = Console.ReadLine().ToLower() == "y";

            Console.Write(@"Deny negative numbers? (y/n): ");
            var denyNegativeNumbers = Console.ReadLine().ToLower() == "y";

            Console.Write(@"Set upper bound: ");
            var upperBound = 1000;
            int.TryParse(Console.ReadLine(), out upperBound);

            if (allowNewLineDelimiter)
            {
                DefaultDelimiters.Add("\\n");
            }
            else
            {
                DefaultDelimiters.Remove("\\n");
            }

            InputParser.UpperBound = upperBound;
            Calculator.DenyNegatives = denyNegativeNumbers;

            Console.WriteLine("\n");
        }

        public static void AddNewLineDelimiterToDefaults(bool allowNewLineDelimiter)
        {
            if (allowNewLineDelimiter)
            {
                if (!DefaultDelimiters.Any(d => d == "\\n"))
                {
                    DefaultDelimiters.Add("\\n");
                }
            }
            else
            {
                if (DefaultDelimiters.Any(d => d == "\\n"))
                {
                    DefaultDelimiters.Remove("\\n");
                }
            }
        }
    }
}
