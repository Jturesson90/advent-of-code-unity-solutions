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
    public class Day12Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/12").text;
        }

        [Test]
        public void PuzzleATests()
        {
            var result = Day12.PuzzleA(_input);
            Assert.AreEqual("expected result", result);
        }

        [TestCase("?###???????? 3,2,1", "10")]
        [TestCase(".??..??...?##. 1,1,3", "4")]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", "1")]
        [TestCase("????.######..#####. 1,6,5", "4")]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", "10")]
        public void PuzzleATests(string input, string expected)
        {
            var result = Day12.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day12.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }
    }
}