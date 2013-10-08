using System;
using System.Collections.Generic;
using System.Linq;

namespace euler.solutions
{
    public class Problem021
    {
        public static void Run()
        {
            var limit = 10000; 
            Dictionary<int, int> divisorSums = new Dictionary<int, int>();
            Enumerable.Range(1, limit-1).Each(n =>
            {
                var divisors = Divisors(n).ToArray();
                divisorSums.Add(n, divisors.Sum());

                //string sDivisors = string.Join(",", divisors);
                //Console.WriteLine("{0} - {1}", n, sDivisors);
            });

            var amicables = new List<int>();
            foreach (var key1 in divisorSums.Keys)
            {
                int value1key2 = divisorSums[key1];
                if (divisorSums.ContainsKey(value1key2))
                {
                    int value2 = divisorSums[value1key2];
                    if (value2 == key1 && key1 != value1key2)
                    {
                        // the numbers are amicable
                        Console.WriteLine("{0} {1}", key1, value1key2);
                        amicables.AddRange(new int[] {key1, value1key2});
                    }
                }
            }
            var amicableSum = amicables.Distinct().Sum();
            Console.WriteLine("The sum of the amicable numbers under {0} is {1}", limit, amicableSum);
        }

        private static IEnumerable<int> Divisors(int number)
        {
            var divisors = new List<int> {1};
            if (number > 3)
                divisors.AddRange(Enumerable.Range(2, number/2 - 1).Where(n => number%n == 0));
            return divisors;
        }
    }
}