using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2015;

namespace AdventOfCode_2015Tests
{
	[TestFixture]
	public class Day3Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2015/3").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day3.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day3.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
