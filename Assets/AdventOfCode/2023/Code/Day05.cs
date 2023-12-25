using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day05
    {
        public static string PuzzleA(string input)
        {
            string[] rows = input.Split("\n\n");
            var seeds = GetSeeds(rows[0]);
            var seedMap = GetSeedMap(rows);
            var result = new List<long>();

            foreach (uint seed in seeds)
            {
                long current = GetLocation(seed, seedMap);
                result.Add(current);
            }


            return result.OrderBy(a => a).First().ToString();
        }

        public static string PuzzleBA(string input)
        {
            string[] rows = input.Split("\n\n");
            var seeds = GetSeeds(rows[0]);
            var seedMap = GetSeedMap(rows);
            var result = new List<long>();
            for (var i = 0; i < seeds.Count; i += 2)
            {
                long seedStart = seeds[i];
                long seedRange = seeds[i + 1];
                long seedEnd = seedStart + seedRange;
                while (true)
                {
                    long seedMiddle = (seedStart + seedEnd) / 2;

                    long locationStart = GetLocation(seedStart, seedMap);
                    long locationMiddle = GetLocation(seedMiddle, seedMap);
                    long locationEnd = GetLocation(seedEnd, seedMap);

                    if (seedStart == seedMiddle && seedMiddle == seedEnd)
                    {
                        result.Add(locationMiddle);
                        Debug.Log($"Location {locationMiddle} found at seed {seedMiddle}");
                        break;
                    }

                    if (locationStart <= locationMiddle && locationStart <= locationEnd)
                    {
                        seedEnd = seedMiddle;
                    }
                    else if (locationEnd <= locationMiddle && locationEnd <= locationStart)
                    {
                        seedStart = seedMiddle;
                    }
                    else if (locationMiddle <= locationStart && locationMiddle <= locationEnd)
                    {
                        long locationTowardsStart = GetLocation((seedStart + seedMiddle) / 2, seedMap);
                        long locationTowardsEnd = GetLocation((seedMiddle + seedEnd) / 2, seedMap);

                        if (locationTowardsStart < locationTowardsEnd)
                            seedEnd = seedMiddle;
                        else
                            seedStart = seedMiddle;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            var min = long.MaxValue;
            foreach (long r in result) min = r < min ? r : min;

            return min.ToString();
        }

        public static string PuzzleB(string input)
        {
            string[] rows = input.Split("\n\n");
            var seeds = GetSeeds(rows[0]);
            var seedMap = GetSeedMap(rows);
            var result = new List<long>();
            for (var i = 0; i < seeds.Count; i += 2)
            {
                long seedStart = seeds[i];
                long seedEnd = seedStart + seeds[i + 1];
                result.Add(GetMin(seedStart, seedEnd, seedMap));
            }

            var min = long.MaxValue;
            foreach (long r in result) min = r < min ? r : min;
            foreach (long r in result) Debug.Log(r);

            return min.ToString();
        }

        private static long GetMin(long seedStart, long seedEnd, List<List<SeedMap>> rows)
        {
            var min = long.MaxValue;
            for (long i = seedStart; i < seedEnd; i++)
            {
                long mins = GetLocation(i, rows);
                min = mins < min ? mins : min;
            }

            return min;
        }

        private static List<List<SeedMap>> GetSeedMap(string[] rows)
        {
            var seedMa = new List<List<SeedMap>>();

            foreach (string xToYMap in rows.Skip(1))
            {
                var s = new List<SeedMap>();
                var mapping = xToYMap.Split("\n").Skip(1);
                foreach (string map in mapping)
                {
                    var numbers = map.Split(" ").Select(uint.Parse).ToList();
                    uint destination = numbers[0];
                    uint source = numbers[1];
                    uint range = numbers[2];
                    s.Add(new SeedMap
                    {
                        Destination = destination,
                        Range = range,
                        Source = source
                    });
                }

                seedMa.Add(s);
            }

            return seedMa;
        }

        private static long GetLocation(long seed, List<List<SeedMap>> seedMap)
        {
            long current = seed;
            foreach (var xToYMap in seedMap)
            foreach (var map in xToYMap)
            {
                long destination = map.Destination;
                long source = map.Source;
                if (current >= source && current <= source + map.Range)
                {
                    current = current - source + destination;
                    break;
                }
            }

            return current;
        }

        private static List<uint> GetSeeds(string s)
        {
            string[] a = s.Replace("seeds: ", "").Split(" ");
            var b = a.Select(a => a.Trim());
            var cc = new List<uint>();
            foreach (string bb in b)
                if (uint.TryParse(bb, out uint bbb))
                    cc.Add(bbb);

            return cc;
        }

        private struct SeedMap
        {
            public long Destination;
            public long Source;
            public long Range;
        }
    }
}