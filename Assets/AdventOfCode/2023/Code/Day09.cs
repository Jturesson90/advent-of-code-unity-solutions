using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2023
{
    public static class Day09
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            string[] a = input.Split("\n");
            int result = a.Sum(a => GetLastValue(a.Split(" ").Select(int.Parse).ToList()));

            return result.ToString();
        }

        private static int GetLastValue(List<int> n)
        {
            var b = new List<List<int>> { n };

            while (true)
            {
                var last = b[^1];
                if (last.All(bb => bb == 0)) break;

                var c = new List<int>();
                if (last.Count <= 1) throw new Exception();

                for (var i = 0; i < last.Count - 1; i++)
                {
                    int diff = last[i + 1] - last[i];
                    c.Add(diff);
                }

                b.Add(c);
            }

            for (int i = b.Count - 2; i >= 0; i--)
            {
                int calcValue = b[i + 1][^1] + b[i][^1];
                b[i].Add(calcValue);
            }

            /*
             * 1   3   6  10  15  21
                 2   3   4   5   6
                   1   1   1   1
                     0   0   0
             */
            return b[0][^1];
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            string[] a = input.Split("\n");
            int result = a.Sum(aa =>
            {
                var n = aa.Split(" ").Select(int.Parse).ToList();
                n.Reverse();
                return GetLastValue(n);
            });

            return result.ToString();
        }
    }
}