using System;
using System.Collections.Generic;
using System.Linq;

namespace euler.solutions
{
    public class Problem023
    {
        private const int Limit = 28123;

        public static void Run()
        {
            Timer.RecordMiliseconds(() =>
            {
                var abundantNumbers = AbundantNumbers();
                var sumResults = new List<int>();

                foreach (var number1 in abundantNumbers)
                {
                    foreach (var number2 in abundantNumbers)
                        sumResults.Add(number1 + number2);
                }

                var distinctResults = sumResults.Distinct().ToArray();
                var sum = 0;
                for (int i = 1; i <= Limit; i++)
                {
                    if (!distinctResults.Contains(i))
                        sum += i;
                }

                Console.WriteLine(
                    "{0} is the sum of all positive intergers which cannot be written as the sum of two abundant numbers",
                    sum);
            });
        }

        private static int[] AbundantNumbers()
        {
            var retVal = new List<int>();
            for (int i = 12; i < Limit; i++)
            {
                if (Problem021.ProperDivisors(i).Sum() > i)
                {
                    retVal.Add(i);
                }
            }
            return retVal.ToArray();
        }
    }
}