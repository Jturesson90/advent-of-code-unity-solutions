using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day03
    {
        private static readonly HashSet<char> Symbols = new()
        {
            '/', '*', '+', '=', '@', '%', '&', '$', '#', '-'
        };

        public static string PuzzleA(string input)
        {
            string[] schematics = input.Split("\n");
            int rows = schematics.Length;
            var notPartNumbers = new List<int>();
            for (var i = 0; i < rows; i++)
            {
                string row = schematics[i];
                var currentNumber = string.Empty;
                var startJ = 0;
                int cols = row.Length;
                for (var j = 0; j <= cols; j++)
                {
                    char c = j >= cols ? '.' : row[j];
                    if (currentNumber == string.Empty && char.IsNumber(c))
                    {
                        startJ = j;
                        currentNumber += c;
                    }
                    else if (currentNumber != string.Empty && char.IsNumber(c))
                    {
                        currentNumber += c;
                    }
                    else if (currentNumber != string.Empty && !char.IsNumber(c))
                    {
                        var s = GetCloseNeighbours(startJ, i, j - 1, rows, cols);
                        var isPartNumber = false;
                        foreach (var a in s)
                        {
                            char d = schematics[a.Y][a.X];
                            if (Symbols.Contains(d))
                            {
                                isPartNumber = true;
                                break;
                            }
                        }

                        if (isPartNumber)
                            notPartNumbers.Add(int.Parse(currentNumber));
                        else
                            Debug.Log(currentNumber + "  this is NOT a part number");

                        currentNumber = string.Empty;
                    }
                }
            }

            return notPartNumbers.Sum().ToString();
        }

        private static List<(int X, int Y)> GetCloseNeighbours(int startX, int startY, int endX, int rows, int cols)
        {
            if (startX > endX) throw new Exception();
            var result = new List<(int, int)>();
            if (IsInside(startX - 1, startY - 1, rows, cols)) result.Add((startX - 1, startY - 1));
            if (IsInside(startX - 1, startY, rows, cols)) result.Add((startX - 1, startY));
            if (IsInside(startX - 1, startY + 1, rows, cols)) result.Add((startX - 1, startY + 1));

            for (int stepX = startX; stepX <= endX; stepX++)
            {
                if (IsInside(stepX, startY - 1, rows, cols)) result.Add((stepX, startY - 1));
                if (IsInside(stepX, startY + 1, rows, cols)) result.Add((stepX, startY + 1));
            }

            if (IsInside(endX + 1, startY - 1, rows, cols)) result.Add((endX + 1, startY - 1));
            if (IsInside(endX + 1, startY, rows, cols)) result.Add((endX + 1, startY));
            if (IsInside(endX + 1, startY + 1, rows, cols)) result.Add((endX + 1, startY + 1));

            return result;
        }

        private static bool IsInside(int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && rows > x && cols > y;
        }

        public static string PuzzleB(string input)
        {
            string[] schematics = input.Split("\n");
            int rows = schematics.Length;
            Dictionary<(int Y, int X), List<int>> dd = new Dictionary<(int X, int Y), List<int>>();
            for (var i = 0; i < rows; i++)
            {
                string row = schematics[i];
                var currentNumber = string.Empty;
                var startJ = 0;
                int cols = row.Length;
                for (var j = 0; j <= cols; j++)
                {
                    char c = j >= cols ? '.' : row[j];
                    if (currentNumber == string.Empty && char.IsNumber(c))
                    {
                        startJ = j;
                        currentNumber += c;
                    }
                    else if (currentNumber != string.Empty && char.IsNumber(c))
                    {
                        currentNumber += c;
                    }
                    else if (currentNumber != string.Empty && !char.IsNumber(c))
                    {
                        var s = GetCloseNeighbours(startJ, i, j - 1, rows, cols);
                        var isMaybeGear = false;
                        var yy = 0;
                        var xx = 0;
                        foreach (var a in s)
                        {
                            char d = schematics[a.Y][a.X];
                            if (d == '*')
                            {
                                yy = a.Y;
                                xx = a.X;
                                isMaybeGear = true;
                                Debug.Log("Added gear(*) at position " + yy + ", " + xx);
                                break;
                            }
                        }

                        if (isMaybeGear)
                        {
                            if (dd.ContainsKey((yy, xx)))
                                dd[(yy, xx)].Add(int.Parse(currentNumber));
                            else
                                dd.Add((yy, xx), new List<int> { int.Parse(currentNumber) });
                        }
                        else
                        {
                            Debug.Log(currentNumber + "  this is NOT a part number");
                        }

                        currentNumber = string.Empty;
                    }
                }
            }

            var sum = 0;
            foreach (var v in dd)
                if (v.Value.Count == 2)
                    sum += v.Value[0] * v.Value[1];

            return sum.ToString();
        }
    }
}