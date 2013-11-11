using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler.solutions
{
    /// <summary>
    /// Even fibonacci numbers
    /// </summary>
    public class Problem002
    {
        public static void Run()
        {
            var fib = new FibonacciGenerator();
            BigInteger sum = 0;
            BigInteger lastFib;
            while ((lastFib = fib.Next()) < 4000000)
            {
                if (lastFib%2 == 0)
                    sum += lastFib;
            }
            Console.WriteLine(sum);
        }
    }

    public class FibonacciGenerator
    {
        private BigInteger _last;
        private BigInteger _secondToLast = 1;

        public BigInteger Next()
        {
            BigInteger retVal = _last + _secondToLast;
            _secondToLast = _last;
            _last = retVal;
            return retVal;
        }

        public IEnumerable<BigInteger> Sequence()
        {
            while (true)
            {
                BigInteger retVal = _last + _secondToLast;
                _secondToLast = _last;
                _last = retVal;
                yield return retVal;
            }
        }
    }

}