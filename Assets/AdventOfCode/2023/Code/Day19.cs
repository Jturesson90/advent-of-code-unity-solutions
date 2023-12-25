using JTuresson.AdventOfCode;

namespace AdventOfCode_2023
{
    public static class Day19
    {
        public static string PuzzleA(string input)
        {
            //Solve puzzle A!
            Day19A a = new Day19A();
            var aa = a.Run(input.Split("\n"));
            return aa;
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            return input;
        }
    }
}