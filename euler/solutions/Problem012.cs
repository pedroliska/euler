using System;
using System.Diagnostics;

namespace euler.solutions
{
    public class Problem012
    {
        public static void Run()
        {
            var target = 500;

            Stopwatch watch = Stopwatch.StartNew();
            var generator = new TriangularNumberGenerator();

            int number;
            int divisorCount;
            do
            {
                number = generator.Next();
                divisorCount = NumberOfDivisors(number);
                Console.WriteLine("number: {0}  divisors {1}", number, divisorCount);
            } while (divisorCount <= target);
            
            watch.Stop();
            Console.WriteLine("{0} is the first triangle number to have over {1} divisors", number, target);
            Console.WriteLine("it took {0} tics to calcluate this", watch.ElapsedTicks);
        }

        public static int NumberOfDivisors(int number)
        {
            int divisorCount = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number%i == 0) divisorCount++;
            }
            return divisorCount;
        }

        private class TriangularNumberGenerator
        {
            private int _lastAddition;
            private int _lastRetVal;

            public int Next()
            {
                return _lastRetVal += ++_lastAddition;
            }
        }
    }
}