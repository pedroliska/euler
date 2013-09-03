using System;
using System.Collections.Generic;
using System.Linq;

namespace euler.solutions
{
    /// <summary>
    /// Largest prime factor. Sieve of Atkins is faster.
    /// </summary>
    public class Problem3b
    {
        public static void Run()
        {
            var start = DateTime.Now;

            long number = 600851475143;
            int maxPrime = (int)Math.Floor(Math.Sqrt(number));
            var generator = new SieveOfEratosthenes(maxPrime, true);

            int largest = 0;
            foreach (int prime in generator.Primes)
            {
                Console.WriteLine(prime);
                if (number%prime == 0)
                    largest = prime;
            }

            Console.WriteLine("{0} is the largest prime factor of {1}", largest, number);
            Console.WriteLine("it took {0} seconds to calcluate this", DateTime.Now.Subtract(start).TotalSeconds);
        }
    }

    /// <summary>
    /// SieveOfPedro is way quicker than this
    /// </summary>
    public class SieveOfEratosthenes
    {
        private readonly List<int> bucket;

        public SieveOfEratosthenes(int primeSearchLimit, bool skip2 = false)
        {
            var max = skip2 ? primeSearchLimit/2 : primeSearchLimit;
            bucket = new List<int>(max);
            int startOn = skip2 ? 3 : 2;
            int incrementBy = skip2 ? 2 : 1;
            for (int i = startOn; i <= primeSearchLimit; i += incrementBy)
                bucket.Add(i);
        }

        public IEnumerable<int> Primes
        {
            get
            {
                while (bucket.Count > 0)
                {
                    int retVal = bucket.First();

                    foreach (int item in bucket.ToArray())
                    {
                        if (item%retVal == 0)
                        {
                            //Console.WriteLine("removing " + item + " from bucket");
                            bucket.Remove(item);
                        }
                    }
                    yield return retVal;
                }
            }
        }
    }
}