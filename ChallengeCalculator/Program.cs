using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    public class Program
    {
        public static string[] Delimiters = new string[]
        {
            ","
        };

        static void Main(string[] args)
        {
            bool quit = false;

            while(!quit)
            {
                Console.Write("Please enter the numbers to add: ");

                var userInput = Console.ReadLine();

                // get numbers 
                var numbers = InputParser.GetNumbers(userInput);

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
