using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day13Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/13").text;
        }

        [Test]
        public void PuzzleATests()
        {
            string result = Day13.PuzzleA(_input);
            Assert.AreEqual("28651", result);
        }

        [TestCase(
            "#.##..##.\n..#.##.#.\n##......#\n##......#\n..#.##.#.\n..##..##.\n#.#.##.#.\n\n#...##..#\n#....#..#\n..##..###\n#####.##.\n#####.##.\n..##..###\n#....#..#",
            "405")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day13.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day13.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }

        [TestCase(
            "#.##..##.\n..#.##.#.\n##......#\n##......#\n..#.##.#.\n..##..##.\n#.#.##.#.\n\n#...##..#\n#....#..#\n..##..###\n#####.##.\n#####.##.\n..##..###\n#....#..#",
            "400")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day13.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}