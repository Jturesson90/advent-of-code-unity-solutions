using AdventOfCode_2015;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2015Tests
{
    [TestFixture]
    public class Day1Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2015/1").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            var result = Day1.PuzzleA(_input);
            Assert.AreEqual("280", result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day1.PuzzleB(_input);
            Assert.AreEqual("1797", result);
        }
    }
}