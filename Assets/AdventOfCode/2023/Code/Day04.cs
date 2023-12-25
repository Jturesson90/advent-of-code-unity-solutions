using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day04
    {
        public static string PuzzleA(string input)
        {
            var result = 0;
            string[] cards = input.Split('\n');
            foreach (string card in cards)
            {
                string[] points = card.Split(":")[1].Split(" | ");
                var left = points[0].Trim().Split(" ").ToHashSet();
                var right = points[1].Trim().Split(" ").ToHashSet();
                var c = 0;
                var same = new HashSet<string>();
                foreach (string r in right)
                {
                    if (r == string.Empty)
                        continue;
                    if (left.Contains(r))
                    {
                        c++;
                        same.Add(r);
                    }
                }

                if (c <= 0)
                {
                    Debug.Log($"{card.Split(":")}: {same.Count}");
                    continue;
                }

                Debug.Log(
                    $"{card.Split(":")[0]}: ({string.Join(",", same)}) gives {(int)Math.Pow(2, c - 1)} points.");
                result += (int)Math.Pow(2, c - 1);
            }

            return result.ToString();
        }

        public static string PuzzleB(string input)
        {
            var winning = new List<int>();
            string[] cards = input.Split('\n');
            foreach (string card in cards)
            {
                string[] points = card.Split(":")[1].Split(" | ");
                var left = points[0].Trim().Split(" ").ToHashSet();
                var right = points[1].Trim().Split(" ").ToHashSet();

                var same = new HashSet<string>();
                foreach (string r in right)
                {
                    if (r == string.Empty)
                        continue;
                    if (left.Contains(r)) same.Add(r);
                }

                winning.Add(same.Count);
            }

            var copies = new Dictionary<int, int>();
            for (var i = 0; i < winning.Count; i++) copies.Add(i + 1, 1);

            for (var i = 1; i <= copies.Keys.Count; i++)
            {
                int cValue = copies[i];
                for (var j = 0; j < cValue; j++)
                {
                    int numWins = winning[i - 1];
                    for (var k = 0; k < numWins; k++) copies[i + 1 + k]++;
                }
            }


            return copies.Sum(x => x.Value).ToString();
        }
    }
}