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
        private List<string> _customDelimiters { get; set; }
        [SetUp]
        public void SetUp()
        {
            _customDelimiters = new List<string>(Program.DefaultDelimiters);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, "1,2,3,4")]
        [TestCase(new int[] { 1, 2, 0, 45 }, "1,2,ewrgv,45")]
        [TestCase(new int[] { 0, 0, 0, 1 }, "0,saef,sefseaf,1")]
        [TestCase(new int[] { 0, 0, 0, 1 }, "0\\nsaef\\nsefseaf\\n1")]
        [TestCase(new int[] { 0, 1, 2, 1, 3, 4, 5 }, "0\\n1\\n2\\n1,3,4,5")]
        public void GetNumbers_InputWithAlphaNumeric_ReturnsNumbers(int[] expected, string input)
        {
            var result = InputParser.GetNumbers(input, _customDelimiters);

            Assert.IsInstanceOf(typeof(int[]), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 0, 0, 1 }, "10001, 100011, 1")]
        [TestCase(new int[] { 1, 2, 0, 31, 0 }, "1, 2, 2536, 31, EGF")]
        public void GetNumbers_InputNumberGreaterThan1000_ReturnsNumbers(int[] expected, string input)
        {
            var result = InputParser.GetNumbers(input, _customDelimiters);

            Assert.IsInstanceOf(typeof(int[]), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(";", "//;\\n1,2;3")]
        [TestCase(":", "//:\\n1,2:3")]
        [TestCase("\"", "//\"\\n1,2\"3")]
        [TestCase("[", "//[\\n1,2[3")]
        [TestCase("]", "//]\\n1,2]3")]
        public void GetCustomDelimiters_SingleSingleCharDelimiter_ReturnsDelimiterList(string expected, string input)
        {
            var result = InputParser.GetCustomDelimiters(input);

            Assert.IsInstanceOf(typeof(List<string>), result);
            Assert.AreEqual(expected, result.ElementAt(0));
        }

        [TestCase("1,2", "//;\\n1,2")]
        [TestCase("1,2;36,serbv,", "//;\\n1,2;36,serbv,")]
        [TestCase("1, 2, 3, 4, 5", "//;\\n1, 2, 3, 4, 5")]
        public void RemoveDelimiterFromInput_CustomDelimiter_ReturnsValidInput(string expected, string input)
        {
            var result = InputParser.RemoveDelimiterFromInput(input);

            Assert.AreEqual(expected, result);
        }
    }
}
