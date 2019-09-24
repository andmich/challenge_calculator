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
    public class InputParserTests
    {
        [TestCase(new int[] { 1, 2, 3, 4}, "1,2,3,4")]
        [TestCase(new int[] { 1, 2, 0, 45 }, "1,2,ewrgv,45")]
        [TestCase(new int[] { 0, 0, 0, 1}, "0,saef,sefseaf,1")]
        public void GetNumbers_InputWithAlphaNumeric_ReturnsNumbers(int[] expected, string input)
        {
            var result = InputParser.GetNumbers(input);

            Assert.IsInstanceOf(typeof(int[]), result);
            Assert.AreEqual(expected, result);
        }
    }
}
