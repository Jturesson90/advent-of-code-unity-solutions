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
	public class Day02Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2015/2").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day2.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day2.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
