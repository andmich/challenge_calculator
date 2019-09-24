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
        [Test]
        public void Add_OverMaximumAllowed_ThrowsException()
        {
            int[] input = new int[]
            {
                1, 2, 3
            };

            Assert.Throws<Exception>(() => Calculator.Add(input), $"Only a max of {Calculator.MaxNumbers} allowed");
        }

        [TestCase(3, new int[] { 1, 2 })]
        [TestCase(153, new int[] { 55, 98 })]
        [TestCase(1, new int[] { 0, 1 })]
        public void Add_UnderMaximumAllowed_ReturnsSum(int expectedSum, int[] input)
        {
            var result = Calculator.Add(input);

            Assert.AreEqual(expectedSum, result);
        }
    }
}
