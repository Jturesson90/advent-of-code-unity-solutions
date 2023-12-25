using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day03Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/03").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day03.PuzzleA(_input);
            Assert.AreEqual("551094", result);
        }

        [TestCase(
            "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..",
            "4361")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day03.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day03.PuzzleB(_input);
            Assert.AreEqual("80179647", result);
        }

        [TestCase(
            "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..",
            "467835")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day03.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}