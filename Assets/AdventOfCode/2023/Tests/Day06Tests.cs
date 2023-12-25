using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day06Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/06").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day06.PuzzleA(_input);
            Assert.AreEqual("140220", result);
        }

        [TestCase("Time:      7  15   30\nDistance:  9  40  200", "288")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day06.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day06.PuzzleB(_input);
            Assert.AreEqual("39570185", result);
        }

        [TestCase("Time:      7  15   30\nDistance:  9  40  200", "71503")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day06.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}