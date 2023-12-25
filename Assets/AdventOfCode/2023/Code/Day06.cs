using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day06
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            var races = GetRaces(input);
            var result = 1;
            foreach (var race in races)
            {
                Debug.Log($"New race, {race.Time} {race.Distance}");
                var raceResults = 0;
                for (var velocity = 0; velocity < race.Time; velocity++)
                {
                    int distance = velocity * (race.Time - velocity);
                    Debug.Log($"Holding the button for {velocity} seconds. Giving distance {distance}");
                    if (distance > race.Distance)
                    {
                        Debug.Log($"You beat the record!");

                        raceResults++;
                    }
                }

                if (raceResults != 0)
                    result *= raceResults;
            }

            return result + "";
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            string[] a = input.Split("\n");
            var times = ParseNumbers(a[0]);
            var distances = ParseNumbers(a[1]);

            var time = long.Parse(string.Join("", times));
            var distance = long.Parse(string.Join("", distances));
            Debug.Log($"T:{time},  D:{distance}");
            int ways = 0;
            for (long velocity = 0; velocity < time; velocity++)
            {
                long tryDistance = velocity * (time - velocity);
                if (tryDistance > distance)
                {
                    ways++;
                }
            }

            return ways + "";
        }

        private static List<Race> GetRaces(string input)
        {
            var result = new List<Race>();
            string[] a = input.Split("\n");
            var times = ParseNumbers(a[0]);
            var distances = ParseNumbers(a[1]);
            for (var i = 0; i < times.Count; i++)
                result.Add(new Race
                {
                    Distance = distances[i],
                    Time = times[i]
                });

            return result;
        }

        private static List<int> ParseNumbers(string ca)
        {
            return ca
                .Split(" ")
                .Where(a => !string.IsNullOrWhiteSpace(a))
                .Where(b => int.TryParse(b, out int r))
                .Select(int.Parse)
                .ToList();
        }
    }


    public class Race
    {
        public int Distance;
        public int Time;
    }
}