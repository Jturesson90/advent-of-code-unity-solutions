using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day08Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/08").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day08.PuzzleA(_input);
            Assert.AreEqual("18727", result);
        }

        [TestCase("LLR\n\nAAA = (BBB, BBB)\nBBB = (AAA, ZZZ)\nZZZ = (ZZZ, ZZZ)", "6")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day08.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day08.PuzzleB(_input);
            Assert.AreEqual("18024643846273", result);
        }

        [TestCase(
            "LR\n\n11A = (11B, XXX)\n11B = (XXX, 11Z)\n11Z = (11B, XXX)\n22A = (22B, XXX)\n22B = (22C, 22C)\n22C = (22Z, 22Z)\n22Z = (22B, 22B)\nXXX = (XXX, XXX)",
            "6")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day08.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}