using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2023
{
    public static class Day08
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            string[] a = input.Split("\n\n");
            string instructions = a[0];
            var paths = GetPathsA(a[1]);
            var i = 0;
            var currentPos = "AAA";
            var counter = 0;
            while (true)
            {
                char dir = instructions[i];
                string nextPos = null;
                if (dir == 'L')
                    nextPos = paths[currentPos].Left;
                else if (dir == 'R')
                    nextPos = paths[currentPos].Right;
                else
                    throw new Exception("HUH?");

                counter++;
                currentPos = nextPos;
                if (currentPos == "ZZZ") break;

                i = (i + 1) % instructions.Length;
            }

            return counter.ToString();
        }

        private static Dictionary<string, (string Left, string Right)> GetPathsA(string p)
        {
            var a = new Dictionary<string, (string Left, string Right)>();
            string[] posInput = p
                .Replace("(", "")
                .Replace(")", "")
                .Split("\n");

            foreach (string v in posInput)
            {
                string[] b = v.Split(" = ");
                string position = b[0];
                string[] c = b[1].Split(", "); //(AAA, ZZZ)
                a.Add(position, (c[0], c[1]));
            }

            return a;
        }

        public static string PuzzleB(string input)
        {
            string[] a = input.Split("\n\n");
            string instructions = a[0];
            var paths = GetPathsA(a[1]);
            var startingPositions = StartingPositions(paths);
            var endingPositions = EndPositions(paths);
            var result = new List<ulong>();
            for (var j = 0; j < startingPositions.Count; j++)
            {
                var i = 0;
                ulong counter = 0;
                string currentPosition = startingPositions[j];
                while (true)
                {
                    char dir = instructions[i];
                    if (dir == 'L')
                        currentPosition = paths[currentPosition].Left;
                    else if (dir == 'R') currentPosition = paths[currentPosition].Right;

                    counter++;
                    if (currentPosition[^1] == 'Z')
                    {
                        result.Add(counter);
                        break;
                    }

                    i = (i + 1) % instructions.Length;
                }
            }


            return CalculateLCM(result).ToString();
        }

        public static List<string> StartingPositions(Dictionary<string, (string Left, string Right)> paths)
        {
            return paths
                .Where(a => a.Key[^1] == 'A')
                .Select(a => a.Key).ToList();
        }

        public static HashSet<string> EndPositions(Dictionary<string, (string Left, string Right)> paths)
        {
            return paths
                .Where(a => a.Key[^1] == 'Z')
                .Select(a => a.Key)
                .ToHashSet();
        }

        private static ulong CalculateLCM(List<ulong> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Input list must not be empty or null.");

            ulong lcm = numbers[0];

            for (var i = 1; i < numbers.Count; i++) lcm = CalculateLcm(lcm, numbers[i]);

            return lcm;
        }

        private static ulong CalculateLcm(ulong a, ulong b)
        {
            return a / CalculateGcd(a, b) * b;
        }

        private static ulong CalculateGcd(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}