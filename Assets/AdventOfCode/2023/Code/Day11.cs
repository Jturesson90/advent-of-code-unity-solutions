using System;
using System.Collections.Generic;
using System.Linq;
using JTuresson.AdventOfCode;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day11
    {
        public static string PuzzleA(string input)
        {
            var a = input.Split("\n").ToList();
            var v = new List<(int Row, int Col)>();
            var emptyColumns = new List<int>();
            var emptyRows = new List<int>();


            for (var j = 0; j < a[0].Length; j++)
            {
                var foundInColumn = false;
                for (var k = 0; k < a.Count; k++)
                    if (a[k][j] == '#')
                    {
                        foundInColumn = true;
                        break;
                    }

                if (!foundInColumn) emptyColumns.Add(j);
            }

            for (var i = 0; i < a.Count; i++)
            {
                string aa = a[i];
                var inRow = false;
                for (var j = 0; j < aa.Length; j++)
                    if (aa[j] == '#')
                    {
                        inRow = true;
                        break;
                    }

                if (!inRow) emptyRows.Add(i);
            }

            for (var i = 0; i < a.Count; i++)
            {
                string aa = a[i];

                for (var j = 0; j < aa.Length; j++)
                    if (aa[j] == '#')
                        v.Add((i, j));
            }


            long distance = 0;
            for (var i = 0; i < v.Count; i++)
            {
                var first = v[i];
                for (int j = i + 1; j < v.Count; j++)
                {
                    var second = v[j];

                    int passedCols = GetPassed(first.Col, second.Col, emptyColumns);
                    int passedRows = GetPassed(first.Row, second.Row, emptyRows);
                    int distance2 = Algorithms.ManhattanDistance(first.Col, first.Row, second.Col, second.Row);
                    distance += distance2 + passedCols + passedRows;
                }
            }

            return distance.ToString();
        }

        public static string PuzzleB(string input, int growth = 1000000)
        {
            var a = input.Split("\n").ToList();
            var v = new List<(int Row, int Col)>();
            var emptyColumns = new List<int>();
            var emptyRows = new List<int>();


            for (var j = 0; j < a[0].Length; j++)
            {
                var foundInColumn = false;
                for (var k = 0; k < a.Count; k++)
                    if (a[k][j] == '#')
                    {
                        foundInColumn = true;
                        break;
                    }

                if (!foundInColumn) emptyColumns.Add(j);
            }

            for (var i = 0; i < a.Count; i++)
            {
                string aa = a[i];
                var inRow = false;
                for (var j = 0; j < aa.Length; j++)
                    if (aa[j] == '#')
                    {
                        inRow = true;
                        break;
                    }

                if (!inRow) emptyRows.Add(i);
            }

            for (var i = 0; i < a.Count; i++)
            {
                string aa = a[i];

                for (var j = 0; j < aa.Length; j++)
                    if (aa[j] == '#')
                        v.Add((i, j));
            }

            long distance = 0;
            for (var i = 0; i < v.Count; i++)
            {
                var first = v[i];
                for (int j = i + 1; j < v.Count; j++)
                {
                    var second = v[j];

                    int passedCols = GetPassed(first.Col, second.Col, emptyColumns);
                    int passedRows = GetPassed(first.Row, second.Row, emptyRows);
                    int distance2 = Algorithms.ManhattanDistance(first.Col, first.Row, second.Col, second.Row);
                    var g = (passedCols + passedRows) * growth;
                    distance += (distance2 - (passedCols + passedRows)) + g;
                }
            }

            return distance.ToString();
        }

        private static int GetPassed(int firstRow, int secondRow, List<int> emptyRows)
        {
            var min = Math.Min(firstRow, secondRow);
            var max = Math.Max(firstRow, secondRow);
            var a = 0;
            for (var i = 0; i < emptyRows.Count; i++)
            {
                int row = emptyRows[i];
                if (min < row && row < max)
                {
                    a++;
                }

                if (row > max) break;
            }

            return a;
        }
    }
}