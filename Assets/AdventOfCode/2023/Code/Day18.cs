using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode_2023
{
    public static class Day18
    {
        private static string ParseDirection(char c)
        {
            return c switch
            {
                '0' => "R",
                '1' => "D",
                '2' => "L",
                '3' => "U",
                _ => throw new ArgumentException()
            };
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle A!
            string[] split = input.Split("\n");
            var navigation = new List<(string Direction, int Steps)>();
            var rowByColor = new Dictionary<int, string>();
            var rowNum = 0;
            foreach (string row in split)
            {
                string[] splitAgain = row.Split(" ");
                string color = splitAgain[2];
                char direction = color[^2];
                var steps = $"{new string(color.Skip(2).Take(5).ToArray())}";
                int stepsParsed = int.Parse(steps, NumberStyles.HexNumber);
                navigation.Add((ParseDirection(direction), stepsParsed));
                rowByColor.Add(rowNum++, splitAgain[2]);
            }

            var visited = new HashSet<(int Row, int Col)>();
            (int Row, int Col) currentPosition = (0, 0);
            int length = navigation.Count;
            for (var i = 0; i < length; i++)
            {
                var dir = navigation[i];
                var p = currentPosition;
                switch (dir.Direction)
                {
                    case "R":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (currentPosition.Row, p.Col + j);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "D":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (p.Row + j, currentPosition.Col);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "U":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (p.Row - j, currentPosition.Col);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "L":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (currentPosition.Row, p.Col - j);
                            visited.Add(currentPosition);
                        }

                        break;
                    default: throw new Exception();
                }
            }

            (int Row, int Col) startFlow = (1, 1);
            if (visited.Contains(startFlow)) throw new Exception("BAD START");
            Flow(visited, startFlow);

            return visited.Count.ToString();
        }

        private static void Flow(HashSet<(int Row, int Col)> visited, (int Row, int Col) start)
        {
            var stack = new Queue<(int Row, int Col)>();
            stack.Enqueue(start);
            while (stack.Count > 0)
            {
                var pos = stack.Dequeue();

                if (visited.Contains(pos)) continue;

                visited.Add(pos);
                stack.Enqueue((pos.Row - 1, pos.Col));
                stack.Enqueue((pos.Row, pos.Col - 1));
                stack.Enqueue((pos.Row + 1, pos.Col));
                stack.Enqueue((pos.Row, pos.Col + 1));
            }
        }

        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            string[] split = input.Split("\n");
            var navigation = new List<(string Direction, int Steps)>();
            var rowByColor = new Dictionary<int, string>();
            var rowNum = 0;
            foreach (string row in split)
            {
                string[] splitAgain = row.Split(" ");
                navigation.Add((splitAgain[0], int.Parse(splitAgain[1])));
                rowByColor.Add(rowNum++, splitAgain[2]);
            }

            var visited = new HashSet<(int Row, int Col)>();
            (int Row, int Col) currentPosition = (0, 0);
            int length = navigation.Count;
            for (var i = 0; i < length; i++)
            {
                var dir = navigation[i];
                var p = currentPosition;
                switch (dir.Direction)
                {
                    case "R":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (currentPosition.Row, p.Col + j);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "D":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (p.Row + j, currentPosition.Col);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "U":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (p.Row - j, currentPosition.Col);
                            visited.Add(currentPosition);
                        }

                        break;
                    case "L":
                        for (var j = 1; j <= dir.Steps; j++)
                        {
                            currentPosition = (currentPosition.Row, p.Col - j);
                            visited.Add(currentPosition);
                        }

                        break;
                    default: throw new Exception();
                }
            }

            (int Row, int Col) startFlow = (1, 1);
            if (visited.Contains(startFlow)) throw new Exception("BAD START");
            Flow(visited, startFlow);

            return visited.Count.ToString();
        }
    }
}