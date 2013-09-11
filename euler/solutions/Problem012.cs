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

    public class TimerOld
    {
        private readonly Stopwatch _watch;

        public TimerOld()
        {
            _watch = Stopwatch.StartNew();
        }

        public void ResultsInSeconds()
        {
            _watch.Stop();
            Console.WriteLine("Completed in {0}ms", _watch.ElapsedMilliseconds);
        }
    }
}