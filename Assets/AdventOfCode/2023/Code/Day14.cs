using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode_2023
{
    public static class Day14
    {
        public static string PuzzleA(string input)
        {
            char[,] grid = GetGrid(input);
            int rowsNum = grid.GetLength(0);
            int rowsCol = grid.GetLength(1);

            for (var i = 0; i < rowsNum; i++)
            for (var j = 0; j < rowsCol; j++)
            {
                char c = grid[i, j];
                switch (c)
                {
                    case 'O':
                        var oldPos = (i, j);
                        var newPos = GetNewPosition(grid, (i, j), 0);
                        if (oldPos.i == newPos.Row && oldPos.j == newPos.Col)
                        {
                        }
                        else
                        {
                            Swap(grid, oldPos, newPos);
                        }

                        break;
                    case '.': break;
                    case '#': break;

                    default: throw new ArgumentException();
                }
            }

            var load = 0;
            for (var i = 0; i < rowsNum; i++)
            for (var j = 0; j < rowsCol; j++)
            {
                char c = grid[i, j];
                if (c == 'O')
                    load += rowsNum - i;
            }

            return load + "";
        }

        public static string PuzzleB(string input)
        {
            const int cycles = 10000000;
            var counts = new List<int>();
            char[,] grid = GetGrid(input);
            int rowsNum = grid.GetLength(0);
            int rowsCol = grid.GetLength(1);
            var roundStonePositions = new List<(int Row, int Col)>();
            for (var i = 0; i < rowsNum; i++)
            for (var j = 0; j < rowsCol; j++)
            {
                char c = grid[i, j];
                if (c == 'O') roundStonePositions.Add((i, j));
            }


            var mem = new List<string>();
            int roundLength = roundStonePositions.Count;
            var found = false;
            var index = 0;
            var remainingCycles = 0;
            for (var cycle = 0; cycle < cycles; cycle++)
            {
                for (var j = 0; j < 4; j++)
                {
                    roundStonePositions = j switch
                    {
                        0 => roundStonePositions.OrderBy(a => a.Row).ToList(),
                        1 => roundStonePositions.OrderBy(a => a.Col).ToList(),
                        2 => roundStonePositions.OrderByDescending(a => a.Row).ToList(),
                        3 => roundStonePositions.OrderByDescending(a => a.Col).ToList(),
                        _ => roundStonePositions
                    };

                    for (var i = 0; i < roundLength; i++)
                    {
                        var oldPos = roundStonePositions[i];
                        var newPos = GetNewPosition(grid, oldPos, j % 4);
                        if (oldPos.Row == newPos.Row && oldPos.Col == newPos.Col)
                        {
                        }
                        else
                        {
                            roundStonePositions[i] = newPos;
                            Swap(grid, oldPos, newPos);
                        }
                    }
                }


                string s = GetGridString(grid);
                if (mem.IndexOf(s) != -1)
                {
                    index = mem.IndexOf(s);
                    break;
                }

                mem.Add(s);
                counts.Add(GetLoad(grid, roundStonePositions));
            }
            foreach (var v in roundStonePositions)
                if (grid[v.Row, v.Col] != 'O')
                    throw new IndexOutOfRangeException();

            int loopLength = mem.Count - index;
            if (loopLength <= 0) throw new Exception();

            int remaining = (cycles - index) % loopLength;
            int ind = index + remaining - 1;
            return counts[ind] + "";
        }

        private static string GetGridString(char[,] grid)
        {
            var s = new StringBuilder();

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                s.Append(";");
                for (var j = 0; j < cols; j++)
                    s.Append(grid[i, j]);
            }

            return s.ToString();
        }

        private static int GetLoad(char[,] grid, List<(int Row, int Col)> g)
        {
            int rows = grid.GetLength(0);
            return g.Sum(v => rows - v.Row);
        }

        private static void Swap(char[,] grid, (int Row, int Col) from, (int Row, int Col) to)
        {
            grid[to.Row, to.Col] = grid[from.Row, from.Col];
            grid[from.Row, from.Col] = '.';
        }

        private static (int Row, int Col) GetNewPosition(char[,] grid, (int Row, int Col) roundStone,
            int direction)
        {
            switch (direction)
            {
                case 0:
                    int newRow = roundStone.Row;
                    for (int i = roundStone.Row - 1; i >= 0; i--)
                    {
                        char c = grid[i, roundStone.Col];
                        if (c == '.')
                            newRow = i;
                        else break;
                    }

                    return (newRow, roundStone.Col);
                case 1:
                    int newCol = roundStone.Col;
                    for (int i = roundStone.Col - 1; i >= 0; i--)
                    {
                        char c = grid[roundStone.Row, i];
                        if (c == '.')
                            newCol = i;
                        else break;
                    }

                    return (roundStone.Row, newCol);
                case 2:
                    newRow = roundStone.Row;
                    int rows = grid.GetLength(0);
                    for (int i = roundStone.Row + 1; i < rows; i++)
                    {
                        char c = grid[i, roundStone.Col];
                        if (c == '.')
                            newRow = i;
                        else break;
                    }

                    return (newRow, roundStone.Col);
                case 3:
                    newCol = roundStone.Col;
                    int cols = grid.GetLength(1);
                    for (int i = roundStone.Col + 1; i < cols; i++)
                    {
                        char c = grid[roundStone.Row, i];
                        if (c == '.')
                            newCol = i;
                        else break;
                    }

                    return (roundStone.Row, newCol);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private static char[,] GetGrid(string input)
        {
            string[] split = input.Split("\n");
            int numRows = split.Length;
            int numCols = split[0].Length;
            var grid = new char[numRows, numCols];

            for (var i = 0; i < numRows; i++)
            {
                string row = split[i];
                for (var j = 0; j < numCols; j++)
                {
                    char c = row[j];
                    grid[i, j] = c;
                }
            }

            return grid;
        }
    }
}