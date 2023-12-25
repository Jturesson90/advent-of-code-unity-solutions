using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2023
{
    public class Day10Data
    {
        public (int Row, int Col) StartingPoint { get; set; }
        public (int Row, int Col) EndPoint { get; set; }
        public Dictionary<(int Row, int Col), int> PositionsByDistance { get; set; }
        public Dictionary<(int Row, int Col), string> TypeLookup { get; set; }
        public List<(int Row, int Col)> Path { get; set; }
        public Dictionary<(int Row, int Col), List<(int Row, int Col)>> Missing { get; set; }
        public HashSet<(int Row, int Col)> Dots { get; set; }
    }

    public static class Day10
    {
        public static string PuzzleA(string input, out Day10Data data)
        {
            //Solve puzzle A!
            string[] a = input.Split("\n");
            var chars = new char[a.Length, a[0].Length];
            var lookup = new Dictionary<(int Row, int Col), string>();

            var positionsByDistance = new Dictionary<(int Row, int Col), int>();
            var positionsByConnections = new Dictionary<(int Row, int Col), List<(int Row, int Col)>>();
            for (var row = 0; row < chars.GetLength(0); row++)
            for (var col = 0; col < chars.GetLength(1); col++)
                chars[row, col] = a[row][col];
            for (var row = 0; row < chars.GetLength(0); row++)
            for (var col = 0; col < chars.GetLength(1); col++)
            {
                if (chars[row, col] == '.')
                {
                    continue;
                }

                ;
                (int Row, int Col) pos = (row, col);
                positionsByConnections.Add(pos, new List<(int Row, int Col)>());
                var list = positionsByConnections[pos];
                switch (chars[row, col])
                {
                    case 'S':
                        lookup.Add((row, col), "S");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case '|':
                        lookup.Add((row, col), "|");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        break;
                    case '-':
                        lookup.Add((row, col), "-");
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case 'L':
                        lookup.Add((row, col), "L");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        break;
                    case 'J':
                        lookup.Add((row, col), "J");
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        break;
                    case '7':
                        lookup.Add((row, col), "7");
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case 'F':
                        lookup.Add((row, col), "F");
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        break;
                }
            }

            var visited = new HashSet<(int Row, int Col)>();
            var unvisited = new HashSet<(int Row, int Col)>();
            var aa = GetStartingPoint(chars);
            unvisited.Add(aa);
            positionsByDistance.Add(aa, 0);
            while (true)
            {
                visited.Add(aa);
                unvisited.Remove(aa);
                var connections = positionsByConnections[aa];
                foreach (var connection in connections)
                    //    if (visited.Contains(connection)) continue;
                    if (positionsByDistance.ContainsKey(connection))
                    {
                        if (positionsByDistance[connection] > positionsByDistance[aa])
                            positionsByDistance[connection] = positionsByDistance[aa] + 1;
                    }
                    else
                    {
                        unvisited.Add(connection);
                        positionsByDistance.Add(connection, positionsByDistance[aa] + 1);
                    }

                if (unvisited.Count == 0 && unvisited.All(aaa => positionsByDistance[aaa] != int.MaxValue)) break;

                aa = unvisited.OrderBy(aaa => positionsByDistance[aaa]).First();
            }


            (int Row, int Col) endpoint = (-1, -1);
            var distance = int.MinValue;
            var startingPoint = GetStartingPoint(chars);
            foreach (var vvv in positionsByDistance)
                if (vvv.Value > distance)
                {
                    distance = vvv.Value;
                    endpoint = vvv.Key;
                }

            var missing = positionsByConnections.Where(aaa => !positionsByDistance.ContainsKey(aaa.Key))
                .ToDictionary(a => a.Key, a => a.Value);
            data = new Day10Data
            {
                StartingPoint = GetStartingPoint(chars),
                EndPoint = endpoint,
                PositionsByDistance = positionsByDistance,
                TypeLookup = lookup,
                Path = new List<(int Row, int Col)>(),
                Missing = missing
            };


            return distance.ToString();
        }

        public enum Direction
        {
            North,
            East,
            South,
            West
        }

        private static void TryConnectNode(char[,] chars, List<(int Row, int Col)> a, Direction direction,
            (int Row, int Col) c)
        {
            (int Row, int Col) b = direction switch
            {
                Direction.North => (c.Row - 1, c.Col),
                Direction.East => (c.Row, c.Col + 1),
                Direction.South => (c.Row + 1, c.Col),
                Direction.West => (c.Row, c.Col - 1),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

            if (IsValid(chars, b) && CanConnect(chars[c.Row, c.Col], chars[b.Row, b.Col], direction)) a.Add(b);
        }

        private static bool CanConnect(char c, char c1, Direction direction)
        {
            if (c != 'S') return true;

            return direction switch
            {
                Direction.North when "|F7".Contains(c1) => true,
                Direction.East when "-7J".Contains(c1) => true,
                Direction.South when "|LJ".Contains(c1) => true,
                Direction.West when "-LF".Contains(c1) => true,
                _ => false
            };
        }


        private static bool IsValid(char[,] chars, (int Row, int Col) pos)
        {
            // Check if the row index is within bounds
            if (pos.Row < 0 || pos.Row >= chars.GetLength(0)) return false;

            // Check if the column index is within bounds
            if (pos.Col < 0 || pos.Col >= chars.GetLength(1)) return false;

            if (chars[pos.Row, pos.Col] == '.') return false;
            // If both row and column indices are within bounds, return true
            return true;
        }

        private static (int Row, int Col) GetStartingPoint(char[,] chars)
        {
            for (var row = 0; row < chars.GetLength(0); row++)
            for (var col = 0; col < chars.GetLength(1); col++)
                if (chars[row, col] == 'S')
                    return (row, col);


            throw new Exception("Should've been found");
        }

        public static string PuzzleB(string input, out Day10Data data)
        {
            //Solve puzzle A!
            string[] a = input.Split("\n");
            var chars = new char[a.Length, a[0].Length];
            var lookup = new Dictionary<(int Row, int Col), string>();

            var positionsByDistance = new Dictionary<(int Row, int Col), int>();
            var positionsByConnections = new Dictionary<(int Row, int Col), List<(int Row, int Col)>>();
            var dots = new HashSet<(int Row, int Col)>();
            for (var row = 0; row < chars.GetLength(0); row++)
            for (var col = 0; col < chars.GetLength(1); col++)
                chars[row, col] = a[row][col];
            for (var row = 0; row < chars.GetLength(0); row++)
            for (var col = 0; col < chars.GetLength(1); col++)
            {
                if (chars[row, col] == '.')
                {
                    lookup.Add((row, col), ".");
                    dots.Add((row, col));
                    continue;
                }

                ;
                (int Row, int Col) pos = (row, col);
                positionsByConnections.Add(pos, new List<(int Row, int Col)>());
                var list = positionsByConnections[pos];
                switch (chars[row, col])
                {
                    case 'S':
                        lookup.Add((row, col), "S");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case '|':
                        lookup.Add((row, col), "|");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        break;
                    case '-':
                        lookup.Add((row, col), "-");
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case 'L':
                        lookup.Add((row, col), "L");
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        break;
                    case 'J':
                        lookup.Add((row, col), "J");
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        TryConnectNode(chars, list, Direction.North, (row, col));
                        break;
                    case '7':
                        lookup.Add((row, col), "7");
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        TryConnectNode(chars, list, Direction.West, (row, col));
                        break;
                    case 'F':
                        lookup.Add((row, col), "F");
                        TryConnectNode(chars, list, Direction.East, (row, col));
                        TryConnectNode(chars, list, Direction.South, (row, col));
                        break;
                }
            }

            var visited = new HashSet<(int Row, int Col)>();
            var unvisited = new HashSet<(int Row, int Col)>();
            var aa = GetStartingPoint(chars);
            var endPoint = positionsByConnections[aa][1];
            positionsByConnections[aa].RemoveAt(1);
            unvisited.Add(aa);
            positionsByDistance.Add(aa, 0);
            while (true)
            {
                visited.Add(aa);
                unvisited.Remove(aa);
                var connections = positionsByConnections[aa];
                foreach (var connection in connections)
                    //    if (visited.Contains(connection)) continue;
                    if (positionsByDistance.ContainsKey(connection))
                    {
                        if (positionsByDistance[connection] > positionsByDistance[aa])
                            positionsByDistance[connection] = positionsByDistance[aa] + 1;
                    }
                    else
                    {
                        unvisited.Add(connection);
                        positionsByDistance.Add(connection, positionsByDistance[aa] + 1);
                    }

                if (unvisited.Count == 0 && unvisited.All(aaa => positionsByDistance[aaa] != int.MaxValue)) break;

                aa = unvisited.OrderBy(aaa => positionsByDistance[aaa]).First();
            }


            (int Row, int Col) endpoint = (-1, -1);
            var distance = int.MinValue;
            var startingPoint = GetStartingPoint(chars);
            foreach (var vvv in positionsByDistance)
                if (vvv.Value > distance)
                {
                    distance = vvv.Value;
                    endpoint = vvv.Key;
                }

            var missing = positionsByConnections.Where(aaa => !positionsByDistance.ContainsKey(aaa.Key))
                .ToDictionary(a => a.Key, a => a.Value);
            data = new Day10Data
            {
                StartingPoint = GetStartingPoint(chars),
                EndPoint = endpoint,
                PositionsByDistance = positionsByDistance,
                TypeLookup = lookup,
                Path = new List<(int Row, int Col)>(),
                Missing = missing,
                Dots = dots
            };
            var linkedList = new List<((int Row, int Col), char c)>();
            var currentPoint = startingPoint;
            linkedList.Add(((currentPoint.Row, currentPoint.Col), chars[currentPoint.Row, currentPoint.Col]));
            var lastVisitedPoint = currentPoint;
            currentPoint = positionsByConnections[currentPoint].First();
            do
            {
                linkedList.Add((currentPoint, chars[currentPoint.Row, currentPoint.Col]));
                var list = positionsByConnections[currentPoint];
                var lastList = positionsByConnections[lastVisitedPoint];
                foreach (var vvv in list)
                {
                    if (vvv == lastVisitedPoint) continue;
                    lastVisitedPoint = currentPoint;
                    currentPoint = vvv;
                    break;
                }
            } while (currentPoint != startingPoint);

            HashSet<(int Row, int col)> inside = new HashSet<(int Row, int col)>();
            for (int i = 1; i < linkedList.Count; i++)
            {
                var last = linkedList[-1];
                var now = linkedList[i];
              
            }

            return distance.ToString();
        }
    }
}