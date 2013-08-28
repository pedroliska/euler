using System;
using System.Collections.Generic;

namespace euler
{
    public class Problem2
    {
        public static void Run()
        {
            var fib = new Fibonacci();
            int sum = 0;
            int lastFib;
            while ((lastFib = fib.Next()) < 4000000)
            {
                if (lastFib%2 == 0)
                    sum += lastFib;
            }
            Console.WriteLine(sum);
        }
    }

    public class Fibonacci
    {
        private int last;
        private int secondToLast = 1;

        public int Next()
        {
            int retVal = last + secondToLast;
            secondToLast = last;
            last = retVal;
            return retVal;
        }

        public IEnumerable<int> Sequence()
        {
            while (true)
            {
                int retVal = last + secondToLast;
                secondToLast = last;
                last = retVal;
                yield return retVal;
            }
        }
    }
}