using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public class Program
    {
        public static List<string> DefaultDelimiters = new List<string>
        {
            ",", "\\n"
        };

        static void Main(string[] args)
        {
            bool quit = false;

            while(!quit)
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
    }
}
