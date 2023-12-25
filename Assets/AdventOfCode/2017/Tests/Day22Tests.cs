using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2017;

namespace AdventOfCode_2017Tests
{
	[TestFixture]
	public class Day22Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2017/22").text;
		}

		[Test]
		public void PuzzleATests()
		{
			var result = Day22.PuzzleA(_input);
			Assert.AreEqual("expected result", result);
		}

		[Test]
		public void PuzzleBTests()
		{
			var result = Day22.PuzzleB(_input);
			Assert.AreEqual("expected result", result);
		}
	}
}
