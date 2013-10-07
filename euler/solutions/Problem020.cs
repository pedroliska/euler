using System;
using System.Linq;
using System.Numerics;

namespace euler.solutions
{
    public class Problem020
    {
         public static void Run()
         {
             int number = 100;
             var factorial = Factorial(number);
             var sum = SumOfDigits(factorial);
             Console.WriteLine("The factorial digit sum of {0}! is {1}", number, sum);
         }
        private static BigInteger Factorial(int number)
        {
            BigInteger start = 1;
            return Enumerable.Range(1, number).Aggregate(start, (a,b) => a*b);
        }
        private static int SumOfDigits(BigInteger big)
        {
            return big.ToString().Select(c => int.Parse(c.ToString())).Aggregate(0, (a, b) => a + b);
        }

    }
}