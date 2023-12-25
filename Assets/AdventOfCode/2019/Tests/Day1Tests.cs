using AdventOfCode_2019;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2019Tests
{
    [TestFixture]
    public class Day1Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2019/1").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            var result = Day1.PuzzleA(_input);
            Assert.AreEqual("expected result", result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day1.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }
    }
}