using AdventOfCode_2022;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2022Tests
{
    [TestFixture]
    public class Day20Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2022/20").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            var result = Day20.PuzzleA(_input);
            Assert.AreEqual("expected result", result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day20.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }
    }
}