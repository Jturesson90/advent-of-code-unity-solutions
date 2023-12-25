using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day14Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/14").text;
        }

        [Test]
        public void PuzzleATests()
        {
            const string expected = "107430";
            string result = Day14.PuzzleA(_input);
            Assert.AreEqual(expected, result);
        }

        [TestCase(
            "O....#....\nO.OO#....#\n.....##...\nOO.#O....O\n.O.....O#.\nO.#..O.#.#\n..O..#O..O\n.......O..\n#....###..\n#OO..#....",
            "136")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day14.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day14.PuzzleB(_input);
            Assert.AreEqual("96317", result);
        }
    }
}