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
    public class Day18Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/18").text;
        }

        [Test]
        public void PuzzleATests()
        {
            var result = Day18.PuzzleA(_input);
            Assert.AreEqual("66993", result);
        }

        [Test]
        public void PuzzleBTests()
        {
            var result = Day18.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }

        [TestCase(
            "R 6 (#70c710)\nD 5 (#0dc571)\nL 2 (#5713f0)\nD 2 (#d2c081)\nR 2 (#59c680)\nD 2 (#411b91)\nL 5 (#8ceee2)\nU 2 (#caa173)\nL 1 (#1b58a2)\nU 2 (#caa171)\nR 2 (#7807d2)\nU 3 (#a77fa3)\nL 2 (#015232)\nU 2 (#7a21e3)",
            "952408144115")]
        [Test]
        public void PuzzleBTests(string input, string expected)
        {
            var result = Day18.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase(
            "R 6 (#70c710)\nD 5 (#0dc571)\nL 2 (#5713f0)\nD 2 (#d2c081)\nR 2 (#59c680)\nD 2 (#411b91)\nL 5 (#8ceee2)\nU 2 (#caa173)\nL 1 (#1b58a2)\nU 2 (#caa171)\nR 2 (#7807d2)\nU 3 (#a77fa3)\nL 2 (#015232)\nU 2 (#7a21e3)",
            "62")]
        [Test]
        public void PuzzleATests(string input, string expected)
        {
            var result = Day18.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }
    }
}