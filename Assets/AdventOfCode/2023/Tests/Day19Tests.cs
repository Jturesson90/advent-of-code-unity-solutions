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
	public class Day19Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2023/19").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day19.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day19.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
