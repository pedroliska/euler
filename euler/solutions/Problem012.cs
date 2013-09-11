using System;
using System.Diagnostics;

namespace euler.solutions
{
    public class Problem012
    {
        public static void Run()
        {
            int target = 500;

            Timer.RecordMiliseconds(() =>
            {
                Stopwatch watch = Stopwatch.StartNew();
                var generator = new TriangularNumberGenerator();

                int number;
                int divisorCount;
                do
                {
                    number = generator.Next();
                    divisorCount = NumberOfDivisors(number);
                } while (divisorCount <= target);

                Console.WriteLine("{0} is the first triangle number to have over {1} divisors", number, target);
            });
        }

        public static int NumberOfDivisors(int number)
        {
            int divisorCount = 0;
            for (int i = 1; i <= Math.Sqrt(number); i++)
                if (number%i == 0) divisorCount+=2;

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

    public static class Timer
    {
        public static void RecordMiliseconds(Action action)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            action();
            stopWatch.Stop();
            Console.WriteLine("it took {0} miliseconds to calcluate this", stopWatch.ElapsedMilliseconds);
        }
    }
}