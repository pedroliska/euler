using System;
using System.Linq;

namespace euler.solutions
{
    public class Problem018
    {
        public static void Run()
        {
            string rawTriangle = @"
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            int[][] triangle = GetTriangle(rawTriangle);

            CalculateMaxSum(triangle);
        }

        public static void CalculateMaxSum(int[][] triangle)
        {
            Timer.RecordMiliseconds(() =>
            {
                int maxSum = 0;
                int[] currentLineSums = null;
                int[] previousLineSums = triangle.Last();

                foreach (var line in triangle.Reverse().Skip(1))
                {
                    currentLineSums = new int[line.Length];
                    for (int itemIndex = 0; itemIndex < line.Length; itemIndex++)
                    {
                        int item = line[itemIndex];
                        currentLineSums[itemIndex] = previousLineSums[itemIndex] > previousLineSums[itemIndex + 1]
                            ? previousLineSums[itemIndex] + item
                            : previousLineSums[itemIndex + 1] + item;
                    }
                    previousLineSums = currentLineSums;
                }

                Console.WriteLine("{0} is the maximum total from top to bottom of the triangle", currentLineSums.First());
            });
        }

        public static int[][] GetTriangle(string rawTriangle)
        {
            string[] sLines = rawTriangle.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var retVal = new int[sLines.Length][];
            for (int i = 0; i < sLines.Length; i++)
                retVal[i] = sLines[i].Split(' ').Select(int.Parse).ToArray();
            return retVal;
        }
    }
}