using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventOfCode_2023
{
    public static class Day13
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            string[] groups = input.Split("\n\n");
            var result = 0;
            foreach (string group in groups)
            {
                int pointsFromGroups = GetPointsFromGroup(group);
                result += pointsFromGroups;
            }

            return result.ToString();
        }

        private static int GetPointsFromGroup(string group)
        {
            string[] rows = group.Split("\n");


            int checkForPerfectRowAt = Check(rows);

            if (checkForPerfectRowAt >= 0) return 100 * checkForPerfectRowAt;

            var columns = new string[rows[0].Length];
            for (var i = 0; i < columns.Length; i++)
            {
                var s = new StringBuilder();
                foreach (string t in rows)
                    s.Append(t[i]);

                columns[i] = s.ToString();
            }

            checkForPerfectRowAt = Check(columns);
            if (checkForPerfectRowAt >= 0) return checkForPerfectRowAt;

            checkForPerfectRowAt = Check(rows, 1);
            if (checkForPerfectRowAt >= 0) return 100 * checkForPerfectRowAt;
            checkForPerfectRowAt = Check(columns, 1);
            if (checkForPerfectRowAt >= 0) return checkForPerfectRowAt;
            checkForPerfectRowAt = Check(rows, 2);
            if (checkForPerfectRowAt >= 0) return 100 * checkForPerfectRowAt;
            checkForPerfectRowAt = Check(columns, 2);
            if (checkForPerfectRowAt >= 0) return checkForPerfectRowAt;
            checkForPerfectRowAt = Check(rows, 3);
            if (checkForPerfectRowAt >= 0) return 100 * checkForPerfectRowAt;
            checkForPerfectRowAt = Check(columns, 3);
            if (checkForPerfectRowAt >= 0) return checkForPerfectRowAt;

            Debug.Log(group + "\n");
            return 0;
        }

        private static int Check(string[] rows, int skip = 0)
        {
            int s = skip;
            int checkForPerfectRowAt = -1;
            for (var i = 1; i < rows.Length; i++)
            {
                string firstRow = rows[i - 1];
                string secondRow = rows[i];
                if (firstRow == secondRow)
                {
                    if (s <= 0)
                    {
                        checkForPerfectRowAt = i;
                        break;
                    }

                    s--;
                }
            }

            var foundRowMirror = true;
            if (checkForPerfectRowAt > 0)
            {
                int i = checkForPerfectRowAt - 1;
                for (int j = checkForPerfectRowAt; i >= 0 && j < rows.Length; i--, j++)
                    if (rows[i] != rows[j])
                    {
                        foundRowMirror = false;
                        break;
                    }
            }

            if (foundRowMirror)
                return checkForPerfectRowAt;
            return -1;
        }

        public static string PuzzleB(string input)
        {
            string[] groups = input.Split("\n\n");
            var result = 0;

            foreach (string group in groups)
            {
                string groupWithFixedSmudge = FixSmudge(group);
                int pointsFromGroups = GetPointsFromGroup(groupWithFixedSmudge);
                result += pointsFromGroups;
            }

            return result.ToString();
        }

        private static string FixSmudge(string group)
        {
            string[] rows = group.Split("\n");
            int found = -1;
            int found2 = -1;
            for (var i = 0; i < rows.Length; i++)
            {
                for (int j = i + 1; j < rows.Length; j++)
                {
                    var k = 0;
                    string s = rows[i];
                    string d = rows[j];
                    for (var l = 0; l < s.Length; l++)
                    {
                        if (s[l] != d[l])
                        {
                            k++;
                        }

                        if (k > 1) break;
                    }

                    if (k == 1)
                    {
                        found = i;
                        found2 = j;
                        break;
                    }
                }

                if (found != -1)
                    break;
            }

            if (found != -1)
            {
                rows[found] = rows[found2];
                return string.Join("\n", rows);
            }

            var columns = new string[rows[0].Length];
            for (var i = 0; i < columns.Length; i++)
            {
                var s = new StringBuilder();
                foreach (string t in rows)
                    s.Append(t[i]);

                columns[i] = s.ToString();
            }

            for (var i = 0; i < columns.Length; i++)
            {
                for (int j = i + 1; j < columns.Length; j++)
                {
                    var k = 0;
                    string s = columns[i];
                    string d = columns[j];
                    for (var l = 0; l < s.Length; l++)
                    {
                        if (s[l] != d[l])
                        {
                            k++;
                        }

                        if (k > 1) break;
                    }

                    if (k == 1)
                    {
                        found = i;
                        found2 = j;
                        break;
                    }
                }

                if (found != -1)
                    break;
            }

            if (found != -1)
            {
                columns[found] = columns[found2];
                var newRows = new string[columns[0].Length];
                for (var i = 0; i < newRows.Length; i++)
                {
                    var s = new StringBuilder();
                    foreach (string t in columns)
                        s.Append(t[i]);
                    newRows[i] = s.ToString().Reverse().ToString();
                }

                rows = newRows;
                rows = rows.Reverse().ToArray();
                var ss = string.Join("\n", rows);
                return ss;
            }

            throw new Exception();
        }
    }
}