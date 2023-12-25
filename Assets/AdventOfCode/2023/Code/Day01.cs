namespace AdventOfCode_2023
{
    public static class Day01
    {
        public static string PuzzleA(string input)
        {
            var total = 0;
            string[] r = input.Split("\n");
            foreach (string d in r)
            {
                var first = "";
                var second = "";
                var isFirst = true;
                foreach (char c in d)
                    if (char.IsNumber(c))
                    {
                        if (isFirst)
                        {
                            first = c + "";
                            isFirst = false;
                            continue;
                        }

                        second = c + "";
                    }

                second = second == string.Empty ? first : second;
                total += int.Parse(first + second);
            }

            return total.ToString();
        }

        public static string PuzzleB(string input)
        {
            var total = 0;
            input = input.Replace("one", "on1e");
            input = input.Replace("eight", "eigh8t");
            input = input.Replace("seven", "seve7n");
            input = input.Replace("two", "tw2o");
            input = input.Replace("three", "thre3e");
            input = input.Replace("four", "fou4r");
            input = input.Replace("five", "fiv5e");
            input = input.Replace("six", "si6x");
            input = input.Replace("nine", "nine9");
            string[] r = input.Split("\n");
            foreach (string d in r)
            {
                var first = "";
                var second = "";
                var isFirst = true;
                foreach (char c in d)
                    if (char.IsNumber(c))
                    {
                        if (isFirst)
                        {
                            first = c + "";
                            isFirst = false;
                            continue;
                        }

                        second = c + "";
                    }

                second = second == string.Empty ? first : second;
                total += int.Parse(first + second);
            }

            return total.ToString();
        }
    }
}