using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day11Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/11").text;
        }

        [Test]
        public void PuzzleATests()
        {
            string result = Day11.PuzzleA(_input);
            Assert.AreEqual("10173804", result);
        }

        [TestCase(
            "...#......\n.......#..\n#.........\n..........\n......#...\n.#........\n.........#\n..........\n.......#..\n#...#.....",
            "374")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day11.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day11.PuzzleB(_input);
            Assert.AreEqual("634324905172", result);
        }

        [TestCase(
            "...#......\n.......#..\n#.........\n..........\n......#...\n.#........\n.........#\n..........\n.......#..\n#...#.....",
            "1030")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day11.PuzzleB(input, 10);
            Assert.AreEqual(expected, result);
        }
    }
}