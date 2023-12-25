using System;

namespace AdventOfCode_2015
{
    public static class Day1
    {
        public static string PuzzleA(string input)
        {
            var k = 0;

            foreach (var t in input)
                switch (t)
                {
                    case ')':
                        k--;
                        break;
                    case '(':
                        k++;
                        break;
                    default:
                        throw new ArgumentException(t.ToString());
                }

            return k.ToString();
        }

        public static string PuzzleB(string input)
        {
            int pos = 1, k = 0;

            foreach (var t in input)
            {
                switch (t)
                {
                    case ')':
                        k--;
                        break;
                    case '(':
                        k++;
                        break;
                    default:
                        throw new ArgumentException(t.ToString());
                }

                if (k == -1) return pos.ToString();

                pos++;
            }

            return input;
        }
    }
}