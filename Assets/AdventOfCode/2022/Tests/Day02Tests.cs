using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2022;

namespace AdventOfCode_2022Tests
{
	[TestFixture]
	public class Day02Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2022/02").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day02.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day02.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
