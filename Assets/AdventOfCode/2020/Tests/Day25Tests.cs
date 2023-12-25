using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2020;

namespace AdventOfCode_2020Tests
{
	[TestFixture]
	public class Day25Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2020/25").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day25.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day25.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
