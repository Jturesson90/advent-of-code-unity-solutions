using System;

namespace AdventOfCode_2023
{
    public static class Day02
    {
        public static string PuzzleA(string input)
        {
       
            const int maxRedCubes = 12;
            const int maxGreenCubes = 13;
            const int maxBlueCubes = 14;
            
            var result = 0;
            string[] games = input.Split("\n");
            foreach (string game in games)
            {
                string[] g = game.Split(": ");
                int gameId = int.Parse(g[0].Split(" ")[1]);
                string[] sets = g[1].Split("; ");
                var possibleGame = true;
                foreach (string set in sets)
                {
                    string[] cubes = set.Split(", ");
                    if (!possibleGame) continue;
                    foreach (string cube in cubes)
                    {
                        string[] color = cube.Split(" ");
                        switch (color[1])
                        {
                            case "blue":
                                if (int.Parse(color[0]) > maxBlueCubes)
                                    possibleGame = false;
                                break;
                            case "red":
                                if (int.Parse(color[0]) > maxRedCubes)
                                    possibleGame = false;
                                break;
                            case "green":
                                if (int.Parse(color[0]) > maxGreenCubes)
                                    possibleGame = false;
                                break;
                            default:
                                throw new AggregateException("Something is wrong, it's not a color it is " + color[1]);
                        }
                    }
                }

                if (possibleGame) result += gameId;
            }

            //Solve puzzle A!
            return result.ToString();
        }

        public static string PuzzleB(string input)
        {
            var result = 0;

            string[] games = input.Split("\n");
            foreach (string game in games)
            {
                string[] g = game.Split(": ");
                string[] sets = g[1].Split("; ");
                var minBlueCubes = 0;
                var minGreenCubes = 0;
                var minRedCubes = 0;

                foreach (string set in sets)
                {
                    string[] cubes = set.Split(", ");

                    foreach (string cube in cubes)
                    {
                        string[] color = cube.Split(" ");
                        switch (color[1])
                        {
                            case "blue":
                                if (int.Parse(color[0]) > minBlueCubes)
                                    minBlueCubes = int.Parse(color[0]);
                                break;
                            case "red":
                                if (int.Parse(color[0]) > minRedCubes)
                                    minRedCubes = int.Parse(color[0]);
                                break;
                            case "green":
                                if (int.Parse(color[0]) > minGreenCubes)
                                    minGreenCubes = int.Parse(color[0]);
                                break;
                            default:
                                throw new AggregateException("Something is wrong, it's not a color it is " + color[1]);
                        }
                    }
                }

                result += (minRedCubes * minGreenCubes * minBlueCubes);
            }

            //Solve puzzle A!
            return result.ToString();
        }
    }
}