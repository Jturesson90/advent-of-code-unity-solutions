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
	public class Day03Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2015/03").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day03.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day03.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
