using System.Collections.Generic;
using System.Linq;
using AdventOfCode_2023;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2023Tests
{
    [TestFixture]
    public class Day05Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2023/05").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            string result = Day05.PuzzleA(_input);
            Assert.AreEqual("84470622", result);
        }

        [TestCase(
            "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4",
            "35")]
        public void PuzzleATests(string input, string expected)
        {
            string result = Day05.PuzzleA(input);
            Assert.AreEqual(expected, result);
        }

        [Test, Ignore("Too heavy")]
        public void PuzzleBTests()
        {
            string result = Day05.PuzzleB(_input);
            Assert.AreEqual("expected result", result);
        }

        [TestCase(
            "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4",
            "46")]
        public void PuzzleBTests(string input, string expected)
        {
            string result = Day05.PuzzleB(input);
            Assert.AreEqual(expected, result);
        }
    }
}