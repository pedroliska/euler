using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace euler.solutions
{
    public class Problem7
    {
        public static void Run()
        {
            DateTime start = DateTime.Now;

            int numberOfPrimes = 10001;
            var generator = new SieveOfPedro();

            int last = 0;
            for (int i = 0; i < numberOfPrimes; i++)
                last = generator.Next();

            Console.WriteLine("the {0}th prime number is {1}", numberOfPrimes, last);
            Console.WriteLine("it took {0} seconds to calcluate this", DateTime.Now.Subtract(start).TotalSeconds);
        }
    }

    public class SieveOfPedro
    {
        private List<int> _pastPrimes;
        private int _potentialPrime;

        public int Next()
        {
            //return NextSkipEven(); // 2.3 seconds to 1000
            return NextWithSquareRootOptimization(); // 0.001 seconds to 1000
        }

        private int NextSkipEven()
        {
            if (_pastPrimes == null)
            {
                _pastPrimes = new List<int>();
                _potentialPrime = 3;
                return 2;
            }

            // check if a past prime is a factor of potentialPrime
            while (_pastPrimes.Any(p => _potentialPrime%p == 0))
                _potentialPrime += 2;

            _pastPrimes.Add(_potentialPrime);
            return _potentialPrime;
        }

        private int NextWithSquareRootOptimization()
        {
            if (_pastPrimes == null)
            {
                _pastPrimes = new List<int>();
                _potentialPrime = 1;
                return 2;
            }

            bool isPrime = true;
            do
            {
                _potentialPrime += 2;
                var sqrtOfPotentialPrime = (int)Math.Sqrt(_potentialPrime);
                foreach (int prime in _pastPrimes)
                {
                    if (prime > sqrtOfPotentialPrime)
                    {
                        isPrime = true;
                        break;
                    }

                    if (_potentialPrime%prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            } while (!isPrime);

            _pastPrimes.Add(_potentialPrime);
            return _potentialPrime;
        }
    }
}