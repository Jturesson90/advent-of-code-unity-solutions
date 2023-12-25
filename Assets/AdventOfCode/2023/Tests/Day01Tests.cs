using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day01Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/1").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day01.PuzzleA(_input);
            Assert.AreEqual("53080", result);
        }

        [TestCase("1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet", "142")]
        public void PuzzleATests_Simple(string input, string expected)
        {
            string result = Day01.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            string result = Day01.PuzzleB(_input);
            Assert.AreEqual("53268", result);
        }

        [TestCase("two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen",
            "281")]
        public void PuzzleBTests_Simple(string input, string expected)
        {
            string result = Day01.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}