using ChallengeCalculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(3, new int[] { 1, 2 })]
        [TestCase(153, new int[] { 55, 98 })]
        [TestCase(1, new int[] { 0, 1 })]
        [TestCase(78, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 })]
        public void Add_AllValidNumbers_ReturnsSum(int expectedSum, int[] input)
        {
            var result = Calculator.Add(input);

            Assert.AreEqual(expectedSum, result);
        }

        [TestCase(new int[] { 1, -5, -6, 2})]
        [TestCase(new int[] { 0, -1 })]
        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 9, -1 })]
        public void Add_NegativeNumbers_ThrowsException(int[] input)
        {
            var negatives = input.Where(number => number < 0).ToArray();
            Assert.Throws<Exception>(() => Calculator.Add(input), $"Negative numbers are not allowed: {string.Join(",", negatives)}");
        }
    }
}
