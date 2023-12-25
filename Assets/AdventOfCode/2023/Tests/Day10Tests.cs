using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day10Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/10").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day10.PuzzleA(_input, out var a);
            Assert.AreEqual("6815", result);
        }

        [TestCase(".....\n.S-7.\n.|.|.\n.L-J.\n.....", "4")]
        [TestCase("..F7.\n.FJ|.\nSJ.L7\n|F--J\nLJ...", "8")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day10.PuzzleA(input, out var a);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day10.PuzzleB(_input, out var a);
            Assert.AreEqual("6815", result);
        }

        [TestCase(
            "...........\n.S-------7.\n.|F-----7|.\n.||.....||.\n.||.....||.\n.|L-7.F-J|.\n.|..|.|..|.\n.L--J.L--J.\n...........",
            "4")]
        [TestCase("..F7.\n.FJ|.\nSJ.L7\n|F--J\nLJ...", "8")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day10.PuzzleB(input, out var a);
            Assert.AreEqual(expected, result);
        }
    }
}