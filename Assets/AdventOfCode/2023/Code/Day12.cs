using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day12
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            string[] rows = input.Split("\n");

            foreach (string row in rows)
            {
                string[] s = row.Split(" ");
                string left = s[0];
                int[] right = s[1].Split(",").Select(int.Parse).ToArray();

                var groups = new List<int>();
                for (var i = 0; i < left.Length; i++)
                {
                    var a = 0;
                    for (var j = 0; j < right.Length; j++)
                    {
                    }
                }

                Debug.Log($"3 - {input}  found at " + FindFirstPlace(0, 3, left));
            }

            return input;
        }

        private static int FindFirstPlace(int startIndex, int number, string left)
        {
            for (int i = startIndex; i < left.Length; i++)
            {
                if (i > 0 && left[i - 1] == '#') continue;
                char s = left[i];
                if (number + i > left.Length) return -1;

                var failed = false;
                for (int j = i; j < number + i; j++)
                {
                    if (left[j] == '.')
                    {
                        failed = true;
                        break;
                    }

                    if (left[j] == '#') continue;
                    if (left[j] == '?') continue;
                }

                if (!failed)
                {
                    if (left.Length <= i + number)
                    {
                    }
                    else
                    {
                        if (left[i + number] == '#')
                        {
                        }
                        else
                        {
                            return i;
                        }
                    }
                }
            }

            return -1;
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            return input;
        }
    }
}