using AdventOfCode_2016;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2016Tests
{
    [TestFixture]
    public class Day13Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2016/13").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            var result = Day13.PuzzleA(_input);
            Assert.AreEqual("expected result", result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day13.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }
    }
}