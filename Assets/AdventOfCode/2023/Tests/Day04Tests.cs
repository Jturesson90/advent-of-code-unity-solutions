using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day04Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/04").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day04.PuzzleA(_input);
            Assert.AreEqual("21213", result);
        }

        [TestCase(
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            "13")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day04.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day04.PuzzleB(_input);
            Assert.AreEqual("8549735", result);
        }

        [TestCase(
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            "30")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day04.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}