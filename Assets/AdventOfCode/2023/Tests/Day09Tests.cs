using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2023;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day09Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/09").text;
        }

        [Test]
        public void PuzzleATests()
        {
            var result = Day09.PuzzleA(_input);
            Assert.AreEqual("1904165718", result);
        }

        [TestCase("0 3 6 9 12 15\n1 3 6 10 15 21\n10 13 16 21 30 45", "114")]
        public void PuzzleATests(string input, string expected)
        {
            var result = Day09.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day09.PuzzleB(_input);
            Assert.AreEqual("964", result);
        }
    }
}