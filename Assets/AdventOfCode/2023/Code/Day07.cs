using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day07
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            var hands = ParseHands(input);
            var a = new HandComparerWorstFirst();
            hands.Sort(a);
            var result = 0;
            for (var i = 0; i < hands.Count; i++) result += hands[i].Bid * (i + 1);

            return result + "";
        }

        private static List<Hand2> ParseHands2(string input)
        {
            string[] h = input.Split("\n");
            var hands = new List<Hand2>();
            foreach (string handInput in h)
            {
                string[] c = handInput.Split(" ");
                hands.Add(new Hand2(c[0], int.Parse(c[1])));
            }

            return hands;
        }

        private static List<Hand> ParseHands(string input)
        {
            string[] h = input.Split("\n");
            var hands = new List<Hand>();
            foreach (string handInput in h)
            {
                string[] c = handInput.Split(" ");
                hands.Add(new Hand(c[0], int.Parse(c[1])));
            }

            return hands;
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle A!
            var hands = ParseHands2(input);
            var a = new HandComparerWorstFirst2();
            hands.Sort(a);
            var result = 0;
            for (var i = 0; i < hands.Count; i++)
            {
                result += hands[i].Bid * (i + 1);
                Debug.Log(hands[i].Cards);
            }

            return result + "";
        }
    }


    public class HandComparerWorstFirst : Comparer<Hand>
    {
        public static readonly Dictionary<char, int> CardPointsLookup = new()
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'T', 10 },
            { 'J', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 }
        };

        public override int Compare(Hand x, Hand y)
        {
            for (var i = 0; i < x.NumOfEachSort.Count(); i++)
            {
                int xx = x.NumOfEachSort[i];
                int yy = y.NumOfEachSort[i];
                if (xx > yy) return 1;
                if (yy > xx) return -1;
            }

            for (var i = 0; i < x.Cards.Length; i++)
            {
                char xx = x.Cards[i];
                char yy = y.Cards[i];
                int xPoints = CardPointsLookup[xx];
                int yPoints = CardPointsLookup[yy];
                if (xPoints == yPoints) continue;

                if (xPoints > yPoints)
                    return 1;
                return -1;
            }

            throw new Exception();
        }
    }

    public class HandComparerWorstFirst2 : Comparer<Hand2>
    {
        public static readonly Dictionary<char, int> CardPointsLookup = new()
        {
            { 'J', 2 },
            { '2', 3 },
            { '3', 4 },
            { '4', 5 },
            { '5', 6 },
            { '6', 7 },
            { '7', 8 },
            { '8', 9 },
            { '9', 10 },
            { 'T', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 }
        };

        public override int Compare(Hand2 x, Hand2 y)
        {
            for (var i = 0; i < x.NumOfEachSort.Count(); i++)
            {
                int xx = x.NumOfEachSort[i];
                int yy = y.NumOfEachSort[i];
                if (xx > yy) return 1;
                if (yy > xx) return -1;
            }

            //        var hand1 = new Hand(x.Cards, x.Bid);
            //       var hand2 = new Hand(y.Cards, y.Bid);
            var xxx = x.Cards.Count(a => a == 'J');
            var yyy = x.Cards.Count(a => a == 'J');
            if (xxx > yyy) return -1;
            if (yyy > xxx) return 1;
            for (var i = 0; i < x.Cards.Length; i++)
            {
                char xx = x.Cards[i];
                char yy = y.Cards[i];
                int xPoints = CardPointsLookup[xx];
                int yPoints = CardPointsLookup[yy];
                if (xPoints == yPoints) continue;

                if (xPoints > yPoints)
                    return 1;
                return -1;
            }

            return 0;
        }
    }

    public class Hand
    {
        public readonly int Bid;
        public readonly string Cards;
        public readonly IReadOnlyDictionary<char, int> CardsLookup;
        public readonly List<int> NumOfEachSort;

        public Hand(string cards, int bid)
        {
            NumOfEachSort = new List<int>();
            Bid = bid;
            Cards = cards;
            var d = new Dictionary<char, int>();
            foreach (char card in cards)
                if (d.ContainsKey(card))
                    d[card]++;
                else
                    d.Add(card, 1);

            CardsLookup = d.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, b => b.Value);
            var i = 0;
            foreach (int item in CardsLookup.Values)
            {
                NumOfEachSort.Add(item);
                i++;
            }

            for (int j = i; j < 5; j++) NumOfEachSort.Add(0);
        }
    }

    public class Hand2
    {
        public readonly int Bid;
        public readonly string Cards;
        public readonly IReadOnlyDictionary<char, int> CardsLookup;
        public readonly List<int> NumOfEachSort;

        public Hand2(string cards, int bid)
        {
            NumOfEachSort = new List<int>();
            Bid = bid;
            Cards = cards;
            var d = new Dictionary<char, int>();
            foreach (char card in cards)
                if (d.ContainsKey(card))
                    d[card]++;
                else
                    d.Add(card, 1);

            CardsLookup = d.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, b => b.Value);
            var i = 0;
            var jokers = 0;
            foreach (var item in CardsLookup)
                if (item.Key == 'J')
                {
                    jokers += item.Value;
                }
                else
                {
                    NumOfEachSort.Add(item.Value);
                    i++;
                }

            for (int j = i; j < 5; j++) NumOfEachSort.Add(0);

            NumOfEachSort[0] += jokers;
        }
    }
}