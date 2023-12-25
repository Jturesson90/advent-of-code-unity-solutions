using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day07Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/07").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day07.PuzzleA(_input);
            Assert.AreEqual("250951660", result);
        }

        [TestCase("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", "6440")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day07.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day07.PuzzleB(_input);
            Assert.AreEqual("251481660", result);
        }
        [TestCase("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", "5905")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day07.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}